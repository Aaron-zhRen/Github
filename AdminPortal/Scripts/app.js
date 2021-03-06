﻿var ViewModel = function () {
    var self = this;
    self.admins = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();
    self.appgroups = ko.observableArray();
    self.newAdmin = {
        Tenant: ko.observable(),
        TenantId: ko.observable(),
        AppGroup: ko.observable(),
        AppGroupId: ko.observable(),
        AppType: ko.observable(),
        AppTypeId:ko.observable(),
   }

    var adminsUri = '/api/admins/';
    var appgroupsUri = '/api/appgroups';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllAdmins() {
        ajaxHelper(adminsUri, 'GET').done(function (data) {
            self.admins(data);
        });
    }

    self.getAdminDetail = function (item) {
        ajaxHelper(adminsUri + item.AdminId, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    function getAppGroups() {
        ajaxHelper(appgroupsUri, 'GET').done(function (data) {
            self.appgroups(data);
        });
    }


    self.addAdmin = function (formElement) {
        var admin = {
            Tenant: self.newAdmin.Tenant().TenantName,
            AppGroup: self.newAdmin.AppGroup().AppGroupName,
            AppType: self.newAdmin.AppType().Type,
          
        };

        ajaxHelper(adminsUri, 'POST', admin).done(function (item) {
            self.admins.push(item);
        });
    }

    // Fetch the initial data.
    getAllAdmins();
    getAppGroups();
};

ko.applyBindings(new ViewModel());

//selcet rencurrenceType
$(function () {
    $("#panel-hour").hide();
    $("#panel-day").hide();
    $("#panel-week").hide();
    $("#panel-month").hide();
    $("#IcmPanel").hide();
    $("#selectedenv-panel").hide();
    $("#selectedicm-panel").hide();
   

    var icmisenable = false;
    var icmpanelbody = false;


    $("#icmisenablecontroller").change(function () {
        console.log("icmisenablecontroller-->")
        icmisenable = !icmisenable;

        if (icmisenable) { $("#IcmPanel").show(); }
        else {
            $("#IcmPanel").hide();
            $("#selectedicm-panel").hide();
        }
    })

    $("#selectIcm").change(function () {
        var selec = $(this).val();
        console.log("what-Icm--->" + selec);
        icmpanelbody = true
        if (icmisenable == true) {
            if(icmpanelbody == true)
            $("#selectedicm-panel").show();
        }

        console.log("selec");
        $.ajax({
            url: "Create?value="+selec,
            type: "GET",
            success: function (data) {
                console.log(data)
            },
            error: function () {
                console.log("page request faild")
            },
        })

        
    })
    $("#recurrencetypes").change(function () {
        var selec = $(this).val();
        console.log("what" + selec);
        if (selec == "Daily") {
            console.log("true");
        } else {
            console.log("false");
        }

        switch (selec) {
            case "Minutely":
                $("#panel-hour").hide();
                $("#panel-day").hide();
                $("#panel-week").hide();
                $("#panel-month").hide();
                $("#panel-minutes").show();
                console.log("Minutely");
                break;
            case "Hourly":
                $("#panel-minutes").hide();
                $("#panel-day").hide();
                $("#panel-week").hide();
                $("#panel-month").hide();
                $("#panel-hour").show();
                console.log("Hourly");
                break;
            case "Daily":
                $("#panel-minutes").hide();
                $("#panel-hour").hide();
                $("#panel-week").hide();
                $("#panel-month").hide();
                $("#panel-day").show();
                console.log("Daily");
                break;
            case "Weekly":
                $("#panel-minutes").hide();
                $("#panel-hour").hide();
                $("#panel-day").hide();
                $("#panel-month").hide();
                $("#panel-week").show();
                console.log("Weekly");
                break;
            case "Monthly":
                $("#panel-minutes").hide();
                $("#panel-hour").hide();
                $("#panel-day").hide();
                $("#panel-week").hide();
                $("#panel-month").show();
                console.log("Monthly");
                break;
            default: break;
        }

    });
})




//$(function () {
//    $('#datetimepicker2').datetimepicker({
//        format: 'LT'
//    });
//});

//$(function () {
//    $("li input").datetimepicker({
//        format: 'LT'
//    });
//    $("#AddStartTime-day").click(function () {
//        $("ol#ol-day").append("<li><input type='text' id='datetimepicker3'/></li>");
//        $("li input").datetimepicker({
//            format: 'LT'
//        });
//    });
//    $("#DeleteStartTime-day").click(function () {
//        $("ol#ol-day li:last-child").remove();
//    });


//    $("li input").datetimepicker({
//        format: 'LT'
//    });
//    $("#AddStartTime-week").click(function () {
//        console.log("<input type='text' id='datetimepicker3'/>")
//        $("ol#ol-week").append("<li><input type='text' id='datetimepicker3'/></li>");
//        $("li input").datetimepicker({
//            format: 'LT'
//        });
//    });
//    $("#DeleteStartTime-week").click(function () {
//        $("ol#ol-week li:last-child").remove();
//    });


//    $("td input").click(function () {
//        console.log("click")
//        $(this).css("background", "#808080");
//    });


//    $("td input").dblclick(function () {
//        console.log("click")
//        $(this).css("background", "#ffffff");
//    });

//    $("li input").datetimepicker({
//        format: 'LT'
//    });
//    $("#AddStartTime-month").click(function () {
//        $("ol#ol-month").append("<li><input type='text' id='datetimepicker3'/></li>");
//        $("li input").datetimepicker({
//            format: 'LT'
//        });
//    });
//    $("#DeleteStartTime-month").click(function () {
//        $("ol#ol-month li:last-child").remove();
//    });
//});

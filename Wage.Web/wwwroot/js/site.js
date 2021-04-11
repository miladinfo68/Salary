$(() => {

    $('#tblSchedule').DataTable({
        "paging": true,
        "lengthChange": true,
        "searching": true,
        "ordering": true,
        "info": true,
        "autoWidth": true
    });

    $('#tblNewEntrance').DataTable({
        "paging": true,
        "lengthChange": true,
        "searching": true,
        "ordering": true,
        "info": true,
        "autoWidth": true
    });

    $('#tblBaseAmount').DataTable({
        "paging": true,
        "lengthChange": true,
        "searching": true,
        "ordering": true,
        "info": true,
        "autoWidth": true
    });

    $('#tblResearchCouncil').DataTable({
        "paging": true,
        "lengthChange": true,
        "searching": true,
        "ordering": true,
        "info": true,
        "autoWidth": true
    });

    $('#tblPresenceInWeek').DataTable({
        "paging": true,
        "lengthChange": true,
        "searching": true,
        "ordering": true,
        "info": true,
        "autoWidth": true
    });

    $('#tblPresenceInMonth').DataTable({
        "paging": true,
        "lengthChange": true,
        "searching": true,
        "ordering": true,
        "info": true,
        "autoWidth": true
    });

    $('#tblHolidays').DataTable({
        "paging": true,
        "lengthChange": true,
        "searching": true,
        "ordering": true,
        "info": true,
        "autoWidth": true
    });


    $(".content input[type=search]").attr("placeholder", "جستجو....")
        //.closest('.col-sm-12')
        .closest('.row')
        .children()
        .css({ "display": "flex", "align-self": "center" })
        .end()
        .find('select')
        .append(`<option value=\"200\">200</option>
                 <option value=\"300\">300</option>
                 <option value=\"400\">400</option>
                 <option value=\"500\">500</option>
                 <option value=\"1000\">1000</option>
                 <option value=\"1500\">1500</option>
                 <option value=\"2000\">2000</option>
                 <option value=\"2500\">2500</option>
                 <option value=\"3000\">3000</option>
                 <option value=\"3500\">3500</option>`);

    $(".content .dataTables_paginate ")
        //.closest('.col-sm-12')
        .closest('.row')
        .css({ "align-items": "center" });

    $("#tblSchedule_wrapper").find("input[type = search]")//.attr("placeholder", "جستجو....")
        //.closest('.col-sm-12')
        .closest('.row')
        .children()
        .removeClass("col-sm-12 col-md-6")
        .addClass("col-lg-3 col-md-12")
        .end()
        .append("<div class=\"col-lg-3 col-md-12\"><input id=\"fileSchedule\" class=\"form-control-sm\"  type=\"file\" accept=\".csv, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel\"/></div>")
        .append("<div class=\"col-lg-3 col-md-12\"><button class=\"btn btn-success btn-sm btnBulkInsertSchedule\">درج اکسل</button></div>")
        .end()
        .find(".fil.form-control-sm").css({ "padding": "0", "outline-color": "#f4f6f9" })
        .css({ "display": "flex", "align-self": "center" });


    addCalendersToInputDays();


    $(".btnBulkInsertSchedule").on("click", function () {
        debugger;
        let inputFile = $("#fileSchedule")[0].files;
        if (inputFile != null && inputFile.length > 0) {
            let xlfile = inputFile[0];
            var formData = new FormData();
            formData.append("file", xlfile);
            $.ajax({
                url: '/Home/BulkAddOrUploadScheduleExcell',
                data: formData,
                type: 'POST',
                contentType: false, // NEEDED, DON'T OMIT THIS (requires jQuery 1.6+)
                processData: false, // NEEDED, DON'T OMIT THIS
                success: function (tblErrs) {
                    if (tblErrs == "") {
                        $success = $(".wrapperNewEntrance #msgSuccess");
                        $success.addClass('alert alert-success text-center').html("درج با موفقیت انجام گردید").fadeIn();
                        setTimeout(function () {
                            $success.fadeOut('slow');
                        }, 8000);
                    } else {
                        $error = $(".wrapperSchedule #msgError");
                        var errs = "";
                        var html = "";
                        debugger;
                        errs += "<table class=\"table table-bordered table-responsive table-hover tbl-date-enter text-center\"><thead><tr><th>شناسه</th><th>تاریخ ورود</th><th>ساعت ورود</th><th>ساعت خروج</th><th>حداقل زمان حضور</th><th>نوع حضور</th></tr></thead><tbody>";
                        for (var err of tblErrs) {
                            errs += "<tr><td>" + err.groupManagerId + "</td><td>" + err.entranceDate + "</td><td>" + err.entranceTime + "</td><td>" + err.exitTime + "</td><td>" + err.minTime + "</td><td>" + err.presenceType + "</td></tr>";
                        }
                        errs += "</tbody></table>";
                        html += `<div class="alert alert-danger text-center"> <strong>رکوردهای زیر به دلیل عدم مطابقت درج نگردید</strong> </div>` + errs;
                        $error.html('').html(html);
                        //var html += `<div class="alert alert-danger text-center"></div>`;
                        //$error.html('').html(`<div class="alert alert-danger text-center">
                        //                        <div class=\"row\">
                        //                            <div class=\"col-12\">
                        //                                <div class=\"col-2\">
                        //                                    <button type="button" class="close" > <span>X</span></button>
                        //                                </div>
                        //                                <div class=\"col-10\">
                        //                                     <strong>رکوردهای زیر به دلیل عدم مطابقت درج نگردید</strong> 
                        //                                </div>
                        //                            </div>
                        //                            <div class=\"col-12\"> `+ errs + ` </div>
                        //                        </div>                                                                                         
                        //                    </div>`);




                        //$error.html('')
                        //.html("<div class=\"alert alert-danger text-center\"><h6>رکوردهای زیر به دلیل عدم مطابقت درج نگردید</h6>" + errs + "</div>").show();// .fadeIn();                                        
                        //setTimeout(function () {
                        //$error.fadeOut('slow');
                        //}, 2000);
                    }

                },
                error: function (jqXHR, exception) {
                    alert("WOW Error Occured !!!!", "Error Message")
                }
            });
        }
    });

    $("#fileSchedule").on("click", function (e) {
        $(this).val('');
        $('#msgError').html('');
    });

});




var persianDatePattern = /^[1-4]\d{3}\/((0[1-6]\/((3[0-1])|([1-2][0-9])|(0[1-9])))|((1[0-2]|(0[7-9]))\/(30|31|([1-2][0-9])|(0[1-9]))))$/;
var emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
var timePattern = /(^([01]?[0-9]|2[0-3])(:[0-5][0-9]$)?)$/;
var onlyDegitPattern = /\d{1,8}/;

function isNullOrEmpty(str) { return !str || str === ''; }
$.fn.hasAttr = function (name) { return this.attr(name) !== undefined; };

function convertHHmmToMinut(hms) {
    //var hms = '02:04:33';  
    var minutes = 0, a = [];
    if (!isNullOrEmpty(hms)) {
        if (hms.includes(':'))
            a = hms.split(':');
        else {
            a[0] = hms;
            a[1] = 0;
        }
        minutes = (+a[0]) * 60 + (+a[1]);

        //var seconde = ((+a[2]) / 60);
        //console.log(minutes + "," + seconde);
    }
    return minutes;
}

function convertMinsToHHmm(mins) {
    if (!isNullOrEmpty(hms)) {
        let h = Math.floor(mins / 60);
        let m = mins % 60;
        h = h < 10 ? '0' + h : h;
        m = m < 10 ? '0' + m : m;
        return `${h}:${m}`;
    }
    return '';
}

function gregorian_to_jalali(gy = null, gm = null, gd = null) {
    if (!gy || !gm || !gd) {
        var date = new Date();
        gy = date.getFullYear();
        gm = date.getMonth() + 1;
        gd = date.getDate();
    }
    //var hdr = gregorian_to_jalali(y, m, d)

    g_d_m = [0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334];
    if (gy > 1600) {
        jy = 979;
        gy -= 1600;
    }
    else {
        jy = 0;
        gy -= 621;
    }
    gy2 = (gm > 2) ? (gy + 1) : gy;
    days = (365 * gy) + (parseInt((gy2 + 3) / 4)) - (parseInt((gy2 + 99) / 100)) + (parseInt((gy2 + 399) / 400)) - 80 + gd + g_d_m[gm - 1];
    jy += 33 * (parseInt(days / 12053));
    days %= 12053;
    jy += 4 * (parseInt(days / 1461));
    days %= 1461;
    if (days > 365) {
        jy += parseInt((days - 1) / 365);
        days = (days - 1) % 365;
    }
    jm = (days < 186) ? 1 + parseInt(days / 31) : 7 + parseInt((days - 186) / 30);
    jd = 1 + ((days < 186) ? (days % 31) : ((days - 186) % 30));

    var resultY = jy.toString();
    var resultM = jm < 10 ? "0" + jm.toString() : jm.toString();
    var resultD = jd < 10 ? "0" + jd.toString() : jd.toString();
    var fullPersianDate = resultY + '/' + resultM + '/' + resultD;
    return fullPersianDate;
}

function normalizePersianDate(persianDate) {
    let normalized = "";
    if (persianDate && persianDate.trim().length > 0 && persianDate.split('/').length == 3) {
        let splited = persianDate.split('/');
        normalized = splited[0] + "/" + (splited[1].length == 1 ? "0" + splited[1] : + splited[1])
            + "/" + (splited[2].length == 1 ? "0" + splited[2] : + splited[2]);
    }
    return normalized;
}

function addCalendersToInputDays() {
    let today = gregorian_to_jalali();
    //new Date().toLocaleDateString('fa-IR');
    $("table input.pdate").each(function () {
        let objCal_i = this.id;
        objcal = new AMIB.persianCalendar(objCal_i, { defaultDate: today });
    });
}

//$(".btnRefreshGrid").on("click", function () {
//    window.location = window.location;
//});

$('table td').find('input').on('change', function (e) {
    //debugger;
    if ($(this).hasAttr('style')) {
        $(this).removeAttr('style');
    }
});


/*@@@@@@@@@@@@@@@@@@@@@@@@@@  Schedule js view*/
/*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*/



$("#tblSchedule .btnNewSchedule").on("click", function () {

    let inputs = $(this).closest("td").closest("tr").find('input');

    let entranceDate = inputs.filter('.entranceDate')[0];
    let entranceTime = inputs.filter('.entranceTime')[0];
    let exitTime = inputs.filter('.exitTime')[0];
    let minTime = inputs.filter('.minTime')[0];

    let groupManagerIdValue = inputs.filter('.hdn_grpId')[0].value;
    let entranceDateValue = normalizePersianDate(entranceDate.value);
    let entranceTimeValue = entranceTime.value;
    let exitTimeValue = exitTime.value;
    let minTimeValue = minTime.value;

    let validation = true;

    if (!persianDatePattern.test(entranceDateValue)) {
        $(entranceDate).css({ 'border': '2px solid red' });
        validation = false;
    }
    if (!timePattern.test(entranceTimeValue)) {
        $(entranceTime).css({ 'border': '2px solid red' });
        validation = false;
    }
    if (!timePattern.test(exitTimeValue)) {
        $(exitTime).css({ 'border': '2px solid red' });
        validation = false;
    }
    if (!timePattern.test(minTimeValue)) {
        $(minTime).css({ 'border': '2px solid red' });
        validation = false;
    }
    if (convertHHmmToMinut(exitTimeValue) - convertHHmmToMinut(entranceTimeValue) <= 0) {
        $(entranceTime).css({ 'border': '2px solid red' });
        $(exitTime).css({ 'border': '2px solid red' });
        validation = false;
    }

    if (!validation) return false;

    var data = {
        "entranceDate": entranceDateValue,
        "entranceTime": entranceTimeValue,
        "exitTime": exitTimeValue,
        "minTime": minTimeValue,
        "groupManagerId": groupManagerIdValue,
    }

    $.ajax({
        url: '/Home/Schedule',
        type: 'POST',
        data: data,
        success: function (res) {

            if (res) {
                $success = $(".wrapperSchedule #msgSuccess");
                $success.addClass('alert alert-success text-center').html("عملیات موفقیت آمیز").fadeIn();
                setTimeout(function () {

                    $success.fadeOut('slow');
                    //clear data                 

                    let $entranceDate = inputs.filter('.entranceDate')[0];
                    let $entranceTime = inputs.filter('.entranceTime')[0];
                    let $exitTime = inputs.filter('.exitTime')[0];
                    let $minTime = inputs.filter('.minTime')[0];

                    if ($($entranceDate).hasAttr('style')) { $($entranceDate).removeAttr('style'); }
                    if ($($entranceTime).hasAttr('style')) { $($entranceTime).removeAttr('style'); }
                    if ($($exitTime).hasAttr('style')) { $($exitTime).removeAttr('style'); }
                    if ($($minTime).hasAttr('style')) { $($minTime).removeAttr('style'); }

                    $entranceDate.value = "";
                    $entranceTime.value = "";
                    $exitTime.value = "";
                    $minTime.value = "";
                    //window.location = window.location;
                }, 2000);

            } else {
                $error = $(".wrapperSchedule #msgError");
                $error.addClass('alert alert-danger text-center').html("خطا در روند عملیات").fadeIn();
                setTimeout(function () {
                    $error.fadeOut('slow');
                    //window.location = window.location;
                }, 2000);
            }
            //window.location = window.location;
        },
        error: function (jqXHR, exception) {
            alert("WOW Error Occured !!!!", "Error Message")
        }
    });

});

function fnScheduleDetails(grpId, profName) {
    debugger
    if (grpId > 0) {
        $.ajax({
            url: '/Home/SheduleDetails',
            type: 'POST',
            data: { "id": grpId },
            success: function (res) {
                debugger;
                if (res.length > 0) {
                    let trs = "";
                    for (var item of res) {
                        trs += `<tr>
                                        <td><span class="entranceDate">`+ item.entranceDate + `</span></td>
                                        <td><span class="entranceTime">`+ item.entranceTime + `</span></td>
                                        <td><span class="exitTime">`+ item.exitTime + `</span></td>
                                        <td><span class="minTime">`+ item.minTime + `</span></td>
                                        <td><button class="btn btn-outline-danger" onclick="removeScheduleDetails(`+ item.id + `,` + item.groupManagerId + `)" >حذف </button></td>
                                    </tr>`;
                    }
                    $('#tblScheduleDetails>tbody').html('').html(trs);
                    $("#SchedulModalTitle").text(profName);

                    setTimeout(function () {
                        $('#SchedulModal').modal('show');
                    }, 100);
                }
                //window.location = window.location;
            },
            error: function (jqXHR, exception) {
                alert("WOW Error Occured !!!!", "Error Message")
            }
        });

    }
}

function removeScheduleDetails(id, groupManagerId) {
    if (id && groupManagerId && id > 0 && groupManagerId > 0) {
        $.ajax({
            url: '/Home/RemoveSchedule',
            type: 'POST',
            data: { "id": id, "groupManagerId": groupManagerId },
            success: function (res) {
                debugger;
                if (res.length > 0) {
                    let trs = "";
                    for (var item of res) {
                        trs += `<tr>
                                        <td><span class="entranceDate">`+ item.entranceDate + `</span></td>
                                        <td><span class="entranceTime">`+ item.entranceTime + `</span></td>
                                        <td><span class="exitTime">`+ item.exitTime + `</span></td>
                                        <td><span class="minTime">`+ item.minTime + `</span></td>
                                        <td><button class="btn btn-outline-danger" onclick="removeScheduleDetails(`+ item.id + `,` + item.groupManagerId + `)" >حذف </button></td>
                                    </tr>`;
                    }
                    $('#tblScheduleDetails>tbody').html('').html(trs);
                } else {
                    $('#tblScheduleDetails>tbody').html('');
                }
                //window.location = window.location;
            },
            error: function (jqXHR, exception) {
                alert("WOW Error Occured !!!!", "Error Message")
            }
        });
    }

}

/*@@@@@@@@@@@@@@@@@@@@@@@@@@  Newentrance js view*/
/*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*/

$("#btnBulkInsertNewEntrance").on("click", function () { 
    let inputFile = $("#fileNewEntrance")[0].files;
    if (inputFile != null && inputFile.length > 0) {
        let xlfile = inputFile[0];
        var formData = new FormData();
        formData.append("file", xlfile);
        $.ajax({
            url: '/Home/BulkAddNewEntranceExcell',
            data: formData,
            type: 'POST',
            contentType: false, // NEEDED, DON'T OMIT THIS (requires jQuery 1.6+)
            processData: false, // NEEDED, DON'T OMIT THIS
            success: function (tblErrs) {
                debugger;
                if (tblErrs == "") {
                    $success = $(".wrapperNewEntrance #msgSuccess");
                    $success.addClass('alert alert-success text-center').html("درج با موفقیت انجام گردید").fadeIn();
                    setTimeout(function () {
                        $success.fadeOut('slow');
                    }, 8000);
                } else {
                    $error = $(".wrapperNewEntrance #msgError");
                    var errs = "";
                    var html = "";
                    debugger;
                    errs += "<table class=\"table table-bordered table-responsive table-hover tbl-date-enter text-center\"><thead><tr><th>شناسه</th><th>تاریخ ورود</th><th>ساعت ورود</th><th>ساعت خروج</th><th>نوع حضور</th></tr></thead><tbody>";
                    for (var err of tblErrs) {
                        errs += "<tr><td>" + err.groupManagerId + "</td><td>" + err.entranceDate + "</td><td>" + err.entranceTime + "</td><td>" + err.exitTime + "</td><td>" + err.presenceType + "</td></tr>";
                    }
                    errs += "</tbody></table>";
                    html += `<div class="alert alert-danger text-center"> <strong>رکوردهای زیر به دلیل تکراری بودن درج نگردید</strong> </div>` + errs;
                    $error.html('').html(html);                   
                }

            },
            error: function (jqXHR, exception) {
                alert("WOW Error Occured !!!!", "Error Message")
            }
        });
    }
});

$("#tblNewEntrance .btnNewEntrance").on("click", function () {
    debugger;
    let inputs = $(this).closest("td").closest("tr").find('input,select');

    let entranceDate = inputs.filter('.entranceDate')[0];
    let entranceTime = inputs.filter('.entranceTime')[0];
    let exitTime = inputs.filter('.exitTime')[0];
    let isOnline = inputs.filter('.drpPresenceType')[0].value;

    let groupManagerIdValue = inputs.filter('.hdn_grpId')[0].value;
    let entranceDateValue = normalizePersianDate(entranceDate.value);
    let entranceTimeValue = entranceTime.value;
    let exitTimeValue = exitTime.value;

    //return false;
    let validation = true;

    if (!persianDatePattern.test(entranceDateValue)) {
        $(entranceDate).css({ 'border': '2px solid red' });
        validation = false;
    }
    if (!timePattern.test(entranceTimeValue)) {
        $(entranceTime).css({ 'border': '2px solid red' });
        validation = false;
    }
    if (!timePattern.test(exitTimeValue)) {
        $(exitTime).css({ 'border': '2px solid red' });
        validation = false;
    }
    if (convertHHmmToMinut(exitTimeValue) - convertHHmmToMinut(entranceTimeValue) <= 0) {
        $(entranceTime).css({ 'border': '2px solid red' });
        $(exitTime).css({ 'border': '2px solid red' });
        validation = false;
    }

    if (!validation) return false;

    var data = {
        "entranceDate": entranceDateValue,
        "entranceTime": entranceTimeValue,
        "exitTime": exitTimeValue,
        "groupManagerId": groupManagerIdValue,
        "isOnline": isOnline == 1 ? true : false
    }
    //return false;
    $.ajax({
        url: '/Home/NewEntrance',
        type: 'POST',
        data: data,
        success: function (res) {
            debugger;
            if (res) {
                if (res) {
                    $success = $(".wrapperNewEntrance #msgSuccess");
                    $success.addClass('alert alert-success text-center').html("عملیات موفقیت آمیز").fadeIn();
                    setTimeout(function () {

                        $success.fadeOut('slow');
                        //clear data
                        let $entranceDate = inputs.filter('.entranceDate')[0];
                        let $entranceTime = inputs.filter('.entranceTime')[0];
                        let $exitTime = inputs.filter('.exitTime')[0];

                        if ($($entranceDate).hasAttr('style')) { $($entranceDate).removeAttr('style'); }
                        if ($($entranceTime).hasAttr('style')) { $($entranceTime).removeAttr('style'); }
                        if ($($exitTime).hasAttr('style')) { $($exitTime).removeAttr('style'); }

                        $entranceDate.value = "";
                        $entranceTime.value = "";
                        $exitTime.value = "";

                    }, 2000);
                }
            } else {
                $error = $(".wrapperNewEntrance #msgError");
                $error.addClass('alert alert-danger text-center').html("رکورد تکراری یا دارای همپوشانی با رکوردهای مشابه در این روز!").fadeIn();
                setTimeout(function () { $error.fadeOut('slow') }, 2000);
            }
        },
        error: function (jqXHR, exception) {

            $error = $(".wrapperNewEntrance #msgError");
            $error.addClass('alert alert-danger text-center').html("خطا در روند عملیات").fadeIn();
            setTimeout(function () { $error.fadeOut('slow') }, 2000);
        }
    });

});

function fnEntranceDetails(grpId, profName) {
    if (grpId > 0) {
        $.ajax({
            url: '/Home/EntranceDetails',
            type: 'POST',
            data: { "groupManagerId": grpId },
            success: function (res) {
                debugger;
                if (res.length > 0) {
                    let trs = "";
                    for (var item of res) {
                        trs += `<tr>
                                  <td><span class="entranceDate">`+ item.entranceDate + `</span></td>
                                  <td><span class="entranceTime">`+ item.entranceTime + `</span></td>
                                  <td><span class="exitTime">`+ item.exitTime + `</span></td>   
                                  <td><span class="isOnline">`+ item.isOnline + `</span></td>  
                                  <td><button class="btn btn-outline-danger" onclick="removeEntranceDetails(`+ item.id + `,` + item.groupManagerId + `)" >حذف </button></td>
                               </tr>`;
                    }
                    $('#tblEntranceDetails>tbody').html('').html(trs);
                    $("#EntranceDetailsModalTitle").text(profName);

                    setTimeout(function () {
                        $('#EntranceDetailsModal').modal('show');
                    }, 100);
                } else {
                    $('#tblEntranceDetails>tbody').html('');
                }
                //window.location = window.location;
            },
            error: function (jqXHR, exception) {
                alert("WOW Error Occured !!!!", "Error Message")
            }
        });
    }
}

function removeEntranceDetails(id, groupManagerId) {
    if (id && groupManagerId && id > 0 && groupManagerId > 0) {
        $.ajax({
            url: '/Home/RemoveEntranceDetails',
            type: 'POST',
            data: { "id": id, "groupManagerId": groupManagerId },
            success: function (res) {
                debugger;
                if (res.length > 0) {
                    let trs = "";
                    for (var item of res) {
                        trs += `<tr>
                                        <td><span class="entranceDate">`+ item.entranceDate + `</span></td>
                                        <td><span class="entranceTime">`+ item.entranceTime + `</span></td>
                                        <td><span class="exitTime">`+ item.exitTime + `</span></td>   
                                        <td><span class="isOnline">`+ item.isOnline + `</span></td>  
                                        <td><button class="btn btn-outline-danger" onclick="removeEntranceDetails(`+ item.id + `,` + item.groupManagerId + `)" >حذف </button></td>
                                    </tr>`;
                    }
                    $('#tblEntranceDetails>tbody').html('').html(trs);
                } else {
                    $('#tblEntranceDetails>tbody').html('');
                }
                //window.location = window.location;
            },
            error: function (jqXHR, exception) {
                alert("WOW Error Occured !!!!", "Error Message")
            }
        });
    }

}

/*@@@@@@@@@@@@@@@@@@@@@@@@@@  BaseAmount js view*/
/*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*/

$(".wrapperBaseMount .btnShowGroupManagersByMonth").on("click", e => {
    debugger;
    var year = $("#drpYears").val();
    var month = $("#drpMonthes").val();
    var startAt = $("#txtStartAt").val();
    var url = "";

    if (startAt && startAt.split("/").length == 3) {
        var startDateWork = normalizePersianDate(startAt);
        url += window.location.origin + window.location.pathname + "?year=" + 0 + "&month=" + 0 + "&startAt=" + startDateWork;
        window.location.href = url.toLocaleLowerCase();
    }
    else if (year != "0" && month != "0") {
        url += window.location.origin + window.location.pathname + "?year=" + year + "&month=" + month + "&startAt=" + 0
        window.location.href = url.toLocaleLowerCase();
    }
    else if (year != "0" && month == "0") {
        url += window.location.origin + window.location.pathname + "?year=" + year + "&month=" + 0 + "&startAt=" + 0;
        window.location.href = url.toLocaleLowerCase();
    }
    else {
        url += window.location.origin + window.location.pathname;
        window.location.href = url.toLocaleLowerCase();
    }

});


$(".btnShowGroupManagersByMonthExcel").on('click', function () {
    $("#tblBaseAmount").table2excel({
        filename: "report.xls"
    });
});



$("#tblBaseAmount .btnNewBaseAmount").on('click', function () {
    debugger;
    let inputs = $(this).closest("td").closest("tr").find('input');
    let baseAmount = inputs.filter('.baseAmount')[0];
    let grpmId = inputs.filter('.hdn_grpId')[0].value;

    if (isNullOrEmpty(baseAmount.value) || !onlyDegitPattern.test(baseAmount.value)) {
        $(baseAmount).css({ 'border': '2px solid red' });
        return false;
    }
    var data = {
        "id": grpmId,
        "baseAmount": baseAmount.value,
    }

    $.ajax({
        url: '/Home/BaseAmount',
        type: 'POST',
        data: data,
        success: function (res) {
            if (res) {
                $success = $(".wrapperBaseMount #msgSuccess");
                $success.addClass('alert alert-success text-center').html("عملیات موفقیت آمیز").fadeIn();
                setTimeout(function () {
                    $success.fadeOut('slow');
                    inputs.filter('.disabled')[0].value = data.baseAmount;
                    inputs.filter('.baseAmount')[0].value = '';
                    //window.location = window.location;
                }, 2000);

            } else {
                $error = $(".wrapperBaseMount #msgError");
                $error.addClass('alert alert-danger text-center').html("خطا در روند عملیات").fadeIn();
                setTimeout(function () { $error.fadeOut('slow') }, 2000);
            }
            //window.location = window.location;
        },
        error: function (jqXHR, exception) {
            alert("WOW Error Occured !!!!", "Error Message")
        }
    });
});

/*@@@@@@@@@@@@@@@@@@@@@@@@@@  ResearchCouncile js view*/
/*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*/
$("#tblResearchCouncil .btnResearchCouncil").on('click', function () {
    let inputs = $(this).closest("td").closest("tr").find('input');
    let chkCouncil = inputs.filter('.chkCouncil')[0];
    let councilDate = inputs.filter('.councilDate')[0];

    let grpmId = inputs.filter('.hdn_grpId')[0].value;
    let chkCouncilValue = chkCouncil.checked;
    let councilDateValue = normalizePersianDate(councilDate.value)

    if (!chkCouncilValue && !persianDatePattern.test(councilDateValue)) {
        //$(chkCouncil).css({ 'border': '2px solid red' });
        $(chkCouncil).css('outline-color', 'red');
        $(chkCouncil).css('outline-style', 'solid');
        $(chkCouncil).css('outline-width', 'thin');

        $(councilDate).css({ 'border': '2px solid red' });
        return false;
    }
    if (chkCouncilValue && !persianDatePattern.test(councilDateValue)) {
        $(councilDate).css({ 'border': '2px solid red' });
        return false;
    }
    if (!chkCouncilValue && persianDatePattern.test(councilDateValue)) {
        $(chkCouncil).css('outline-color', 'red');
        $(chkCouncil).css('outline-style', 'solid');
        $(chkCouncil).css('outline-width', 'thin');
        return false;
    }
    var data = {
        "id": grpmId,
        "chkCouncil": chkCouncilValue,
        "councilDate": councilDateValue
    }

    $.ajax({
        url: '/Home/ResearchCouncil',
        type: 'POST',
        data: data,
        success: function (res) {
            if (res) {
                $success = $(".wrapperResearchCouncil #msgSuccess");
                $success.addClass('alert alert-success text-center').html("عملیات موفقیت آمیز").fadeIn();
                setTimeout(function () {
                    $success.fadeOut('slow');

                    if ($(chkCouncil).hasAttr('style')) { $(chkCouncil).removeAttr('style'); }
                    if ($(councilDate).hasAttr('style')) { $(councilDate).removeAttr('style'); }
                }, 2000);

            } else {
                $error = $(".wrapperResearchCouncil #msgError");
                $error.addClass('alert alert-danger text-center').html("خطا در روند عملیات").fadeIn();
                setTimeout(function () {
                    $error.fadeOut('slow');
                    //window.location = window.location;
                }, 2000);
            }
            //window.location = window.location;
        },
        error: function (jqXHR, exception) {
            alert("WOW Error Occured !!!!", "Error Message")
        }
    });

});

/*@@@@@@@@@@@@@@@@@@@@@@@@@@  PresenceInWeek and PresenceInMonth js view*/
/*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*/

$(".btnShowPresenceInWeek").on('click', function () {
    //debugger;
    let month = $("#drpMonthes").val() || "0";
    let week = $("#drpWeeks").val() || "0";
    var url = "";
    url += window.location.origin + window.location.pathname + "?month=" + month + "&week=" + week;
    window.location.href = url.toLocaleLowerCase();

});

$(".btnShowPresenceInMonth").on('click', function () {
    //debugger;
    let month = $("#drpMonthes").val() || "0";
    //let week = $("#drpWeeks").val();
    var url = "";
    url += window.location.origin + window.location.pathname + "?month=" + month; //+ "&week=" + week;
    window.location.href = url.toLocaleLowerCase();

});

$(".btnShowPresenceInWeekExcel").on('click', function () {
    $("#tblPresenceInWeek").table2excel({
        filename: "weekreport.xls"
    });
});


$(".btnShowPresenceInMonthExcel").on('click', function () {
    $("#tblPresenceInMonth").table2excel({
        filename: "monthreport.xls"
    });
});

/*@@@@@@@@@@@@@@@@@@@@@@@@@@  Holidays js view*/
/*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*/

$("#tblHolidays .btnAddNewHoliday").on("click", function () {
    let today = gregorian_to_jalali(); //new Date().toLocaleDateString('fa-IR');
    $("#modalAddNewHoliday input.pdate").each(function () {
        let objCal_i = this.id;
        objcal = new AMIB.persianCalendar(objCal_i, { defaultDate: today });
    });
    $('#modalAddNewHoliday').modal('show');
});


$("#modalAddNewHoliday .btnSaveNewHoliday").on("click", e => {
    var isValid = true;
    var date = $("#newHolidayDate").css({ 'border': 'none' }).val();
    var note = $("#newHolidayNote").css({ 'border': 'none' }).val();
    if (!date) {
        isValid = false;
        debugger
        $("#newHolidayDate").css({ 'border': '2px solid red' });;
    }
    if (!note) {
        isValid = false;
        $("#newHolidayNote").css({ 'border': '2px solid red' });
    }
    if (!isValid) return;
    var data = {
        "date": normalizePersianDate(date),
        "note": note
    }

    $.ajax({
        url: '/Home/Holidays',
        type: 'POST',
        data: data,
        success: function (res) {
            if (res.includes("success")) {
                $success = $("#modalAddNewHoliday .msgSuccess");
                $success.addClass('alert alert-success text-center').html("عملیات موفقیت آمیز").fadeIn();
                setTimeout(function () {
                    $success.fadeOut('slow');
                    window.location = window.location;
                }, 1000);
            } else {
                $error = $("#modalAddNewHoliday .msgError");
                $error.addClass('alert alert-danger text-center').html(res).fadeIn();
                setTimeout(function () {
                    $error.fadeOut('slow');
                    window.location = window.location;
                }, 1000);
            }
            //window.location = window.location;
        },
        error: function (jqXHR, exception) {
            alert("WOW Error Occured !!!!", "Error Message")
        }
    });

});

$("#tblHolidays .btnDeleteHoliday").on("click", e => {
    debugger;
    var date = $("#tblHolidays .btnDeleteHoliday").attr("data-date") || "";
    if (window.confirm("آیا اطمینان دارید از حذف رکورد جاری؟") && date != "") {
        $.ajax({
            url: '/Home/RemoveHoliday',
            type: 'POST',
            data: { "date": date },
            success: function (res) {
                if (res.includes("success")) {
                    $success = $(".wrappertblHolidays #msgSuccess");
                    $success.addClass('alert alert-success text-center').html("عملیات موفقیت آمیز").fadeIn();
                    setTimeout(function () {
                        $success.fadeOut('slow');
                        window.location = window.location;
                    }, 1000);
                } else {
                    $error = $(".wrappertblHolidays #msgError");
                    $error.addClass('alert alert-danger text-center').html(res).fadeIn();
                    setTimeout(function () {
                        $error.fadeOut('slow');
                        window.location = window.location;
                    }, 1000);
                }
                //window.location = window.location;
            },
            error: function (jqXHR, exception) {
                alert("WOW Error Occured !!!!", "Error Message")
            }
        });
    }
});


//
/*
function isValidate(data, key) {
    let res = true;
    debugger;
    switch (key) {
        //schedule
        case 1:
            if (data && data.entranceDate && data.entranceTime && data.exitTime && data.minTime) {
                if (!persianDatePattern.test(data.entranceDate)) {
                    $("#tblSchedule input.entranceDate").css({ 'border': '2px soid red' });
                    res = false;
                }
                if (!timePattern.test(data.entranceTime)) {
                    $("#tblSchedule input.enteranceTime").css({ 'border': '1px soid red' });
                    res = false;
                }
                if (!data.exitTime) {
                    $("#tblSchedule input.exitTime").css({ 'border': '1px soid red' });
                    res = false;
                }
                if (!timePattern.test(data.minTime)) {
                    $("#tblSchedule input.minTime").css({ 'border': '1px soid red' });
                    res = false;
                }
                let entTime, exTime;
                if (data.entranceTime.includes(':')) {
                    entTime = parseInt(data.entranceTime.split(':')[0]) * 60;
                    entTime += (data.entranceTime.split(':')[1]).length > 0
                        ? parseInt(data.entranceTime.split(':')[1]) : 0;
                } else {
                    entTime = parseInt(data.entranceTime) * 60;
                }
                if (data.exitTime.includes(':')) {
                    exTime = parseInt(data.exitTime.split(':')[0]) * 60;
                    exTime += (data.exitTime.split(':')[1]).length > 0
                        ? parseInt(data.exitTime.split(':')[1]) : 0;
                } else {
                    exTime = parseInt(data.exitTime) * 60;
                }
                if (entTime > exTime) {
                    $("#tblSchedule input.enteranceTime").css({ 'border': '1px soid red' });
                    $("#tblSchedule input.exitTime").css({ 'border': '1px soid red' });
                    res = false
                }
            } else {
                res = false;
            }
            break;

        //new entrance
        case 2:
            //if (data.entranceDate && data.entranceTime && data.exitTime) {
            if (!persianDatePattern.test(data.entranceDate)) {
                $("#tblNewEntrance").find(".entranceDate").css({ 'border': '2px soid red' });
                res = false;
            }
            if (!timePattern.test(data.entranceTime)) {
                $("#tblNewEntrance:input.enteranceTime").css({ 'border': '1px soid red' });
                res = false;
            }
            if (!data.exitTime) {
                $("#tblNewEntrance input.exitTime").css({ 'border': '1px soid red' });
                res = false;
            }

            let entTime, exTime;
            if (data.entranceTime.includes(':')) {
                entTime = parseInt(data.entranceTime.split(':')[0]) * 60;
                entTime += (data.entranceTime.split(':')[1]).length > 0
                    ? parseInt(data.entranceTime.split(':')[1]) : 0;
            } else {
                entTime = parseInt(data.entranceTime) * 60;
            }
            if (data.exitTime.includes(':')) {
                exTime = parseInt(data.exitTime.split(':')[0]) * 60;
                exTime += (data.exitTime.split(':')[1]).length > 0
                    ? parseInt(data.exitTime.split(':')[1]) : 0;
            } else {
                exTime = parseInt(data.exitTime) * 60;
            }
            if (entTime > exTime) {
                $("#tblNewEntrance input.entranceTime").css({ 'border': '1px soid red' });
                $("#tblNewEntrance input.exitTime").css({ 'border': '1px soid red' });
                res = false
            }
            //} else {
            //    res = false;
            //}
            break;

        //presence in week
        case 3:
            if (isNullOrEmpty(data.monthNo) || isNullOrEmpty(data.weekNo)) {
                res = true;
            }
            break;

        //base amount
        case 4:
            if (isNullOrEmpty(data.baseAmount) || !onlyDegitPattern.test(data.baseAmount)) {
                $("#tblBaseAmount input.baseAmount").css({ 'border': '2px soid red' });
                res = false;
            }
            break;

        //reserch council
        case 5:
            if (isNullOrEmpty(data.councilDate)) {
                $("#tblResearchCouncil input.councilDate").css({ 'border': '2px soid red' });
                res = false;
            }
            break;

    }

    return res;
}

function fnNewSchedule() {
    var inputs = $("#tblSchedule").find('span,input');
    //let profCode = inputs.filter('.profCode')[0].innerText;
    //let profName = inputs.filter('.profName')[0].innerText;
    let entranceDate = inputs.filter('.entranceDate')[0].value;
    let entranceTime = inputs.filter('.entranceTime')[0].value;
    let exitTime = inputs.filter('.exitTime')[0].value;
    let minTime = inputs.filter('.minTime')[0].value;
    let groupManagerId = inputs.filter('.hdn_grpId')[0].value;
    debugger
    var data = {
        "entranceDate": normalizePersianDate(entranceDate),
        "entranceTime": entranceTime,
        "exitTime": exitTime,
        "minTime": minTime,
        "groupManagerId": groupManagerId,
    }

    if (isValidate(data, 1)) {
        $.ajax({
            url: '/Home/Schedule',
            type: 'POST',
            data: data,
            success: function (res) {

                if (res) {
                    $success = $(".wrapperSchedule #msgSuccess");
                    $success.addClass('alert alert-success text-center').html("عملیات موفقیت آمیز").fadeIn();
                    setTimeout(function () {

                        $success.fadeOut('slow');
                        //clear data
                        inputs.filter('.entranceDate')[0].value = "";
                        inputs.filter('.entranceTime')[0].value = "";
                        inputs.filter('.exitTime')[0].value = "";
                        inputs.filter('.minTime')[0].value = "";

                        //window.location = window.location;
                    }, 2000);

                } else {
                    $error = $(".wrapperSchedule #msgError");
                    $error.addClass('alert alert-danger text-center').html("خطا در روند عملیات").fadeIn();
                    setTimeout(function () {
                        $error.fadeOut('slow');
                        //window.location = window.location;
                    }, 2000);
                }
                //window.location = window.location;
            },
            error: function (jqXHR, exception) {
                alert("WOW Error Occured !!!!", "Error Message")
            }
        });
    }

}


 $(".wrapperSchedule .btnSearch").on("click", function () {
    let txtSearch = $(".wrapperSchedule .txtSearch").val();
    if (!isNullOrEmpty(txtSearch)) {
        $.ajax({
            url: '/Home/Search',
            type: 'POST',
            data: { 'data': txtSearch },
            success: function (res) {
                debugger;
                if (res.length > 0) {
                    let trs = "";
                    for (var item of res) {
                        trs += `<tr>
                                    <td>
                                        <span class="profCode">`+ item.profCode + `</span>
                                        <input type="hidden" value="`+ item.id + `" class="hdn_grpId" />
                                    </td>
                                    <td><span class="profName">`+ item.profName + `</span></td>
                                    <td><input class="entranceDate pdate" type="text" id="entranceDate_`+ item.profCode + `" maxlength="10" placeholder="1400/01/01"></td>
                                    <td><input class="entranceTime" type="text" maxlength="5" placeholder="10:10"></td>
                                    <td><input class="exitTime" type="text" maxlength="5" placeholder="12:30"></td>
                                    <td><input class="minTime" type="text" maxlength="5" placeholder="12:30"></td>
                                    <td>
                                        <button class="btn btn-outline-primary" onclick="fnNewSchedule()">درج تاریخ جدید</button>
                                        <button class="btn btn-outline-info" onclick="fnScheduleDetails('`+ item.id + `' , '` + item.profName + `')">
                                            نمایش جزییات
                                        </button>
                                    </td>
                                </tr>`
                    }
                    $('#tblSchedule>tbody').html('').html(trs);
                    addCalendersToInputDays();
                } else {
                    $('#tblSchedule>tbody').html('');
                }
                //window.location = window.location;
            },
            error: function (jqXHR, exception) {
                alert("WOW Error Occured !!!!", "Error Message")
            }
        });
    }

});


  function fnNewEntrance() {
    var inputs = $("#tblNewEntrance").find('span,input');
    //let profCode = inputs.filter('.profCode')[0].innerText;
    //let profName = inputs.filter('.profName')[0].innerText;
    let entranceDate = inputs.filter('.entranceDate')[0].value;
    let entranceTime = inputs.filter('.entranceTime')[0].value;
    let exitTime = inputs.filter('.exitTime')[0].value;
    let groupManagerId = inputs.filter('.hdn_grpId')[0].value;
    debugger
    var data = {
        "entranceDate": normalizePersianDate(entranceDate),
        "entranceTime": entranceTime,
        "exitTime": exitTime,
        "groupManagerId": groupManagerId,
    }
    if (isValidate(data, 2)) {
        $.ajax({
            url: '/Home/NewEntrance',
            type: 'POST',
            data: data,
            success: function (res) {

                if (res) {
                    $success = $(".wrapperNewEntrance #msgSuccess");
                    $success.addClass('alert alert-success text-center').html("عملیات موفقیت آمیز").fadeIn();
                    setTimeout(function () {

                        $success.fadeOut('slow');
                        //clear data
                        inputs.filter('.entranceDate')[0].value = "";
                        inputs.filter('.entranceTime')[0].value = "";
                        inputs.filter('.exitTime')[0].value = "";
                    }, 2000);

                } else {
                    $error = $(".wrapperNewEntrance #msgError");
                    $error.addClass('alert alert-danger text-center').html("خطا در روند عملیات").fadeIn();
                    setTimeout(function () { $error.fadeOut('slow') }, 2000);
                }
                //window.location = window.location;
            },
            error: function (jqXHR, exception) {
                alert("WOW Error Occured !!!!", "Error Message")
            }
        });
    }

}


 $(".wrapperNewEntrance .btnSearch").on("click", function () {
    let txtSearch = $(".wrapperNewEntrance .txtSearch").val();
    if (!isNullOrEmpty(txtSearch)) {
        $.ajax({
            url: '/Home/Search',
            type: 'POST',
            data: { 'data': txtSearch },
            success: function (res) {
                debugger;
                if (res.length > 0) {
                    let trs = "";
                    for (var item of res) {
                        trs += `<tr>
                                    <td>
                                        <span class="profCode">`+ item.profCode + `</span>
                                        <input type="hidden" value="`+ item.id + `" class="hdn_grpId" />
                                    </td>
                                    <td><span class="profName">`+ item.profName + `</span></td>
                                    <td><input class="entranceDate pdate" type="text" id="entranceDate_`+ item.profCode + `" maxlength="10" placeholder="1400/01/01"></td>
                                    <td><input class="entranceTime" type="text" maxlength="5" placeholder="10:10"></td>
                                    <td><input class="exitTime" type="text" maxlength="5" placeholder="12:30"></td>
                                    <td>
                                        <button class="btn btn-outline-primary" onclick="fnNewEntrance()">درج تاریخ جدید</button>
                                        <button class="btn btn-outline-info" onclick="fnEntranceDetails('`+ item.id + `','` + item.profName + `')">
                                            نمایش جزییات
                                        </button>
                                    </td>
                                </tr>`
                    }
                    $('#tblNewEntrance>tbody').html('').html(trs);
                    addCalendersToInputDays();
                } else {
                    $('#tblNewEntrance>tbody').html('');
                }
                //window.location = window.location;
            },
            error: function (jqXHR, exception) {
                alert("WOW Error Occured !!!!", "Error Message")
            }
        });
    }

});




function fnBaseAmount() {
    //debugger;
    var inputs = $("#tblBaseAmount").find('input');
    let baseAmount = inputs.filter('.baseAmount')[0].value;
    let grpmId = inputs.filter('.hdn_grpId')[0].value;

    var data = {
        "id": grpmId,
        "baseAmount": baseAmount,
    }
    if (isValidate(data, 4)) {
        $.ajax({
            url: '/Home/BaseAmount',
            type: 'POST',
            data: data,
            success: function (res) {
                if (res) {
                    $success = $(".wrapperBaseMount #msgSuccess");
                    $success.addClass('alert alert-success text-center').html("عملیات موفقیت آمیز").fadeIn();
                    setTimeout(function () {
                        $success.fadeOut('slow');
                        inputs.filter('.disabled')[0].value = baseAmount;
                        inputs.filter('.baseAmount')[0].value = '';
                        //window.location = window.location;
                    }, 2000);

                } else {
                    $error = $(".wrapperBaseMount #msgError");
                    $error.addClass('alert alert-danger text-center').html("خطا در روند عملیات").fadeIn();
                    setTimeout(function () { $error.fadeOut('slow') }, 2000);
                }
                //window.location = window.location;
            },
            error: function (jqXHR, exception) {
                alert("WOW Error Occured !!!!", "Error Message")
            }
        });
    }
}


$(".wrapperBaseMount .btnSearch").on("click", function () {
    let txtSearch = $(".wrapperBaseMount .txtSearch").val();
    if (!isNullOrEmpty(txtSearch)) {
        $.ajax({
            url: '/Home/Search',
            type: 'POST',
            data: { 'data': txtSearch },
            success: function (res) {
                debugger;
                if (res.length > 0) {
                    let trs = "";
                    for (var item of res) {
                        trs += `<tr>
                                    <td>
                                        <span class="profCode">`+ item.profCode + `</span>
                                        <input type="hidden" value="`+ item.id + `" class="hdn_grpId" />
                                    </td>
                                    <td><span class="profName">`+ item.profName + `</span></td>
                                    <td><input class="disabled" disabled type="text" value="`+ item.baseAmount + `"></td>
                                    <td><input class="baseAmount" type="text" placeholder="1000000"></td>
                                    <td><button class="btn btn-info" onclick="fnBaseAmount()">افزودن</button></td>
                                </tr>`
                    }
                    $('#tblBaseAmount>tbody').html('').html(trs);
                } else {
                    $('#tblBaseAmount>tbody').html('');
                }
                //window.location = window.location;
            },
            error: function (jqXHR, exception) {
                alert("WOW Error Occured !!!!", "Error Message")
            }
        });
    }

});



function fnResearchCouncil() {
    //debugger;
    var inputs = $("#tblResearchCouncil").find('input');
    let chkCouncil = (inputs.filter('.chkCouncil')[0]).checked;
    let councilDate = inputs.filter('.councilDate')[0].value;
    let grpmId = inputs.filter('.hdn_grpId')[0].value;

    var data = {
        "id": grpmId,
        "chkCouncil": chkCouncil,
        "councilDate": councilDate
    }

    if (isValidate(data, 5)) {
        data.councilDate = normalizePersianDate(councilDate);
        $.ajax({
            url: '/Home/ResearchCouncil',
            type: 'POST',
            data: data,
            success: function (res) {
                if (res) {
                    $success = $(".wrapperResearchCouncil #msgSuccess");
                    $success.addClass('alert alert-success text-center').html("عملیات موفقیت آمیز").fadeIn();
                    setTimeout(function () {
                        $success.fadeOut('slow');
                        //window.location = window.location;
                    }, 2000);

                } else {
                    $error = $(".wrapperResearchCouncil #msgError");
                    $error.addClass('alert alert-danger text-center').html("خطا در روند عملیات").fadeIn();
                    setTimeout(function () {
                        $error.fadeOut('slow');
                        //window.location = window.location;
                    }, 2000);
                }
                //window.location = window.location;
            },
            error: function (jqXHR, exception) {
                alert("WOW Error Occured !!!!", "Error Message")
            }
        });
    }
};


$(".wrapperResearchCouncil .btnSearch").on('click', function () {
    let txtSearch = $(".wrapperResearchCouncil .txtSearch").val();
    if (!isNullOrEmpty(txtSearch)) {
        $.ajax({
            url: '/Home/Search',
            type: 'POST',
            data: { 'data': txtSearch },
            success: function (res) {
                debugger;
                if (res.length > 0) {
                    let trs = "";
                    for (var item of res) {
                        trs += `<tr>
                                    <td>
                                        <span class="profCode">`+ item.profCode + `</span>
                                        <input type="hidden" value="`+ item.id + `" class="hdn_grpId" />
                                    </td>
                                    <td><span class="profName">`+ item.profName + `</span></td>
                                    <td><input class="chkCouncil" type="checkbox" checked="`+ item.chkCouncil + `"></td>
                                    <td><input class="councilDate pdate" type="text" value="`+ item.councilDate + `" id="entranceDate_` + item.profCode + `" /></td>
                                    <td><button class="btn btn-info" onclick="fnResearchCouncil()" >افزودن</button></td>
                                </tr>`
                    }
                    $('#tblResearchCouncil>tbody').html('').html(trs);
                    addCalendersToInputDays();
                } else {
                    $('#tblResearchCouncil>tbody').html('');
                }
                //window.location = window.location;
            },
            error: function (jqXHR, exception) {
                alert("WOW Error Occured !!!!", "Error Message")
            }
        });
    }

});


$(".btnShowPresenceInWeek").on('click', function () {

    var data = {
        "yearNo": $("#hdn_currentyYear").val(),
        "monthNo": $('#drpMounthes').val(),
        "weekNo": $('#drpWeeks').val(),
        "searchData":"" //$(".wrapperPresenceInWeek .txtSearch").val()
    }


    if (isValidate(data, 3)) {
        $.ajax({
            url: '/Home/PresenceInWeek',
            type: 'POST',
            data: data,
            success: function (resp) {
                debugger;
                let tbody = $(".wrapperPresenceInWeek #tblPresenceInWeek>tbody");
                tbody.html('');
                tbody.html(resp);
            },
            error: function (jqXHR, exception) {
                alert("WOW Error Occured !!!!", "Error Message")
            }
        });
    }

});

$(".wrapperPresenceInWeek .btnSearch").on('click', function () {

    var data = {
        "yearNo": $("#hdn_currentyYear").val(),
        "monthNo": $('#drpMounthes').val(),
        "weekNo": $('#drpWeeks').val(),
        "searchData": $(".wrapperPresenceInWeek .txtSearch").val()
    }


    if (isValidate(data, 3)) {
        $.ajax({
            url: '/Home/PresenceInWeek',
            type: 'POST',
            data: data,
            success: function (resp) {
                debugger;
                let tbody = $(".wrapperPresenceInWeek #tblPresenceInWeek>tbody");
                tbody.html('');
                tbody.html(resp);
            },
            error: function (jqXHR, exception) {
                alert("WOW Error Occured !!!!", "Error Message")
            }
        });
    }

});



$(".btnShowPresenceInMonth").on('click', function () {

    var data = {
        "yearNo": $("#hdn_currentyYear").val(),
        "monthNo": $('#drpMounthes').val(),
        "weekNo": '',
        "searchData": $(".wrapperPresenceInMonth.txtSearch").val()
    }


    //if (isValidate(data, 3)) {
    $.ajax({
        url: '/Home/PresenceInMonth',
        type: 'POST',
        data: data,
        success: function (resp) {
            debugger;
            let tbody = $(".wrapperPresenceInMonth #tblPresenceInMonth>tbody");
            tbody.html('');
            tbody.html(resp);
        },
        error: function (jqXHR, exception) {
            alert("WOW Error Occured !!!!", "Error Message")
        }
    });
    //}

});

$(".wrapperPresenceInMonth .btnSearch").on('click', function () {

    var data = {
        "yearNo": $("#hdn_currentyYear").val(),
        "monthNo": $('#drpMounthes').val(),
        "weekNo": '',
        "searchData": $(".wrapperPresenceInMonth .txtSearch").val()
    }


    //if (isValidate(data, 3)) {
    $.ajax({
        url: '/Home/PresenceInMonth',
        type: 'POST',
        data: data,
        success: function (resp) {
            debugger;
            let tbody = $(".wrapperPresenceInMonth #tblPresenceInMonth>tbody");
            tbody.html('');
            tbody.html(resp);
        },
        error: function (jqXHR, exception) {
            alert("WOW Error Occured !!!!", "Error Message")
        }
    });
    //}

});

 */


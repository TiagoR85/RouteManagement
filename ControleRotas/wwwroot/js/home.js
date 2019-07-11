$(document).ready(function () {
    dateToCalendar();
});

function dateToCalendar() {
    let currentDate = new Date().toLocaleDateString("pt-br");
    $("#calendar").html('<span class="pull-left clickable"><i class="glyphicon glyphicon-calendar"></i></span> &nbsp;' + currentDate);
    return currentDate;
}

function nextDay() {
    console.log("Next day");
}

function lastDay() {
    console.log("Last day");
}

function refreshDay() {
    dateToCalendar();
}

$(document).ready(function () {
    $("#allcourse").hide();
    $("#allTeacher").hide();
});

function getcourses(year) {
    var y = year;
    
    $.ajax({
        type: "POST",
        url: "/Home/GetSubect", data: { "year": y }, success: function (result) {
            $("#allcourse").html(result);
        }
    });
    $(document).ready(function () {
        $("#allcourse").show();
    });

}

function getTeacher(sub) {
    var subId = sub;
   
    $.ajax({
        type: "POST",
        url: "/Home/GetTeacher", data: { "subId": subId }, success: function (result) {
            $("#allTeacher").html(result);
        }
    });
    $(document).ready(function () {
        $("#allTeacher").show();
    });
}
$(document).ready(function () {
    $.ajax({
        type: 'Get',
        url: '../Admin/GetAgencies',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var mySelect = $('#agencylist');
            mySelect.append(
                $('<option></option>').val("").html("Select Agency")
            );
            $.each(data.list, function (id, obj) {
                mySelect.append(
                    $('<option></option>').val(obj.id).html(obj.name)
                );
            });

            var agency = data.agency;
            if (data.role == 2) {
                $('#agencylist').val(agency.toString()); $('#agencylist').attr('disabled', true);
                $('#categorylist').load("../Admin/GetCategorys/" + parseInt($("#agencylist").val()));
                $('#categorymaster').load("../Admin/AddCategory/" + parseInt($("#agencylist").val()));

            } else { $('#categorymaster').load("../Admin/AddCategory/" + parseInt($("#agencylist").val()));}




        }
    });

});

function onchangeAgency() {
    var id = 'agencylist';
    if ($('#' + id).val() == null || $('#' + id).val() == '') {
        $("#" + id).css('border-color', '#dc3545');
        $("#" + id + "-error").show();

    }
    else {
        $("#" + id).css('border-color', '#ced4da');
        $("#" + id + "-error").hide();
    }
    $('#categorylist').load("../Admin/GetCategorys/" + parseInt($("#agencylist").val()));
    $('#categorymaster').load("../Admin/AddCategory/" + parseInt($("#agencylist").val()));
}

function clear() {
    $('#Categoryid').val('');
    

}

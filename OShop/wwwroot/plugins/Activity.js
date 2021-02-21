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
                $('#activitymaster').load("../Admin/ActivityMaster/" + parseInt($("#agencylist").val()));
            } else { $('#activitymaster').load("../Admin/ActivityMaster/" + parseInt($("#agencylist").val())); }

        }
    });
    //Date range picker
    //$('#reservation').daterangepicker();


});

function clearbill(id) {
    
    $.ajax({
        type: 'Get',
        url: '../Admin/ClearBill',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { 'id': id },
        success: function (data) {
          if(data == true) {
            bindActivities();
          }
        }
    });
}



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
    $('#activitymaster').load("../Admin/ActivityMaster/" + parseInt($("#agencylist").val()));
}


function validateShop() {
    if ($('#agencylist').val() == null || $('#agencylist').val() == '') {

        $("#agencylist").css('border-color', '#dc3545');
        $("#agencylist-error").show();
        return false;
    }
    else if ($('#shopcode').val() != '' || $('#shoplist').val() != '') {
        $('#shopcode-error')
        $("#shopcode").css('border-color', '#ced4da');
        $("#shopcode-error").hide();
        $("#shoplist").css('border-color', '#ced4da');
        $("#shoplist-error").hide();
        return true;
    }

    else {
        $("#shopcode").css('border-color', '#dc3545');
        $("#shopcode-error").show();
        $("#shoplist").css('border-color', '#dc3545');
        $("#shoplist-error").show();
        return false;
    }
}
function bindActivities() {
    var condition = validateShop();
    if (condition == true) {
        $("#activitylist").load("../Admin/GetActivityList", { shopno: $('#shoplist').val(), shopcode: $('#shopcode').val() },
            function (response, status, xhr) {
                if (status == "error") {
                    alert("An error occurred while loading the results.");
                }
            });
    }
}
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
                $('#usermaster').load("../Admin/AddUser/" + parseInt($("#agencylist").val()));
                $('#userlist').load("../Admin/GetUsers/" + parseInt($("#agencylist").val()));

            } else { $('#usermaster').load("../Admin/AddUser/" + parseInt($("#agencylist").val())); }




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
    $('#userlist').load("../Admin/GetUsers/" + parseInt($("#agencylist").val()));
    $('#usermaster').load("../Admin/AddUser/" + parseInt($("#agencylist").val()));
}

function clear() {
    $('#loginnameid').val('');
    $('#mobileid').val('')
    $('#emailid').val('')
    $('#Roleid').val('')
    
}

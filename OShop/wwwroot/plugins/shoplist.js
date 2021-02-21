$(document).ready(function () {
    $.ajax({
        type: 'Get',
        url: '../Admin/GetAgencies',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async:false,
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
                $('#shopmaster').load("../Admin/AddShop/" + parseInt($("#agencylist").val()));
                $('#shoplist').load("../Admin/GetShops/" + parseInt($("#agencylist").val()));

            } else { $('#shopmaster').load("../Admin/AddShop/" + parseInt($("#agencylist").val()));}

            

            
        }
    });
    ///$('#example1').dataTable();
    
    



    //$('#agencylist').attr('onchange', function () {
    //    alert(1)
       
    //});





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
    $('#shoplist').load("../Admin/GetShops/" + parseInt($("#agencylist").val()));
    $('#shopmaster').load("../Admin/AddShop/" + parseInt($("#agencylist").val()));
}

function clear() {
    $('#Shopcategoryid').val('');
    $('#shopnameid').val('')
    $('#shopcodeid').val('')
    $('#amountid').val('')
    $('#shopaddr').val('')
    $('#shopno').val('')
    $('#shopemail').val('')
}

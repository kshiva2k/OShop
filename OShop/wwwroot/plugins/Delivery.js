$(document).ready(function () {
    $("#chequeno").attr('readonly', true);
    $('#chequeno').addClass('input-disabled');
    
    $("#paymentmode").change(function () {
        if ($("#paymentmode option:selected").val() == 2) {
            $("#chequeno").removeAttr('readonly');
            $('#chequeno').removeClass('input-disabled');            
        }
        else {
            $("#chequeno").attr('readonly', true);
            $('#chequeno').addClass('input-disabled');
            $("#chequeno").val('');
        }
    });
    //$("#count").change(function () {        
      
        
    //});
    //$("#save").click('onclick', function () {
       
});

function SaveDelivery() {

    var condition = Validatedelivery();

    if (condition == true) {

        var json = {
            "Agencyid": $("#aid").val(),
            "Shopid": $("#id").val(),
            "Quantity": $("#count").val(),
            "Invoiceamount": $("#billamount").text(),
            "Paymentmode": $("#paymentmode option:selected").text(),
            "Paymentno": $("#chequeno").val(),
            "Actualpayment": $("#paidamt").val(),
            "ReturnQuantity": $("#return").val()
        };
        $.ajax({
            type: 'Get',
            url: '../User/AddDelivery',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: json,
            success: function (data) {
                //console.log(data);
                toastr.success('Delivery entry succeed.');
                //return true;
                ClearData();
                $('#shopdetails').hide();
            }
        });
    }
    else {
        toastr.error('Error while enter delivery details.');
        return false;
    }
}

function PaymentMode() {
    if ($('#paymentmode').val() == '2') {
        $('#dCheque').show();
    }
    else {
        $('#dCheque').hide();
    }
}

function Onkeyupsbill() {
    if ($("#count").val() != "" && parseInt($("#count").val()) > 0) {
        $("#billamount").text(parseInt($("#count").val()) * parseFloat($("#amt").val()));
        $("#overallbill").text(parseFloat($("#hiddenoverallbill").val()) + parseFloat($("#billamount").text()));
    }
    else {
        $("#billamount").text(0);
        $("#overallbill").text($("#hiddenoverallbill").val());
    }
}

function GetShopDetail() {

    var condition = validateShop();
    if (condition == true) {
        $.ajax({
            url: '../User/GetShopDetail/',
            data: { "code": $("#shopcode").val(), "shopname": parseInt($("#shoplist").val()) },
            contentType: "json",
            success: function (data) {
                $("#id").val(data.id);
                $("#aid").val(data.agencyid);
                $("#code").text(data.code);
                $("#shopname").text(data.name);
                $("#address").text(data.address);
                $("#amt").val(data.amount);
                $("#overallbill").text(data.overallAmount);
                $("#hiddenoverallbill").val(data.overallAmount);

                $('#shopdetails').show();
            }
        });
    }
    else {

    }
}

function validateShop() {
    if ($('#shopcode').val() != '' || $('#shoplist').val() != '') {
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

function Validatedelivery() {
    if ($('#count').val() == '') {
        $("#count").css('border-color', '#dc3545');
        $("#count-error").show();
        return false;
    }
    else if ($('#paymentmode').val() == '') {
        $("#paymentmode").css('border-color', '#dc3545');
        $("#paymentmode-error").show();
        return false;
    }
    else if ($('#paymentmode').val() == '2') {
        if ($('#chequeno').val() == '') {
            $("#chequeno").css('border-color', '#dc3545');
            $("#chequeno-error").show();
            return false;
        }

        else {
            return true;
        }
    }
    else {
        return true;
    }
}

function ClearData() {
    $("#shopcode").val('');
    $("#Code").text('');
    $("#id").val('');
    $("#aid").val('');
    $("#shopname").text('');
    $("#address").text('');
    $("#count").val('');
    $("#amt").val('');
    $("#paidamt").val('');
    $("#hiddenoverallbill").val('');
    $("#billamount").text('');
    $("#overallbill").text('');
    $("#chequeno").val('');
    $("#return").val('');
    $("#count").val('');
    $('#paymentmode').prop('selectedIndex', 0);
}
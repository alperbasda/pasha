
$(document).ready(function() {
    var str = "";
    var filled = false;
    $('#lastId').removeAttr('readonly');
    if ($('#count').val() == "" || $('#count').val() == "undefined") {
        filled = true;
    }
    for (var i = 0; i < $('.selection').find("option:selected").length ; i++) {
        if ($('.selection').find("option:selected").eq(i).text() == "" || $('.selection').find("option:selected").eq(i).text() == "undefined") {
            filled = true;
        }
        str += $('.selection').find("option:selected").eq(i).text() + ",";
    }
    if (filled == false) {
        $('#lastId').val(str + $('.product').attr('id'));
    } else {
        alert("Hesaplama için tüm bilgileri doldurunuz");
    }
    $('#lastId').attr('readonly', 'readonly');
});

$('.selection').change(function () {
    var str = "";
    var filled = false;
    $('#lastId').removeAttr('readonly');
    if ($('#count').val() == "" || $('#count').val() == "undefined") {
        filled = true;
    }
    for (var i = 0; i < $('.selection').find("option:selected").length ; i++) {
        if ($('.selection').find("option:selected").eq(i).text() == "" || $('.selection').find("option:selected").eq(i).text()=="undefined") {
            filled = true;
        }
        str += $('.selection').find("option:selected").eq(i).text() + ",";
    }
    if (filled==false) {
        $('#lastId').val(str+$('.product').attr('id'));
    } else {
        alert("Hesaplama için tüm bilgileri doldurunuz");
    }
    $('#lastId').attr('readonly', 'readonly');
});
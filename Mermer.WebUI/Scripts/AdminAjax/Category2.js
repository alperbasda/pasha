$(document).ready(function () {
    $.ajax({
        dataType: 'JSON',
        type: 'GET',
        url: '../../Category/GetCategoriesJson',
        contentType: 'application/json;',
        success: function (response) {
            var a = JSON.parse(response);
            $('#categories').children('option').remove();
            for (var i = 0; i < a.length; i++) {
                $('#categories').append('<option value=' + a[i].Id + '>' + a[i].Name + '</option>');
            }
            $('#categories').selectpicker('refresh');
            $('#products').selectpicker('refresh');
            
        }

    });
});

$('#categories').on('change', function (e) {

    $.ajax({
        dataType: 'JSON',
        type: 'GET',
        url: '../../Product/GetProductsInCategoryJson',
        contentType: 'application/json;',
        data: { 'id': this.value },
        success: function (response) {
            var a = JSON.parse(response);
            $('#products').children('optgroup').remove();
            $('#products').children('option').remove();
            for (var i = 0; i < a.length; i++) {
                var last = $('#products').append('<optgroup data-subtext="' + a[i].Name + '">');

                for (var j = 0; j < a[i].PropertiesRelationsIds.length; j++) {
                    $(last).append('<option data-subtext="' + a[i].Name + '" value=' + a[i].PropertiesRelationsIds[j] + '>' + a[i].PropertiesStr[j] + '</option>');
                }

                $('#products').append('</optgroup>');
            }
            $('#products').selectpicker('refresh');
        }

    });

});

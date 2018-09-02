﻿function removeImage(item) {

    if (confirm("Resim silinsin mi?")) {
        $.ajax({
            dataType: 'JSON',
            type: 'GET',
            url: '../RemoveImage',
            data: { 'path': $(item).attr('src') },
            contentType: 'application/json;',
            success: function (response) {
                if (response == 1)
                    $(item).parent('div').remove();
            }

        });
    }

}

var filterArrays = [[]];
var filterTableArrays = [[]];
var lastResult = [];
var productImages = [];
var productImagesDescriptions = [];
var arrSelectedVal = [];
var arrSelectedText = [];
var array = [];
var firstlength = 0;
var table;
var pid = 0;

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


function AddSingleProduct(item) {
    $.ajax({
        dataType: 'JSON',
        type: 'GET',
        url: '../Product/AddProductJson',
        contentType: 'application/json;',
        data: { 'CategoryId': $('#categories').find("option:selected").val(), 'Name': $('#productName').val(), 'Description': $('#productDescription').val() },
        success: function (response) {
            pid = response;
            $.ajax({
                dataType: 'JSON',
                type: 'GET',
                url: '../AddProductImageJson',
                contentType: 'application/json;',
                data: { 'productId': pid, 'images': JSON.stringify(productImages), 'imagesDesc': JSON.stringify(productImagesDescriptions) },
                traditional: true,
                success: function () {
                    alert("Başarılı");
                    $('#images').append('<div class="col-lg-2 col-md-2"><img onlick="removeImage(this)" class="img-responsive" src=' + turn[1] + ' alt="Ürün Resim"/></div>');
                }


            });
        }

    });

}

function removeImage(item) {

    if (confirm("Resim silinsin mi?")) {
        $.ajax({
            dataType: 'JSON',
            type: 'GET',
            url: '../RemoveImage',
            data: { 'path': $(item).attr('src') },
            contentType: 'application/json;',
            success: function (response) {
                if (response == 1)
                    $(item).parent('div').remove();
            }

        });
    }

}

function uploadImage(pid) {
    $.ajax({
        dataType: 'JSON',
        type: 'GET',
        url: 'AddProductImageJson',
        contentType: 'application/json;',
        data: { 'productId': pid, 'images': JSON.stringify(productImages), 'imagesDesc': JSON.stringify(productImagesDescriptions) },
        traditional: true,
        success: function () {
            alert("Başarılı");
            $('#images').append('<div class="col-lg-2 col-md-2"><img onlick="removeImage(this)" class="img-responsive" src=' + turn[1] + ' alt="Ürün Resim"/></div>');
        }


    });
}

var itemstr = "";

$('#btnUploadShow').click(function () {
    $('#uploadImageInput').click();
});


$('#uploadImageInput').change(function () {
    productImages = [];
    productImagesDescriptions = [];
    var data = new FormData();
    var files = $('#uploadImageInput').get(0).files;
    $('#myprogress').attr('aria-valuenow', 0).css('width', 0 + '%').text(0 + '%');
    data.append('file', files[0]);
    $.ajax({
        xhr: function () {
            var xhr = new window.XMLHttpRequest();
            xhr.upload.addEventListener('progress',
                function (e) {

                    if (e.lengthComputable) {
                        var percent = Math.round((e.loaded / e.total) * 100);
                        $('#myprogress').attr('aria-valuenow', percent).css('width', percent + '%').text(percent + '%');

                    }
                });
            return xhr;


        },

        url: '../UploadImage',
        type: 'POST',
        processData: false,
        data: data,
        dataType: 'json',
        contentType: false,
        success: function (turn) {
            productImages.push(turn[1]);
            productImagesDescriptions.push($('#imageDesc').val());
            $.ajax({
                dataType: 'JSON',
                type: 'GET',
                url: '../AddProductImageJson',
                contentType: 'application/json;',
                data: { 'productId': parseInt($('span[data-key]').data('key')), 'images': JSON.stringify(productImages), 'imagesDesc': JSON.stringify(productImagesDescriptions) },
                traditional: true,
                success: function () {
                    $('#imageDesc').val("");
                    $('#images').append('<div class="col-lg-2 col-md-2"><img onlick="removeImage(this)" class="img-responsive" src=' + turn[1] + ' alt="Ürün Resim"/></div>');
                }


            });


        }


    });
});


$('#defaultValueUpdate').click(function () {

    $.ajax({
        dataType: 'JSON',
        type: 'GET',
        url: '../SetDefaultValueJson',
        contentType: 'application/json;',
        data: { 'categoryId': $('#categories').val(), 'productId': $('form[data-pid]').data('pid'), 'productName': $('#productName').val(), 'productDescription': $('#productDescription').val() },
        success: function (response) {
            $('#defaultValueUpdate').val('Başarılı!!!');
            
        }

    });

});

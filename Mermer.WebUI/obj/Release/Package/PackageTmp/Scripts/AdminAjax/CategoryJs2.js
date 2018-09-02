
$('#btnUploadShow').click(function () {
    $('#uploadImageInput').click();

});


$('#uploadImageInput').change(function () {
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
        url: '../../Product/UploadImage',
        type: 'POST',
        processData: false,
        data: data,
        dataType: 'json',
        contentType: false,
        success: function (turn) {
            $('#url').val(turn[1]);
            $('#images').append('<div class="col-lg-2 col-md-2"><img class="img-responsive" src=' + turn[1] + ' alt="Ürün Resim"/></div>');
        },


    });
});

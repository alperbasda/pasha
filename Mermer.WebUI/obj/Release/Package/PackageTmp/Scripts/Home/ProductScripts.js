
function GetProducts(item) {
    $.each($('.staff-item2'),
        function(index, item2) {
            if (!$(item2).hasClass($(item).data('cad'))) {
                $(item2).hide();
            } else {
                $(item2).show();
            }
        });
    $('.categoryName').html($(item).children('h1').html() + " Ürünleri");
}

$('.menuItem').click(function() {
    $('#kapat').click();
    if (this.hash !== "") {
        event.preventDefault();

        var hash = this.hash;

        $('html, body').animate({
            scrollTop: $(hash).offset().top-90
        }, 800);
    } // End if

});

$('#showMenu').click(function() {
    $('.show-big-menu').click();
});
var selectElement = "<span class='selected'></span>";
var selectElement2 = "<span class='arrow open'></span>";
$(window).load(function () {
    var url = window.location.href;
    $('li.nav-item.active').removeClass('active').removeClass('open');
    $('li.nav-item.active').children('a').children('.selected').remove();
    $('li.nav-item.active').children('a').children('.arrow').remove();
    $('li.nav-item a').filter(function () {
        if (this.href == url) {
            if ($(this).parent('.nav-item').parents('.sub-menu').length > 0) {
                $(this).parent('.nav-item').parent('.sub-menu').parent('.nav-item').addClass('active').addClass('open'); 
                $('#navigate').append('<a href="">' + $(this).parent('.nav-item').parent('.sub-menu').parent('.nav-item').children('a').children('span').text() + '</a><i class="fa fa-angle-right"></i>');
                $(this).parent('.nav-item').parent('.sub-menu').parent('.nav-item').children('a').append(selectElement);
                $(this).parent('.nav-item').parent('.sub-menu').parent('.nav-item').children('a').append(selectElement2);
            } else {
                $(this).append(selectElement);
                $(this).append(selectElement2);
            }
            $('#navigate').append('<a href="">' + $(this).children('span').text());
        }
        return this.href == url;
    }).parent().addClass('active').addClass('open');

});
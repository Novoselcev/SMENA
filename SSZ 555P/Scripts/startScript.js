﻿$(document).ready(function () { 
    var Nameuser = $('input#Username').val();
    actTabnomer(Nameuser);

    $('input#Username').change(function () {
        Nameuser = $('input#Username').val();
        actTabnomer(Nameuser);
    });
});

function actTabnomer(Nameuser)
{
    var str = Nameuser.toLowerCase();
    if (str == "novoselcev.a" || str == "hasmet" || str == "mralbert") {
        $('#tabNomerV').css({"visibility":"visible","display":""});
    }
    else {
        $('#tabNomerV').css({ "visibility": "hidden", "display": "none" });
    }
}



(function ($) {
    $.enhanceFormsBehaviour = function () {
        $('.the_form').enhanceBehaviour();
    }

    $.fn.enhanceBehaviour = function () {
        return this.each(function () {
            var submits = $(this).find(':submit');
            submits.click(function () {
                var hidden = document.createElement('input');
                hidden.type = 'hidden';
                hidden.name = this.name;
                hidden.value = this.value;
                this.parentNode.insertBefore(hidden, this)
            });
            $(this).submit(function () {
                submits.attr("disabled", "disabled");
            });
            $(window).unload(function () {
                submits.removeAttr("disabled");
            })
        });
    }
})(jQuery);



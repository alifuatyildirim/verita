function bootstrapElementInit() {

    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
};

function dropdownSelect() {
    $(".dropdown-select .dropdown-menu li a").click(function (e) {
        e.preventDefault();
        $(this).parents(".dropdown").find('.dropdown-select-title span').html($(this).text());
        $(this).parents(".dropdown").find('.dropdown-select-title span').val($(this).data('value'));

    });
}

$.fn.hasAttr = function (name) {
    return this.attr(name) !== undefined;
};


$.fn.windowPaddingCalc = function (options) {

    var defaults = {
        sourceEl: ".hidden-container",
        paddingLeft: true,
        paddingRight: false,
        width: false
    };

    var settings = $.extend({}, defaults, options);


    return this.each(function () {



        let hiddenContainer = $(settings.sourceEl);
        var elem = $(this);

        if (settings.paddingLeft) {
            let screenWidth = $(window).width(),
                paddingCalc = (screenWidth - hiddenContainer.width()) / 2;

            elem.css('padding-left', paddingCalc);
        }

        if (settings.paddingRight) {
            let screenWidth = $(window).width(),
                paddingCalc = (screenWidth - hiddenContainer.width()) / 2;

            elem.css('padding-right', paddingCalc);
        }


        if (settings.width) {
            let screenWidth = hiddenContainer.width();
            elem.css('width', screenWidth);
        }

    });


};

if ($('.swiper-container').length) {
    const swiper = new Swiper(".swiper-container", {
        speed: 400,
        navigation: {
            nextEl: ".swiper-store-navigation-next",
            prevEl: ".swiper-store-navigation-prev",
        },
        loop: true,

        effect: 'fade',
        fadeEffect: {
            crossFade: true
        },
        pagination: {
            el: ".swiper-pagination",
            type: "bullets",
            clickable: true,
        },
    });
}


if ($('.store-showcase-swiper').length) {
    const storeShowcase = new Swiper('.store-showcase-swiper', {
        slidesPerView: "auto",
        autoplay: {
            delay: 7000,
        },
        spaceBetween: 25,
        navigation: {
            nextEl: '.store-showcase-arrow .store-showcase-arrow-right',
            prevEl: '.store-showcase-arrow .store-showcase-arrow-left',
        },
    });
}


if ($('.our-trainings-swiper').length) {
    const ourTrainingsSwiper = new Swiper('.our-trainings-swiper', {
        slidesPerView: "auto",
        autoplay: {
            delay: 4000,
        },
        spaceBetween: 20,

    });

}




if ($('.home-head-right-slider .swiper').length) {
    const homeRightSlider = new Swiper(".home-head-right-slider .swiper", {
        slidesPerView: 1,
        autoplay: {
            delay: 14000,
        },
        loop: true,

        navigation: {
            nextEl: ".swiper-right-slider-navigation-next",
            prevEl: ".swiper-right-slider-navigation-prev",
        },
    });

}


function propertyToogle() {
    var readmore_btn = $('.property-readmore');

    $(readmore_btn).on('click', function () {
        var $this = $(this),
            parentClass = $this.parent('.product-property').find('.property-list');


        if (parentClass.hasClass('property-list-show')) {
            $this.removeClass('readmore-hide');
            parentClass.removeClass('property-list-show');
        } else {
            $this.addClass('readmore-hide');
            parentClass.addClass('property-list-show');
        }

    });



}

function productNumberInput(name) {
    if ($(name).length) {

        $(name).each(function () {

            let $inputId = $(this).find('input'),
                $numberInput = $inputId,
                numberBtnMinus = $inputId.parent('.product-number').find('.product-number-btn-minus'),
                numberBtnPlus = $inputId.parent('.product-number').find('.product-number-btn-plus'),
                min = 1,
                max = 1000;

            if ($numberInput.hasAttr('min')) {
                min = Number($numberInput.attr('min'));
            }
            if ($numberInput.hasAttr('max')) {
                max = Number($numberInput.attr('max'));
            }

            //$numberInput.attr('value', min);

            $(numberBtnMinus).on("click", function () {

                $numberInput.val(function () {
                    var _val = $numberInput.val();

                    if (_val > min) {

                        _val = Number(_val) - 1;

                        $numberInput.attr('value', _val);

                        return _val;

                    } else {
                        return this.value
                    }
                });

                lengthInputVal();

            });

            $(numberBtnPlus).on("click", function () {

                $numberInput.val(function () {
                    if (this.value < max) {

                        var _val = Number($numberInput.val()) + 1;
                        $numberInput.attr('value', _val);

                        return _val;

                    } else {
                        return this.value
                    }
                });

                lengthInputVal();

            });

            /* Input change min - max number */
            $numberInput.on('input', function () {
                var field = $(this);

                if (/\D/g.test(this.value) || !this.value) {
                    this.value = min;
                    field.attr('value', min);
                }

                if (field.val() > max) {
                    this.value = max;
                    field.attr('value', max);
                }

                if (field.val() >= min) {
                    this.value = Number(field.val()).toString();
                    field.attr('value', this.value);
                }

                lengthInputVal();

            });

            function lengthInputVal() {

                switch ($numberInput.val().length) {
                    case 1:
                        $numberInput.removeClass();
                        break;

                    case 2:
                        $numberInput.removeClass();
                        $numberInput.addClass('number-length-2');
                        break;

                    case 3:
                        $numberInput.removeClass();
                        $numberInput.addClass('number-length-3');
                        break;

                    case 4:
                        $numberInput.removeClass();
                        $numberInput.addClass('number-length-4');
                        break;

                    default:
                        break;
                }
            }


        });
    }
}


// Navbar Mega Menu - Navs Hover 
if ($(window).width() > 768) {
    $('header .nav-item').on('click', function () {

        if ($(this).data('href')) {
            window.location.href = $(this).data("href");
        }

    })
}


if (window.matchMedia('only screen and (min-width: 991.01px)').matches) {


}

if ($('.sale-form').length) {
    function saleforminput() {
        $('.sale-form .intl-tel-input input').removeClass("form-control-lg").addClass("form-control");
    }
    setTimeout(saleforminput, 1000);
}


(function ($) {


    propertyToogle();
    dropdownSelect();
    bootstrapElementInit();

    $('.our-trainings-swiper').windowPaddingCalc();
    $('.store-showcase-swiper').windowPaddingCalc({
        paddingLeft: true,
        paddingRight: true
    });



})(window.jQuery);
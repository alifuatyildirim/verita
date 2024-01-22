var AjaxCart = {
    loadWaiting: false,
    loadElement: '',
    topcartselector: '',
    topwishlistselector: '',
    flyoutcartselector: '',

    init: function (topcartselector, topwishlistselector, flyoutcartselector) {
        this.loadWaiting = false;
        this.loadElement = '',
        this.topcartselector = topcartselector;
        this.topwishlistselector = topwishlistselector;
        this.flyoutcartselector = flyoutcartselector;
    },

    setLoadWaiting: function (display, el) {
        this.loadWaiting = display;
        if (display) {
            this.loadElement = $(el);
            this.loadElement.addClass('ajax-loading');
        }
        else {
            this.loadElement.removeClass('ajax-loading');
            this.loadElement = '';
        }
    },

    setSuccessClass: function () {
        var $el = this.loadElement;
        $el.addClass('ajax-success');
        setTimeout(function ()
        {
            $el.removeClass('ajax-success');
        }, 3000);
    },

    //add a product to the cart from the catalog pages
    addproducttocart_catalog: function (urladd, formselector, el) {
        if (this.loadWaiting != false) {
            return;
        }
        this.setLoadWaiting(true, el);

        $.ajax({
            cache: false,
            url: urladd,
            data: $(formselector).serialize(),
            type: 'post',
            success: function (response) {
                AjaxCart.success_process(response, "addproducttocart", formselector);
            },
            complete: this.resetLoadWaiting,
            error: this.ajaxFailure
        });
    },

    //add a product to the cart from the product details page
    addproducttocart_details: function (urladd, formselector, el) {
        if (this.loadWaiting != false) {
            return;
        }
        this.setLoadWaiting(true, el);
        $.ajax({
            cache: false,
            url: urladd,
            data: $(formselector).serialize(),
            type: 'post',
            success: function (response) {
                AjaxCart.success_process(response, "addproducttocart");
            },
            complete: this.resetLoadWaiting,
            error: this.ajaxFailure
        });
    },

    //remove a product to the cart
    removeproducttocart: function (urlremove, el) {
        if (this.loadWaiting != false) {
            return;
        }
        this.setLoadWaiting(true, el);
        $.ajax({
            cache: false,
            url: urlremove,
            type: 'post',
            success: function (response) {
                AjaxCart.success_process(response, "removeproducttocart");
            },
            complete: this.resetLoadWaiting,
            error: this.ajaxFailure
        });
      
    },

    //add a product to the wishlist
    addproducttowishlist: function (urladd, el) {
        if (this.loadWaiting != false) {
            return;
        }
        this.setLoadWaiting(true, el);
        $.ajax({
            cache: false,
            url: urladd,
            type: 'post',
            success: function (response) {
                AjaxCart.success_process(response, "addproducttowishlist");
            },
            complete: this.resetLoadWaiting,
            error: this.ajaxFailure
        });
    },

    //remove a product to the wishlist
    removeproducttowishlist: function (urlremove, el) {
        if (this.loadWaiting != false) {
            return;
        }
        this.setLoadWaiting(true, el);
        $.ajax({
            cache: false,
            url: urlremove,
            type: 'post',
            success: function (response) {
                AjaxCart.success_process(response, "removeproducttowishlist");
            },
            complete: this.resetLoadWaiting,
            error: this.ajaxFailure
        });
    },

    //add a product to compare list
    addproducttocomparelist: function (urladd, el) {
        if (this.loadWaiting != false) {
            return;
        }
        this.setLoadWaiting(true, el);
        $.ajax({
            cache: false,
            url: urladd,
            type: 'post',
            success: function (response) {
                AjaxCart.success_process(response, "addproducttocomparelist");
            },
            complete: this.resetLoadWaiting,
            error: this.ajaxFailure
        });
    },

    success_process: function (response, eventName, formselector) {
        if (response.updatetopcartsectionhtml) {
            $(AjaxCart.topcartselector).html(response.updatetopcartsectionhtml);
        }
        if (response.updatetopwishlistsectionhtml) {
            $(AjaxCart.topwishlistselector).html(response.updatetopwishlistsectionhtml);
        }
        if (response.updateflyoutcartsectionhtml) {
            $(AjaxCart.flyoutcartselector).replaceWith(response.updateflyoutcartsectionhtml);
        }
        if (response.productattributessectionhtml) {
            $(formselector).append(response.productattributessectionhtml);
        }
        if (response.message) {
            //display notification
            if (response.success == true) {
                //success
                displayNotification(response.message, 'success');
                //set success class
                AjaxCart.setSuccessClass();
                //publish event
                $(document).trigger(eventName);
            }
            else {
                //error
                displayNotification(response.message, 'error');
            }
            return false;
        }
        if (response.redirect) {
            location.href = response.redirect;
            return true;
        }
        return false;
    },

    resetLoadWaiting: function () {
        AjaxCart.setLoadWaiting(false);
    },

    ajaxFailure: function () {
        console.log('error.');
    }
};
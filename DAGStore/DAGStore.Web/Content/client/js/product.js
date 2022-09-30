let select = "";
let buttonTab = $(".product-preview-tab");
let tab = $(".product-content-tab");
let contentTab = $(".product-content-tab-child");

buttonTab.click(function () {

    select = $(this).attr('control');

    tab.removeClass("active");
    for (let i = 0; i <= tab.length; i++) {

        if ($(tab[i]).attr("control") === select) {
            $(tab[i]).addClass("active");
        }

        contentTab.removeClass("active").removeClass("show");
        for (let k = 0; k <= contentTab.length; k++) {

            if ($(contentTab[k]).attr("control") === select) {

                $(contentTab[k]).addClass("show").addClass("active");
            }
        }
    }
});







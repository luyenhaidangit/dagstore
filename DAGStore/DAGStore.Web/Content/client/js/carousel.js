$(document).ready(function () {
    //Big Campaign Carousel
    var swiperBigCampaign = new Swiper(".big-campaign__swiper", {
        slidesPerView: 1,
        spaceBetween: 0,
        slidesPerGroup: 1,
        loop: true,
        loopFillGroupWithBlank: true,
        autoplay: {
            delay: 3000,
            disableOnInteraction: false,
        },
        pagination: {
            el: ".big-campaign__dot",
            clickable: true,
        },
        navigation: {
            nextEl: ".big-campaign__button-next",
            prevEl: ".big-campaign__button-pre",
        },

        breakpoints: {
            992: {
                slidesPerView: 2,
                spaceBetween: 16
            }
        }
    });


    //Hot Deal Carousel
    var swiperHotDeal = new Swiper(".hot-deal__swiper", {
        spaceBetween: 16,
        slidesPerGroup: 2,
        freeMode: true,
        navigation: {
            nextEl: ".hot-deal__button-next",
            prevEl: ".hot-deal__button-prev",
        },
        breakpoints: {
            1400: {
                slidesPerView: 5,
                spaceBetween: 16,
                slidesPerGroup: 5,
                loop: true,
            },
            1200: {
                slidesPerView: 4,
                spaceBetween: 24,
                slidesPerGroup: 4,
                loop: true,
            },

            992: {
                slidesPerView: 3,
                spaceBetween: 24,
                slidesPerGroup: 3,
                loop: true,
            },
            768: {
                watchSlidesProgress: true,
                slidesPerView: 2,
                spaceBetween: 24,
                slidesPerGroup: 2,
            },
            567: {
                watchSlidesProgress: true,
                slidesPerView: 2,
                spaceBetween: 24,
                slidesPerGroup: 2,
                loop: true,
                freeMode: false,
            },
        }
    });

    // Promo Brand Carousel
    var swiperOutstanding = new Swiper(".promo-brand__swiper-outstanding", {
        slidesPerView: 1,
        spaceBetween: 16,
        slidesPerGroup: 1,
        loop: true,
        loopFillGroupWithBlank: true,
        autoplay: {
            delay: 3000,
            disableOnInteraction: false,
        },
        pagination: {
            el: ".promo-brand-outstanding__dot",
            clickable: true,
        },
        navigation: {
            nextEl: ".promo-brand-outstanding__button-next",
            prevEl: ".promo-brand-outstanding__button-prev",
        },

        breakpoints: {
            // when window width is >= 320px
            992: {
                slidesPerView: 3,
                spaceBetween: 16
            },

            768: {
                slidesPerView: 2,
                spaceBetween: 16
            }
        }
    });

    var swiperProduct = new Swiper(".promo-brand__swiper-product", {
        spaceBetween: 16,
        slidesPerGroup: 2,
        freeMode: true,
        navigation: {
            nextEl: ".promo-brand-product__button-next",
            prevEl: ".promo-brand-product__button-prev",
        },
        breakpoints: {
            1400: {
                slidesPerView: 5,
                spaceBetween: 16,
                slidesPerGroup: 5,
                loop: true,
            },
            1200: {
                slidesPerView: 4,
                spaceBetween: 24,
                slidesPerGroup: 4,
                loop: true,
            },

            992: {
                slidesPerView: 3,
                spaceBetween: 24,
                slidesPerGroup: 3,
                loop: true,
            },
            768: {
                watchSlidesProgress: true,
                slidesPerView: 2,
                spaceBetween: 24,
                slidesPerGroup: 2,
            },
            567: {
                watchSlidesProgress: true,
                slidesPerView: 2,
                spaceBetween: 24,
                slidesPerGroup: 2,
                loop: true,
                freeMode: false,
            },
        }
    });

    // Cate Feature Carousel
    var swiperCateFeature = new Swiper(".cate-feature__body", {
        grid: {
            rows: 2,
        },
        freeMode: true,
        spaceBetween: 8,
        pagination: {
            el: ".swiper-pagination",
            clickable: true,
        },
        breakpoints: {
            1200: {
                slidesPerView: 10,
                grid: {
                    rows: 2,
                },
            },

            992: {
                slidesPerView: 8,
                grid: {
                    rows: 2,
                },
            },
            768: {
                slidesPerView: 6,
                grid: {
                    rows: 2,
                },
            },
            576: {
                slidesPerView: 4,
                grid: {
                    rows: 2,
                },
            },
            0: {
                slidesPerView: 3,
                grid: {
                    rows: 2,
                },
            }
        }
    });

    // Discount Payonl Carousel
    var swiperDiscountPayonl = new Swiper(".discount-payonl__swiper", {
        slidesPerView: 1,
        spaceBetween: 16,
        slidesPerGroup: 1,
        loop: true,
        loopFillGroupWithBlank: true,
        autoplay: {
            delay: 3000,
            disableOnInteraction: false,
        },
        pagination: {
            el: ".discount-payonl__dot",
            clickable: true,
        },
        navigation: {
            nextEl: ".discount-payonl__button-next",
            prevEl: ".discount-payonl__button-prev",
        },

        breakpoints: {
            992: {
                slidesPerView: 3,
                spaceBetween: 16
            },

            768: {
                slidesPerView: 2,
                spaceBetween: 16
            }
        }
    });

    // Service Conv Carousel
    var swiperServiceConv = new Swiper(".service-conv__body", {
        slidesPerView: "auto",
        spaceBetween: 16,
        freeMode: true,
    });

    // Trademark Carousel
    var swiperTrademark = new Swiper(".trademark__swiper", {
        slidesPerView: 1,
        spaceBetween: 16,
        slidesPerGroup: 1,
        freeMode: true,
        // loop: true,
        loopFillGroupWithBlank: true,
        // autoplay: {
        //     delay: 3000,
        //     disableOnInteraction: false,
        // },
        pagination: {
            el: ".trademark__dot",
            clickable: true,
        },
        navigation: {
            nextEl: ".trademark__button-next",
            prevEl: ".trademark__button-prev",
        },

        breakpoints: {
            // when window width is >= 320px
            992: {
                slidesPerView: 3,
                spaceBetween: 16
            },

            768: {
                slidesPerView: 2,
                spaceBetween: 16
            }
        }
    });

    // NewChain Carousel
    var swiperTrademark = new Swiper(".newchain__swiper", {
        slidesPerView: 1,
        spaceBetween: 16,
        slidesPerGroup: 1,
        freeMode: true,
        loop: true,
        loopFillGroupWithBlank: true,
        autoplay: {
            delay: 3000,
            disableOnInteraction: false,
        },
        pagination: {
            el: ".newchain__dot",
            clickable: true,
        },
        navigation: {
            nextEl: ".newchain__button-next",
            prevEl: ".newchain__button-prev",
        },

        breakpoints: {
            992: {
                slidesPerView: 3,
                spaceBetween: 16
            },

            768: {
                slidesPerView: 2,
                spaceBetween: 16
            }
        }
    });

    // Promo Bhx Carousel
    var swiperPromoBhx = new Swiper(".promo-bhx__swiper", {
        slidesPerView: 1,
        spaceBetween: 4,
        slidesPerGroup: 1,
        freeMode: true,
        // loop: true,
        loopFillGroupWithBlank: true,

        breakpoints: {
            1400: {
                slidesPerView: 5,
                spaceBetween: 12
            },

            1200: {
                slidesPerView: 4,
                spaceBetween: 12
            },
            992: {
                slidesPerView: 3,
                spaceBetween: 12
            },
            768: {
                slidesPerView: 2,
                spaceBetween: 12
            },
            576: {
                slidesPerView: 1,
                spaceBetween: 12
            }
        }
    });

    // banner-top slider -- product categories
    var swiperOutstanding = new Swiper(".product-categories__top-banner__carousel", {
        slidesPerView: 1,
        spaceBetween: 16,
        slidesPerGroup: 1,
        loop: true,
        loopFillGroupWithBlank: true,
        // autoplay: {
        //     delay: 3000,
        //     disableOnInteraction: false,
        // },
        pagination: {
            el: ".promo-brand-outstanding__dot",
            clickable: true,
        },
        navigation: {
            nextEl: ".product-categories__top-banner__carousel__button-next",
            prevEl: ".product-categories__top-banner__carousel__button-prev",
        },

        // breakpoints: {
        //     // when window width is >= 320px
        //     992: {
        //         slidesPerView: 3,
        //         spaceBetween: 16
        //       },

        //     768: {
        //         slidesPerView: 2,
        //         spaceBetween: 16
        //       }
        //   }
    });

    // fitler product
    var boxFilterProductCategories = new Swiper(".box-filter__filter-group-item", {
        // slidesPerView: 7,
        // spaceBetween: 10,
        freeMode: true,
        // pagination: {
        //   el: ".swiper-pagination",
        //   clickable: true,
        // },
    });



    // Preview product
    var productPreviewListImgProduct = new Swiper(".product-preview__list-img-product", {
        slidesPerView: 1,
        slidesPerGroup: 1,
        loop: true,
        loopFillGroupWithBlank: true,
        pagination: {
            el: ".discount-payonl__dot",
            clickable: true,
        },
        navigation: {
            nextEl: ".product-preview__list-img-product__button-next",
            prevEl: ".product-preview__list-img-product__button-pre",
        },
    });

    // Content Product
    // Preview product
    var productPreviewListImgProduct = new Swiper(".product-content__list-img-product", {
        slidesPerView: 1,
        slidesPerGroup: 1,
        loop: true,
        loopFillGroupWithBlank: true,
        pagination: {
            el: ".discount-payonl__dot",
            clickable: true,
        },
        navigation: {
            nextEl: ".product-content__list-img-product__button-next",
            prevEl: ".product-content__list-img-product__button-pre",
        },
    });

    //Hot Deal Carousel
    var swiperHotDeal = new Swiper(".suggestion-product__accessory__swiper", {
        spaceBetween: 16,
        slidesPerGroup: 2,
        freeMode: true,
        navigation: {
            nextEl: ".hot-deal__button-next",
            prevEl: ".hot-deal__button-prev",
        },
        breakpoints: {
            1400: {
                slidesPerView: 5,
                spaceBetween: 16,
                slidesPerGroup: 5,
                loop: true,
            },
            1200: {
                slidesPerView: 4,
                spaceBetween: 24,
                slidesPerGroup: 4,
                loop: true,
            },

            992: {
                slidesPerView: 3,
                spaceBetween: 24,
                slidesPerGroup: 3,
                loop: true,
            },
            768: {
                watchSlidesProgress: true,
                slidesPerView: 2,
                spaceBetween: 24,
                slidesPerGroup: 2,
            },
            567: {
                watchSlidesProgress: true,
                slidesPerView: 2,
                spaceBetween: 24,
                slidesPerGroup: 2,
                loop: true,
                freeMode: false,
            },
        }
    });

    //Hot Deal Carousel
    var swiperHotDeal = new Swiper(".suggestion-product__more__swiper", {
        spaceBetween: 16,
        slidesPerGroup: 2,
        freeMode: true,
        navigation: {
            nextEl: ".suggestion-product__more__button-next",
            prevEl: ".suggestion-product__more__button-prev",
        },
        breakpoints: {
            1400: {
                slidesPerView: 5,
                spaceBetween: 16,
                slidesPerGroup: 5,
                loop: true,
            },
            1200: {
                slidesPerView: 4,
                spaceBetween: 24,
                slidesPerGroup: 4,
                loop: true,
            },

            992: {
                slidesPerView: 3,
                spaceBetween: 24,
                slidesPerGroup: 3,
                loop: true,
            },
            768: {
                watchSlidesProgress: true,
                slidesPerView: 2,
                spaceBetween: 24,
                slidesPerGroup: 2,
            },
            567: {
                watchSlidesProgress: true,
                slidesPerView: 2,
                spaceBetween: 24,
                slidesPerGroup: 2,
                loop: true,
                freeMode: false,
            },
        }
    });






});


// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.service-slider-images').slick({
  infinite: true,
  slidesToShow: 1,
  slidesToScroll: 1,
  arrows:false,

  //prevArrow: '<img src="/content/site/img/icon/left-icon.svg" alt="prev" class="slick-prev"></img>',
  //nextArrow: '<img src="/content/site/img/icon/left-icon.svg"" alt="next" class="slick-next"></img>',

  responsive: [
    {
      breakpoint: 1024,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1,
        infinite: true,
        dots: false,
        //prevArrow: '<img src="/img/icon/Frame-7.svg" alt="prev" class="slick-prev"></img>',
        //nextArrow: '<img src="/img/icon/Frame-6.svg" alt="next" class="slick-next"></img>',

      }
    },
  ]
});4
$('.question').on('click', function () {
  if ($(this).find(".answer").css("display") == ("none")) {
    $(this).find(".answer").css('display', 'block');
    $(this).find(".faq-open").css("display", "none");
    $(this).find(".faq-close").css("display", "block");
    $(this).find(".faq-question").css("color", "#333333");
    $(this).find(".faq-border-add").addClass("faq-border");

  }
  else {
    $(this).find(".answer").css('display', 'none');
    $(this).find(".faq-open").css("display", "block");
    $(this).find(".faq-close").css("display", "none");
    $(this).find(".faq-question").css("color", "rgba(24, 24, 27, 0.50)");
    $(this).find(".faq-border-add").removeClass("faq-border");
  }
});

$('.service-slider-images2').slick({
  infinite: true,
  slidesToShow: 3,
  slidesToScroll: 1,
  arrows:true,
  dots:true,

  prevArrow: '<img src="img-content/site/icon/slider-left-icon.svg" alt="prev" class="slick-prev"></img>',
  nextArrow: '<img src="img-content/site/icon/slider-left-icon.svg" alt="next" class="slick-next"></img>',

  responsive: [
    {
      breakpoint: 1024,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1,
        infinite: true,
        dots: false,
        //prevArrow: '<img src="/img/icon/Frame-7.svg" alt="prev" class="slick-prev"></img>',
        //nextArrow: '<img src="/img/icon/Frame-6.svg" alt="next" class="slick-next"></img>',

      }
    },
  ]
});

$('.multiple-items').slick({
  infinite: false,
  slidesToShow: 1,
  slidesToScroll: 1,
  arrows: false
});

$('.index-card').mouseover(function(){
  console.log("asd");
  $(this).find(".overlay").css('background-color', 'rgba(61, 0, 11, 0.5)');
});
$('.index-card').mouseout(function(){
  console.log("asd");
  $(this).find(".overlay").css('background-color', 'rgba(0, 0, 0, 0.2)');
});

$('.open-dropdown').click(function () {
  console.log('tıkladın');
});

$(document).ready(function(){
  $(".regular").slick({
    dots: true,
    infinite: true,
    slidesToShow: 1,
    slidesToScroll: 1,
    autoplay: true,
    fade: true,
    autoplaySpeed: 8000
  });

  $('.section__detail-img-gm').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: false,
    fade: true,
    asNavFor: '.section__detail-img-pm'
  });
  $('.section__detail-img-pm').slick({
    slidesToShow: 2,
    slidesToScroll: 1,
    asNavFor: '.section__detail-img-gm',
    dots: true,
    centerMode: true,
    focusOnSelect: true
  });
});
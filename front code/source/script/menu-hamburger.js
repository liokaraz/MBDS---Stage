//menu off
$(".btn-menu-cancel").on('click', function() {
  TweenLite.to(".menu-hamburger", 0.5, {left:-1500});
});
//menu on
$(".btn-menu").on('click', function() {
  TweenLite.to(".menu-hamburger", 0.3, {left:0});
});
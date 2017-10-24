$(".js-box-image").on('click', function() {
  $(".popup-video").css({
    display: 'block'
  })
  $(".popup-background").css({
    display: 'block',
    opacity: '0.7'
  })
})
$(".popup-background").on('click', function() {
   $(".popup-background").css({
    display: 'none',
    opacity: '0'
  })
  $(".popup-video").css({
    display: 'none'
  })

})
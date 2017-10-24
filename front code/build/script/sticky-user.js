var stickyState = 0;
$(".header-user").on('click', function() {
  if (stickyState == 1) {
    stickyState = 0;
    TweenMax.fromTo(".header-user-menu", 0.3, 
      {
        display: "block", 
        opacity: 1,
        top: "145px"
      },
      {
        display:"none",
        opacity:0,
        top: "112px"
      }
    );
    return null;
  }
  if (stickyState == 0) {
    stickyState = 1;
    TweenMax.fromTo(".header-user-menu", 0.3, 
      {
        display: "none", 
        opacity: 0,
        top: "112px"
      },
      {
        display:"block",
        opacity:1,
        top: "145px"
      }
    );
  }
  return null;
});
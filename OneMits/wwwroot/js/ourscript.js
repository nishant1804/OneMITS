$(document).ready(function() {

  // required elements
  var imgPopup = $('.img-popup');
  var imgCont  = $('.ls-izmir');
  var popupImage = $('.img-popup img');
  var closeBtn = $('.close-btn');

  // handle events
  imgCont.on('click', function() {
    var img_src = $(this).children('img').attr('src');
    imgPopup.children('img').attr('src', img_src);
    imgPopup.addClass('opened');
  });

  $(imgPopup, closeBtn).on('click', function() {
    imgPopup.removeClass('opened');
    imgPopup.children('img').attr('src', '');
  });

  popupImage.on('click', function(e) {
    e.stopPropagation();
  });
  
});



/* Demo purposes only */
var snippet = [].slice.call(document.querySelectorAll('.hover'));
if (snippet.length) {
  snippet.forEach(function (snippet) {
    snippet.addEventListener('mouseout', function (event) {
      if (event.target.parentNode.tagName === 'figure') {
        event.target.parentNode.classList.remove('hover')
      } else {
        event.target.parentNode.classList.remove('hover')
      }
    });
  });
}


























(function($) { "use strict";
    
  //Page arrs

    document.getElementsByTagName("body")[0].addEventListener("mousemove", function(n) {
        t.style.left = n.clientX + "px", 
    t.style.top = n.clientY + "px", 
    e.style.left = n.clientX + "px", 
    e.style.top = n.clientY + "px", 
    i.style.left = n.clientX + "px", 
    i.style.top = n.clientY + "px"
    });
    var t = document.getElementById("arr"),
        e = document.getElementById("arr2"),
        i = document.getElementById("arr3");
    function n(t) {
        e.classList.add("hover"), i.classList.add("hover")
    }
    function s(t) {
        e.classList.remove("hover"), i.classList.remove("hover")
    }
    s();
    for (var r = document.querySelectorAll(".hover-target"), a = r.length - 1; a >= 0; a--) {
        o(r[a])
    }
    function o(t) {
        t.addEventListener("mouseover", n), t.addEventListener("mouseout", s)
    }
  
  $(document).ready(function() {
    
    /* Hero Case blur images */     
    
    $('.blur-name:nth-child(1)').on('mouseenter', function() {
      $('.blur-name.active').removeClass('active');
      $('.blur-images li.show').removeClass("show");
      $('.blur-images li:nth-child(1)').addClass("show");
      $('.blur-name:nth-child(1)').addClass('active');
    })
    $('.blur-name:nth-child(2)').on('mouseenter', function() {
      $('.blur-name.active').removeClass('active');
      $('.blur-images li.show').removeClass("show");
      $('.blur-images li:nth-child(2)').addClass("show");
      $('.blur-name:nth-child(2)').addClass('active');
    })
    $('.blur-name:nth-child(3)').on('mouseenter', function() {
      $('.blur-name.active').removeClass('active');
      $('.blur-images li.show').removeClass("show");
      $('.blur-images li:nth-child(3)').addClass("show");
      $('.blur-name:nth-child(3)').addClass('active');
    })
    $('.blur-name:nth-child(4)').on('mouseenter', function() {
      $('.blur-name.active').removeClass('active');
      $('.blur-images li.show').removeClass("show");
      $('.blur-images li:nth-child(4)').addClass("show");
      $('.blur-name:nth-child(4)').addClass('active');
    })
    $('.blur-name:nth-child(1)').trigger('mouseenter')   
   });  

  
  //Switch dark/light
  
  $("#switch").on('click', function () {
    if ($("body").hasClass("light")) {
      $("body").removeClass("light");
      $("#switch").removeClass("switched");
    }
    else {
      $("body").addClass("light");
      $("#switch").addClass("switched");
    }
  });   
  
  
  })(jQuery);
















  
(function( $ ) {      "use strict";   
  $(function() {
      $('a[href*="#"]:not([href="#"])').click(function() {
            if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
              var target = $(this.hash);
              target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
              if (target.length) {
                $('html, body').animate({
                  scrollTop: target.offset().top
                }, 1000);
                return false;
              }
            }
        });
  });   
}(jQuery));
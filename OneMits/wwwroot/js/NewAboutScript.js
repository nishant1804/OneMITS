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


















(function($) {
  
  function initTurnCss() {
    var css = "@-webkit-keyframes circTxt--rotating{from{transform-origin:center;-webkit-transform:rotate(0);-o-transform:rotate(0);transform:rotate(0)}to{transform-origin:center;-webkit-transform:rotate(360deg);-o-transform:rotate(360deg);transform:rotate(360deg)}}",
      head = document.head || document.getElementsByTagName("head")[0],
      style = document.createElement("style");

    head.appendChild(style);

    style.type = "text/css";
    if (style.styleSheet) {
      // This is required for IE8 and below.
      style.styleSheet.cssText = css;
    } else {
      style.appendChild(document.createTextNode(css));
    }
  }

  function createCircularText(txt, radius, classIndex) {
    (txt = txt.split("")), (classIndex = classIndex[0]);
    //classIndex = $('.circTxt')[0];
    var deg = 360 / txt.length,
      origin = 0;
    txt.forEach(ea => {
      ea = `<p style='height:${radius}px;width:${radius}px;text-align:center;position:absolute;transform:rotate(${origin}deg);transform-origin:bottom center'>${ea}</p>`;
      classIndex.innerHTML += ea;
      origin += deg;
    });
  }

  $.fn.circleText = function(parameters = {}) {
    $(this).each(function() {
      var paramsdefault = {
        padding: 144,
        glue: "",
        turn: false,
        duration: 10,
        repeat: 1,
        radius: 100,
        background: "",
        rounded: true,
        reverse: false,
      };

      var params = {
        padding:
          "padding" in parameters ? parameters.padding : paramsdefault.padding,
        glue: "glue" in parameters ? parameters.glue : paramsdefault.glue,
        turn: "turn" in parameters ? parameters.turn : paramsdefault.turn,
        duration:
          "duration" in parameters ? parameters.duration : paramsdefault.duration,
        repeat: "repeat" in parameters ? parameters.repeat : paramsdefault.repeat,
        radius: "radius" in parameters ? parameters.radius : paramsdefault.radius,
        background:
          "background" in parameters
            ? parameters.background
            : paramsdefault.background,
        rounded:
          "rounded" in parameters ? parameters.rounded : paramsdefault.rounded,
        content:
          "content" in parameters ? parameters.content : paramsdefault.content,
          reverse:
          "reverse" in parameters ? parameters.reverse : paramsdefault.reverse
      };

      //set the content
      var content;
            if (params.content) {
                //if !empty params.content -> set the content as content + glue
                content = params.content + params.glue;
            } else if ($(this).text().length > 0) {
                //if empty params.content -> set the content as innerhtml + glue
                content = $(this).html() + params.glue;
            } else {
                content = "You forgot to include content ❤";
            }
      //erase the html to create all chars after
      $(this).html("");

      //create the circular text
      createCircularText(content.repeat(params.repeat), params.radius, $(this));

      //set css for the container
      $(this).css({
        height: params.radius * 2 + params.padding * 2,
        width: params.radius * 2 + params.padding * 2,
        display: "flex",
        "justify-content": "center",
        padding: params.padding,
        background: params.background,
        "border-radius": params.rounded ? "50%" : ""
      });

      //set the
      if (params.turn === true) {
        initTurnCss();
        var animation_direction = (params.reverse) ? 'reverse' : 'normal'
        var animation = `circTxt--rotating ${params.duration}s linear infinite ${animation_direction}`;
        $(this).css({
          "transform-origin": "center",
          animation: animation
        });
      }
    });
  };
})(jQuery);
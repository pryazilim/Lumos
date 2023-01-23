
$(document).ready(function () {
  $("select").niceSelect();
});

$(document).ready(function () {
  var table = $('#example').DataTable({
    "lengthChange": false,
    "language": {
      "infoEmpty": "No entries to show",
      "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json",
      "paginate": {
        "previous": "<",
        "next": ">"
      },
    },
  });
  $("#mySearchText1").on('input', function () {
    table.search($('#mySearchText1').val()).draw();
  });
  $("input[type='search']").on('input', function () {
    table.columns([1]).search($('#mySearchText').val()).draw();
  });

  $(document).on("click", ".optionSelectFilter .option", function () {
    var val = $(this).data("value");
    $('#filterType').val(val);
    table.columns([2]).search($('#filterType').val()).draw();
  });
  $("#refresh").click(function () {
    window.location.reload();
  });
});

$.extend(true, $.fn.dataTable.defaults, {
  "searching": true,
  "ordering": false
});

$(".login_content input").keypress(function (e) {
  if (e.keyCode == 13) {
    Login();
  }
});
function myFunction() {
  var img = document.getElementById("imgCloseEye").src;
  var x = document.getElementById("myPassword");
  if (x.type === "password") {
    x.type = "text";
    document.getElementById("imgCloseEye").src = "/img/icon/Eye.svg"
  } else {
    x.type = "password";
    document.getElementById("imgCloseEye").src = "/img/icon/Eye-slash.svg"
  }
}

$('.textarea').keyup(function () {
  var characterCount = $(this).val().length,
    current = $('#current'),
    maximum = $('#maximum'),
    theCount = $('#the-count');

  current.text(characterCount);
  /*This isn't entirely necessary, just playin around*/
  if (characterCount == 200) {
    maximum.css('color', '#E31A1A');
    current.css('color', '#E31A1A');
    theCount.css('font-weight', 'bold');
  }
  else {
    maximum.css('color', '#6c757d');
    current.css('color', '#6c757d');
    theCount.css('font-weight', '400');
  }
});

$(".open-left-bar").click(function () {
  if ($(".sidebar-left").css("display") == ("none")) {
    $(".closebutton").css("display", "block");
    $(".openbutton").css("display", "none");
    $(".sidebar-left").css("display", "block");

    $(".sidebar-right").css("display", "none");
    $(".userclose").css("display", "none");
    $(".useropen").css("display", "block");
  }
  else {
    $(".closebutton").css("display", "none");
    $(".openbutton").css("display", "block");
    $(".sidebar-left").css("display", "none");
  }
});
$(".open-right-bar").click(function () {
  if ($(".sidebar-right").css("display") == ("none")) {
    $(".userclose").css("display", "block");
    $(".useropen").css("display", "none");
    $(".sidebar-right").css("display", "block");

    $(".sidebar-left").css("display", "none");
    $(".closebutton").css("display", "none");
    $(".openbutton").css("display", "block");
  }
  else {
    $(".userclose").css("display", "none");
    $(".useropen").css("display", "block");
    $(".sidebar-right").css("display", "none");
  }
});
$(".openUserDropDown").click(function () {
  if ($(".userDropDown").css("display") == ("none")) {
    $(".userDropDown").css("display", "grid");
    $(".overlaypage").css("display", "block");
    $(".sabitDropDown").css("display", "none");
    $("body").css("overflow", "hidden");
  }
  else {
    $(".userDropDown").css("display", "none");
    $(".overlaypage").css("display", "none");
    $("body").css("overflow", "scroll");
  }
});
$(".openSabitDropDown").click(function () {
  if ($(".sabitDropDown").css("display") == ("none")) {
    $(".sabitDropDown").css("display", "none");
    $(this).find(".sabitDropDown").css("display", "grid");
    $(".userDropDown").css("display", "none");
    $(".overlaypage").css("display", "block");
    $("body").css("overflow", "hidden");

  }
  else {
    $(".sabitDropDown").css("display", "none");
    $(this).find(".sabitDropDown").css("display", "none");
    $(".overlaypage").css("display", "none");
    $("body").css("overflow", "scroll");
  }
});
$(".overlaypage").click(function () {
  if ($(".overlaypage").css("display") == ("block")) {
    $(".userDropDown").css("display", "none");
    $(".sabitDropDown").css("display", "none");
    $(".overlaypage").css("display", "none");
    $(".alertCard").css("display", "none");
    $("body").css("overflow", "scroll");
  }
});
$(".filtre").click(function () {
  if ($(".filtre-container").css("display") == ("none")) {
    $(".filtre-white").css("display", "none");
    $(".filtre-black").css("display", "block");
    $(".filtre-container").css("display", "flex");
  }
  else {
    $(".filtre-white").css("display", "block");
    $(".filtre-black").css("display", "none");
    $(".filtre-container").css("display", "none");
  }
});
$("#type1").on('click', function () {
  $("div, h2").removeClass("active-border text-dark")
  $("#type1 div").removeClass("opacitys")
  $("#type1").find("div").addClass("active-border")
  $("#type1").find("h2").addClass("text-dark")
  $("#type2").find("div").addClass("opacitys")
  $("#type3").find("div").addClass("opacitys")
  $("#type4").find("div").addClass("opacitys")
  $("#type2Description").css("display", "grid")
  $("#type3ButtonTitle").css("display", "flex")
  $("#type4Title").css("display", "grid")
  $(".type-3-none").css("display", "block")
  $(function () {
    var target = $("#scroll");
    target = target.length ? target : $('[name=' + this.hash.substr(1) + ']');
    if (target.length) {
      $('html,body').animate({
        scrollTop: target.offset().top
      }, 500);
      return false;
    }
  });
});
$("#type2").on('click', function () {
  $("div, h2").removeClass("active-border text-dark")
  $("#type2 div").removeClass("opacitys")
  $("#type2").find("div").addClass("active-border ")
  $("#type2").find("h2").addClass(" text-dark")
  $("#type1").find("div").addClass("opacitys")
  $("#type3").find("div").addClass("opacitys")
  $("#type4").find("div").addClass("opacitys")
  $("#type2Description").css("display", "grid")
  $("#type3ButtonTitle").css("display", "flex")
  $("#type4Title").css("display", "grid")
  $(".type-3-none").css("display", "block")
  $(function () {
    var target = $("#scroll");
    target = target.length ? target : $('[name=' + this.hash.substr(1) + ']');
    if (target.length) {
      $('html,body').animate({
        scrollTop: target.offset().top
      }, 500);
      return false;
    }
  });
});
$("#type3").on('click', function () {
  $("div, h2").removeClass("active-border text-dark")
  $("#type3 div").removeClass("opacitys")
  $("#type3").find("div").addClass("active-border")
  $("#type3").find("h2").addClass("text-dark")
  $("#type1").find("div").addClass("opacitys")
  $("#type2").find("div").addClass("opacitys")
  $("#type4").find("div").addClass("opacitys")
  $("#type2Description").css("display", "grid")
  $("#type3ButtonTitle").css("display", "flex")
  $("#type4Title").css("display", "grid")
  $(".type-3-none").css("display", "none")
  $(function () {
    var target = $("#scroll");
    target = target.length ? target : $('[name=' + this.hash.substr(1) + ']');
    if (target.length) {
      $('html,body').animate({
        scrollTop: target.offset().top
      }, 500);
      return false;
    }
  });
});
$("#type4").on('click', function () {
  $("div, h2").removeClass("active-border text-dark")
  $("#type4 div").removeClass("opacitys")
  $("#type4").find("div").addClass("active-border")
  $("#type4").find("h2").addClass("text-dark")
  $("#type1").find("div").addClass("opacitys")
  $("#type2").find("div").addClass("opacitys")
  $("#type3").find("div").addClass("opacitys")
  $("#type2Description").css("display", "none")
  $("#type3ButtonTitle").css("display", "none")
  $("#type4Title").css("display", "none")
  $(function () {
    var target = $("#scroll");
    target = target.length ? target : $('[name=' + this.hash.substr(1) + ']');
    if (target.length) {
      $('html,body').animate({
        scrollTop: target.offset().top
      }, 500);
      return false;
    }
  });
});

$(".alertCardOpen").click(function () {
  if ($(".alertCard").css("display") == ("none")) {
    $(".alertCard").css("display", "block")
    $(".alertOverlay").css("display", "block")
  }
})
$(".closeAlertCard").click(function () {
  if ($(".alertCard").css("display") == ("block")) {
    $(".alertCard").css("display", "none")
    $(".alertOverlay").css("display", "none")
  }
})
$(".succesCardOpen").click(function () {
  if ($(".succesCard").css("margin-right") == ("-450px")) {
    $(".succesCard").animate({ "margin-right": "15px" }
      , {
        complete: function () {
          $(".succesCard").delay(3000).animate({ "margin-right": "-450px" });
          $('.alertOverlay')
            .delay(3000)
            .queue(function (next) {
              $(this).css('display', 'none');
              next();

            });
          $(document)
            .delay(3300)
            .queue(function (next) {
              window.location.href = "/sliderList.html";
              next();
            });
        }
      });
    $(".alertOverlay").css("display", "block")
  }
})
$(".succesCardOpen1").click(function () {
  if ($(".succesCard").css("margin-right") == ("-450px")) {
    $(".succesCard").animate({ "margin-right": "15px" }
      , {
        complete: function () {
          $(".succesCard").delay(3000).animate({ "margin-right": "-450px" });
          $('.alertOverlay')
            .delay(3000)
            .queue(function (next) {
              $(this).css('display', 'none');
              next();

            });
          $(document)
            .delay(3300)
            .queue(function (next) {
              window.location.href = "/sabit.html";
              next();
            });
        }
      });
    $(".alertOverlay").css("display", "block")
  }
})

$(".returnPage").click(function () {
  var referrer = document.referrer;
  window.location.href = referrer;
});
$(".closeCategorieSidebar").click(function () {
  $(".CategorySidebarAdd").animate({ right: '-912px' });
  $(".overlaypage1").css("display", "none");
  $("body").css("overflow-y", " scroll");
});
$(".AddCardOpen").click(function () {
  $(".CategorySidebarAdd").animate({ right: '0px' });
  $(".overlaypage1").css("display", "block");
  $("body").css("overflow-y", " hidden");
});
$(".PrFillUpdateForm").click(function () {
  $(".CategorySidebarAdd").animate({ right: '0px' });
  $(".overlaypage1").css("display", "block");
});


$(document).on("click", "#categoryselect", function () {
  var val = $(this).data("categoryid1");
  console.log(val);
  if (val > 0) {
    setTimeout(function () {
      $(".underCategorie").css("display", "grid");
      $("#categoryid1").niceSelect("update");
    }, 500);
  }
  else {
    $(".underCategorie").css("display", "none");
  }
});

$(document).on("click", "#categoryselect", function () {
  var val = $(this).data("type1");
  console.log(val);
  if (val > 0) {
    setTimeout(function () {
      $("#type1").niceSelect("update");
    }, 500);
  }
});

//CategorySelectorOpen
$("#CategoryHave").click(function () {
  if ($("#CategoryOption").css("display") == ("none")) {
    $("#CategoryOption").css("display", "block")
  }
})
$("#CategoryNone").click(function () {
  if ($("#CategoryOption").css("display") == ("block")) {
    $("#CategoryOption").css("display", "none")
  }
})

//GalleryConentAdd
$(".contentAdd").click(function () {
  if ($(".contentDelete").css("display") == ("none")) {
    $(".contentDelete").css("display", "block");
    $(".GalleryListContainer").css("display", "flex");
    $(".contentAdd").css("display", "none");
  }
});
$(".contentDelete").click(function () {
  if ($(".contentAdd").css("display") == ("none")) {
    $(".contentAdd").css("display", "block");
    $(".GalleryListContainer").css("display", "none");
    $(".contentDelete").css("display", "none");
  }
});
$(document).ready(function () {
  var val = $("#galleryIds").val();
  if (val > 0) {
    setTimeout(function () {
      $(".GalleryListContainer").css("display", "flex");
      $(".contentDelete").css("display", "block");
      $(".contentAdd").css("display", "none");
    }, 200);
  }
  else {
    $(".GalleryListContainer").css("display", "none");
    $(".contentAdd").css("display", "block");
    $(".contentDelete").css("display", "none");
  }
});
//ProductConentAdd
$(".contentProductAdd").click(function () {
  if ($(".contentProductDelete").css("display") == ("none")) {
    $(".contentProductDelete").css("display", "block");
    $(".ProductListContainer").css("display", "flex");
    $(".contentProductAdd").css("display", "none");
  }
});
$(".contentProductDelete").click(function () {
  if ($(".contentProductAdd").css("display") == ("none")) {
    $(".contentProductAdd").css("display", "block");
    $(".ProductListContainer").css("display", "none");
    $(".contentProductDelete").css("display", "none");
  }
});
$(document).ready(function () {
  var val = $("#productIds").val();
  if (val > 0) {
    setTimeout(function () {
      $(".ProductListContainer").css("display", "flex");
      $(".contentProductDelete").css("display", "block");
      $(".contentProductAdd").css("display", "none");
    }, 200);
  }
  else {
    $(".ProductListContainer").css("display", "none");
    $(".contentProductAdd").css("display", "block");
    $(".contentProductDelete").css("display", "none");
  }
});
//ProductPropertyContentAdd
$(".contentProductPropertyAdd").click(function () {
  if ($(".contentProductPropertyDelete").css("display") == ("none")) {
    $(".contentProductPropertyDelete").css("display", "block");
    $(".ProductPropertyListContainer").css("display", "flex");
    $(".contentProductPropertyAdd").css("display", "none");
  }
});
$(".contentProductPropertyDelete").click(function () {
  if ($(".contentProductPropertyAdd").css("display") == ("none")) {
    $(".contentProductPropertyAdd").css("display", "block");
    $(".ProductPropertyListContainer").css("display", "none");
    $(".contentProductPropertyDelete").css("display", "none");
  }
});
$(document).ready(function () {
  var val = $("#productPropertyIds").val();
  if (val > 0) {
    setTimeout(function () {
      $(".ProductPropertyListContainer").css("display", "flex");
      $(".contentProductPropertyDelete").css("display", "block");
      $(".contentProductPropertyAdd").css("display", "none");
    }, 200);
  }
  else {
    $(".ProductPropertyListContainer").css("display", "none");
    $(".contentProductPropertyAdd").css("display", "block");
    $(".contentProductPropertyDelete").css("display", "none");
  }
});
//VideoContentAdd
$(".contentVideoAdd").click(function () {
  if ($(".contentVideoDelete").css("display") == ("none")) {
    $(".contentVideoDelete").css("display", "block");
    $(".VideoContainer").css("display", "block");
    $(".contentVideoAdd").css("display", "none");

  }
});
$(".contentVideoDelete").click(function () {
  if ($(".contentVideoAdd").css("display") == ("none")) {
    $(".contentVideoAdd").css("display", "block");
    $(".VideoContainer").css("display", "none");
    $(".contentVideoDelete").css("display", "none");
  }
});
//TableContentAdd
$(".contentTableAdd").click(function () {
  if ($(".contentTableDelete").css("display") == ("none")) {
    $(".contentTableDelete").css("display", "block");
    $(".TableContainer").css("display", "block");
    $(".contentTableAdd").css("display", "none");
  }
});
$(".contentTableDelete").click(function () {
  if ($(".contentTableAdd").css("display") == ("none")) {
    $(".contentTableAdd").css("display", "block");
    $(".TableContainer").css("display", "none");
    $(".contentTableDelete").css("display", "none");
  }
});
$(".linkGoWeb").on('click', function () {
  $(".overlaypage").css("display", "none");
  $(".userDropDown ").css("display", "none");

});
// Galllery
$(".galleryImg").hover(function () {
  if ($(this).find(".ImgOverlay").css("display") == ("none")) {
    $(this).find(".ImgOverlay").css("display", "block");
  }
  else {
    $(".ImgOverlay").css("display", "none");
  }
});
//CategoryServiceControl
$(document).ready(function () {
  var val = $("#categoryIdServices").val();
  if (val > 0) {
    setTimeout(function () {
      $("#CategoryOption").css("display", "block");
      $('#CategoryHave').prop('checked', true);
    }, 200);
  }
  else {
    $("#CategoryOption").css("display", "none");
    $('#CategoryNone').prop('checked', false);
  }
});
$(document).ready(function () {
  $(".checked").prop('checked', true);
});
$(document).ready(function () {
  var val = $(".Typehave").val();
  if (val == 1) {
    setTimeout(function () {
      $("div, h2").removeClass("active-border text-dark");
      $("#type1 div").removeClass("opacitys");
      $("#type1").find("div").addClass("active-border ");
      $("#type1").find("h2").addClass(" text-dark");
      $("#type2Description").css("display", "grid");
      $("#type3ButtonTitle").css("display", "flex");
      $("#type4Title").css("display", "grid");
      $(".type-3-none").css("display", "block")
    }, 200);
  }
  if (val == 2) {
    setTimeout(function () {
      $("div, h2").removeClass("active-border text-dark")
      $("#type2 div").removeClass("opacitys");
      $("#type2").find("div").addClass("active-border ");
      $("#type2").find("h2").addClass(" text-dark");
      $("#type2Description").css("display", "grid");
      $("#type3ButtonTitle").css("display", "flex");
      $("#type4Title").css("display", "grid");
      $(".type-3-none").css("display", "block")
    }, 200);
  }
  if (val == 3) {
    setTimeout(function () {
      $("div, h2").removeClass("active-border text-dark")
      $("#type3 div").removeClass("opacitys");
      $("#type3").find("div").addClass("active-border ");
      $("#type3").find("h2").addClass(" text-dark");
      $("#type2Description").css("display", "grid");
      $("#type3ButtonTitle").css("display", "flex");
      $("#type4Title").css("display", "grid");
      $(".type-3-none").css("display", "none")
    }, 200);
  }
  //if (val == 4) {
  //    setTimeout(function () {
  //        $("div, h2").removeClass("active-border text-dark")
  //        $("#type4 div").removeClass("opacitys");
  //        $("#type4").find("div").addClass("active-border ");
  //        $("#type4").find("h2").addClass(" text-dark");
  //        $("#type2Description").css("display", "none");
  //        $("#type3ButtonTitle").css("display", "none");
  //        $("#type4Title").css("display", "none");
  //    }, 200);
  //}
});

jQuery.cachedScript = function (url, options) {
  options = $.extend(options || {}, {
      dataType: "script",
      type: "GET",
      cache: true,
      url: url
  });
  return jQuery.ajax(options);
};

function ckEditor_init() {
  if ($('[type=ckeditor]').length > 0) {
      $.when(
          LibrarySources.CkEditor.JS.Load(),
          $.Deferred(function (deferred) {
              $(deferred.resolve);
          })
      ).done(function () {
          $('[type=ckeditor]').each(function (index, e) {
              $(e).hide();
          });

          $('[type=ckeditor]').each(function (index, e) {
              if (typeof ($(e).attr('id')) != "undefined") {
                  CKEDITOR.replace($(e).attr('id'));
                  CKEDITOR.instances[$(e).attr('id')].setData($(e).val());
              }
              $(e).fadeIn(300);
          });

      });
  }
}
function dataTable_init() {
  if ($('[type=datatable]').length > 0) {
      $.when(
          LibrarySources.DataTable.JS.Load(),
          LibrarySources.DataTable.CSS.Load(),

          $.Deferred(function (deferred) {
              $(deferred.resolve);
          })
      ).done(function () {
          $('[type=datatable]').each(function (index, e) {

              var self = $(e);
              var attrOpt = self.attr('opt');
              var DblClickEvent = self.attr('pr-dblclick');
              var ClickEvent = self.attr('pr-click');
              var itemId = self.attr('id');

              if (typeof (itemId) == "undefined") {
                  itemId = randomNameGenerate();
                  self.attr('id', itemId);
              }

              var options = {
                  responsive: true,
                  "language": {
                      "url": "//cdn.datatables.net/plug-ins/1.10.7/i18n/Turkish.json"
                  }
              };

              if (IsNull(attrOpt) == false) {
                  try {
                      options = $.extend(options, JSON.parse(attrOpt));
                  } catch (e) {
                      options = {
                          "language": {
                              "url": "//cdn.datatables.net/plug-ins/1.10.7/i18n/Turkish.json"
                          },
                      };
                  }
              }

              window["dt" + itemId] = $(e).dataTable(options);

              if (IsNull(DblClickEvent) == false) {
                  $(e).find('tbody').on('dblclick', 'tr', function () {
                      var that = $(this);
                      var data = window["dt" + that.attr("id")].DataTable();
                      var test = data.row(this).data();
                      executeFunctionByName(DblClickEvent, window, data.row(this).data());
                  });
              }

          });
      });
  }
}

function SourceBase(srcVal) {
  var obj = {
      src: srcVal,
      Load: function () {
          var dfd = jQuery.Deferred();
          var that = this;

          var extension = that.src.split('.');
          if (extension[extension.length - 1] == "js") {
              $.cachedScript(that.src).done(function (e) {
                  dfd.resolve();
              });
          } else if (extension[extension.length - 1] == "css") {
              var cssFile = document.createElement('link');
              cssFile.href = that.src;
              cssFile.type = "text/css"
              cssFile.rel = "stylesheet";
              document.head.appendChild(cssFile);
              dfd.resolve();
          }
          return dfd.promise();
      },
      Loaded: false
  };

  return obj;
}
var LibrarySources = {

  DataTable: {
      JS: SourceBase("/Content/Admin/plugins/jquery-datatable/datatables.min.js"),
      CSS: SourceBase("/Content/Admin/plugins/jquery-datatable/datatables.min.css")
  },

  CkEditor: {
      JS: SourceBase("//cdn.ckeditor.com/4.5.10/standard/ckeditor.js")
  }

};

// init
$(function () {

  ckEditor_init();

  dataTable_init();

  setEvents();
});

function setEvents() {
  $("input[type=file]").on('change', function (e) {
      var tempReviewid = $(this).attr("pr-reviewid");
      if (typeof (tempReviewid) != "undefined") {
          var files = $(this).get(0).files;
          if (files.length > 0) {
              if (typeof (FileReader) != "undefined") {
                  var fileName = files.name;
                  var tmppath = URL.createObjectURL(e.target.files[0]);
                  $("#" + tempReviewid).attr('src', tmppath);
              }
          }
      }
  });

  $("[onlynumber]").on('keypress', function (e) {
      var limit = $(this).attr("onlynumber");
      var theEvent = e || window.event;
      var key = theEvent.keyCode || theEvent.which;
      key = String.fromCharCode(key);
      var regex = /[0-9]/;
      if (typeof (limit) == "undefined" || limit == "") {
          if (!regex.test(key)) {
              theEvent.returnValue = false;
              if (theEvent.preventDefault) theEvent.preventDefault();
          }
      }
      else {
          if (limit < ($(this).val().length + 1)) {
              theEvent.returnValue = false;
              if (theEvent.preventDefault) theEvent.preventDefault();
          } else if (!regex.test(key)) {
              theEvent.returnValue = false;
              if (theEvent.preventDefault) theEvent.preventDefault();
          }
      }
  });

  $('.PrPost').on('click', function () {
      $('.PrPost').attr('disabled');
      var self = $(this);
      var _containerSelector = "div.x_panel";
      var _refreshAfterSuccess = false;
      var _url = self.attr("pr-url");
      var _successFunction = self.attr('pr-onsuccess');
      var _successMessage = "İşlem Başarılı";

      if (typeof (_url) == "undefined")
          throw "Url Bulunamadı";

      if (typeof (self.parents(_containerSelector).find('[pr-name]')) == "undefined")
          throw "Gönderilecek Veri Bulunamadı";

      if (typeof (self.attr("pr-parent-selector")) != "undefined")
          _containerSelector = self.attr("pr-parent-selector");

      if (typeof (self.attr("pr-refresh")) != "undefined") {
          var refreshVal = self.attr("pr-refresh");
          if (refreshVal == "true")
              _refreshAfterSuccess = true;
          else
              _refreshAfterSuccess = false;
      }


      if (typeof (self.attr("pr-success-message")) != "undefined")
          _successMessage = self.attr("pr-success-message");

      if (typeof (self.attr("pr-sendtype")) != "undefined" && self.attr("pr-sendtype") == "formdata") {
          var _formData = new FormData();
          self.parents(_containerSelector).find('[pr-name]').each(function (index, e) {
              var eval = collectDataFromElement(e);
              if (IsNull(eval) == false)
                  _formData.append($(e).attr("pr-name"), eval);

          });
          var _requireObj = checkRequires(self.parents(_containerSelector));
          if (_requireObj.Success)
              Post(_formData, _url, _successMessage, _refreshAfterSuccess, _successFunction);
          else
              swal("Eksik Bilgi", _requireObj.Message, "error");
      }
      else {
          var data = {};
          self.parents(_containerSelector).find('[pr-name]').each(function (index, e) {

              var eval = collectDataFromElement(e);
              if (IsNull(eval) == false)
                  data[$(e).attr("pr-name")] = eval;

          });
          PostJson(data, _url, _successMessage, _refreshAfterSuccess, _successFunction);
      }
      $('.PrPost').removeAttr('disabled');
  });

  $('.PrResetForm').on('click', function () {
      var self = $(this);
      var _containerSelector = "";

      if (typeof (self.attr("pr-parent-selector")) != "undefined")
          _containerSelector = self.attr("pr-parent-selector");
      else
          throw "Parent selector Bulunamadı";

      self.parents(_containerSelector).find('[pr-name]').each(function (index, e) {
          if ($(e).attr('type') == "text" || $(e).attr('type') == "hidden" || $(e).attr('type') == "password") {
              $(e).val("");
          }
          else if ($(e).attr('type') == "checkbox") {
              $(e).prop('checked', false);
          }
          else if ($(e).attr('type') == "file") {
              $(e).val("");
          }
          else if ($(e).attr('type') == "ckeditor") {
              CKEDITOR.instances[$(e).attr('id')].setData("");
          }

          if ($(e).parent().find('label').length > 0)
              $(e).parent().removeClass("focused");
      });

  });

  $(document).on('click', ".PrRemoveBtn", function () {
      $('.PrRemoveBtn').attr('disabled');
      var self = $(this);
      var _url = self.attr("pr-url");
      var _successMessage = "Silme işlemi başarılı";
      var _successFunction = self.attr('pr-onsuccess');
      var _refreshAfterSuccess = false;
      var _questionMessage = "Silme işlemini onaylıyor musunuz?"

      if (typeof (_url) == "undefined")
          throw "Url Bulunamadı";

      if (typeof (self.attr("pr-id")) == "undefined")
          throw "Id Bulunamadı";

      if (typeof (self.attr("pr-refresh")) != "undefined") {
          var refreshVal = self.attr("pr-refresh");
          if (refreshVal == "true")
              _refreshAfterSuccess = true;
          else
              _refreshAfterSuccess = false;
      }

      if (typeof (self.attr("pr-success-message")) != "undefined")
          _successMessage = self.attr("pr-success-message");

      if (typeof (self.attr("pr-question-message")) != "undefined")
          _questionMessage = self.attr("pr-question-message");

      swal({
          title: "Emin Misiniz?",
          text: _questionMessage,
          type: "warning",
          showCancelButton: true,
          cancelButtonText: "İptal",
          confirmButtonColor: "#DD6B55",
          confirmButtonText: "Sil!",
          closeOnConfirm: false
      },
          function () {
              var _data = { 'id': self.attr("pr-id") }
              PostJson(_data, _url, _successMessage, _refreshAfterSuccess, _successFunction);
          });
      $('.PrRemoveBtn').removeAttr('disabled');
  });

  $('.PrUpdateOrderNo').on('click', function () {
      var self = $(this);
      var _url = self.attr("pr-url");
      var _successMessage = "Sıralama Güncellendi";
      var _successFunction = self.attr('pr-onsuccess');
      var _refreshAfterSuccess = false;
      var data = {};

      if (typeof (_url) == "undefined")
          throw "Url Bulunamadı";

      if (typeof (self.attr("pr-id")) == "undefined")
          throw "Id Bulunamadı";


      if (typeof (self.attr("pr-refresh")) != "undefined") {
          var refreshVal = self.attr("pr-refresh");
          if (refreshVal == "true")
              _refreshAfterSuccess = true;
          else
              _refreshAfterSuccess = false;
      }


      self.parents('td').find('input[type=text]').each(function (index, e) {
          data.id = self.attr("pr-id");
          data.OrderNo = $(e).val();

          PostJson(data, _url, _successMessage, _refreshAfterSuccess, _successFunction);
      });
  });

  $(document).on('click', ".PrFillUpdateForm", function () {
      var self = $(this);
      self.each(function () {
          $.each(this.attributes, function () {
              if (this.specified) {
                  if (this.name.match("^prtext")) {
                      $('#' + this.name.split('-')[1]).val(this.value).change();
                  } else if (this.name.match("^prselect")) {
                      $('#' + this.name.split('-')[1]).val(this.value).change();
                  } else if (this.name.match("^primage")) {
                      $('#' + this.name.split('-')[1]).attr('src', this.value);
                  } else if (this.name.match("^prckeditor")) {
                      CKEDITOR.instances[this.name.split('-')[1]].setData(this.value);
                  } else if (this.name.match("^prcheckbox")) {
                      var _val = false;
                      if (this.value == "true" || this.value == "True")
                          _val = true;
                      $('#' + this.name.split('-')[1]).prop('checked', _val);
                  }
                  else if (this.name.match("^prradio")) {
                      $('input[name="' + this.name.split('-')[1] + '"][value=' + this.value + ']').prop('checked', true);
                  }
                  if ($('#' + this.name.split('-')[1]).parent().find('label').length > 0)
                      $('#' + this.name.split('-')[1]).parent().addClass("focused");
              }
          });
      });
      var _moneyControl = $(this).hasClass('GoToTop');
      if (_moneyControl) {
          $(".Money2").focus();
      }
      else {
          $(".Money").focus();
      }
  });
}

function resetEvents() {
  $("input[type=file]").unbind('change');
  $("[onlynumber]").unbind('keypress');
  $('.PrPost').unbind('click');
  $('.PrResetForm').unbind('click');
  $('.PrRemoveBtn').unbind('click');
  $('.PrUpdateOrderNo').unbind('click');
  $('.PrFillUpdateForm').unbind('click');

  setEvents();
}

function checkRequires(parentElement) {
  var obj = {};
  obj.Success = true;
  obj.Message = "";
  $(parentElement).find('[pr-required]').each(function (index, e) {
      if (obj.Success) {

          if ($(e).attr('type') == "file") {
              var files = $(e).get(0).files;
              if (IsNull(files) == true || files.length == 0) {
                  obj.Message = $(e).attr('pr-required');
                  obj.Success = false;
                  return;
              }
          }
          else if ($(e).attr('type') == "ckeditor") {
              var eval = multiLineHtmlEncode(CKEDITOR.instances[$(e).attr('id')].getData());
              if (IsNull(eval) == true) {
                  obj.Message = $(e).attr('pr-required');
                  obj.Success = false;
                  return;
              }
          }
          else {
              var eval = $(e).val();
              if (IsNull(eval) == true) {
                  obj.Message = $(e).attr('pr-required');
                  obj.Success = false;
                  return;
              }
          }
      }
  });

  return obj;
}

function Post(data, Url, SuccessMessage, refreshVal, SuccessFunction) {
  $.ajax({
      xhr: function () {
          var xhr = new window.XMLHttpRequest();
          $(".PostLoader").show();
          xhr.upload.addEventListener("progress", function (evt) {
              $(".progress").show();
              $(".progress").html(' <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width:0">0%</div>');
              if (evt.lengthComputable) {
                  var percentComplete = evt.loaded / evt.total;

                  $('.progress-bar').css({
                      width: percentComplete * 100 + '%'
                  });
                  $(".progress-bar").html(percentComplete * 100 + '%');
              }
          }, false);
          return xhr;
      },
      url: Url,
      type: "POST",
      processData: false,
      contentType: false,
      data: data,
      success: function (response) {
          $(".PostLoader").hide();
          if (!response.Success) {
              swal("Hata", response.Message, "error");
          } else {
              if (IsNull(SuccessFunction) != true) {

                  if (response.Message != null) {
                      swal("", htmlDecode(response.Message), "success");
                  }
                  else {
                      executeFunctionByName(SuccessFunction, window, response);
                  }
              }
              else {
                  swal("", SuccessMessage, "success");
                  if (refreshVal)
                      setTimeout(function () {
                          window.location.reload();
                      }, 1000);
              }
          }
      },
      error: function (er) {
          $(".PostLoader").hide();
          swal("Hata", "Beklenmeyen bir hata oluştu. Lütfen PR yazılım ile iletişime geçin.", "error");
      }
  });
}

function PostJson(data, Url, SuccessMessage, refreshVal, SuccessFunction) {
  $.ajax({
      xhr: function () {
          var xhr = new window.XMLHttpRequest();
          $(".PostLoader").show();
          xhr.upload.addEventListener("progress", function (evt) {
              $(".progress").show();
              $(".progress").html(' <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width:0">0%</div>');
              if (evt.lengthComputable) {
                  var percentComplete = evt.loaded / evt.total;

                  $('.progress-bar').css({
                      width: percentComplete * 100 + '%'
                  });
                  $(".progress-bar").html(percentComplete * 100 + '%');
              }
          }, false);
          return xhr;
      },
      url: Url,
      type: "POST",
      processData: false,
      dataType: "json",
      contentType: 'application/json; charset=utf-8',
      data: JSON.stringify(data),
      success: function (response) {
          $(".PostLoader").hide();
          if (!response.Success) {
              swal("Hata", response.Message, "error");
          } else {
              if (IsNull(SuccessFunction) == false) {
                  if (response.Message != null) {
                      swal("", htmlDecode(response.Message), "success");
                  }
                  else {
                      executeFunctionByName(SuccessFunction, window, response);
                  }
              }
              else {
                  swal("", SuccessMessage, "success");
                  if (refreshVal)
                      setTimeout(function () {
                          window.location.reload();
                      }, 1000);
              }
          }
      },
      error: function (er) {
          $(".PostLoader").hide();
          swal("Hata", "Beklenmeyen bir hata oluştu. Lütfen PR yazılım ile iletişime geçin.", "error");
      }
  });
}

function collectDataFromElement(e) {
  if ($(e).attr('type') == "checkbox") {
      var eval = $(e).is(":checked");
      return eval;
  }
  else if ($(e).attr('type') == "file") {
      var files = $(e).get(0).files;
      if (files.length > 0) {
          var dataObj = {};
          dataObj.Files = files[0];
          return dataObj.Files;
      }
  }
  else if ($(e).attr('type') == "ckeditor") {
      var eval = multiLineHtmlEncode(CKEDITOR.instances[$(e).attr('id')].getData());
      return eval;
  } else {
      var eval = $(e).val();
      if (typeof ($(e).attr("encode")) != "undefined")
          eval = htmlEncode(eval);
      return eval;
  }

  return null;
}

function multiLineHtmlEncode(value) {
  var lines = value.split(/\r\n|\r|\n/);
  for (var i = 0; i < lines.length; i++) {
      lines[i] = htmlEncode(lines[i]);
  }
  return lines.join('\r\n');
}

function htmlEncode(value) {
  return $('<div />').text(value).html();
}

function htmlDecode(value) {
  return $('<div />').html(value).text();
}

function IsNull(val) {
  return (typeof (val) == "undefined" || val == null)
}

function whenAvailable(name, callback) {
  var interval = 10; // ms
  window.setTimeout(function () {
      if (window[name]) {
          callback(window[name]);
      } else {
          window.setTimeout(arguments.callee, interval);
      }
  }, interval);
}

function executeFunctionByName(functionName, context, args) {
  var args = [].slice.call(arguments).splice(2);
  var namespaces = functionName.split(".");
  var func = namespaces.pop();
  for (var i = 0; i < namespaces.length; i++) {
      context = context[namespaces[i]];
  }
  return context[func].apply(context, args);
}

function randomNameGenerate() {
  function s4() {
      return Math.floor((1 + Math.random()) * 0x10000)
          .toString(16)
          .substring(1);
  }
  return s4() + s4() + s4() + s4();
}

jQuery.cachedScript = function (url, options) {
options = $.extend(options || {}, {
  dataType: "script",
  type: "GET",
  cache: true,
  url: url
});
return jQuery.ajax(options);
};

function ckEditor_init() {
if ($('[type=ckeditor]').length > 0) {
  $.when(
    LibrarySources.CkEditor.JS.Load(),
    $.Deferred(function (deferred) {
      $(deferred.resolve);
    })
  ).done(function () {
    $('[type=ckeditor]').each(function (index, e) {
      $(e).hide();
    });

    $('[type=ckeditor]').each(function (index, e) {
      if (typeof ($(e).attr('id')) != "undefined") {
        CKEDITOR.replace($(e).attr('id'));
        CKEDITOR.instances[$(e).attr('id')].setData($(e).val());
      }
      $(e).fadeIn(300);
    });

  });
}
}
function dataTable_init() {
if ($('[type=datatable]').length > 0) {
  $.when(
    LibrarySources.DataTable.JS.Load(),
    LibrarySources.DataTable.CSS.Load(),

    $.Deferred(function (deferred) {
      $(deferred.resolve);
    })
  ).done(function () {
    $('[type=datatable]').each(function (index, e) {

      var self = $(e);
      var attrOpt = self.attr('opt');
      var DblClickEvent = self.attr('pr-dblclick');
      var ClickEvent = self.attr('pr-click');
      var itemId = self.attr('id');

      if (typeof (itemId) == "undefined") {
        itemId = randomNameGenerate();
        self.attr('id', itemId);
      }

      var options = {
        responsive: true,
        "language": {
          "url": "//cdn.datatables.net/plug-ins/1.10.7/i18n/Turkish.json"
        }
      };

      if (IsNull(attrOpt) == false) {
        try {
          options = $.extend(options, JSON.parse(attrOpt));
        } catch (e) {
          options = {
            "language": {
              "url": "//cdn.datatables.net/plug-ins/1.10.7/i18n/Turkish.json"
            },
          };
        }
      }

      window["dt" + itemId] = $(e).dataTable(options);

      if (IsNull(DblClickEvent) == false) {
        $(e).find('tbody').on('dblclick', 'tr', function () {
          var that = $(this);
          var data = window["dt" + that.attr("id")].DataTable();
          var test = data.row(this).data();
          executeFunctionByName(DblClickEvent, window, data.row(this).data());
        });
      }

    });
  });
}
}

function SourceBase(srcVal) {
var obj = {
  src: srcVal,
  Load: function () {
    var dfd = jQuery.Deferred();
    var that = this;

    var extension = that.src.split('.');
    if (extension[extension.length - 1] == "js") {
      $.cachedScript(that.src).done(function (e) {
        dfd.resolve();
      });
    } else if (extension[extension.length - 1] == "css") {
      var cssFile = document.createElement('link');
      cssFile.href = that.src;
      cssFile.type = "text/css"
      cssFile.rel = "stylesheet";
      document.head.appendChild(cssFile);
      dfd.resolve();
    }
    return dfd.promise();
  },
  Loaded: false
};

return obj;
}
var LibrarySources = {

DataTable: {
  JS: SourceBase("/Content/Admin/plugins/jquery-datatable/datatables.min.js"),
  CSS: SourceBase("/Content/Admin/plugins/jquery-datatable/datatables.min.css")
},

CkEditor: {
  JS: SourceBase("//cdn.ckeditor.com/4.5.10/standard/ckeditor.js")
}

};

// init
$(function () {

ckEditor_init();

dataTable_init();

setEvents();
});

function setEvents() {
$("input[type=file]").on('change', function (e) {
  var tempReviewid = $(this).attr("pr-reviewid");
  if (typeof (tempReviewid) != "undefined") {
    var files = $(this).get(0).files;
    if (files.length > 0) {
      if (typeof (FileReader) != "undefined") {
        var fileName = files.name;
        var tmppath = URL.createObjectURL(e.target.files[0]);
        $("#" + tempReviewid).attr('src', tmppath);
      }
    }
  }
});

$("[onlynumber]").on('keypress', function (e) {
  var limit = $(this).attr("onlynumber");
  var theEvent = e || window.event;
  var key = theEvent.keyCode || theEvent.which;
  key = String.fromCharCode(key);
  var regex = /[0-9]/;
  if (typeof (limit) == "undefined" || limit == "") {
    if (!regex.test(key)) {
      theEvent.returnValue = false;
      if (theEvent.preventDefault) theEvent.preventDefault();
    }
  }
  else {
    if (limit < ($(this).val().length + 1)) {
      theEvent.returnValue = false;
      if (theEvent.preventDefault) theEvent.preventDefault();
    } else if (!regex.test(key)) {
      theEvent.returnValue = false;
      if (theEvent.preventDefault) theEvent.preventDefault();
    }
  }
});

$('.PrPost').on('click', function () {
  $('.PrPost').attr('disabled');
  var self = $(this);
  var _containerSelector = "div.x_panel";
  var _refreshAfterSuccess = false;
  var _url = self.attr("pr-url");
  var _successFunction = self.attr('pr-onsuccess');
  var _successMessage = "İşlem Başarılı";

  if (typeof (_url) == "undefined")
    throw "Url Bulunamadı";

  if (typeof (self.parents(_containerSelector).find('[pr-name]')) == "undefined")
    throw "Gönderilecek Veri Bulunamadı";

  if (typeof (self.attr("pr-parent-selector")) != "undefined")
    _containerSelector = self.attr("pr-parent-selector");

  if (typeof (self.attr("pr-refresh")) != "undefined") {
    var refreshVal = self.attr("pr-refresh");
    if (refreshVal == "true")
      _refreshAfterSuccess = true;
    else
      _refreshAfterSuccess = false;
  }


  if (typeof (self.attr("pr-success-message")) != "undefined")
    _successMessage = self.attr("pr-success-message");

  if (typeof (self.attr("pr-sendtype")) != "undefined" && self.attr("pr-sendtype") == "formdata") {
    var _formData = new FormData();
    self.parents(_containerSelector).find('[pr-name]').each(function (index, e) {
      var eval = collectDataFromElement(e);
      if (IsNull(eval) == false)
        _formData.append($(e).attr("pr-name"), eval);

    });
    var _requireObj = checkRequires(self.parents(_containerSelector));
    if (_requireObj.Success)
      Post(_formData, _url, _successMessage, _refreshAfterSuccess, _successFunction);
    else
      swal("Eksik Bilgi", _requireObj.Message, "error");
  }
  else {
    var data = {};
    self.parents(_containerSelector).find('[pr-name]').each(function (index, e) {

      var eval = collectDataFromElement(e);
      if (IsNull(eval) == false)
        data[$(e).attr("pr-name")] = eval;

    });
    PostJson(data, _url, _successMessage, _refreshAfterSuccess, _successFunction);
  }
  $('.PrPost').removeAttr('disabled');
});

$('.PrResetForm').on('click', function () {
  var self = $(this);
  var _containerSelector = "";

  if (typeof (self.attr("pr-parent-selector")) != "undefined")
    _containerSelector = self.attr("pr-parent-selector");
  else
    throw "Parent selector Bulunamadı";

  self.parents(_containerSelector).find('[pr-name]').each(function (index, e) {
    if ($(e).attr('type') == "text" || $(e).attr('type') == "hidden" || $(e).attr('type') == "password") {
      $(e).val("");
    }
    else if ($(e).attr('type') == "checkbox") {
      $(e).prop('checked', false);
    }
    else if ($(e).attr('type') == "file") {
      $(e).val("");
    }
    else if ($(e).attr('type') == "ckeditor") {
      CKEDITOR.instances[$(e).attr('id')].setData("");
    }

    if ($(e).parent().find('label').length > 0)
      $(e).parent().removeClass("focused");
  });

});

$(document).on('click', ".PrRemoveBtn", function () {
  $('.PrRemoveBtn').attr('disabled');
  var self = $(this);
  var _url = self.attr("pr-url");
  var _successMessage = "Silme işlemi başarılı";
  var _successFunction = self.attr('pr-onsuccess');
  var _refreshAfterSuccess = false;
  var _questionMessage = "Silme işlemini onaylıyor musunuz?"

  if (typeof (_url) == "undefined")
    throw "Url Bulunamadı";

  if (typeof (self.attr("pr-id")) == "undefined")
    throw "Id Bulunamadı";

  if (typeof (self.attr("pr-refresh")) != "undefined") {
    var refreshVal = self.attr("pr-refresh");
    if (refreshVal == "true")
      _refreshAfterSuccess = true;
    else
      _refreshAfterSuccess = false;
  }

  if (typeof (self.attr("pr-success-message")) != "undefined")
    _successMessage = self.attr("pr-success-message");

  if (typeof (self.attr("pr-question-message")) != "undefined")
    _questionMessage = self.attr("pr-question-message");

  swal({
    title: "Emin Misiniz?",
    text: _questionMessage,
    type: "warning",
    showCancelButton: true,
    cancelButtonText: "İptal",
    confirmButtonColor: "#DD6B55",
    confirmButtonText: "Sil!",
    closeOnConfirm: false
  },
    function () {
      var _data = { 'id': self.attr("pr-id") }
      PostJson(_data, _url, _successMessage, _refreshAfterSuccess, _successFunction);
    });
  $('.PrRemoveBtn').removeAttr('disabled');
});

$('.PrUpdateOrderNo').on('click', function () {
  var self = $(this);
  var _url = self.attr("pr-url");
  var _successMessage = "Sıralama Güncellendi";
  var _successFunction = self.attr('pr-onsuccess');
  var _refreshAfterSuccess = false;
  var data = {};

  if (typeof (_url) == "undefined")
    throw "Url Bulunamadı";

  if (typeof (self.attr("pr-id")) == "undefined")
    throw "Id Bulunamadı";


  if (typeof (self.attr("pr-refresh")) != "undefined") {
    var refreshVal = self.attr("pr-refresh");
    if (refreshVal == "true")
      _refreshAfterSuccess = true;
    else
      _refreshAfterSuccess = false;
  }


  self.parents('td').find('input[type=text]').each(function (index, e) {
    data.id = self.attr("pr-id");
    data.OrderNo = $(e).val();

    PostJson(data, _url, _successMessage, _refreshAfterSuccess, _successFunction);
  });
});

$(document).on('click', ".PrFillUpdateForm", function () {
  var self = $(this);
  self.each(function () {
    $.each(this.attributes, function () {
      if (this.specified) {
        if (this.name.match("^prtext")) {
          $('#' + this.name.split('-')[1]).val(this.value).change();
        } else if (this.name.match("^prselect")) {
          $('#' + this.name.split('-')[1]).val(this.value).change();
        } else if (this.name.match("^primage")) {
          $('#' + this.name.split('-')[1]).attr('src', this.value);
        } else if (this.name.match("^prckeditor")) {
          CKEDITOR.instances[this.name.split('-')[1]].setData(this.value);
        } else if (this.name.match("^prcheckbox")) {
          var _val = false;
          if (this.value == "true" || this.value == "True")
            _val = true;
          $('#' + this.name.split('-')[1]).prop('checked', _val);
        }
        else if (this.name.match("^prradio")) {
          $('input[name="' + this.name.split('-')[1] + '"][value=' + this.value + ']').prop('checked', true);
        }
        if ($('#' + this.name.split('-')[1]).parent().find('label').length > 0)
          $('#' + this.name.split('-')[1]).parent().addClass("focused");
      }
    });
  });
  var _moneyControl = $(this).hasClass('GoToTop');
  if (_moneyControl) {
    $(".Money2").focus();
  }
  else {
    $(".Money").focus();
  }
});
}

function resetEvents() {
$("input[type=file]").unbind('change');
$("[onlynumber]").unbind('keypress');
$('.PrPost').unbind('click');
$('.PrResetForm').unbind('click');
$('.PrRemoveBtn').unbind('click');
$('.PrUpdateOrderNo').unbind('click');
$('.PrFillUpdateForm').unbind('click');

setEvents();
}

function checkRequires(parentElement) {
var obj = {};
obj.Success = true;
obj.Message = "";
$(parentElement).find('[pr-required]').each(function (index, e) {
  if (obj.Success) {

    if ($(e).attr('type') == "file") {
      var files = $(e).get(0).files;
      if (IsNull(files) == true || files.length == 0) {
        obj.Message = $(e).attr('pr-required');
        obj.Success = false;
        return;
      }
    }
    else if ($(e).attr('type') == "ckeditor") {
      var eval = multiLineHtmlEncode(CKEDITOR.instances[$(e).attr('id')].getData());
      if (IsNull(eval) == true) {
        obj.Message = $(e).attr('pr-required');
        obj.Success = false;
        return;
      }
    }
    else {
      var eval = $(e).val();
      if (IsNull(eval) == true) {
        obj.Message = $(e).attr('pr-required');
        obj.Success = false;
        return;
      }
    }
  }
});

return obj;
}

function Post(data, Url, SuccessMessage, refreshVal, SuccessFunction) {
$.ajax({
  xhr: function () {
    var xhr = new window.XMLHttpRequest();
    $(".PostLoader").show();
    xhr.upload.addEventListener("progress", function (evt) {
      $(".progress").show();
      $(".progress").html(' <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width:0">0%</div>');
      if (evt.lengthComputable) {
        var percentComplete = evt.loaded / evt.total;

        $('.progress-bar').css({
          width: percentComplete * 100 + '%'
        });
        $(".progress-bar").html(percentComplete * 100 + '%');
      }
    }, false);
    return xhr;
  },
  url: Url,
  type: "POST",
  processData: false,
  contentType: false,
  data: data,
  success: function (response) {
    $(".PostLoader").hide();
    if (!response.Success) {
      swal("Hata", response.Message, "error");
    } else {
      if (IsNull(SuccessFunction) != true) {

        if (response.Message != null) {
          swal("", htmlDecode(response.Message), "success");
        }
        else {
          executeFunctionByName(SuccessFunction, window, response);
        }
      }
      else {
        swal("", SuccessMessage, "success");
        if (refreshVal)
          setTimeout(function () {
            window.location.reload();
          }, 1000);
      }
    }
  },
  error: function (er) {
    $(".PostLoader").hide();
    swal("Hata", "Beklenmeyen bir hata oluştu. Lütfen PR yazılım ile iletişime geçin.", "error");
  }
});
}

function PostJson(data, Url, SuccessMessage, refreshVal, SuccessFunction) {
$.ajax({
  xhr: function () {
    var xhr = new window.XMLHttpRequest();
    $(".PostLoader").show();
    xhr.upload.addEventListener("progress", function (evt) {
      $(".progress").show();
      $(".progress").html(' <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width:0">0%</div>');
      if (evt.lengthComputable) {
        var percentComplete = evt.loaded / evt.total;

        $('.progress-bar').css({
          width: percentComplete * 100 + '%'
        });
        $(".progress-bar").html(percentComplete * 100 + '%');
      }
    }, false);
    return xhr;
  },
  url: Url,
  type: "POST",
  processData: false,
  dataType: "json",
  contentType: 'application/json; charset=utf-8',
  data: JSON.stringify(data),
  success: function (response) {
    $(".PostLoader").hide();
    if (!response.Success) {
      swal("Hata", response.Message, "error");
    } else {
      if (IsNull(SuccessFunction) == false) {
        if (response.Message != null) {
          swal("", htmlDecode(response.Message), "success");
        }
        else {
          executeFunctionByName(SuccessFunction, window, response);
        }
      }
      else {
        swal("", SuccessMessage, "success");
        if (refreshVal)
          setTimeout(function () {
            window.location.reload();
          }, 1000);
      }
    }
  },
  error: function (er) {
    $(".PostLoader").hide();
    swal("Hata", "Beklenmeyen bir hata oluştu. Lütfen PR yazılım ile iletişime geçin.", "error");
  }
});
}

function collectDataFromElement(e) {
if ($(e).attr('type') == "checkbox") {
  var eval = $(e).is(":checked");
  return eval;
}
else if ($(e).attr('type') == "file") {
  var files = $(e).get(0).files;
  if (files.length > 0) {
    var dataObj = {};
    dataObj.Files = files[0];
    return dataObj.Files;
  }
}
else if ($(e).attr('type') == "ckeditor") {
  var eval = multiLineHtmlEncode(CKEDITOR.instances[$(e).attr('id')].getData());
  return eval;
} else {
  var eval = $(e).val();
  if (typeof ($(e).attr("encode")) != "undefined")
    eval = htmlEncode(eval);
  return eval;
}

return null;
}

function multiLineHtmlEncode(value) {
var lines = value.split(/\r\n|\r|\n/);
for (var i = 0; i < lines.length; i++) {
  lines[i] = htmlEncode(lines[i]);
}
return lines.join('\r\n');
}

function htmlEncode(value) {
return $('<div />').text(value).html();
}

function htmlDecode(value) {
return $('<div />').html(value).text();
}

function IsNull(val) {
return (typeof (val) == "undefined" || val == null)
}

function whenAvailable(name, callback) {
var interval = 10; // ms
window.setTimeout(function () {
  if (window[name]) {
    callback(window[name]);
  } else {
    window.setTimeout(arguments.callee, interval);
  }
}, interval);
}

function executeFunctionByName(functionName, context, args) {
var args = [].slice.call(arguments).splice(2);
var namespaces = functionName.split(".");
var func = namespaces.pop();
for (var i = 0; i < namespaces.length; i++) {
  context = context[namespaces[i]];
}
return context[func].apply(context, args);
}

function randomNameGenerate() {
function s4() {
  return Math.floor((1 + Math.random()) * 0x10000)
    .toString(16)
    .substring(1);
}
return s4() + s4() + s4() + s4();
}


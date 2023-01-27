using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Lumos.Base
{
  public static class Functions
  {
    public static string MainSiteURL = "http://Lumos.pryazilim.net/";
    private static readonly string CookieKey = "RPjtJEE7CLfmbCbJ2UPW6bt3Q3BK8gquHsSK6qV8QWMVRfS2uYMDWLgE72LwVPwLaGYRUpQ6qrgX2R8he4fcTwfkMV24rnWvvSQbGQPHauYYqBKq6fydbhEzgB7J9gqQKYEY5QPcjJJ6qauuYHTpqV7qCv5epZghBDXwfYk6NZfZ6A2xz5u5mbsTN2wcULdB5csxc4HbzAsapuZKWm8b4AvG8fxx9nr8Chp2qr6ZMBz39fq9YaPmLGBXcVLbmM79";
    private static readonly string PASSWORD = "4y7VHJc6GsmbJbBZAh6nGEpBf4cPpzfCaJ9BG4EWzuXrqedpfsbDnBC4tGKccW8t9SXC7KQ8bshuSThBY7aRU8nZm47ah2Lvhyccfbz72C5mNHVJbkBqVKPnhvDMkJ5hacwaGVkLmMkBYqJ3zMypFXxRrZMgSvTkhqfbkdPj6rbQYVXurnx8HXGjntkWTDu2LDdwPj7T2QwAKrtHXVukNYwxkJaNtqL4bUL6VWPkcvdUujArePBY2NaJjM6Nkuzs";
    private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("F9QJw8GktZ4QJvWd");
    private static readonly byte[] UserId_initVectorBytes = Encoding.ASCII.GetBytes("3UerXk2HcKMZYvJ8");
    private static readonly int KEY_SIZE = 256;
    public static string MailCVSiteUrl = "";
    public static string Host = "smtp.gmail.com";
    public static int Port = 587;
    public static string MailAdress = "mailgonder35@gmail.com";
    public static string Password = "eipvmmysxagpegha";
    public static string CaptchaSecret = "6Lf9utcjAAAAAKTOLLNvQiaHwTYZvftoW-dliTCE";
    //6LevI-4ZAAAAAEYSULFICuLSnjYzWst4QmesOEQW
    public static string Alici
    {
      get
      {
        // var data = Statics.getLayoutValues();

        return ("cenkerbakann@gmail.com");
      }
    }
    public static string PRyazilim
    {
      get
      {
        return ("destek@pryazilim.com");
      }
    }
    public static bool CaptchaValidationControl(string text)
    {
      try
      {
        bool Valid = false;
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.google.com/recaptcha/api/siteverify?secret=" + CaptchaSecret + "&response=" + text);

        using (var wResponse = req.GetResponse())
        {
          using (var readStream = new StreamReader(wResponse.GetResponseStream()))
          {
            string jsonResponse = readStream.ReadToEnd();
            var data = JsonSerializer.Deserialize<GeneralModel.CaptchaModel>(jsonResponse);
            Valid = data!.success;
          }
        }
        return Valid;
      }
      catch (WebException)
      {
        return true;
      }
    }
    public static string StripTagsRegexIcerik(string source)
    {
      var alt = "";
      var url = "";
      var style = "";
      if (source.Contains("_img"))
      {
        var src = source;
        alt = src.Split('"')[1];
        url = src.Split('"')[3];
        style = src.Split('"')[5];

      }
      source = source.Replace("_-TagAc-_", "<")
                     .Replace("_-TagKapa-_", ">")
                     .Replace("<strong>", "--|strong Tagi Aç|--")
                     .Replace("</strong>", "--|strong Tagi kapa|--")
                     .Replace("<img alt=\"" + alt + "\" src=\"" + url + "\" style=\"" + style + "\" />", "--|img Tagi Aç|--")
                     .Replace("<b>", "--|strong Tagi Aç|--")
                     .Replace("</b>", "--|strong Tagi kapa|--")
                     .Replace("<i>", "--|em Tagi Aç|--")
                     .Replace("</i>", "--|em Tagi kapa|--")
                     .Replace("<em>", "--|em Tagi Aç|--")
                     .Replace("</em>", "--|em Tagi kapa|--")
                     .Replace("<h4>", "--|h4 Tagi Aç|--")
                     .Replace("</h4>", "--|h4 Tagi kapa|--")
                     .Replace("<h2>", "--|h2 Tagi Aç|--")
                     .Replace("</h2>", "--|h2 Tagi kapa|--")
                     .Replace("<span style=\"text-decoration: underline;\">", "--|span Tagi Aç|--")
                     .Replace("</span>", "--|span Tagi kapa|--")
                     .Replace("<ol>", "--|ol Tagi Aç|--")
                     .Replace("</ol>", "--|ol Tagi kapa|--")
                     .Replace("<ul>", "--|ul Tagi Aç|--")
                     .Replace("</ul>", "--|ul Tagi kapa|--")
                     .Replace("<li>", "--|li Tagi Aç|--")
                     .Replace("</li>", "--|li Tagi kapa|--")
                     .Replace("<br />", "--|br Tagi aç kapa|--")
                     .Replace("<p>", "--|p Tagi Aç|--")
                     .Replace("</p>", "--|p Tagi kapa|--")
                     .Replace("&lt;script&gt;", "")
                     .Replace("&lt;/script&gt;", "");
      source = Regex.Replace(source, "<.*?>|&lt;iframe.*?/iframe&gt;", string.Empty)
                    .Replace("<", "&amp;lt;")
                    .Replace(">", "&amp;gt;")
                    .Replace("&lt;", "&amp;lt;")
                    .Replace("&gt;", "&amp;gt;")
                    .Replace("--|strong Tagi Aç|--", "<strong>")
                    .Replace("--|strong Tagi kapa|--", "</strong>")
                    .Replace("--|img Tagi Aç|--", "<img alt=\"" + alt + "\" src=\"" + url + "\" style=\"" + style + "\" />")
                    .Replace("--|em Tagi Aç|--", "<em>")
                    .Replace("--|em Tagi kapa|--", "</em>")
                    .Replace("--|h4 Tagi Aç|--", "<h4>")
                    .Replace("--|h4 Tagi kapa|--", "</h4>")
                    .Replace("--|h2 Tagi Aç|--", "<h2>")
                    .Replace("--|h2 Tagi kapa|--", "</h2>")
                    .Replace("--|span Tagi Aç|--", "<span style=\"text-decoration: underline;\">")
                    .Replace("--|span Tagi kapa|--", "</span>")
                    .Replace("--|ol Tagi Aç|--", "<ol>")
                    .Replace("--|ol Tagi kapa|--", "</ol>")
                    .Replace("--|ul Tagi Aç|--", "<ul>")
                    .Replace("--|ul Tagi kapa|--", "</ul>")
                    .Replace("--|li Tagi Aç|--", "<li>")
                    .Replace("--|li Tagi kapa|--", "</li>")
                    .Replace("--|br Tagi aç kapa|--", "<br>")
                    .Replace("--|p Tagi Aç|--", "<p>")
                    .Replace("--|p Tagi kapa|--", "</p>")
                    .Replace("&nbsp;", " ")
                    .Replace("</strong><strong>", string.Empty)
                    .Replace("</strong><br><strong>", "<br>")
                    .Replace("</span><span style=\"text-decoration: underline;\">", string.Empty)
                    .Replace("</span><br><span style=\"text-decoration: underline;\">", "<br>")
                    .Replace("</em><em>", string.Empty)
                    .Replace("</em><br><em>", "<br>");
      return source;
    }

    public static void RandevuMailGonder(string N, string E, string P, DateTime? D)
    {
      try
      {
        SmtpClient sc = new SmtpClient();
        sc.Port = Port;
        sc.Host = Host;
        sc.EnableSsl = true;
        sc.Credentials = new NetworkCredential(MailAdress, Password);

        MailMessage mail = new MailMessage();

        mail.From = new MailAddress(MailAdress, "Randevu Mailleri");

        mail.To.Add(Alici);

        mail.Subject = "Randevu Formundan Yazanlar";
        mail.IsBodyHtml = true;
        mail.Body =
            "<b>Adı Soyadı : </b>" + N + "<br><br>" +
            "<b>Email Adresi : </b>" + E + "<br><br>" +
            "<b>Randevu Tarihi : </b>" + string.Format("{0:dd MMMM yyyy HH:mm}", D) + "<br><br>" +
            "<b>Telefon : </b>" + P;


        sc.Send(mail);
      }
      catch (Exception)
      {
      }
    }
    public static void SifremiUnuttumMailGonder(Guid id, string Email, string Name, string Surname)
    {

      try
      {
        SmtpClient sc = new SmtpClient();
        sc.Port = Port;
        sc.Host = Host;
        sc.EnableSsl = true;
        sc.Credentials = new NetworkCredential(MailAdress, Password);

        MailMessage mail = new MailMessage();

        mail.From = new MailAddress(MailAdress, "1Shoe4You");

        mail.To.Add(Email);

        mail.Subject = "1Shoe4You Şifremi Unuttum";
        mail.IsBodyHtml = true;
        mail.Body =
            "Sayın " + Name + " " + Surname + ",<br>" +
            "<p>Aşağıdaki linke tıklayarak şifrenizi güncelleyebilirsiniz.</p><br>" +
            "<a href='" + MainSiteURL + "/sifredegistir_" + id + "'>ŞİFREMİ DEĞİŞTİR</a>";

        sc.Send(mail);
      }
      catch (Exception)
      {
      }
    }
    public static void IletisimMailGonder(string N, string E, string P, string S, string M)
    {
      try
      {
        SmtpClient sc = new SmtpClient();
        sc.Port = Port;
        sc.Host = Host;
        sc.EnableSsl = true;
        sc.Credentials = new NetworkCredential(MailAdress, Password);

        MailMessage mail = new MailMessage();

        mail.From = new MailAddress(MailAdress, "İletişim Mailleri");

        mail.To.Add(Alici);

        mail.Subject = "İletişim Formundan Yazanlar";
        mail.IsBodyHtml = true;
        mail.Body =
            "<b>Adı Soyadı : </b>" + N + "<br><br>" +
            "<b>Email : </b>" + E + "<br><br>" +
            "<b>Telefon Numarası : </b>" + P + "<br><br>" +
            "<b>Konu : </b>" + S + "<br><br>" +
            "<b>Mesajı : </b>" + M;

        sc.Send(mail);
      }
      catch (Exception)
      {
      }
    }
    public static void DestekTalebiMailGonder(string T, string M)
    {
      try
      {
        SmtpClient sc = new SmtpClient();
        sc.Port = Port;
        sc.Host = Host;
        sc.EnableSsl = true;
        sc.Credentials = new NetworkCredential(MailAdress, Password);

        MailMessage mail = new MailMessage();

        mail.From = new MailAddress(MailAdress, "Destek Talebi Maili");

        mail.To.Add(PRyazilim);

        mail.Subject = "Destek Talebi Formu";
        mail.IsBodyHtml = true;
        mail.Body =
            "<b>Firma Adı : </b> AERA air innovation <br><br>" +
            "<b>Talep Konusu : </b>" + T + "<br><br>" +
            "<b>Mesajı : </b>" + M;

        sc.Send(mail);
      }
      catch (Exception)
      {
      }
    }

    //  public static void ImportAdminCookie(string Username, long userID, string permission)
    // {
    //   var _date = DateTime.Now.AddDays(30);

    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__of") // ID
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = CookieEncoder(userID.ToString())
    //   });

    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__yb") // Username
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = CookieEncoder(Username)
    //   });
    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__ty") // Perm
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = CookieEncoder(permission)
    //   });
    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__ks") // CID
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = VerifyCookieEncoder(userID.ToString())
    //   });
    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__df") // CUsername
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = VerifyCookieEncoder(Username)
    //   });

    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__ug") // CPerm
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = VerifyCookieEncoder(permission)
    //   });
    // }

    //  public static void DeletaAdminCookie()
    // {
    //   var _date = DateTime.Now.AddDays(-1d);

    //   HttpContext.Current.Response.Cookies.Clear();

    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__of")
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = "-1"
    //   });

    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__yb")
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = "-1"
    //   });

    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__ks")
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = "-1"
    //   });

    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__df")
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = "-1"
    //   });
    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__ty")
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = "-1"
    //   });

    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__ug")
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = "-1"
    //   });

    //   HttpContext.Current.Session.Abandon();
    // }
    // public static void DeletaUserCookie()
    // {


    //   var _date = DateTime.Now.AddDays(-1d);

    //   HttpContext.Current.Response.Cookies.Clear();


    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__rb")
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = "-1"
    //   });


    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__mm")
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = "-1"
    //   });

    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__ky")
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = "-1"
    //   });

    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__sb")
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = "-1"
    //   });

    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__gg")
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = "-1"
    //   });

    //   HttpContext.Current.Response.Cookies.Add(new HttpCookie("__fo")
    //   {
    //     Expires = _date,
    //     HttpOnly = true,
    //     Value = "-1"
    //   });

    //   HttpContext.Current.Session.Abandon();
    // }

    public static void SetLangCookie(HttpContext httpContext, string lang)
    {
      httpContext.Response.Cookies.Append("lang", lang, new CookieOptions
      {
        Expires = DateTime.Now.AddDays(30),
        HttpOnly = false
      });
    }

    public static long AdminUserID(HttpContext httpContext)
    {
      var idc = httpContext.Request.Cookies["__of"];

      var _userId = Convert.ToInt32(CookieDecoder(idc));

      return Statics.getAdminValues().FirstOrDefault(e => e.Id == _userId) == null ? -1 : _userId;
    }

    public static string AdminUsername(HttpContext httpContext)
    {
      try
      {
        var usc = httpContext.Request.Cookies["__yb"];
        var vusc = httpContext.Request.Cookies["__df"];
        string _un = CookieDecoder(usc);

        if (_un == VerifyCookieDecoder(vusc))
          return _un;
        else
          return string.Empty;
      }
      catch (Exception)
      {
        return string.Empty;
      }
    }
     public static string CookieEncoder(string text)
    {
      var _result = string.Empty;
      var _rnd = new Random();

      for (int i = 0; i < text.Length; i++)
      {
        string asd = text[i].ToString();
        var sdfg = CookieKey[_rnd.Next(0, CookieKey.Length - 1)].ToString();
        _result += text[i].ToString() + CookieKey[_rnd.Next(0, CookieKey.Length - 1)].ToString();
      }
      return encryptWithKey(_result);
    }
    public static string CookieDecoder(string text)
    {
      var _result = string.Empty;

      text = decryptWithKey(text);

      for (int i = 0; i < text.Length; i += 2)
      {
        _result += text[i].ToString();
      }
      return _result;
    }
    private static string decryptWithKey(string value)
    {
      byte[] cipherTextBytes = Convert.FromBase64String(value);
      using (PasswordDeriveBytes password = new PasswordDeriveBytes(PASSWORD, null))
      {
        byte[] keyBytes = password.GetBytes(KEY_SIZE / 8);
        using (var symmetricKey = Aes.Create())
        {
          symmetricKey.Mode = CipherMode.CBC;
          using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
          {
            using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
            {
              using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
              {
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
              }
            }
          }
        }
      }
    }
     private static string encryptWithKey(string value)
    {
      byte[] plainTextBytes = Encoding.UTF8.GetBytes(value);
      using (PasswordDeriveBytes password = new PasswordDeriveBytes(PASSWORD, null))
      {
        byte[] keyBytes = password.GetBytes(KEY_SIZE / 8);
        using (var symmetricKey = Aes.Create())
        {
          symmetricKey.Mode = CipherMode.CBC;
          using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
          {
            using (MemoryStream memoryStream = new MemoryStream())
            {
              using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
              {
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] cipherTextBytes = memoryStream.ToArray();
                return Convert.ToBase64String(cipherTextBytes);
              }
            }
          }
        }
      }
    }
     public static string VerifyCookieDecoder(string text)
    {
      var _result = string.Empty;

      text = decryptWithKey(text);

      for (int i = 2; i < text.Length; i += 3)
      {
        _result += text[i].ToString();
      }
      return _result;
    }
    public static string VerifyCookieEncoder(string text)
    {
      var _result = string.Empty;
      var _rnd = new Random();

      for (int i = 0; i < text.Length; i++)
      {
        _result += CookieKey[_rnd.Next(0, CookieKey.Length - 1)].ToString() + CookieKey[_rnd.Next(0, CookieKey.Length - 1)].ToString() + text[i].ToString();
      }
      return encryptWithKey(_result);
    }
    public static void CropImage(Image originalImage, string path, int _targetWidth, int _targetHeight, bool IsCrop, int imageType, Rectangle? destinationRectangle = null)
    {
      Bitmap _processedPhoto = null;
      Graphics grafik = null;

      int _lastWidth = 0, _lastHeight = 0;

      // 274, File Orientation
      if (Array.IndexOf(originalImage.PropertyIdList, 274) > -1)
      {
        var orientation = (int)originalImage.GetPropertyItem(274).Value[0];
        switch (orientation)
        {
          case 1:
            // No rotation required.
            break;
          case 2:
            originalImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
            break;
          case 3:
            originalImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            break;
          case 4:
            originalImage.RotateFlip(RotateFlipType.Rotate180FlipX);
            break;
          case 5:
            originalImage.RotateFlip(RotateFlipType.Rotate90FlipX);
            break;
          case 6:
            originalImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            break;
          case 7:
            originalImage.RotateFlip(RotateFlipType.Rotate270FlipX);
            break;
          case 8:
            originalImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            break;
        }
        // This EXIF data is now invalid and should be removed.
        originalImage.RemovePropertyItem(274);
      }

      try
      {
        if ((originalImage.Width < _targetWidth) && (originalImage.Height < _targetHeight))
        {
          _processedPhoto = new Bitmap(originalImage.Width, originalImage.Height);
          grafik = Graphics.FromImage(_processedPhoto);

          grafik.SmoothingMode = SmoothingMode.HighQuality;
          grafik.CompositingQuality = CompositingQuality.HighQuality;
          grafik.InterpolationMode = InterpolationMode.Default;
          grafik.PixelOffsetMode = PixelOffsetMode.HighQuality;

          var codec = ImageCodecInfo.GetImageEncoders();
          Console.WriteLine(codec[imageType]);
          var eParams = new EncoderParameters(1);
          eParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 85L);

          grafik.DrawImage(originalImage, 0, 0, originalImage.Width, originalImage.Height);

          _processedPhoto.Save(path, codec[imageType], eParams);

          GC.Collect();
        }
        else
        {
          if (IsCrop != true)
          {
            float _OrjiRatio = (float)originalImage.Width / (float)originalImage.Height;

            float _hedefRatio = (float)_targetWidth / (float)_targetHeight;

            if (_OrjiRatio > _hedefRatio) //Widthe Göre
            {
              _lastWidth = _targetWidth;
              _lastHeight = Convert.ToInt32(_targetWidth / _OrjiRatio);
            }
            else //heighte göre
            {
              _lastHeight = _targetHeight;
              _lastWidth = Convert.ToInt32(_targetHeight * _OrjiRatio);
            }

            _processedPhoto = new Bitmap(_lastWidth, _lastHeight);
            grafik = Graphics.FromImage(_processedPhoto);

            grafik.SmoothingMode = SmoothingMode.HighQuality;
            grafik.CompositingQuality = CompositingQuality.HighQuality;
            grafik.InterpolationMode = InterpolationMode.Default;
            grafik.PixelOffsetMode = PixelOffsetMode.HighQuality;

            var codec = ImageCodecInfo.GetImageEncoders();
            var eParams = new EncoderParameters(1);
            eParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 85L);

            grafik.DrawImage(originalImage, 0, 0, _lastWidth, _lastHeight);

            _processedPhoto.Save(path, codec[imageType], eParams);

            GC.Collect();
          }
          else
          {
            float _OrjiRatio = (float)originalImage.Width / (float)originalImage.Height;

            float _hedefRatio = (float)_targetWidth / (float)_targetHeight;

            if (_hedefRatio < _OrjiRatio) // heighte göre
            {
              _lastHeight = _targetHeight;

              _lastWidth = Convert.ToInt32(_targetHeight * _OrjiRatio);
            }
            else // widthe göre
            {
              _lastWidth = _targetWidth;

              _lastHeight = Convert.ToInt32(_targetWidth / _OrjiRatio);
            }

            _processedPhoto = new Bitmap(_lastWidth, _lastHeight);
            grafik = Graphics.FromImage(_processedPhoto);

            grafik.SmoothingMode = SmoothingMode.HighQuality;
            grafik.CompositingQuality = CompositingQuality.HighQuality;
            grafik.InterpolationMode = InterpolationMode.Default;
            grafik.PixelOffsetMode = PixelOffsetMode.HighQuality;

            var codec = ImageCodecInfo.GetImageEncoders();
            var eParams = new EncoderParameters(1);
            eParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 85L);

            grafik.DrawImage(originalImage, 0, 0, _lastWidth, _lastHeight);

            GC.Collect();

            var _processedPhotoWidth = _processedPhoto.Width;

            var _processedPhotoHeight = _processedPhoto.Height;

            var _ortWidth = Convert.ToInt32((_processedPhoto.Width - _targetWidth) / 2);

            var _ortHeight = Convert.ToInt32((_processedPhoto.Height - _targetHeight) / 2);

            var sourceRectangle = new Rectangle(_ortWidth, _ortHeight, _targetWidth, _targetHeight);

            if (destinationRectangle == null)
            {
              destinationRectangle = new Rectangle(Point.Empty, sourceRectangle.Size);
            }

            var croppedImage = new Bitmap(destinationRectangle.Value.Width, destinationRectangle.Value.Height);

            using (var graphics = Graphics.FromImage(croppedImage))
            {
              graphics.DrawImage(_processedPhoto, destinationRectangle.Value, sourceRectangle, GraphicsUnit.Pixel);
            }

            croppedImage.Save(path, codec[imageType], eParams);

            GC.Collect();
          }
        }
      }
      catch (Exception)
      {
        throw;
      }
    }
     public static string GetUniqueKey(int maxSize)
    {
      char[] chars = new char[62];
      chars =
      "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
      byte[] data = new byte[1];
      using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
      {
        crypto.GetNonZeroBytes(data);
        data = new byte[maxSize];
        crypto.GetNonZeroBytes(data);
      }
      StringBuilder result = new StringBuilder(maxSize);
      foreach (byte b in data)
      {
        result.Append(chars[b % (chars.Length)]);
      }
      return result.ToString();
    }
     public static string PhotoTitle(string Title)
    {
      try
      {
        Title = Regex.Replace(Title, @"[ ]{2,}", "-");
        Title = Regex.Replace(Title, @"(\|@|&|'|\(|\)|<|>|#|)", "").Replace("?", "").ToLower();

        Title = Title.Replace("ç", "c").
            Replace("ş", "s").
            Replace("ğ", "g").
            Replace("ı", "i").
            Replace("ö", "o").
            Replace("ü", "u").
            Replace(" ", "-").Replace("+", "");
      }
      catch (Exception)
      {
      }

      return Title;
    }

  }
}

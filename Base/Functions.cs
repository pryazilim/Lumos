using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

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
            var data = JsonConvert.DeserializeObject<GeneralModel.CaptchaModel>(jsonResponse);
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

    public static void SetLangCookie(string lang)
    {
      var _date = DateTime.Now.AddDays(30);

      // HttpContext.Current.Response.Cookies.Add(new HttpCookie("lang") // ID
      // {
      //   Expires = _date,
      //   HttpOnly = true,
      //   Value = lang
      // });
    }
// TODO://soru
    //  public static long AdminUserID()
    // {
    //   try
    //   {
    //     var idc = HttpContext.Current.Request.Cookies["__of"];
    //     var usc = HttpContext.Current.Request.Cookies["__yb"];
    //     var vidc = HttpContext.Current.Request.Cookies["__ks"];
    //     var vusc = HttpContext.Current.Request.Cookies["__df"];

    //     long _userId = Convert.ToInt64(CookieDecoder(idc.Value));

    //     var UserArray = Statics.getAdminValues().Select(x => x.Id).ToList();

    //     if (UserArray.Contains(Convert.ToInt32(_userId)))
    //     {
    //       if (idc.Expires < DateTime.Now)
    //       {
    //         if (_userId == Convert.ToInt64(VerifyCookieDecoder(vidc.Value)))
    //         {
    //           if (CookieDecoder(usc.Value) != VerifyCookieDecoder(vusc.Value))
    //             return -1;
    //         }
    //         else
    //         {
    //           return -1;
    //         }
    //         return _userId;
    //       }
    //     }
    //     else
    //     {
    //       return -1;
    //     }

    //     return -1;
    //   }
    //   catch (Exception)
    //   {
    //     return -1;
    //   }
    // }

    // public static string AdminUsername()
    // {
    //   try
    //   {
    //     var usc = HttpContext.Current.Request.Cookies["__yb"];
    //     var vusc = HttpContext.Current.Request.Cookies["__df"];
    //     string _un = CookieDecoder(usc.Value);

    //     if (_un == VerifyCookieDecoder(vusc.Value))
    //       return _un;
    //     else
    //       return string.Empty;
    //   }
    //   catch (Exception)
    //   {
    //     return string.Empty;
    //   }
    // }

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
        using (RijndaelManaged symmetricKey = new RijndaelManaged())
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
        using (RijndaelManaged symmetricKey = new RijndaelManaged())
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

  }
}

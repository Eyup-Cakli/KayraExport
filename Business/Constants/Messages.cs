using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants;

public class Messages
{
    public static string Added = "Ekleme işlemi başarılı.";
    public static string Deleted = "Silme işlemi başarılı.";
    public static string Updated = "Güncelleme işlemi başarılı.";

    public static string InvalidAdd = "Ekleme işlemi başarısız.";
    public static string InvalidUpdate = "Güncelleme işlemi başarısız.";
    public static string InvalidDelete = "Silme işlemi başarısız.";

    public static string NameInvalid = "Geçersiz isim.";
    public static string IdInvalid = "Geçersiz ID.";

    public static string MaintananceTime = "Sistem bakımda.";
    public static string Listed = "Listelendi.";

    public static string ProductNameAlreadyExists = "Bu isimde zaten bir ürün kaydı bulunmakta.";
    public static string EmailFieldAlreadyExists = "Bu isimde zaten bir email kaydı bulunmakta.";

    public static string ImageUploaded = "Resim başarıyla yüklendi.";
    public static string ImageDeleted = "Resim başarıyla silindi.";
    public static string ImageUpdated = "Resim başarıyla güncellendi.";

    public static string ProductNotExists = "Ürün bulunamadı.";
    public static string UserNotExists = "Kullanıcı bulunamadı.";
    public static string AuthorizationDenied = "Yetkiniz yok.";

    public static string AccessTokenCreated = "Token oluşturuldu.";
    public static string UserRegistered = "Kayıt oldu.";
    public static string UserNotFound = "Kullanıcı bulunamadı.";
    public static string UserAlreadyExists = "Böyle bir kullanıcı adı zaten kayırlı.";
    public static string PasswordError = "Hatalı şifre.";
    public static string SuccessfulLogin = "Giriş işlemi başarılı.";

    public static string UpdateSuccessful = "Güncelleme işlemi başarılı.";
}

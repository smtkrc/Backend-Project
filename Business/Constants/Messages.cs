using GeneralClass.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Süre hatası";
        public static string ProductListed = "Ürünler listelendi";
        public static string ProductCountOfCategoryError="Ürün kategorisi 10 dan fazla olamaz...";
        public static string ProductNameErrorExists="Bu isimde ürün zaten var...";
        public static string CategoryLimitExceded="Kategori limiti aşıldı...";
        public static string AuthorizationDenied="Yetkiniz yok...";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Şifre Hatalı";
        public static string SuccessfulLogin="Giriş Başarılı";
        public static string UserAlreadyExists="Kullanıcı çıkış yaptı";
        public static string AccessTokenCreated="Token oluşturuldu";
        public static string UserRegistered="Kullanıcı kaydedildi";
    }
}

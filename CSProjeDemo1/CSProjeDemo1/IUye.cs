using System;
using System.Collections.Generic;

namespace CSProjeDemo1
{
    /// <summary>
    /// Üye işlemlerini tanımlayan arayüz
    /// </summary>
    public interface IUye
    {
        /// <summary>
        /// Üyenin adı
        /// </summary>
        string Ad { get; set; }

        /// <summary>
        /// Üyenin soyadı
        /// </summary>
        string Soyad { get; set; }

        /// <summary>
        /// Üyenin TC kimlik numarası
        /// </summary>
        string TCNO { get; set; }

        /// <summary>
        /// Üyenin üyelik numarası
        /// </summary>
        string UyeNo { get; set; }

        /// <summary>
        /// Üyelik başlangıç tarihi
        /// </summary>
        DateTime UyelikTarihi { get; set; }

        /// <summary>
        /// Üyenin iletişim numarası
        /// </summary>
        string Telefon { get; set; }

        /// <summary>
        /// Üyenin e-posta adresi
        /// </summary>
        string Eposta { get; set; }

        /// <summary>
        /// Üyenin ödünç aldığı kitapların listesi
        /// </summary>
        List<Kitap> OduncAlinanKitaplar { get; }

        /// <summary>
        /// Kitap ödünç alma
        /// </summary>
        /// <param name="kitap">Ödünç alınacak kitap</param>
        /// <returns>İşlem başarılı ise true, değilse false</returns>
        bool KitapOduncAl(Kitap kitap);

        /// <summary>
        /// Kitap iade etme
        /// </summary>
        /// <param name="kitap">İade edilecek kitap</param>
        /// <returns>İşlem başarılı ise true, değilse false</returns>
        bool KitapIadeEt(Kitap kitap);

        /// <summary>
        /// Ödünç alınan kitapları listeler
        /// </summary>
        /// <returns>Ödünç alınan kitapların listesi</returns>
        List<Kitap> OduncAlinanKitaplariGoruntule();

        /// <summary>
        /// Üye bilgilerini gösterir
        /// </summary>
        /// <returns>Üye bilgileri</returns>
        string UyeBilgileriniGoruntule();
    }
} 
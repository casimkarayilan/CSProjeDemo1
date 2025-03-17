using System;
using System.Collections.Generic;

namespace CSProjeDemo1
{
    /// <summary>
    /// Kütüphane üyesini temsil eden sınıf
    /// </summary>
    public class Uye : IUye
    {
        /// <summary>
        /// Üyenin adı
        /// </summary>
        public string Ad { get; set; }

        /// <summary>
        /// Üyenin soyadı
        /// </summary>
        public string Soyad { get; set; }

        /// <summary>
        /// Üyenin TC kimlik numarası
        /// </summary>
        public string TCNO { get; set; }

        /// <summary>
        /// Üyenin üyelik numarası
        /// </summary>
        public string UyeNo { get; set; }

        /// <summary>
        /// Üyelik başlangıç tarihi
        /// </summary>
        public DateTime UyelikTarihi { get; set; }

        /// <summary>
        /// Üyenin iletişim numarası
        /// </summary>
        public string Telefon { get; set; }

        /// <summary>
        /// Üyenin e-posta adresi
        /// </summary>
        public string Eposta { get; set; }

        /// <summary>
        /// Üyenin ödünç aldığı kitapların listesi
        /// </summary>
        private List<Kitap> oduncKitaplar;

        /// <summary>
        /// Ödünç alınan kitapların listesine erişim property'si
        /// </summary>
        public List<Kitap> OduncAlinanKitaplar { get { return oduncKitaplar; } }

        /// <summary>
        /// Üye constructor
        /// </summary>
        /// <param name="ad">Üyenin adı</param>
        /// <param name="soyad">Üyenin soyadı</param>
        /// <param name="tcno">TC kimlik numarası</param>
        /// <param name="telefon">Telefon numarası</param>
        /// <param name="eposta">E-posta adresi</param>
        public Uye(string ad, string soyad, string tcno, string telefon, string eposta)
        {
            Ad = ad;
            Soyad = soyad;
            TCNO = tcno;
            UyeNo = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(); // Rastgele üye no
            UyelikTarihi = DateTime.Now;
            Telefon = telefon;
            Eposta = eposta;
            oduncKitaplar = new List<Kitap>();
        }

        /// <summary>
        /// Kitap ödünç alma
        /// </summary>
        /// <param name="kitap">Ödünç alınacak kitap</param>
        /// <returns>İşlem başarılı ise true, değilse false</returns>
        public bool KitapOduncAl(Kitap kitap)
        {
            // Kitap ödünç alınabilir mi?
            if (kitap.KitapDurumu != Durum.OduncAlabilir)
            {
                return false;
            }

            // Ödünç al
            if (kitap.OduncAl(DateTime.Now, DateTime.Now.AddDays(15)))
            {
                oduncKitaplar.Add(kitap);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Kitap iade etme
        /// </summary>
        /// <param name="kitap">İade edilecek kitap</param>
        /// <returns>İşlem başarılı ise true, değilse false</returns>
        public bool KitapIadeEt(Kitap kitap)
        {
            // Kitap bu üyede mi?
            bool bulundu = false;
            foreach (var k in oduncKitaplar)
            {
                if (k == kitap)
                {
                    bulundu = true;
                    break;
                }
            }
            
            if (!bulundu)
                return false;

            // İade et
            if (kitap.IadeEt())
            {
                oduncKitaplar.Remove(kitap);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Ödünç alınan kitapları listeler
        /// </summary>
        /// <returns>Ödünç alınan kitapların listesi</returns>
        public List<Kitap> OduncAlinanKitaplariGoruntule()
        {
            return oduncKitaplar;
        }

        /// <summary>
        /// Üye bilgilerini gösterir
        /// </summary>
        /// <returns>Üye bilgileri</returns>
        public string UyeBilgileriniGoruntule()
        {
            return $"Üye No: {UyeNo}, Ad: {Ad}, Soyad: {Soyad}, " +
                   $"TC: {TCNO}, Üyelik: {UyelikTarihi.ToShortDateString()}, " +
                   $"Tel: {Telefon}, E-posta: {Eposta}, " +
                   $"Ödünç kitap sayısı: {oduncKitaplar.Count}";
        }

        /// <summary>
        /// Ödünç alınan kitapların detaylarını gösterir
        /// </summary>
        /// <returns>Kitap bilgileri</returns>
        public string KitapBilgileriniGoster()
        {
            if (oduncKitaplar.Count == 0)
            {
                return "Ödünç kitap yok";
            }

            string sonuc = "";
            foreach (var kitap in oduncKitaplar)
            {
                sonuc += kitap.BilgileriGoruntule() + "\n";
            }

            return sonuc;
        }
    }
} 
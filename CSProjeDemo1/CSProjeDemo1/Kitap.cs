using System;

namespace CSProjeDemo1
{
    /// <summary>
    /// Kitapların temel özelliklerini içeren abstract sınıf
    /// </summary>
    public abstract class Kitap
    {
        /// <summary>
        /// Kitabın ISBN numarası
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// Kitabın başlığı
        /// </summary>
        public string Baslik { get; set; }

        /// <summary>
        /// Kitabın yazarı
        /// </summary>
        public string Yazar { get; set; }

        /// <summary>
        /// Kitabın yayın yılı
        /// </summary>
        public int YayinYili { get; set; }

        /// <summary>
        /// Kitabın mevcut durumu
        /// </summary>
        public Durum KitapDurumu { get; set; }

        /// <summary>
        /// Kitabın ödünç alındığı tarih
        /// </summary>
        public DateTime? OduncAlmaTarihi { get; set; }

        /// <summary>
        /// Kitabın iade edileceği tarih
        /// </summary>
        public DateTime? IadeTarihi { get; set; }

        /// <summary>
        /// Kitap constructor
        /// </summary>
        /// <param name="isbn">ISBN numarası</param>
        /// <param name="baslik">Kitap başlığı</param>
        /// <param name="yazar">Kitap yazarı</param>
        /// <param name="yayinYili">Yayın yılı</param>
        protected Kitap(string isbn, string baslik, string yazar, int yayinYili)
        {
            ISBN = isbn;
            Baslik = baslik;
            Yazar = yazar;
            YayinYili = yayinYili;
            KitapDurumu = Durum.OduncAlabilir; // Varsayılan olarak kitap ödünç alınabilir durumda
            OduncAlmaTarihi = null;
            IadeTarihi = null;
        }

        /// <summary>
        /// Kitap bilgilerini görüntüler
        /// </summary>
        /// <returns>Kitap bilgileri</returns>
        public virtual string BilgileriGoruntule()
        {
            return $"ISBN: {ISBN}, Başlık: {Baslik}, Yazar: {Yazar}, Yayın Yılı: {YayinYili}, Durum: {KitapDurumu}";
        }

        /// <summary>
        /// Kitabı ödünç alma işlemi
        /// </summary>
        /// <param name="oduncTarihi">Ödünç alma tarihi</param>
        /// <param name="iadeTarihi">İade tarihi</param>
        /// <returns>İşlem başarılı ise true, değilse false</returns>
        public virtual bool OduncAl(DateTime oduncTarihi, DateTime iadeTarihi)
        {
            if (KitapDurumu == Durum.OduncAlabilir)
            {
                KitapDurumu = Durum.OduncVerildi;
                OduncAlmaTarihi = oduncTarihi;
                IadeTarihi = iadeTarihi;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kitap iade işlemi
        /// </summary>
        /// <returns>İşlem başarılı ise true, değilse false</returns>
        public virtual bool IadeEt()
        {
            if (KitapDurumu == Durum.OduncVerildi)
            {
                KitapDurumu = Durum.OduncAlabilir;
                OduncAlmaTarihi = null;
                IadeTarihi = null;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kitap durumunu değiştirir
        /// </summary>
        /// <param name="yeniDurum">Yeni durum</param>
        public virtual void DurumGuncelle(Durum yeniDurum)
        {
            KitapDurumu = yeniDurum;
            if (yeniDurum != Durum.OduncVerildi)
            {
                OduncAlmaTarihi = null;
                IadeTarihi = null;
            }
        }

        /// <summary>
        /// Kitap türüne ait bilgileri döndürür
        /// </summary>
        /// <returns>Kitap türüne özgü bilgiler</returns>
        public abstract string TurBilgisiGoruntule();
    }
} 
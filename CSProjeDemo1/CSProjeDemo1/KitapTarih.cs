using System;

namespace CSProjeDemo1
{
    /// <summary>
    /// Tarih kitaplarını temsil eden sınıf
    /// </summary>
    public class KitapTarih : Kitap
    {
        /// <summary>
        /// Tarihi dönem (Antik Çağ, Orta Çağ, Modern Dönem, vb.)
        /// </summary>
        public string Donem { get; set; }

        /// <summary>
        /// Kitabın kapsadığı tarih aralığı
        /// </summary>
        public string TarihAraligi { get; set; }

        /// <summary>
        /// Coğrafi bölge
        /// </summary>
        public string CografiBolge { get; set; }

        /// <summary>
        /// Kitapta ele alınan önemli kişiler veya olaylar
        /// </summary>
        public string OnemliKisilerOlaylar { get; set; }

        /// <summary>
        /// KitapTarih constructor
        /// </summary>
        /// <param name="isbn">ISBN numarası</param>
        /// <param name="baslik">Kitap başlığı</param>
        /// <param name="yazar">Kitap yazarı</param>
        /// <param name="yayinYili">Yayın yılı</param>
        /// <param name="donem">Tarihi dönem</param>
        /// <param name="tarihAraligi">Kapsadığı tarih aralığı</param>
        /// <param name="cografiBolge">Coğrafi bölge</param>
        /// <param name="onemliKisilerOlaylar">Önemli kişiler/olaylar</param>
        public KitapTarih(string isbn, string baslik, string yazar, int yayinYili,
                          string donem, string tarihAraligi, string cografiBolge,
                          string onemliKisilerOlaylar = "") 
            : base(isbn, baslik, yazar, yayinYili)
        {
            Donem = donem;
            TarihAraligi = tarihAraligi;
            CografiBolge = cografiBolge;
            OnemliKisilerOlaylar = onemliKisilerOlaylar;
        }

        /// <summary>
        /// Tarih kitabı bilgilerini gösterir
        /// </summary>
        public override string TurBilgisiGoruntule()
        {
            string olaylar = "";
            
            if (OnemliKisilerOlaylar != "")
                olaylar = "Önemli Kişiler/Olaylar: " + OnemliKisilerOlaylar;
            else
                olaylar = "Önemli kişi/olay belirtilmemiş";
                
            return "Tür: Tarih, Dönem: " + Donem + ", Tarih: " + TarihAraligi + 
                  ", Bölge: " + CografiBolge + ", " + olaylar;
        }

        /// <summary>
        /// Kitap bilgilerini gösterir
        /// </summary>
        public override string BilgileriGoruntule()
        {
            return base.BilgileriGoruntule() + ", " + TurBilgisiGoruntule();
        }
    }
} 
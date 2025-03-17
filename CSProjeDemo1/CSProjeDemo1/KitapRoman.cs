using System;

namespace CSProjeDemo1
{
    /// <summary>
    /// Roman kitaplarını temsil eden sınıf
    /// </summary>
    public class KitapRoman : Kitap
    {
        /// <summary>
        /// Romanın türü (Polisiye, Fantastik, Bilim Kurgu, vb.)
        /// </summary>
        public string RomanTuru { get; set; }

        /// <summary>
        /// Romanın sayfa sayısı
        /// </summary>
        public int SayfaSayisi { get; set; }

        /// <summary>
        /// Romanda bir dizi/seri parçası mı?
        /// </summary>
        public bool SeriMi { get; set; }

        /// <summary>
        /// Eğer bir seri ise, serinin adı
        /// </summary>
        public string SeriAdi { get; set; }

        /// <summary>
        /// Romanda seri numarası (seri değilse 0)
        /// </summary>
        public int SeriNo { get; set; }

        /// <summary>
        /// KitapRoman constructor
        /// </summary>
        /// <param name="isbn">ISBN numarası</param>
        /// <param name="baslik">Kitap başlığı</param>
        /// <param name="yazar">Kitap yazarı</param>
        /// <param name="yayinYili">Yayın yılı</param>
        /// <param name="romanTuru">Romanın türü</param>
        /// <param name="sayfaSayisi">Sayfa sayısı</param>
        /// <param name="seriMi">Seri parçası mı?</param>
        /// <param name="seriAdi">Seri adı</param>
        /// <param name="seriNo">Serideki numarası</param>
        public KitapRoman(string isbn, string baslik, string yazar, int yayinYili, 
                          string romanTuru, int sayfaSayisi, bool seriMi = false, 
                          string seriAdi = "", int seriNo = 0) 
            : base(isbn, baslik, yazar, yayinYili)
        {
            RomanTuru = romanTuru;
            SayfaSayisi = sayfaSayisi;
            SeriMi = seriMi;
            SeriAdi = seriAdi;
            SeriNo = seriNo;
        }

        /// <summary>
        /// Roman kitabı bilgilerini gösterir
        /// </summary>
        public override string TurBilgisiGoruntule()
        {
            string seri = "";
            
            if (SeriMi)
                seri = "Seri: " + SeriAdi + ", No: " + SeriNo;
            else
                seri = "Seri değil";
            
            return "Tür: Roman, Kategori: " + RomanTuru + ", Sayfa: " + SayfaSayisi + ", " + seri;
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
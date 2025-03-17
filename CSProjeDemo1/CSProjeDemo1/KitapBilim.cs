using System;

namespace CSProjeDemo1
{
    /// <summary>
    /// Bilim kitaplarını temsil eden sınıf
    /// </summary>
    public class KitapBilim : Kitap
    {
        /// <summary>
        /// Bilim alanı (Fizik, Kimya, Biyoloji, vb.)
        /// </summary>
        public string BilimAlani { get; set; }

        /// <summary>
        /// Kitabın bilimsel dizini (varsa)
        /// </summary>
        public string BilimselDizin { get; set; }

        /// <summary>
        /// Akademik kitap mı?
        /// </summary>
        public bool AkademikMi { get; set; }

        /// <summary>
        /// KitapBilim constructor
        /// </summary>
        /// <param name="isbn">ISBN numarası</param>
        /// <param name="baslik">Kitap başlığı</param>
        /// <param name="yazar">Kitap yazarı</param>
        /// <param name="yayinYili">Yayın yılı</param>
        /// <param name="bilimAlani">Bilim alanı</param>
        /// <param name="bilimselDizin">Bilimsel dizin</param>
        /// <param name="akademikMi">Akademik kitap mı?</param>
        public KitapBilim(string isbn, string baslik, string yazar, int yayinYili, 
                           string bilimAlani, string bilimselDizin = "", bool akademikMi = false) 
            : base(isbn, baslik, yazar, yayinYili)
        {
            BilimAlani = bilimAlani;
            BilimselDizin = bilimselDizin;
            AkademikMi = akademikMi;
        }

        /// <summary>
        /// Bilim kitabı bilgilerini gösterir
        /// </summary>
        public override string TurBilgisiGoruntule()
        {
            string akademikDurum = AkademikMi ? "Akademik" : "Akademik Değil";
            string dizin = "";
            
            if (BilimselDizin != "")
                dizin = "Dizin: " + BilimselDizin;
            else
                dizin = "Dizin yok";
            
            return "Tür: Bilim, Alan: " + BilimAlani + ", " + dizin + ", " + akademikDurum;
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
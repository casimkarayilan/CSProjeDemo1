using System;
using System.Collections.Generic;
using System.Linq;

namespace CSProjeDemo1
{
    /// <summary>
    /// Kütüphane sisteminin ana sınıfı
    /// </summary>
    public class Kutuphane
    {
        /// <summary>
        /// Kütüphanenin adı
        /// </summary>
        public string Ad { get; private set; }

        /// <summary>
        /// Kütüphanenin adresi
        /// </summary>
        public string Adres { get; set; }

        /// <summary>
        /// Kütüphanedeki tüm kitapların listesi
        /// </summary>
        private List<Kitap> kitapListesi;

        /// <summary>
        /// Kütüphanenin tüm üyelerinin listesi
        /// </summary>
        private List<Uye> uyeListesi;

        /// <summary>
        /// Kitapların listesine salt okunur erişim
        /// </summary>
        public List<Kitap> Kitaplar 
        { 
            get { return kitapListesi; }
        }

        /// <summary>
        /// Üyelerin listesine salt okunur erişim
        /// </summary>
        public List<Uye> Uyeler 
        { 
            get { return uyeListesi; }
        }

        /// <summary>
        /// Kutuphane constructor
        /// </summary>
        /// <param name="ad">Kütüphanenin adı</param>
        /// <param name="adres">Kütüphanenin adresi</param>
        public Kutuphane(string ad, string adres)
        {
            Ad = ad;
            Adres = adres;
            kitapListesi = new List<Kitap>();
            uyeListesi = new List<Uye>();
        }

        #region Kitap İşlemleri

        /// <summary>
        /// Kütüphaneye yeni kitap ekler
        /// </summary>
        /// <param name="k">Eklenecek kitap</param>
        public void KitapEkle(Kitap k)
        {
            foreach(var kitap in kitapListesi)
            {
                if(kitap.ISBN == k.ISBN)
                {
                    throw new Exception($"Bu ISBN zaten var: {k.ISBN}");
                }
            }

            kitapListesi.Add(k);
        }

        /// <summary>
        /// Kütüphaneden kitap siler
        /// </summary>
        /// <param name="isbn">Silinecek kitabın ISBN'i</param>
        /// <returns>İşlem başarılı ise true, değilse false</returns>
        public bool KitapSil(string isbn)
        {
            var silinecekKitap = null as Kitap;
            
            foreach(var k in kitapListesi)
            {
                if(k.ISBN == isbn)
                {
                    silinecekKitap = k;
                    break;
                }
            }
            
            if(silinecekKitap == null)
                return false;
                
            if(silinecekKitap.KitapDurumu == Durum.OduncVerildi)
                return false;
                
            return kitapListesi.Remove(silinecekKitap);
        }

        /// <summary>
        /// ISBN numarasına göre kitap arar
        /// </summary>
        /// <param name="isbn">Aranacak ISBN</param>
        /// <returns>Bulunan kitap veya null</returns>
        public Kitap KitapBul(string isbn)
        {
            foreach(var k in kitapListesi)
            {
                if(k.ISBN == isbn)
                    return k;
            }
            return null;
        }

        /// <summary>
        /// Kitap başlığına göre kitapları arar
        /// </summary>
        /// <param name="baslik">Aranacak başlık</param>
        /// <returns>Bulunan kitapların listesi</returns>
        public List<Kitap> BasliklaKitapAra(string baslik)
        {
            var sonuc = new List<Kitap>();
            
            foreach(var k in kitapListesi)
            {
                if(k.Baslik.ToLower().Contains(baslik.ToLower()))
                    sonuc.Add(k);
            }
            
            return sonuc;
        }

        /// <summary>
        /// Yazara göre kitapları arar
        /// </summary>
        /// <param name="yazar">Aranacak yazar</param>
        /// <returns>Bulunan kitapların listesi</returns>
        public List<Kitap> YazarlaKitapAra(string yazar)
        {
            var sonuc = new List<Kitap>();
            
            foreach(var k in kitapListesi)
            {
                if(k.Yazar.ToLower().Contains(yazar.ToLower()))
                    sonuc.Add(k);
            }
            
            return sonuc;
        }

        /// <summary>
        /// Kitabın durumunu günceller
        /// </summary>
        /// <param name="isbn">Kitabın ISBN'i</param>
        /// <param name="yeniDurum">Yeni durum</param>
        /// <returns>İşlem başarılı ise true, değilse false</returns>
        public bool DurumGuncelle(string isbn, Durum yeniDurum)
        {
            var kitap = KitapBul(isbn);
            
            if(kitap == null)
                return false;
                
            kitap.DurumGuncelle(yeniDurum);
            return true;
        }

        /// <summary>
        /// Belirli bir türdeki kitapları listeler
        /// </summary>
        /// <typeparam name="T">Kitap türü</typeparam>
        /// <returns>Bulunan kitapların listesi</returns>
        public List<T> TurListele<T>() where T : Kitap
        {
            var sonuc = new List<T>();
            
            foreach(var k in kitapListesi)
            {
                if(k is T)
                    sonuc.Add((T)k);
            }
            
            return sonuc;
        }

        /// <summary>
        /// Mevcut duruma göre kitapları listeler
        /// </summary>
        /// <param name="durum">Aranacak durum</param>
        /// <returns>Bulunan kitapların listesi</returns>
        public List<Kitap> DurumaGoreListele(Durum d)
        {
            var sonuc = new List<Kitap>();
            
            foreach(var k in kitapListesi)
            {
                if(k.KitapDurumu == d)
                    sonuc.Add(k);
            }
            
            return sonuc;
        }

        #endregion

        #region Üye İşlemleri

        /// <summary>
        /// Kütüphaneye yeni üye ekler
        /// </summary>
        /// <param name="u">Eklenecek üye</param>
        public void UyeEkle(Uye u)
        {
            foreach(var uye in uyeListesi)
            {
                if(uye.TCNO == u.TCNO)
                {
                    throw new Exception($"Bu TC no zaten var: {u.TCNO}");
                }
            }

            uyeListesi.Add(u);
        }

        /// <summary>
        /// Kütüphaneden üye siler
        /// </summary>
        /// <param name="tcNo">Silinecek üyenin TC numarası</param>
        /// <returns>İşlem başarılı ise true, değilse false</returns>
        public bool UyeSil(string tcNo)
        {
            var silinecekUye = null as Uye;
            
            foreach(var u in uyeListesi)
            {
                if(u.TCNO == tcNo)
                {
                    silinecekUye = u;
                    break;
                }
            }
            
            if(silinecekUye == null)
                return false;
                
            if(silinecekUye.OduncAlinanKitaplar.Count > 0)
                return false;
                
            return uyeListesi.Remove(silinecekUye);
        }

        /// <summary>
        /// TC numarasına göre üye arar
        /// </summary>
        /// <param name="tcNo">Aranacak TC</param>
        /// <returns>Bulunan üye veya null</returns>
        public Uye TCNoIleUyeBul(string tcNo)
        {
            foreach(var u in uyeListesi)
            {
                if(u.TCNO == tcNo)
                    return u;
            }
            return null;
        }

        /// <summary>
        /// Üye numarasına göre üye arar
        /// </summary>
        /// <param name="uyeNo">Aranacak üye numarası</param>
        /// <returns>Bulunan üye veya null</returns>
        public Uye UyeNoBul(string uyeNo)
        {
            foreach(var u in uyeListesi)
            {
                if(u.UyeNo == uyeNo)
                    return u;
            }
            return null;
        }

        /// <summary>
        /// İsim ve soyisime göre üyeleri arar
        /// </summary>
        /// <param name="ad">Aranacak ad</param>
        /// <param name="soyad">Aranacak soyad</param>
        /// <returns>Bulunan üyelerin listesi</returns>
        public List<Uye> IsimleUyeAra(string isim, string soyad = "")
        {
            var sonuc = new List<Uye>();
            
            foreach(var u in uyeListesi)
            {
                if(string.IsNullOrEmpty(soyad))
                {
                    if(u.Ad.ToLower().Contains(isim.ToLower()))
                        sonuc.Add(u);
                }
                else
                {
                    if(u.Ad.ToLower().Contains(isim.ToLower()) && u.Soyad.ToLower().Contains(soyad.ToLower()))
                        sonuc.Add(u);
                }
            }
            
            return sonuc;
        }

        #endregion

        #region Ödünç Verme ve İade İşlemleri

        /// <summary>
        /// Üyeye kitap ödünç verir
        /// </summary>
        /// <param name="uyeNo">Üye numarası</param>
        /// <param name="isbn">Kitap ISBN'i</param>
        /// <returns>İşlem başarılı ise true, değilse false</returns>
        public bool OduncVer(string uyeNo, string isbn)
        {
            var uye = UyeNoBul(uyeNo);
            var kitap = KitapBul(isbn);
            
            if(uye == null || kitap == null)
                return false;
                
            return uye.KitapOduncAl(kitap);
        }

        /// <summary>
        /// Üyeden kitap iadesi alır
        /// </summary>
        /// <param name="uyeNo">Üye numarası</param>
        /// <param name="isbn">Kitap ISBN'i</param>
        /// <returns>İşlem başarılı ise true, değilse false</returns>
        public bool IadeAl(string uyeNo, string isbn)
        {
            var uye = UyeNoBul(uyeNo);
            var kitap = KitapBul(isbn);
            
            if(uye == null || kitap == null)
                return false;
                
            return uye.KitapIadeEt(kitap);
        }

        #endregion

        #region Raporlama İşlemleri

        /// <summary>
        /// Kütüphane istatistikleri görüntüler
        /// </summary>
        /// <returns>Kütüphane istatistikleri</returns>
        public string IstatistikGoster()
        {
            int toplamKitap = kitapListesi.Count;
            int oduncKitap = 0;
            int kayipKitap = 0;
            int mevcutKitap = 0;
            
            foreach(var k in kitapListesi)
            {
                if(k.KitapDurumu == Durum.OduncVerildi)
                    oduncKitap++;
                else if(k.KitapDurumu == Durum.MevcutDegil)
                    kayipKitap++;
                else
                    mevcutKitap++;
            }
            
            return $"Kütüphane: {Ad}\n" +
                   $"Toplam kitap: {toplamKitap}\n" +
                   $"Ödünç kitap: {oduncKitap}\n" +
                   $"Kayıp kitap: {kayipKitap}\n" +
                   $"Mevcut kitap: {mevcutKitap}\n" +
                   $"Toplam üye: {uyeListesi.Count}";
        }

        /// <summary>
        /// Tüm kitapları listeler
        /// </summary>
        /// <returns>Kitap bilgilerinin listesi</returns>
        public List<string> KitaplariListele()
        {
            var list = new List<string>();
            foreach(var k in kitapListesi)
            {
                list.Add(k.BilgileriGoruntule());
            }
            return list;
        }

        /// <summary>
        /// Tüm üyeleri listeler
        /// </summary>
        /// <returns>Üye bilgilerinin listesi</returns>
        public List<string> UyeleriListele()
        {
            var list = new List<string>();
            foreach(var u in uyeListesi)
            {
                list.Add(u.UyeBilgileriniGoruntule());
            }
            return list;
        }

        /// <summary>
        /// Belirli bir üyenin ödünç aldığı kitapları listeler
        /// </summary>
        /// <param name="uyeNo">Üye numarası</param>
        /// <returns>Kitap bilgilerinin listesi</returns>
        public List<string> UyeninKitaplariniListele(string uyeNo)
        {
            var uye = UyeNoBul(uyeNo);
            var liste = new List<string>();
            
            if(uye == null || uye.OduncAlinanKitaplar.Count == 0)
                return liste;
                
            foreach(var k in uye.OduncAlinanKitaplar)
            {
                liste.Add(k.BilgileriGoruntule());
            }
            
            return liste;
        }

        #endregion
    }
} 
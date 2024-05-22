using Microsoft.VisualBasic.ApplicationServices;
using System;

namespace ndProje
{


    public partial class Form1 : Form
    {
        private List<IRandevu> randevular = new List<IRandevu>();
        List<Calisan> calisanListe;
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("Saç kesimi");
            comboBox1.Items.Add("Düz fön");
            comboBox1.Items.Add("Kýrýk fön");
            comboBox1.Items.Add("Boyatma");
            comboBox1.Items.Add("Rasta");
            comboBox1.Items.Add("Manikür/Pedikür");
            comboBox1.Items.Add("Protez Týrnak");
            comboBox1.Items.Add("Ýpek kirpik");
            comboBox1.Items.Add("Microblading");
            comboBox1.Items.Add("Keratin Bakým");
            calisanlar = LoadPersonelFromFile();


            listBox1.Items.Clear();
            using (StreamReader sr = new StreamReader("C:\\Users\\emird\\source\\repos\\ndProje\\randevu.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listBox1.Items.Add(line);
                }
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hizmetin ücretini göster
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Saç kesimi":
                    tutar.Text = "50TL";
                    break;
                case "Düz fön":
                    tutar.Text = "30TL";
                    break;
                case "Kýrýk fön":
                    tutar.Text = "40TL";
                    break;
                case "Boyatma":
                    tutar.Text = "100TL";
                    break;
                case "Rasta":
                    tutar.Text = "200TL";
                    break;
                case "Manikür/Pedikür":
                    tutar.Text = "60TL";
                    break;
                case "Protez Týrnak":
                    tutar.Text = "150TL";
                    break;
                case "Ýpek kirpik":
                    tutar.Text = "80TL";
                    break;
                case "Microblading":
                    tutar.Text = "200TL";
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri
            {
                ad = textBox1.Text,
                soyad = textBox2.Text,
                telefon = textBox3.Text
            };
            Calisan calisan = new Calisan
            {
                ad = "",
                soyad = "",
                telefon = "" 
            };
            Randevu randevu = new Randevu
            {
                RandevuTarih = dateTimePicker1.Value,
                hizmet = comboBox1.SelectedItem.ToString(),
                Musteri = musteri,
                Calisan = calisan
            };
            randevular.Add(randevu);

            // Müþteri adý ve soyadý boþ olamaz
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Müþteri adý ve soyadý boþ olamaz.");
                return;
            }

            // Müþteri adý ve soyadý sadece harf içerebilir
            if (textBox1.Text.Any(char.IsDigit) || textBox2.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Müþteri adý ve soyadý sadece harf içerebilir.");
                return;
            }

            DateTime randevuTarihi = dateTimePicker1.Value;
            string adSoyad = $"{textBox1.Text} {textBox2.Text}";
            string randevuBilgisi = $"{randevuTarihi}: {adSoyad} - {comboBox1.SelectedItem}";


            // Randevu tarihi bugünden önce olamaz
            if (randevuTarihi <= DateTime.Today)
            {
                MessageBox.Show("Randevu tarihi bugünden önce olamaz.");
                return;
            }

            // Pazar günü randevu alýnamaz
            if (randevuTarihi.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Pazar günü randevu alýnamaz.");
                return;
            }

            // Randevu bilgisi listeye ekleniyor
            listBox1.Items.Add(randevuBilgisi);
            MessageBox.Show("Randevu alýndý.");


            //ayný günde en fazla 10  randevu alýnabilir
            int count = 0;
            foreach (var item in listBox1.Items)
            {
                if (item.ToString().Contains(randevuTarihi.ToString()))
                {
                    count++;
                }
            }
            if (count > 10)
            {
                MessageBox.Show("Ayný günde en fazla 10 randevu alýnabilir.");
                listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                return;
            }


            // Randevu bilgileri txt dosyasýna yazdýrýlýyor
            using (StreamWriter sw = new StreamWriter("C:\\Users\\emird\\source\\repos\\ndProje\\randevu.txt", true))
            {
                sw.WriteLine(randevuBilgisi);
            }

            // Randevu bilgileri txt dosyasýndan okunuyor
            using (StreamReader sr = new StreamReader("C:\\Users\\emird\\source\\repos\\ndProje\\randevu.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listBox1.Items.Add(line);
                }
            }

            // Randevu bilgisi listeye ekleniyor
            listBox1.Items.Add(randevuBilgisi);
            //MessageBox.Show("Randevu alýndý.");

            //txt dosyasýndaki verileri listboxa yazdýrma
            listBox1.Items.Clear();
            using (StreamReader sr = new StreamReader("C:\\Users\\emird\\source\\repos\\ndProje\\randevu.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listBox1.Items.Add(line);
                }
            }
            void LoadAppointmentsFromFile()
            {
                if (File.Exists("C:\\Users\\emird\\source\\repos\\ndProje\\randevu.txt"))
                {
                    using (StreamReader sr = new StreamReader("C:\\Users\\emird\\source\\repos\\ndProje\\randevu.txt"))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            listBox1.Items.Add(line);
                        }
                    }
                }
            }

            //txt dosyasýndaki verileri listboxa yazdýrma
            listBox1.Items.Clear();
            using (StreamReader sr = new StreamReader("C:\\Users\\emird\\source\\repos\\ndProje\\randevu.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listBox1.Items.Add(line);
                }
            }




        }

        private List<Calisan> LoadPersonelFromFile()
        {
            var calisanList = new List<Calisan>();
            var lines = File.ReadAllLines("C:\\Users\\emird\\source\\repos\\ndProje\\personel.txt");
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length >= 4) // Make sure we have enough parts
                {
                    var calisan = new Calisan
                    {
                        ad = parts[0].Trim(),
                        soyad = parts[1].Trim(),
                        telefon = parts[2].Trim(),
                        kullaniciAdi = parts[3].Trim(),
                        sifre = parts[4].Trim()
                    };
                    calisanList.Add(calisan);
                }
            }
            return calisanList;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string kullaniciAdi;
            string sifre;
            BilgiAl(out kullaniciAdi, out sifre);
            if (!Kullanici(kullaniciAdi, sifre))
            {
                MessageBox.Show("Sadece Personel randevu silebilir.");
                return;
            }

            // Seçili randevuyu sil
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                MessageBox.Show("Randevu silindi.");
            }
            else
            {
                MessageBox.Show("Lütfen bir randevu seçin.");
            }
            //silinen randevuyu txt dosyasýndan da sil
            File.WriteAllText("C:\\Users\\emird\\source\\repos\\ndProje\\randevu.txt", string.Empty);
            using (StreamWriter sw = new StreamWriter("C:\\Users\\emird\\source\\repos\\ndProje\\randevu.txt", true))
            {
                foreach (var item in listBox1.Items)
                {
                    sw.WriteLine(item.ToString());
                }
            }

        }
        private void BilgiAl(out string kullaniciAdi, out string sifre)
        {
            giris giris = new giris();
            giris.ShowDialog();
            kullaniciAdi = giris.KullaniciAdi;
            sifre = giris.Sifre;
        }


        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string kullaniciAdi;
            string sifre;
            BilgiAl(out kullaniciAdi, out sifre);

            if (!Kullanici(kullaniciAdi, sifre))
            {
                MessageBox.Show("Sadece personel randevu guncelleyebilir.");
                return;
            }
            //seçili randevu bilgilerini güncelle
            if (listBox1.SelectedIndex != -1)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Müþteri adý ve soyadý boþ olamaz.");
                    return;
                }

                if (textBox1.Text.Any(char.IsDigit) || textBox2.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Müþteri adý ve soyadý sadece harf içerebilir.");
                    return;
                }

                DateTime randevuTarihi = dateTimePicker1.Value;
                string adSoyad = $"{textBox1.Text} {textBox2.Text}";
                string randevuBilgisi = $"{randevuTarihi}: {adSoyad} - {comboBox1.SelectedItem}";

                if (randevuTarihi <= DateTime.Today)
                {
                    MessageBox.Show("Randevu tarihi bugünden önce olamaz.");
                    return;
                }

                if (randevuTarihi.DayOfWeek == DayOfWeek.Sunday)
                {
                    MessageBox.Show("Pazar günü randevu alýnamaz.");
                    return;
                }

                listBox1.Items[listBox1.SelectedIndex] = randevuBilgisi;
                MessageBox.Show("Randevu güncellendi.");

                File.WriteAllText("C:\\Users\\emird\\source\\repos\\ndProje\\randevu.txt", string.Empty);
                using (StreamWriter sw = new StreamWriter("C:\\Users\\emird\\source\\repos\\ndProje\\randevu.txt", true))
                {
                    foreach (var item in listBox1.Items)
                    {
                        sw.WriteLine(item.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir randevu seçin.");
            }
        }
        private bool Kullanici(string kullaniciAdi, string sifre)
        {
    return calisanlar.Any(p => p.kullaniciAdi == kullaniciAdi && p.sifre == sifre);
        }

        List<Calisan> calisanlar = new List<Calisan>();


        private void personelButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Ad,soyad veya telefon alani bos birakilamaz.");
                return;
            }

            if (textBox3.Text.Length != 10)
            {
                MessageBox.Show("telefon numarasi 10 haneli olmalidir.");
                return;
            }


            if (!textBox3.Text.All(char.IsDigit))
            {
                MessageBox.Show("Telefon alani yanlizca sayi icerebilir.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Kullanici adi veya sifre alani bos birakilamaz.");
                return;
            }

            if (textBox4.Text.Length < 5 || textBox5.Text.Length < 5)
            {
                MessageBox.Show("Kullanici adi ve sifre en az 5 karakter olmalidir.");
                return;
            }

            Calisan calisan = new Calisan
            {
                ad = textBox1.Text,
                soyad = textBox2.Text,
                telefon = textBox3.Text ,
                kullaniciAdi = textBox4.Text, 
                sifre = textBox5.Text 
            };

            calisanlar.Add(calisan);

            WritePersonnelToFile(calisan);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            MessageBox.Show("Personel eklendi.");
        }
        private void WritePersonnelToFile(Calisan calisan)
        {
            using (StreamWriter sw = new StreamWriter("C:\\Users\\emird\\source\\repos\\ndProje\\personel.txt", true))
            {
                sw.WriteLine($"{calisan.ad}, {calisan.soyad}, {calisan.telefon}, {calisan.kullaniciAdi}, {calisan.sifre}");
            }
        }

    }
    public class Kisi
    {
        public string ad { get; set; }
        public string soyad { get; set; }
        public string telefon { get; set; }
    }
    public class Calisan : Kisi
    {
        public string kullaniciAdi { get; set; }
        public string sifre { get; set; }

    }
    public class Musteri : Kisi
    {
    }
    public interface IRandevu
    {
        DateTime RandevuTarih { get; set; }
        string hizmet { get; set; }
        Musteri Musteri { get; set; }
        Calisan Calisan { get; set; }
    }
    public class Randevu : IRandevu
    {
        public DateTime RandevuTarih { get; set; }
        public string hizmet { get; set; }
        public Musteri Musteri { get; set; }
        public Calisan Calisan { get; set; }
    }
}
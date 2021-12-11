using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace PrimeSwingFactorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void ChangeSize(int width, int height)// bu methodu girilen değerin sonucunun büyüklüğüne göre form çerçevesinin boyutlarını ayarlamak için oluşturdum.
        {
            this.Size = new Size(width, height);
        }
        private void txtGiris_KeyPress(object sender, KeyPressEventArgs e)//burayı girilecek değerin sadece rakam olması için oluşturdum.
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '-' && e.KeyChar != '+')
            {
                e.Handled = true;
            }
            
        }
        private void txtGiris_KeyDown(object sender, KeyEventArgs e)//burayı enter a basınca button a otomatik tıklasın diye oluşturdum.
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnHesapla_Click(sender, e);
            }
        }
        public void btnHesapla_Click(object sender, EventArgs e)
        {
            Islemler();
            
        }
        public void Islemler()
        {
            Form1 f1 = new Form1();
            ChangeSize(f1.Size.Width, f1.Size.Height);
            string input = txtGiris.Text;                        //texte gelen mesaj string olduğu için input ve output adında 
            BigInteger output = new BigInteger();                //iki değişken oluşturup string i integer a çevirdim.
            BigInteger result = new BigInteger();
            if (input == "") //kullanıcı değer girmeden buton a basarsa uyarı vermesi için oluşturduğum blok
            {
                DialogResult uyari;
                uyari = MessageBox.Show("Her hangi bir sayı girilmedi!!\nLütfen pozitif bir sayı giriniz.", "Uyarı Ekranı");
            }
            else
            {
                output = Convert.ToInt32(input); //kullanıcıdan aldığım text i işlem yapmak için int a dönüştürüyorum
                if (output >= 0)
                {

                    lblBilgi.Text = "( n = " + output.ToString() + " için )";
                    result = MyPrimeFactorizationSwing.Run(output);

                    if (result.ToString().Length > 34) // çıkan sonuç çok uzunsa aşağı satıra inmesi için işlemler yaptım.
                    {
                        string sonuc = "";
                        string metinsel_sonuc = result.ToString();
                        List<string> list = new List<string>();
                        int liste_uzunlugu;
                        if (metinsel_sonuc.Length % 34 == 0)
                        {
                            liste_uzunlugu = (int)(metinsel_sonuc.Length / 34);
                        }
                        else
                        {
                            liste_uzunlugu = (int)((metinsel_sonuc.Length / 34) + 1);
                        }
                        for (int i = 0; i < liste_uzunlugu; i++)
                        {
                            if (metinsel_sonuc.Length > 34)
                            {
                                list.Add(metinsel_sonuc.Substring(0, 34));
                            }
                            else
                            {
                                list.Add(metinsel_sonuc);
                                break;
                            }
                            metinsel_sonuc = metinsel_sonuc.Substring(34);
                        }

                        for (int i = 0; i < list.Count; i++)
                        {
                            sonuc += string.Concat(list[i].ToString(), "\n");
                        }
                        if (list.Count > 4)
                        {
                            int yuksekLik = (f1.Size.Height) + ((list.Count - 4) * 20);
                            ChangeSize(f1.Size.Width, yuksekLik);
                        }
                        lblsonuc.Text = sonuc;
                    }
                    else
                        lblsonuc.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Lütfen pozitif bir tam sayı giriniz ");
                }
            }


        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtGiris_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}

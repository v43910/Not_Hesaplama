using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabratuvarOdevi211103
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        string hesaplamaSonucu = "";
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            int basariNotu = 0;
            bool gectiMi = false;


            if (txtAdi.Text!=string.Empty && txtSoyadi.Text!=string.Empty)
            {
                basariNotu = (int)(Convert.ToInt16(txtVize.Text) * 0.40) + (int)(Convert.ToInt16(txtFinal.Text) * 0.60);
                hesaplamaSonucu = txtAdi.Text + " " + txtSoyadi.Text+"    "+basariNotu+"    ";
                
                switch (katsayiHesapla(basariNotu))
                {
                     case 4.0f:
                        hesaplamaSonucu += "  AA  ";
                        gectiMi = true;
                        break;
                    case 3.5f:
                        hesaplamaSonucu += "  BA  ";
                        gectiMi = true;
                        break;
                    case 3.0f:
                        hesaplamaSonucu += "  BB  ";
                        gectiMi = true;
                        break;
                    case 2.5f:
                        hesaplamaSonucu += "  CB  ";
                        gectiMi = true;
                        break;
                    case 2.0f:
                        hesaplamaSonucu += "  CC  ";
                        gectiMi = true;
                        break;
                    case 1.5f:
                        hesaplamaSonucu += "  DC  ";
                        break;
                    case 1.0f:
                        hesaplamaSonucu += "  DD  ";
                        break;
                    default:
                        hesaplamaSonucu += "  FD  ";
                        break;
                }

                if (gectiMi && Convert.ToInt16(txtDevamsizlik.Text) > 10)
                {
                    hesaplamaSonucu += "   Kaldı (Devamsızlık)";
                }
                else if (!gectiMi)
                {
                    hesaplamaSonucu += "   Kaldı (Ortalama)";
                }
                else
                {
                    hesaplamaSonucu += "   Gecti";
                }

                listBox1.Items.Add(hesaplamaSonucu);

            }
            else
            {
                MessageBox.Show("Lütfen Öğrencinin Adını Soyadını giriniz.");
            }
        }

        private float katsayiHesapla(int hesaplananNot) {
            float katsayi = 0;

            if (hesaplananNot >= 90)
            {
                katsayi = 4.0f;
            }
            else if (hesaplananNot > 84 && hesaplananNot < 90)
            {
                katsayi = 3.5f;
            }
            else if (hesaplananNot > 79 && hesaplananNot < 85)
            {
                katsayi = 3;
            }
            else if (hesaplananNot > 74 && hesaplananNot < 80)
            {
                katsayi = 2.5f;
            }
            else if (hesaplananNot > 64 && hesaplananNot < 75)
            {
                katsayi = 2;
            }
            else if (hesaplananNot > 59 && hesaplananNot < 65)
            {
                katsayi = 1.5f;
            }
            else
            {
                katsayi = 1;
            }
            return katsayi;
        }

        //sadece rakamsal girişi denetler.(txtVize, txtFinal, txtDevamsızlık) 
        private void sadeceRakam(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        //boş bırakılırsa 0 -sıfır- yazar
        private void txtVize_Leave(object sender, EventArgs e)
        {
            if (txtVize.Text==string.Empty)
            {
                txtVize.Text = "0";
            }
        }

        private void txtFinal_Leave(object sender, EventArgs e)
        {
            if (txtFinal.Text == string.Empty)
                txtFinal.Text = "0";
        }

        private void txtDevamsizlik_Leave(object sender, EventArgs e)
        {
            if (txtDevamsizlik.Text == string.Empty)
                txtDevamsizlik.Text = "0";
        }
    }
}

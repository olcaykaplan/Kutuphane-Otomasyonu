using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace _KutuphaneOtomasyonu
{
    public partial class _Kayitcs : Form
    {
        public _Kayitcs()
        {
            InitializeComponent();
        }

        private void _Kayitcs_Load(object sender, EventArgs e)
        {
            cmbSehir.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            if (txtTC.Text == "" || txtAd.Text == "" || txtSoyad.Text == "" || txtSoyad.Text == "" || txtKullaniciAdi.Text == "" || txtSifre.Text == "" || txtSifreTekrari.Text == "" || txt_eposta.Text == "" || rtxtAdres.Text == "" || cmbSehir.SelectedIndex == 0 || txtIlce.Text == "")
            {
                MessageBox.Show("Lütfen gerekli tüm bilgileri doldurunuz... ");
            }
            else
            {
                if (comboBox1.SelectedItem.ToString() == "")
                {
                    MessageBox.Show("Lütfen cinsiyetinizi belirtiniz.");
                }
                else
                {
                    if (txtGsm.Text == "" && txtEvTelefonu.Text == "")
                    {
                        MessageBox.Show("Lütfen Gsm veya Ev Telefonunuz dan\n en az birisinin bilgisini giriniz");
                    }
                    else
                    {
                        SqlConnection baglan = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
                        SqlCommand komut = new SqlCommand();
                        baglan.Open();
                        komut.Connection = baglan;
                        komut.CommandType = CommandType.StoredProcedure;
                        komut.CommandText = "MembershipInsert";
                        komut.Parameters.AddWithValue("@Uye_id", ParameterDirection.Output);
                        komut.Parameters.AddWithValue("@TC_NO", txtTC.Text);
                        komut.Parameters.AddWithValue("@Adi", txtAd.Text);
                        komut.Parameters.AddWithValue("@Soyadi", txtSoyad.Text);
                        komut.Parameters.AddWithValue("@E_Posta", txt_eposta.Text);
                        komut.Parameters.AddWithValue("@Ev_Telefonu", txtEvTelefonu.Text);
                        komut.Parameters.AddWithValue("@GSM", txtGsm.Text);
                        komut.Parameters.AddWithValue("@Adres", rtxtAdres.Text);
                        komut.Parameters.Add("@Cinsiyet", SqlDbType.Bit).Value = comboBox1.SelectedItem.ToString()== "Bay" ? true : false;
                        komut.Parameters.Add("@Admin", SqlDbType.Bit).Value = false; 
                        komut.Parameters.AddWithValue("@Kullanici_Adi", txtKullaniciAdi.Text);
                        komut.Parameters.AddWithValue("@Password", txtSifre.Text);
                        komut.Parameters.AddWithValue("@Aktif", SqlDbType.Bit).Value = true; 
                        komut.Parameters.AddWithValue("@il", txtIlce.Text);
                        komut.Parameters.AddWithValue("@ilce", cmbSehir.SelectedItem.ToString());
                        komut.ExecuteNonQuery();
                            baglan.Close();

                            MessageBox.Show("Kayıt Başarılı");
                        
                        }
                    }
                }
            }
        
            

        private void btnIptal_Click(object sender, EventArgs e)
        {
            txt_eposta.Clear();
            txtAd.Clear();
            txtEvTelefonu.Clear();
            txtGsm.Clear();
            txtIlce.Clear();
            txtKullaniciAdi.Clear();
            txtSifre.Clear();
            txtSifreTekrari.Clear();
            txtSoyad.Clear();
            rtxtAdres.Clear();
            txtTC.Clear();
            cmbSehir.SelectedIndex = 0;
            MessageBox.Show("Kayıt işlemi iptal edildi.");
            this.Hide();
            Login giris = new Login();
            giris.ShowDialog();

        }

    }
}

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


    public partial class Login : Form
    {
        public static SqlConnection baglan = null;
        public static Login pointer = null;
        public static bool isAdmin ;
        public Login()
        {
            pointer = this;

            InitializeComponent();
        

        }
        public void baglanma()
        {
            SqlConnection baglan = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
            baglan.Open();
        }
        private void Login_Load(object sender, EventArgs e)
        {
        }

        public bool loginCheck()
        {
            //olcaykaplan
            SqlDataReader dr = null;
            SqlConnection baglan = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
            baglan.Open();
            String komutString = "SELECT * from Membership WHERE Kullanici_Adi='" + txtAd.Text + "' AND Password='" + txtSifre.Text + "' ";

            SqlCommand cmd = new SqlCommand(komutString, baglan);

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return true; // LOGİN BAŞARILI
            }

            else
            {
                return false; // LOGİN BAŞARISIZ

            }
        }
        public void dogrula()
        {
            SqlConnection baglan = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
            baglan.Open();
            SqlDataReader oku = null;

            String komutString = "select * from Membership where Kullanici_Adi='" + txtAd.Text + "' AND Admin = 1 ";

            SqlCommand cmd = new SqlCommand(komutString, baglan);

            oku = cmd.ExecuteReader();

            if (oku.Read())
            {
                isAdmin = true;

            }

            else
            {
                isAdmin = false;
            }
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            _Kayitcs kayit = new _Kayitcs();
            kayit.ShowDialog();
        }


        private void btnGiris_Click(object sender, EventArgs e)
        {


            if (txtAd.Text == string.Empty && txtSifre.Text == string.Empty)
            {
                MessageBox.Show("Lütfen eksik olan giriş bilgilerinizi doldurunuz.");
            }


            else if (loginCheck()) //böyle bir kayıt olup olmadığı  var ise  burası
            {
                MessageBox.Show("Giriş Başarılı.");

                dogrula();
                pointer.Hide();
                if (isAdmin)
                {
                   

                    if (_AnaMonu.pointer == null) //eğer ilk defa açılıyorsa
                    {
                       
                        _AnaMonu form2 = new _AnaMonu();
                        form2.Show();
                        // yeni formu oluşturduk, Form2'nin pointer'ına otomatikman verilmiş oldu
                    }

                    else // eğer form2 daha önce açılmışsa
                    {
                        _AnaMonu.pointer.Show();
                    }

                }
                else
                {
                    pointer.Hide();
                    if (_AnaMonu.pointer == null) //eğer ilk defa açılıyorsa
                    {
                        
                        _AnaMonu form2 = new _AnaMonu();
                        form2.Show();
                        // yeni formu oluşturduk, Form2'nin pointer'ına otomatikman verilmiş oldu
                    }

                    else // eğer form2 daha önce açılmışsa
                    {
                        _AnaMonu.pointer.Show();
                    }
                }

            }
            else
            {

                //login yanlışsa ne yapsın, mesela:
                MessageBox.Show("Hatalı giriş!");
            }

        }
    }
}




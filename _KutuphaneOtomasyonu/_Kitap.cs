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
    public partial class _Kitap : Form
    {
        public static _Kitap pointer = null;
        public _Kitap()
        {
            pointer = this;
            InitializeComponent();
        }

        SqlConnection connenction = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        DataTable table = new DataTable();
      
        private void guncel()
        {
            table.Clear();
            SqlDataAdapter adptr = new SqlDataAdapter("select * from Books ", connenction);
            adptr.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void yazar()
        {
            SqlConnection connenction = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select yazar_adi +' '+ yazar_soyadi AS ADSOYAD, yazar_id , yazar_adi,yazar_soyadi from Author ", connenction);
            SqlDataReader read;
            connenction.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {

                cmbYazar.Items.Add(read["ADSOYAD"].ToString());
            }
            read.Close();
            connenction.Close();

        }

        private void tur()
        {
            SqlConnection connenction = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select tur_id, Tur from BooksType ", connenction);
            SqlDataReader read;
            connenction.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {

                cmbTur.Items.Add(read["Tur"].ToString());
            }
            read.Close();
            connenction.Close();
        }

        private void yayinev()
        {
            SqlConnection connenction = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select yayievi_id, Yayievi_adi from PublishingHouse", connenction);
            SqlDataReader read;
            connenction.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {

                cmYayinevi.Items.Add(read["Yayievi_adi"].ToString());
            }
            read.Close();
            connenction.Close();
        }

        private void Raf()
        {
            SqlConnection connenction = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select RafSutun+' '+ RafSatir As Raf, raf_id  from Shelves", connenction);
            SqlDataReader read;
            connenction.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {

                cmbRaf.Items.Add(read["Raf"].ToString());
            }
            read.Close();
            connenction.Close();
        }

        private void dil1()
        {
            SqlConnection connenction = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select dil_id, diller from Language", connenction);
            SqlDataReader read;
            connenction.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {

                cmbDil.Items.Add(read["diller"].ToString());
            }
            read.Close();
            connenction.Close();
         
        }

        private void cevirmen()
        {
            SqlConnection connenction = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select cevirmen_ad+' '+cevirmen_soyad as Cevirmen, cevirmen_id,cevirmen_ad,cevirmen_soyad from Translator", connenction);
            SqlDataReader read;
            connenction.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {

                cmbCevirmen.Items.Add(read["Cevirmen"].ToString());
            }
            read.Close();
            connenction.Close();
        }

        private void _Kitap_Load(object sender, EventArgs e)
        {
            guncel();
            yazar();
            tur();
            yayinev();
            cevirmen();
            dil1();
            Raf();
        }

        private void btnGeridon_Click(object sender, EventArgs e)
        {
            this.Hide();
            _AnaMonu.pointer.Show();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            connenction.Open();
            command.Connection = connenction;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "BooksInsert";
            command.Parameters.AddWithValue("@Kitap_id", ParameterDirection.Output);
            command.Parameters.AddWithValue("@KitapBarkodu", txtKitapBarkodu.Text);
            command.Parameters.AddWithValue("@KitapAdi", txtKitapAdi.Text);
            command.Parameters.AddWithValue("yazar_id", cmbYazar.SelectedItem.ToString());
            command.Parameters.AddWithValue("@tur_id", cmbTur.SelectedItem.ToString());
            command.Parameters.AddWithValue("@yayinevi_id", cmYayinevi.SelectedItem.ToString());
            command.Parameters.AddWithValue("@BasimYili", txtBasimYili.Text);
            command.Parameters.AddWithValue("@CiltNo", txtCiltNo.Text);
            command.Parameters.AddWithValue("@raf_id", cmbRaf.SelectedItem.ToString());
            command.Parameters.AddWithValue("@dil_id", cmbDil.SelectedItem.ToString());
            command.Parameters.AddWithValue("@cevirmen_id", cmbCevirmen.SelectedItem.ToString());
            command.Parameters.AddWithValue("@SayfaSayisi", txtSayfaSayisi.Text);
            command.Parameters.AddWithValue("@BaskiNo", txtBaskiNo.Text);
            command.Parameters.AddWithValue("@durum_id", txtDurum.Text);
            command.Parameters.AddWithValue("@OkunmaSayisi", txtOkunmaSayisi.Text);
            command.Parameters.AddWithValue("@Stok", txtStok.Text);
            command.Parameters.AddWithValue("@Satis_Fiyati", txtSatisFiyati.Text);
            command.Parameters.AddWithValue("@Kiralık_Fiyati", txtKiralikFiyati.Text);
            command.ExecuteNonQuery();
            connenction.Close();
        }

     string yazarID;

        private void cmbYazar_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connenction = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("", connenction);
            SqlDataReader read;
            connenction.Open();
            read = cmd.ExecuteReader();
         

                yazarID=read["Raf"].ToString();
          
            read.Close();
            connenction.Close();
         }

        private void btnYazarEkle_Click(object sender, EventArgs e)
        {
           
            if (_yazar.pointer==null)
            {
                _yazar yazar = new _yazar();
                yazar.ShowDialog();
            }
            else
	        {
                _yazar.pointer.ShowDialog();
    	    }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if (Tur.pointer == null)
            {
                Tur tur = new Tur();
                tur.ShowDialog();
            }
            else
            {
                Tur.pointer.ShowDialog();
            }
        }

        private void btnYayinevi_Click(object sender, EventArgs e)
        {
     
            if (_yayinevi.pointer == null)
            {
                _yayinevi yayinevi = new _yayinevi();
                yayinevi.ShowDialog();
            }
            else
            {
                _yayinevi.pointer.ShowDialog();
            }
        }

        private void btnRaf_Click(object sender, EventArgs e)
        {
        
            if (raf.pointer == null)
            {
                raf raflar = new raf();
                raflar.ShowDialog();
            }
            else
            {
                raf.pointer.ShowDialog();
            }
        }

        private void btnDil_Click(object sender, EventArgs e)
        {
        
            if (dil.pointer == null)
            {
                dil diller = new dil();
                diller.ShowDialog();
            }
            else
            {
                dil.pointer.ShowDialog();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}


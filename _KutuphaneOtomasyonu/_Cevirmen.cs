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
        public partial class _Cevirmen : Form
        {
            public static _Cevirmen pointer = null;
            public _Cevirmen()
            {
                pointer = this;
                InitializeComponent();
            }
            SqlConnection con = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            DataTable table = new DataTable();
        
            private void guncel()
            {
                table.Clear();
                SqlDataAdapter adptr = new SqlDataAdapter("select cevirmen_ad, cevirmen_soyad from Translator", con);
                adptr.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }

            private void btnKapat_Click(object sender, EventArgs e)
            {
                this.Close();
            }
            
      

            private void _Cevirmen_Load(object sender, EventArgs e)
            {
                guncel();
                txtAd.Focus();
            }
            private bool InsertCheck()
            {
                SqlDataReader dt = null;
                SqlConnection con = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
                con.Open();
                String command = "select * from Translator where cevirmen_ad='" + txtAd.Text + "' and cevirmen_soyad ='" + txtSoyad.Text + "' ";
                SqlCommand cmd = new SqlCommand(command, con);
                dt = cmd.ExecuteReader();
                if (dt.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            private void btnEkle_Click(object sender, EventArgs e)
            {
                if (InsertCheck())
                {
                    MessageBox.Show("Bu yazar daha önce eklenmiş.");
                    txtAd.Clear();
                    txtSoyad.Clear();
                    txtAd.Focus();
                }

                else
                {

                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "TranslatorInsert";
                    cmd.Parameters.AddWithValue("@cevirmen_id", ParameterDirection.Output);
                    cmd.Parameters.AddWithValue("@cevirmen_ad", txtAd.Text);
                    cmd.Parameters.AddWithValue("@cevirmen_soyad", txtSoyad.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    guncel();
                    txtAd.Clear();
                    txtSoyad.Clear();
                    txtAd.Focus();
                }

            }
        }
    }

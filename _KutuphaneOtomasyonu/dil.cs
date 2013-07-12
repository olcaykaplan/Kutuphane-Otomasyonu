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
    public partial class dil : Form
    {
        public static dil pointer = null;
        public dil()
        {
            pointer = null;
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        DataTable table = new DataTable();

        private void guncel()
        {
            table.Clear();
            SqlDataAdapter adptr = new SqlDataAdapter("select diller from Language", con);
            adptr.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dil_Load(object sender, EventArgs e)
        {
            guncel();
            txtdil.Focus();
        }
        public bool InsertCheck()
        {
            SqlDataReader dr = null;
            SqlConnection con = new SqlConnection("Data Source=OLCAY\\MYTESTINSTANCE;Initial Catalog=Kutuphane;Integrated Security=True");
            con.Open();
            String command = "select *  from Language where diller='"+txtdil.Text+"' ";
            SqlCommand cm = new SqlCommand(command,con);
            dr = cm.ExecuteReader();
            if (dr.Read())
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
                MessageBox.Show("Bu isimde bir dil daha önce eklenmiş.");
                txtdil.Clear();
                txtdil.Focus();
            }
            else
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LanguageInsert";
                cmd.Parameters.AddWithValue("@dil_id", ParameterDirection.Output);
                cmd.Parameters.AddWithValue("@diller", txtdil.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                guncel();
                txtdil.Clear();
                txtdil.Focus();

            }
        
        }
    }
}

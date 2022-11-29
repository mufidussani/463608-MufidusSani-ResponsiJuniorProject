using Npgsql;
using Responsi.Entity;
using Responsi.Repository;
using System.Data;
using System.Xml.Linq;

namespace Responsi
{
    public partial class Form1 : Form
    {
        private NpgsqlConnection conn;
        string connstring = "Host=localhost;Port=2022;Username=postgres;Password=informatika;Database=Responsi_mufidussani";
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string sql = null;

        readonly private DepartemenRepository _departemenRepository = new DepartemenRepository();
        //readonly private KaryawanRepository _karyawanRepository = new KaryawanRepository();
        private DataGridViewRow r;
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            sql = "select id_karyawan, nama, nama_dep from karyawan inner join departemen on karyawan.id_dep = departemen.id_dep";
            cmd = new NpgsqlCommand(sql, conn);
            dt = new DataTable();
            NpgsqlDataReader rd = cmd.ExecuteReader();
            dt.Load(rd);
            dgvKaryawan.DataSource = dt;
            conn.Close();
        }
        public Form1()
        {
            InitializeComponent();
            List<Departemen> ListDepartemen = _departemenRepository.GetAll();
            //List<Karyawan> ListKaryawan = _karyawanRepository.GetAll();
            //dgvKaryawan.DataSource = ListKaryawan;
            comboBoxDepartemen.DataSource = ListDepartemen;
            comboBoxDepartemen.DisplayMember = "nama_dep";

        }

        private void comboBoxDepartemen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from st_insert_karyawan(:_nama,:_id_dep)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_nama", tbNama.Text);
                cmd.Parameters.AddWithValue("_id_dep", comboBoxDepartemen.SelectedIndex);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data Users berhasil diinputkan", "Well Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    tbNama.Text = null;
                    UpdateDgv();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Insert FAIL!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateDgv()
        {
            conn.Open();
            sql = "select id_karyawan, nama, nama_dep from karyawan inner join departemen on karyawan.id_dep = departemen.id_dep";
            cmd = new NpgsqlCommand(sql, conn);
            dt = new DataTable();
            NpgsqlDataReader rd = cmd.ExecuteReader();
            dt.Load(rd);
            dgvKaryawan.DataSource = dt;
            conn.Close();
        }

        private void dgvKaryawan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvKaryawan.Rows[e.RowIndex];
                tbNama.Text = r.Cells["nama"].Value.ToString();
                comboBoxDepartemen.Text = r.Cells["nama_dep"].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Mohon pilih baris data yang akan diupdate", "Good!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                conn.Open();
                sql = @"select * from st_update(:_id_karyawan, :_nama, :_id_dep)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_id_karyawan", r.Cells["id_karyawan"].Value.ToString());
                cmd.Parameters.AddWithValue("_nama", tbNama.Text);
                cmd.Parameters.AddWithValue("_id_dep", comboBoxDepartemen.SelectedIndex);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data Users Berhasil diupdate", "Well Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    tbNama.Text = null;
                    r = null;
                    UpdateDgv();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Update FAIL!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
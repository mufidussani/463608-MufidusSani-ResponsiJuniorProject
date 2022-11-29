using Npgsql;
using Responsi.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responsi.Repository
{
    public interface IDepartemenRepository
    {
        List<Departemen> GetAll();
    }
    public class DepartemenRepository : IDepartemenRepository
    {
        private NpgsqlConnection conn;
        string connstring = "Host=localhost;Port=2022;Username=postgres;Password=informatika;Database=Responsi_mufidussani";
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string sql = null;

        public List<Departemen> GetAll()
        {
            List<Departemen> listDepartemen = new List<Departemen>();
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            sql = "select * from st_select_departemen()";
            cmd = new NpgsqlCommand(sql, conn);
            dt = new DataTable();
            NpgsqlDataReader rd = cmd.ExecuteReader();
            Console.WriteLine(rd.ToString());
            while (rd.Read())
            {
                Departemen newDepartemen = new Departemen
                {
                    id_dep = (int)rd["_id_dep"],
                    nama_dep = rd["_nama_dep"].ToString(),
                };
                listDepartemen.Add(newDepartemen);
            }
            rd.Close();
            conn.Close();
            return listDepartemen;
        }
    }
}

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
    public interface IKaryawanRepository
    {
        List<Karyawan> GetAll();
        //void Add(string nama, string id_dep);
        //void Update(string id_karyawan)
    }
    //public class KaryawanRepository : IKaryawanRepository
    //{
    //    private NpgsqlConnection conn;
    //    string connstring = "Host=localhost;Port=2022;Username=postgres;Password=informatika;Database=Responsi_mufidussani";
    //    public DataTable dt;
    //    public static NpgsqlCommand cmd;
    //    private string sql = null;

    //    public List<Karyawan> GetAll()
    //    {
    //        List<Karyawan> listKaryawan = new List<Karyawan>();
    //        conn = new NpgsqlConnection(connstring);
    //        conn.Open();
    //        sql = "select * from st_select_gabungan()";
    //        cmd = new NpgsqlCommand(sql, conn);
    //        dt = new DataTable();
    //        NpgsqlDataReader rd = cmd.ExecuteReader();
    //        Console.WriteLine(rd.ToString());
    //        while (rd.Read())
    //        {
    //            Karyawan newKaryawan = new Karyawan
    //            {
    //                id_karyawan = rd["_id_karyawan"].ToString(),
    //                nama = rd["_nama"].ToString(),
    //                nama_dep = rd["_nama_dep"].ToString(),
    //            };
    //            listKaryawan.Add(newKaryawan);
    //        }
    //        rd.Close();
    //        conn.Close();
    //        return listKaryawan;
    //    }
    }

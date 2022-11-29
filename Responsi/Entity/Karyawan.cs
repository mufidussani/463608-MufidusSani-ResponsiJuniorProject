using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responsi.Entity
{
    public class Karyawan
    {
        public string id_karyawan { get; set; }
        public string nama { get; set; }
        public string nama_dep { get; set; }

        public Karyawan()
        {

        }
        public Karyawan(string _id_karyawan, string _nama, string _nama_dep)
        {
            this.id_karyawan = _id_karyawan;
            this.nama = _nama;
            this.nama_dep = _nama_dep;
        }
    }
}

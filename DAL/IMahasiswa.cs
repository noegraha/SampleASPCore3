using SampleASPCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore.DAL
{
    public interface IMahasiswa
    {
        IEnumerable<Mahasiswa> GetAll();
        Mahasiswa GetByNIM(string nim);
        void Insert(Mahasiswa mhs);
        void Update(Mahasiswa mhs);
        void Delete(string nim);
        IEnumerable<Mahasiswa> GetAllByNim(string nim);
        IEnumerable<Mahasiswa> GetAllByNama(string nama);


    }
}

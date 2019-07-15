using SampleASPCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore.DAL
{
    public interface IPengguna
    {
        void Registrasi(Pengguna pengguna);
        Pengguna CekLogin(string Username, string Password);
    }
}

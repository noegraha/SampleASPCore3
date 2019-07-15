using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleASPCore.Models;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SampleASPCore.DAL
{
    public class MahasiswaDAL : IMahasiswa
    {
        private IConfiguration _config;

        public MahasiswaDAL(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnStr()
        {
            return _config.GetConnectionString("DefaultConnection");
        }
        public void Delete(string nim)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var strSql = @"delete from Mahasiswa where NIM=@NIM";
                try
                {
                    var param = new { NIM = nim };
                    conn.Execute(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error : {sqlEx.Message}");
                }
            }
        }
       
        public IEnumerable<Mahasiswa> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var strSql = @"select * from Mahasiswa order by Nama";
                return conn.Query<Mahasiswa>(strSql);
            }
        }

        public Mahasiswa GetByNIM(string nim)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var strSql = @"select * from Mahasiswa where NIM like @NIM";
                var param = new { nim = "%"+nim+"%" };
                var data = conn.QuerySingleOrDefault<Mahasiswa>(strSql,param);
                if (data != null)
                    return data;
                else
                    throw new Exception("Data tidak ditemukan !");
            }
        }

        public IEnumerable<Mahasiswa> GetAllByNama(string nama)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var strSql = @"select * from Mahasiswa where Nama like @Nama";
                var param = new { Nama="%"+nama+"%" };
                var data = conn.Query<Mahasiswa>(strSql, param);
                return data;
            }
        }
        public void Insert(Mahasiswa mhs)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var strSql = @"insert into Mahasiswa(NIM,Nama,Email,Telp) 
                values (@NIM,@Nama,@Email,@Telp)";

                try
                {
                    var param = new { NIM = mhs.NIM, Nama = mhs.Nama, Email = mhs.Email, Telp = mhs.Telp };
                    conn.Execute(strSql,param);
                }
                catch(SqlException sqlEx)
                {
                    throw new Exception($"Error : {sqlEx.Message}");
                }
            }
        }

        public void Update(Mahasiswa mhs)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var strSql = @"update Mahasiswa set Nama=@Nama, Email=@Email, Telp=@Telp where NIM=@NIM";
                try
                {
                    var param = new { Nama = mhs.Nama, Email = mhs.Email, Telp = mhs.Telp ,Nim=mhs.NIM};
                    conn.Execute(strSql,param);
                }
                catch (SqlException SqlEx)
                {
                    throw new Exception($"Error: {SqlEx.Message}");
                }
            }
        }

        public IEnumerable<Mahasiswa> GetAllByNim(string nim)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var strSql = @"select * from Mahasiswa where NIM=@NIM";
                var param = new
                {
                    NIM = nim
                };
                return conn.Query<Mahasiswa>(strSql, param);
            }
        }
    }
}

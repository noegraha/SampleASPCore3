using Microsoft.Extensions.Configuration;
using SampleASPCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;

namespace SampleASPCore.DAL
{
    public class PenggunaDAL : IPengguna
    {
        private IConfiguration _config;

        public PenggunaDAL(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnStr()
        {
            return _config.GetConnectionString("DefaultConnection");
        }
        public Pengguna CekLogin(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var strSQL = @"select * from Pengguna where Username=@Username and Password=@Password";
                var param = new
                {
                    Username = username,
                    Password = GetMd5(password)
                };
                var data = conn.QuerySingleOrDefault<Pengguna>(strSQL, param);
                if (data != null)
                {
                    return data;
                }
                else
                {
                    throw new Exception("Username atau Password Salah");
                }
            }
        }

        public void Registrasi(Pengguna pengguna)
        {
            using(SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var strSql = @"insert into Pengguna(Username,Password,Aturan,Nama,Telp) 
                values(@Username,@Password,@Aturan,@Nama,@Telp)";
                var param = new
                {
                    Username = pengguna.Username,
                    Password = GetMd5(pengguna.Password),
                    Aturan = pengguna.Aturan,
                    Nama = pengguna.Nama,
                    Telp = pengguna.Telp
                };
                try
                {
                    conn.Execute(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error : {sqlEx.Message}");
                }
            }
        }

        private string GetMd5(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}

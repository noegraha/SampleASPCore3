using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleASPCore.DAL;
using SampleASPCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore.Controllers
{
    public class PenggunaController:Controller
    {
        private IPengguna _pengguna;


        public PenggunaController(IPengguna pengguna)
        {
            _pengguna = pengguna;
        }


        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Login2()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            try
            {
                var data = _pengguna.CekLogin(username, password);
                HttpContext.Session.SetString("username", data.Username);
                HttpContext.Session.SetString("aturan", data.Aturan);
                ViewData["pesan"] = $"<p>Selamat Datang {data.Username}, selamat bergabung kembali</p>";
                return View("Views/Home/Index.cshtml");
            }
            catch (Exception ex)
            {
                ViewData["pesan"] = $"<span class='alert alert-danger'>Username atau Password Anda tidak sesuai</span>";
                return View(); 
            }

        }
        [HttpPost]
        public IActionResult Login2(string username, string password)
        {
            try
            {
                var data = _pengguna.CekLogin(username, password);
                HttpContext.Session.SetString("username", data.Username);
                HttpContext.Session.SetString("aturan", data.Aturan);
                ViewData["pesan"] = $"<p>Selamat Datang {data.Username}, selamat bergabung kembali</p>";
                return View("Views/Home/Index.cshtml");
            }
            catch (Exception ex)
            {
                ViewData["pesan"] = $"<span class='alert alert-danger'>Username atau Password Anda tidak sesuai</span>";
                return View();
            }
        }

            
            public IActionResult Registrasi()
            {
                if (!IsLogin())
                {
                    TempData["pesan"] = "Silahkan login dengan admin dulu";
                    return RedirectToAction("Login", "Pengguna");
                }
                return View();
            }
        


        [HttpPost]
        public IActionResult Registrasi(Pengguna pengguna)
        {
            if (!IsLogin())
            {
                TempData["pesan"] = "<span class='alert alert-danger'>Silahkan Login Terlebih dahulu untuk mengakses halaman mahasiswa</span>";
                return RedirectToAction("Login", "Pengguna");
            }
            else
            {
                if (!CekAturan("admin"))
                {
                    try
                    {
                        _pengguna.Registrasi(pengguna);
                        ViewData["pesan"] =
                        "<span class='alert alert-success'>Registrasi Pengguna Berhasil</span>";
                        return View();
                    }
                    catch (Exception ex)
                    {
                        return Content($"Error: {ex.Message}");
                    }
                }
            }
            TempData["pesan"] = "<span class='alert alert-danger'>Silahkan Login Terlebih dahulu untuk mengakses halaman mahasiswa</span>";
            return RedirectToAction("Login", "Pengguna");
        }

        private bool CekAturan(string Aturan)
        {
            if(HttpContext.Session.GetString("Aturan") != null &&
                HttpContext.Session.GetString("Aturan") == Aturan)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool IsLogin()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}


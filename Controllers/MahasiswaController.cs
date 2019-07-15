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
    public class MahasiswaController:Controller
    {
        private IMahasiswa _mhs;

        public MahasiswaController(IMahasiswa mhs)
        {
            _mhs = mhs;
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
        public IActionResult Index()
        {
            if (!IsLogin())
            {
                TempData["pesan"] = "<span class='alert alert-danger'>Silahkan login dulu untuk masuk kesini</span>";
                return RedirectToAction("Login", "Pengguna");
            }
            var data = _mhs.GetAll();
            return View(data);

        }


        public IActionResult Details(string id)
        {
            var data = _mhs.GetByNIM(id);
            return View(data);
        }
        
        public IActionResult Create()
        {
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
                        TempData["pesan"] = "<span class='alert alert-danger'>Silahkan Login Terlebih dahulu untuk mengakses halaman mahasiswa</span>";
                        return RedirectToAction("Login", "Pengguna");
                        
                    }
                }
                return View();
            }
        }
        [HttpPost]
        public IActionResult Edit(Mahasiswa mhs)
        {
            try
            {
                _mhs.Update(mhs);
                ViewData["Pesan"] =
                    "<span class='alert alert-success'>Data berhasil diupdate !</span>";
                return View("Details",mhs);
            }
            catch(Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }

        private bool CekAturan(string aturan)
        {
            if (HttpContext.Session.GetString("aturan") != null &&
                HttpContext.Session.GetString("aturan") == aturan)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public IActionResult Search(string keyword,string milih)
        {
            IEnumerable<Mahasiswa> data;
            if (milih == "NIM")
            {
                data = _mhs.GetAllByNim(keyword);
            }
            else if (milih == "Nama")
            {
                data = _mhs.GetAllByNama(keyword);
            }
            else
            {
                data = _mhs.GetAll();
            }
            return View("Index",data);

        }
        public IActionResult Delete(string id)
        {
            try
            {
                _mhs.Delete(id);
                ViewData["Pesan"] =
                    "<span class='alert alert-success'>Data berhasil dihapus !</span>";
                return View("Index",_mhs.GetAll());
            }
            catch(Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }

        }
        [HttpPost]
        public IActionResult CreatePost(Mahasiswa mhs)
        {
            try
            {
                _mhs.Insert(mhs);
                ViewData["Pesan"]=
                    "<span class='alert alert-success'>Data berhasil ditambah !</span>";
                return View("Create");
            }
            catch(Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }
    }
}

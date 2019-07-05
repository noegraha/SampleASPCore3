using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using SampleASPCore.Models;

namespace SampleASPCore2.Controllers
{

    public class RegistrasiController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Tampil(Anggota anggota)
        {

            //return Content($"Nama : {anggota.Firstname} {anggota.Lastname} {anggota.Address} {anggota.Telp}");
            return View(anggota);
        }

    }
}

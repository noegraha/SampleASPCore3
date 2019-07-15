using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore.Models
{
    public class Pengguna
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string Repassword { get; set; }
        [Required]
        public string Aturan { get; set; }
        [Required]
        public string Nama { get; set; }
        [Required]
        public string Telp { get; set; }
    }
}

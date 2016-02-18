using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWebApp.Models
{
    public class Companhia
    {
        [Key]
        public int Id { get; set; }
        public string NomeCompanhia { get; set; }
    }
}
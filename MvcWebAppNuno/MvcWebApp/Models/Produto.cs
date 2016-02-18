using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcWebApp.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Volume { get; set; }

        [ForeignKey("Companhia")]
        public int IdCompanhia { get; set; }
        public Companhia Companhia { get; set; }
    }
}
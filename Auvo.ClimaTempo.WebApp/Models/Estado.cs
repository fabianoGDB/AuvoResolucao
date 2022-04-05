using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Auvo.ClimaTempo.WebApp.Models
{
    [Table("Estado")]
    public class Estado
    {

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }

    }
}
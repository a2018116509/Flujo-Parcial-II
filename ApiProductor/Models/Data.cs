using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductor.Models
{
    public class Data
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Estudiante{ get; set; }
        [Required]
        public double Temperatura { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
      
    }
}

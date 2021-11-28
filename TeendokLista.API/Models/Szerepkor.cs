using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TeendokLista.API.Models
{
    [Table("szerepkorok")]
    public partial class Szerepkor
    {
        public Szerepkor()
        {
            felhasznalok = new HashSet<Felhasznalo>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Megnevezes { get; set; }

        [InverseProperty("Szerepkor")]
        public virtual ICollection<Felhasznalo> felhasznalok { get; set; }
    }
}

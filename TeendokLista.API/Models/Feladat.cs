using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TeendokLista.API.Models
{
    [Index(nameof(FelhasznaloId), Name = "IX_Feladatok_FelhasznaloId")]
    [Table("feladatok")]
    public partial class Feladat
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Cim { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Szoveg { get; set; }
        // [MaxLength(6)]
        public DateTime Hatarido { get; set; }
        public bool Teljesitve { get; set; }
        [Column(TypeName = "int(11)")]
        public int FelhasznaloId { get; set; }

        [ForeignKey(nameof(FelhasznaloId))]
        [InverseProperty(nameof(Models.Felhasznalo.feladatok))]
        [JsonIgnore] // Json hivatkozás loop kikapcsolására
        public virtual Felhasznalo Felhasznalo { get; set; }
    }
}

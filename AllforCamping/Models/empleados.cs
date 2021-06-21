namespace AllforCamping.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class empleados
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string nombre { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string app { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string apm { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string area { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(10)]
        public string email { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(10)]
        public string pass { get; set; }
    }
}

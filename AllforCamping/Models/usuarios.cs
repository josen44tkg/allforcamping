namespace AllforCamping.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class usuarios
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string nombre { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string ap_pat { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string ap_mat { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string email { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int telefono { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string pass { get; set; }

        [StringLength(50)]
        public string calle { get; set; }

        public int? numext { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string colonia { get; set; }
    }
}

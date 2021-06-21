namespace AllforCamping.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class compras
    {
        public int Id { get; set; }

        public int? proveedor { get; set; }

        public int? producto { get; set; }

        public int? cantidad { get; set; }

        public double? total { get; set; }

        [StringLength(10)]
        public string status { get; set; }
    }
}

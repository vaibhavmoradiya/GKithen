namespace ServiceApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceType")]
    public partial class ServiceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceId { get; set; }

        [Column("ServiceType")]
        [StringLength(50)]
        public string ServiceType1 { get; set; }

        public double? Price { get; set; }

        [Column(TypeName = "ntext")]
        public string AeraToSupport { get; set; }
    }
}

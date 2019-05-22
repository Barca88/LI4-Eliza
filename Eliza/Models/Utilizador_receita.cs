namespace Eliza.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Utilizador_receita
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idUtilizador { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idReceita { get; set; }

        [Column(TypeName = "date")]
        public DateTime? data { get; set; }

        public int? favorita { get; set; }

        public virtual Receita Receita { get; set; }

        public virtual Utilizador Utilizador { get; set; }
    }
}

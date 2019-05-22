namespace Eliza.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Receita")]
    public partial class Receita
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Receita()
        {
            Acoes = new HashSet<Acoes>();
            Utilizador_receita = new HashSet<Utilizador_receita>();
        }

        [Key]
        public int idReceita { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        [StringLength(50)]
        public string descricao { get; set; }

        [StringLength(50)]
        public string tempo { get; set; }

        [StringLength(50)]
        public string tipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acoes> Acoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utilizador_receita> Utilizador_receita { get; set; }
    }
}

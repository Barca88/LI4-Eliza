namespace Eliza.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ingrediente")]
    public partial class Ingrediente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ingrediente()
        {
            Dispensa = new HashSet<Dispensa>();
            Acoes = new HashSet<Acoes>();
        }

        [Key]
        public int idIngrediente { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        [StringLength(50)]
        public string descrição { get; set; }

        [StringLength(50)]
        public string tipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dispensa> Dispensa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acoes> Acoes { get; set; }
    }
}

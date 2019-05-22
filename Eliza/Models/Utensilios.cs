namespace Eliza.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Utensilios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utensilios()
        {
            Acoes = new HashSet<Acoes>();
        }

        [Key]
        public int idUtensilio { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        [StringLength(50)]
        public string descricao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acoes> Acoes { get; set; }
    }
}

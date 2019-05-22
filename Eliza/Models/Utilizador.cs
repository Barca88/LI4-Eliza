namespace Eliza.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Utilizador")]
    public partial class Utilizador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utilizador()
        {
            Dispensa = new HashSet<Dispensa>();
            Utilizador_receita = new HashSet<Utilizador_receita>();
        }

        [Key]
        public int idUtilizador { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        [StringLength(50)]
        public string rua { get; set; }

        [StringLength(50)]
        public string cidade { get; set; }

        [StringLength(50)]
        public string porta { get; set; }

        [StringLength(50)]
        public string cod_postal { get; set; }

        [StringLength(50)]
        public string intolerancias { get; set; }

        [StringLength(15)]
        public string password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dispensa> Dispensa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utilizador_receita> Utilizador_receita { get; set; }
    }
}

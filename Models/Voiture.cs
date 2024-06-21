using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_ProjetDonetCore.Models
{
    public class Voiture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVoi { get; set; }
        public string matricule { get; set; }
        public string  date_sortie { get; set; }
        public string designation { get; set; }
        public string couleur { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }


}

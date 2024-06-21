using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_ProjetDonetCore.Models
{
    public class Client
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int IdCl { get; set; }
        public string name { get; set; }
        public string cin { get; set; }
        public string adresse  { get; set; }
        public string telephone { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
        
    }
}

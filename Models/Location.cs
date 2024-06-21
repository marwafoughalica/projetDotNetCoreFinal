using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_ProjetDonetCore.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLoc {  get; set; }


        public int IdVoi { get; set; }
        [ForeignKey("IdVoi")]
     public virtual Voiture Voiture { get; set; }



        public int IdCl { get; set; }
        [ForeignKey("IdCl")]
        public virtual Client client { get; set; }

        public string dateLoc { get; set; }
        public string dateRetour {  get; set; }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model of 'Autorius' entity.
	/// </summary>
	public class AutoriusEditVM
	{
        public class AutoriusM
        {
            [DisplayName("Autoriaus ID")]
            [MaxLength(10)]
            [Required]
            public string id { get; set; }

            [DisplayName("Vardas")]
            [Required]
            public string vardas { get; set; }

            [DisplayName("Pavardė")]
            [Required]
            public string pavarde { get; set; }
        }

        public class ParasytaKnygaM
        {
            public int InListId { get; set; }
        
            [DisplayName("Brūkšninis kodas")]
            [MaxLength(30)]
            [Required]
            public string barkodas { get; set; }

            [DisplayName("Pavadinimas")]
            [MaxLength(50)]
            [Required]
            public string pavadinimas { get; set; }

            [DisplayName("Kalba")]
            [MaxLength(20)]
            [Required]
            public string kalba { get; set; }

            [DisplayName("Žanras")]
            public string fkzanras { get; set; }
        }

        public class ListsM
        {
            public IList<SelectListItem> Zanrai { get; set; }
        }

        public IList<ParasytaKnygaM> ParasytaKnyga { get; set; } = new List<ParasytaKnygaM>();

        public AutoriusM Autorius { get; set; } = new AutoriusM();

        public ListsM Lists { get; set; } = new ListsM();
	}
}
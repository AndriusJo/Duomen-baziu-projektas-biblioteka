using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
    public class KnygaEditVM
    {
	/// <summary>
	/// Model of 'Knyga' entity.
	/// </summary>
        public class KnygaM
        {
            [DisplayName("Brūkšninis kodas")]
            [MaxLength(30)]
            [Required]
            public string barkodas { get; set; }

            [DisplayName("Pavadinimas")]
            [MaxLength(50)]
            [Required]
            public string pavadinimas { get; set; }

            [DisplayName("Puslapiu kiekis")]
            [Required]
            public int pslsk { get; set; }

            [DisplayName("Kalba")]
            [MaxLength(20)]
            [Required]
            public string kalba { get; set; }

            [DisplayName("Viso turime:")]
            [Required]
            public int viso_kop { get; set; }

            [DisplayName("Dabar turime:")]
            [Required]
            public int dabar_kop { get; set; }

            [DisplayName("Žanras")]
            public string fkzanras { get; set; }
        }

        public class KopijaM
        {
            public int InListId { get; set; }

            [DisplayName("Kopijos numeris")]
            [Required]
            public int nr { get; set; }

            [DisplayName("Leidėjas")]
            [MaxLength(30)]
            [Required]
            public string leidejas { get; set; }

            [DisplayName("Leidimo metai")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
            [Required]
            public DateTime? leidmet { get; set; }

            [DisplayName("Būsena")]
            [MaxLength(25)]
            [Required]
            public string busena { get; set; }

            [DisplayName("Knyga")]
            [MaxLength(30)]
            public string fkbarkodas { get; set; }
        }

        public class ListsM
        {
        public IList<SelectListItem> Zanrai { get; set; }    

        public IList<SelectListItem> Kopijos { get; set; }    

        }
        /// <summary>
        /// Entity view.
        /// </summary>
        public KnygaM knyga { get; set; } = new KnygaM();


        public IList<KopijaM> Kopijos { get; set;  } = new List<KopijaM>();


        /// <summary>
        /// Lists for drop down controls.
        /// </summary>
        public ListsM Lists { get; set; } = new ListsM();
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Knyga' entity.
	/// </summary>
	public class Knyga
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
	}
}
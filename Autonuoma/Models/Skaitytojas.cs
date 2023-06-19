using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Skaitytojas' entity.
	/// </summary>
	public class Skaitytojas
	{
		[DisplayName("Skaitytojo kodas")]
		[MaxLength(8)]
		[Required]
		public string skkodas { get; set; }

		[DisplayName("Vardas")]
		[MaxLength(30)]
		[Required]
		public string vardas { get; set; }

		[DisplayName("Pavardė")]
		[MaxLength(30)]
		[Required]
		public string pavarde { get; set; }

        [DisplayName("El. Paštas")]
		[EmailAddress]
        [MaxLength(40)]
		[Required]
		public string elpastas { get; set; }

        [DisplayName("Tel. numeris")]
		[MaxLength(15)]
		public string telnr { get; set; }

        [DisplayName("Adresas")]
		[MaxLength(50)]
		public string adresas { get; set; }

        [DisplayName("Banko sąskaita")]
		[MaxLength(34)]
		public string bankosask { get; set; }
	}
}
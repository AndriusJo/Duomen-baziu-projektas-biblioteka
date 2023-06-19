using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Autorius' entity.
	/// </summary>
	public class Autorius
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
}
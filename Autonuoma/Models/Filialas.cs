using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Modelis' entity.
	/// </summary>
	public class Filialas
	{
		[DisplayName("Filialo kodas")]
		public string filkod { get; set; }

		[DisplayName("Miestas")]
		public string miestas { get; set; }

		//Markė
		[DisplayName("El_pastas")]
		public string elpastas{ get; set; }

        [DisplayName("Tel. Numeris")]
		public string telnr { get; set; }
	}
}
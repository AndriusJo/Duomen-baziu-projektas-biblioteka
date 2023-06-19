using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Zanras' entity.
	/// </summary>
	public class Zanras
	{
        [DisplayName("Pavadinimas")]
		[MaxLength(30)]
		[Required]
		public string pavadinimas { get; set; }
	}
}
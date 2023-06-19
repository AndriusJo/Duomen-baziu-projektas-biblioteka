using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model of 'Zanras' entity.
	/// </summary>
	public class ZanrasEditVM
	{
        public int InListId { get; set; }


        [DisplayName("Pavadinimas")]
		[MaxLength(30)]
		[Required]
		public string pavadinimas { get; set; }
	}
}
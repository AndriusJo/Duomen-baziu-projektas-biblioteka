using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model of 'Kopija' entity.
	/// </summary>
	public class KopListVM
	{
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
        public string knygpav { get; set; }
	}
}
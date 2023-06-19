using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.KnygaReportVM

{
	/// <summary>
	/// View model for single contract in late contracts report.
	/// </summary>
	public class Knyga
	{
		[DisplayName("Kopijos nr.")]
		public int kopnr { get; set; }

		[DisplayName("Leidimo metai")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? leidmet { get; set; }

        [DisplayName("Knygos pavadinimas")]
		public string pavadinimas { get; set; }

		public string barkodas { get; set; }

        [DisplayName("Žanras")]
		public string zanras { get; set; }

        [DisplayName("Autorius")]
		public string autorius { get; set; }

		[DisplayName("Puslapių kiekis")]
		public int pslsk { get; set; }

		public int kopsum { get; set; }
	}

	/// <summary>
	/// View model for late contracts report.
	/// </summary>
	public class Report
	{
		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime? DateFrom { get; set; }

		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime? DateTo { get; set; }

		public int? skfrom { get; set; }

		public int? skto { get; set; }

		[MaxLength(1)]
		public char? nuor { get; set; }

		[MaxLength(1)]
		public char? ikir { get; set; }

		public List<Knyga> Knygos { get; set; }

		public int VisoKopiju { get; set; }

		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? SeniausiaKopija { get; set; }

		public int pslkiekis { get; set; }

		public decimal vidpslkiekis { get; set; }
	}
}
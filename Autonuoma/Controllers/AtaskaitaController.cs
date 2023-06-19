using Microsoft.AspNetCore.Mvc;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using KnygaReport = Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.KnygaReportVM;



namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
	/// <summary>
	/// Controller for producing reports.
	/// </summary>e
	public class AtaskaitaController : Controller
	{
		/// <summary>
		/// Produces contracts report.
		/// </summary>
		/// <param name="dateFrom">Starting date. Can be null.</param>
		/// <param name="dateTo">Ending date. Can be null.</param>
		/// <returns>Report view.</returns>
		public ActionResult KnygosReport(DateTime? dateFrom, DateTime? dateTo, int? skfrom, int? skto, char? nuor, char? ikir)
		{
			var report = new KnygaReport.Report();
			report.DateFrom = dateFrom;
			report.DateTo = dateTo?.AddHours(23).AddMinutes(59).AddSeconds(59); //move time of end date to end of day
			report.skfrom = skfrom;
			report.skto = skto;
			report.nuor = nuor;
			report.ikir = ikir;

			report = AtaskaitaRepo.GetKnygosReport(report.DateFrom, report.DateTo, report.skfrom, report.skto, report.nuor, report.ikir);

			report.DateFrom = dateFrom;
			report.DateTo = dateTo?.AddHours(23).AddMinutes(59).AddSeconds(59); //move time of end date to end of day
			report.skfrom = skfrom;
			report.skto = skto;
			report.nuor = nuor;
			report.ikir = ikir;

            report.Knygos = AtaskaitaRepo.GetKnygos(report.DateFrom, report.DateTo, report.skfrom, report.skto, report.nuor, report.ikir);
			
			return View(report);


		}
	}
}



using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Priklauso' entity.
	/// </summary>
	public class Priklauso
	{
		public string fkzanropav { get; set; }
        public string fkknygosbarkod { get; set; }
	}
}
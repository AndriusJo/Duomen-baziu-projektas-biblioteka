using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model of 'Darbuotojas' entity.
	/// </summary>
	public class DarbuotojasEditVM
	{

        public class DarbuotojasM
        {
            [DisplayName("Darbuotojo kodas")]
            [MaxLength(6)]
            [Required]
            public string kodas { get; set; }

            [DisplayName("Vardas")]
            [MaxLength(30)]
            [Required]
            public string vardas { get; set; }

            [DisplayName("Pavardė")]
            [MaxLength(30)]
            [Required]
            public string pavarde { get; set; }

            [DisplayName("Stažas")]
            public int stazas { get; set; }

            [DisplayName("El. Paštas")]
            [EmailAddress]
            [MaxLength(40)]
            [Required]
            public string elpastas { get; set; }

            [DisplayName("Tel. numeris")]
            [MaxLength(15)]
            [Required]
            public string telnr { get; set; }

            [DisplayName("Filialas")]
            public string fkfilialas { get; set; }
        }

        /// <summary>
		/// Select lists for making drop downs for choosing values of entity fields.
		/// </summary>
		public class ListsM
		{
			public IList<SelectListItem> filialai { get; set; }
		}

		/// <summary>
		/// Entity view.
		/// </summary>
		public DarbuotojasM Model { get; set; } = new DarbuotojasM();

		/// <summary>
		/// Lists for drop down controls.
		/// </summary>
		public ListsM Lists { get; set; } = new ListsM();
	}   
}
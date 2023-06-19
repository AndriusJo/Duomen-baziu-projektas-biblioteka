using System.Data;
using MySql.Data.MySqlClient;

using Newtonsoft.Json;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	/// <summary>
	/// Database operations related to 'UzsakytosPaslaugos' entity.
	/// </summary>
	public class UzsakyaKopRepo
	{
		public static void DeleteForKopija(int nr)
		{
			var query =
				$@"DELETE FROM a
				USING `{Config.TblPrefix}uzsakyta_kopija` as a
				WHERE a.fk_KOPIJAnr=?nr";

			Sql.Delete(query, args => {
				args.Add("?nr", MySqlDbType.VarChar).Value = nr;
			});
		}
	}
}
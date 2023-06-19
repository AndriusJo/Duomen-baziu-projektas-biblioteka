using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;



namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	/// <summary>
	/// Database operations related to 'Darbuotojas' entity.
	/// </summary>
	public class ZanrasRepo
	{
		public static List<Zanras> List()
		{
			var zanrai = new List<Zanras>();
			
			string query = $@"SELECT * FROM `{Config.TblPrefix}zanras` ORDER BY pavadinimas ASC";
			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				zanrai.Add(new Zanras
				{
					pavadinimas = Convert.ToString(item["pavadinimas"]),
				});
			}

			return zanrai;
		}

		public static void DeleteForKnyga(string barkodas)
		{
			var query =
				$@"DELETE FROM a
				USING `{Config.TblPrefix}priklauso` as a
				WHERE a.fk_KNYGAbruksninis_kodas=?barkodas";

			Sql.Delete(query, args => {
				args.Add("?barkodas", MySqlDbType.VarChar).Value = barkodas;
			});
		}

		public static List<ZanrasEditVM> LoadForKnyga()
		{
			var result = new List<ZanrasEditVM>();

			var query = $@"SELECT * FROM `{Config.TblPrefix}zanras` ORDER BY pavadinimas ASC";

			var dt = Sql.Query(query);

			var inListId = 0;

			foreach( DataRow item in dt )
			{
				result.Add(new ZanrasEditVM
				{
					InListId = inListId,
					pavadinimas = Convert.ToString(item["pavadinimas"]),
				});

				inListId += 1;
			}

			return result;
		}

		public static void Insert(string barkodas, AutoriusEditVM.ParasytaKnygaM up)
		{

			var query =
				$@"INSERT INTO `{Config.TblPrefix}priklauso`
					(
						fr_KNYGAbruksninis_kodas,
						fr_ZANRASpavadinimas
					)
					VALUES(
						?bark,
						?pav
					)";

			Sql.Insert(query, args => {
				args.Add("?bark", MySqlDbType.VarChar).Value = up.barkodas;
				args.Add("?pav", MySqlDbType.VarChar).Value = up.pavadinimas;

			});

		}
    }
}
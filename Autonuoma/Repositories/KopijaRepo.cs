using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;



namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	/// <summary>
	/// Database operations related to 'Kopija' entity.
	/// </summary>
	public class KopijaRepo
	{
		public static List<KnygaEditVM.KopijaM> List(string barkodas)
		{
			var kopijos = new List<KnygaEditVM.KopijaM>();

			var query =
				$@"SELECT *
				FROM `{Config.TblPrefix}kopija`
				WHERE fk_KNYGAbruksninis_kodas = ?barkodas
				ORDER BY nr ASC";

			var dt =
				Sql.Query(query, args => {
					args.Add("?barkodas", MySqlDbType.VarChar).Value = barkodas;
				});

			var inListId = 0;

			foreach( DataRow item in dt )
			{
				kopijos.Add(new KnygaEditVM.KopijaM
				{
					InListId = inListId,

					nr = Convert.ToInt32(item["nr"]),
					leidejas = Convert.ToString(item["leidejas"]),
					leidmet = Convert.ToDateTime(item["leidimo_metai"]),
					busena = Convert.ToString(item["busena"]),
					fkbarkodas = Convert.ToString(item["fk_KNYGAbruksninis_kodas"])
				});

				//advance in list ID for next entry
				inListId += 1;
			}

			return kopijos;
		}

		public static void Insert(string barkodas, KnygaEditVM.KopijaM up)
		{

			var query =
				$@"INSERT INTO `{Config.TblPrefix}kopija`
					(
						nr,
						leidejas,
						leidimo_metai,
						busena,
						fk_KNYGAbruksninis_kodas
					)
					VALUES(
						?nrr,
						?leid,
						?leidm,
						?bus,
						?fkbarkod
					)";

			Sql.Insert(query, args => {
				args.Add("?nrr", MySqlDbType.Int32).Value = up.nr;
				args.Add("?leid", MySqlDbType.VarChar).Value = up.leidejas;
				args.Add("?leidm", MySqlDbType.Date).Value = up.leidmet;
				args.Add("?bus", MySqlDbType.VarChar).Value = up.busena;
				args.Add("?fkbarkod", MySqlDbType.VarChar).Value = barkodas;
			});

		}

		public static void DeleteForKnyga(string barkodas)
		{
			var query =
				$@"DELETE FROM a
				USING `{Config.TblPrefix}kopija` as a
				WHERE a.fk_KNYGAbruksninis_kodas=?barkodas";

			Sql.Delete(query, args => {
				args.Add("?barkodas", MySqlDbType.VarChar).Value = barkodas;
			});
		}

		/*public static List<KopListVM> List()
		{
			var kopija = new List<KopListVM>();
			
			var query =
				$@"SELECT
					kop.nr,
					kop.leidejas,
                    kop.leidimo_metai,
                    kop.busena,
					knyg.pavadinimas AS knygpav
				FROM
					`{Config.TblPrefix}kopija` kop
					LEFT JOIN `{Config.TblPrefix}knyga` knyg ON knyg.bruksninis_kodas=kop.fk_KNYGAbruksninis_kodas
				ORDER BY knyg.pavadinimas ASC";

			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				kopija.Add(new KopListVM
				{
					nr = Convert.ToInt32(item["nr"]),
					leidejas = Convert.ToString(item["leidejas"]),
					leidmet = Convert.ToDateTime(item["leidimo_metai"]),
                    busena = Convert.ToString(item["busena"]),
                    knygpav = Convert.ToString(item["knygpav"])
				});
			}

			return kopija;
		}*/
    }
}
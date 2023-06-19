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
	public class AutoriusRepo
	{
		public static List<Autorius> List()
		{
			var autoriai = new List<Autorius>();
			
			string query = $@"SELECT * FROM `{Config.TblPrefix}autorius` ORDER BY vardas ASC";
			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				autoriai.Add(new Autorius
				{
					id = Convert.ToString(item["autoriaus_kodas"]),
					vardas = Convert.ToString(item["vardas"]),
					pavarde = Convert.ToString(item["pavarde"])
				});
			}

			return autoriai;
		}

		public static AutoriusEditVM Find(string id)
		{
			var result = new AutoriusEditVM();
			
			string qlquery = $@"SELECT * FROM `{Config.TblPrefix}autorius` WHERE autoriaus_kodas=?id";
			var dt = 
				Sql.Query(qlquery, args => {
                    args.Add("?id", MySqlDbType.VarChar).Value = id;
                });

			var aut = result.Autorius;

			foreach( DataRow item in dt )
			{
				aut.id = Convert.ToString(item["autoriaus_kodas"]);
				aut.vardas = Convert.ToString(item["vardas"]);
				aut.pavarde = Convert.ToString(item["pavarde"]);
			}

			return result;
		}

		public static void Update(AutoriusEditVM evm)
		{
            var query = 
				$@"UPDATE `{Config.TblPrefix}autorius`
				SET
					vardas = ?vard,
					pavarde = ?pav
				WHERE autoriaus_kodas = ?autkod";

            Sql.Update(query, args => {
				args.Add("?vard", MySqlDbType.VarChar).Value = evm.Autorius.vardas;
				args.Add("?pav", MySqlDbType.VarChar).Value = evm.Autorius.pavarde;
				args.Add("?autkod", MySqlDbType.VarChar).Value = evm.Autorius.id;
            });
		}

		public static string Insert(AutoriusEditVM evm)
		{			
			var query = 
				$@"INSERT INTO `{Config.TblPrefix}autorius` 
				(
					autoriaus_kodas,
					vardas,
					pavarde
				)
				VALUES(
					?autkod,
					?vard,
					?pav
				)";

			var nr = 
				Sql.Insert(query, args => {
					args.Add("?vard", MySqlDbType.VarChar).Value = evm.Autorius.vardas;
					args.Add("?pav", MySqlDbType.VarChar).Value = evm.Autorius.pavarde;
					args.Add("?autkod", MySqlDbType.VarChar).Value = evm.Autorius.id;
				});

			return evm.Autorius.id;
		}

		public static void Delete(string id)
		{			
			var query = $@"DELETE FROM `{Config.TblPrefix}autorius` where autoriaus_kodas=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});
		}

		public static void DeleteForKnyga(string barkodas)
		{
			var query =
				$@"DELETE FROM a
				USING `{Config.TblPrefix}parase` as a
				WHERE a.fk_KNYGAbruksninis_kodas=?barkodas";

			Sql.Delete(query, args => {
				args.Add("?barkodas", MySqlDbType.VarChar).Value = barkodas;
			});
		}
    }
}
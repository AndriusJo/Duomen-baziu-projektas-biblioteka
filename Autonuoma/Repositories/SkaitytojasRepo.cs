using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	/// <summary>
	/// Database operations related to 'Darbuotojas' entity.
	/// </summary>
	public class SkaitytojasRepo
	{
		public static List<Skaitytojas> List()
		{
			var Skaitytojas = new List<Skaitytojas>();
			
			string query = $@"SELECT * FROM `{Config.TblPrefix}skaitytojas` ORDER BY vardas ASC";
			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				Skaitytojas.Add(new Skaitytojas
				{
					skkodas = Convert.ToString(item["skaitytojo_kodas"]),
					vardas = Convert.ToString(item["vardas"]),
					pavarde = Convert.ToString(item["pavarde"]),
                    elpastas = Convert.ToString(item["elektroninis_pastas"]),
                    telnr = Convert.ToString(item["tel_nr"]),
                    adresas = Convert.ToString(item["adresas"]),
                    bankosask = Convert.ToString(item["banko_saskaita"])
				});
			}

			return Skaitytojas;
		}

		public static Skaitytojas Find(string id)
		{
			var skait = new Skaitytojas();

			var query =  $@"SELECT * FROM `{Config.TblPrefix}skaitytojas` WHERE skaitytojo_kodas=?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.VarChar).Value = id;
				});

			foreach( DataRow item in dt )
			{
				skait.skkodas = Convert.ToString(item["skaitytojo_kodas"]);
				skait.vardas = Convert.ToString(item["vardas"]);
				skait.pavarde = Convert.ToString(item["pavarde"]);
				skait.elpastas = Convert.ToString(item["elektroninis_pastas"]);
				skait.telnr = Convert.ToString(item["tel_nr"]);
				skait.adresas = Convert.ToString(item["adresas"]);
				skait.bankosask = Convert.ToString(item["banko_saskaita"]);
			}

			return skait;
		}

		public static void Insert(Skaitytojas nskait)
		{
			var query = 
				$@"INSERT INTO `{Config.TblPrefix}skaitytojas`
				(
					skaitytojo_kodas,
					vardas,
					pavarde,
					elektroninis_pastas,
					tel_nr,
					adresas,
					banko_saskaita
				)
				VALUES (
					?skkod,
					?vard,
					?pavard,
					?elpas,
					?tel,
					?adres,
					?banksk
				)";

			Sql.Insert(query, args => {
				args.Add("?skkod", MySqlDbType.VarChar).Value = nskait.skkodas;
				args.Add("?vard", MySqlDbType.VarChar).Value = nskait.vardas;
				args.Add("?pavard", MySqlDbType.VarChar).Value = nskait.pavarde;
				args.Add("?elpas", MySqlDbType.VarChar).Value = nskait.elpastas;
				args.Add("?tel", MySqlDbType.VarChar).Value = nskait.telnr;
				args.Add("?adres", MySqlDbType.VarChar).Value = nskait.adresas;
				args.Add("?banksk", MySqlDbType.VarChar).Value = nskait.bankosask;
			});
		}

		public static void Update(string id, Skaitytojas skait)
		{
			var query = 
				$@"UPDATE`{Config.TblPrefix}skaitytojas`
				SET
					vardas = ?vard,
					pavarde = ?pavard,
					elektroninis_pastas = ?elpas,
					tel_nr = ?tel,
					adresas = ?adres,
					banko_saskaita = ?banksk
				WHERE
					skaitytojo_kodas=?skkod";

			Sql.Update(query, args => {
				args.Add("?skkod", MySqlDbType.VarChar).Value = skait.skkodas;
				args.Add("?vard", MySqlDbType.VarChar).Value = skait.vardas;
				args.Add("?pavard", MySqlDbType.VarChar).Value = skait.pavarde;
				args.Add("?elpas", MySqlDbType.VarChar).Value = skait.elpastas;
				args.Add("?tel", MySqlDbType.VarChar).Value = skait.telnr;
				args.Add("?adres", MySqlDbType.VarChar).Value = skait.adresas;
				args.Add("?banksk", MySqlDbType.VarChar).Value = skait.bankosask;
			});

			
		}

		public static void Delete(string id)
		{
			var query = $@"DELETE FROM `{Config.TblPrefix}skaitytojas` WHERE skaitytojo_kodas=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.VarChar).Value = id;
			});
		}
    }
}
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
	public class DarbuotojasRepo
	{
		public static List<Darbuotojas> List()
		{
			var darbuotojai = new List<Darbuotojas>();
			
			var query =
				$@"SELECT
					da.darbuotojo_kodas,
					da.vardas,
					da.pavarde,
					da.stazas,
					da.el_pastas,
					da.tel_nr,
					fil.miestas AS filialas
				FROM
					`{Config.TblPrefix}darbuotojas` da
					LEFT JOIN `{Config.TblPrefix}filialas` fil ON fil.fil_kodas = da.fk_FILIALASfil_kodas
				ORDER BY da.pavarde ASC";
			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				darbuotojai.Add(new Darbuotojas
				{
                kodas = Convert.ToString(item["darbuotojo_kodas"]),
				vardas = Convert.ToString(item["vardas"]),
				pavarde = Convert.ToString(item["pavarde"]),
                stazas = Convert.ToInt32(item["stazas"]),
                elpastas = Convert.ToString(item["el_pastas"]),
                telnr = Convert.ToString(item["tel_nr"]),
                filialas = Convert.ToString(item["filialas"])
				});
			}

			return darbuotojai;
        }

        public static List<Darbuotojas> ListForFilialas(string fil_kodas)
		{
			var result = new List<Darbuotojas>();

			var query = $@"SELECT * FROM `{Config.TblPrefix}darbuotojas` WHERE fk_FILIALASfil_kodas=?fil_kodas ORDER BY pavarde ASC";

			var dt =
				Sql.Query(query, args => {
					args.Add("?fil_kodas", MySqlDbType.VarChar).Value = fil_kodas;
				});

			foreach( DataRow item in dt )
			{
				result.Add(new Darbuotojas
				{
				kodas = Convert.ToString(item["darbuotojo_kodas"]),
				vardas = Convert.ToString(item["vardas"]),
				pavarde = Convert.ToString(item["pavarde"]),
                stazas = Convert.ToInt32(item["stazas"]),
                elpastas = Convert.ToString(item["el_pastas"]),
                telnr = Convert.ToString(item["tel_nr"]),
                filialas = Convert.ToString(item["fk_FILIALASfil_kodas"])
				});
			}

			return result;
		}


		public static DarbuotojasEditVM Find(string id)
		{
			var devm = new DarbuotojasEditVM();

			var query = $@"SELECT * FROM `{Config.TblPrefix}darbuotojas` WHERE darbuotojo_kodas=?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.VarChar).Value = id;
				});

			foreach( DataRow item in dt )
			{
				devm.Model.kodas = Convert.ToString(item["darbuotojo_kodas"]);
				devm.Model.vardas = Convert.ToString(item["vardas"]);
				devm.Model.pavarde = Convert.ToString(item["pavarde"]);
                devm.Model.stazas = Convert.ToInt32(item["stazas"]);
                devm.Model.elpastas = Convert.ToString(item["el_pastas"]);
                devm.Model.telnr = Convert.ToString(item["tel_nr"]);
                devm.Model.fkfilialas = Convert.ToString(item["fk_FILIALASfil_kodas"]);
			}

			return devm;
		}

		public static Darbuotojas FindForDeletion(string id)
		{
			var devm = new Darbuotojas();

			var query =
				$@"SELECT
					da.darbuotojo_kodas,
					da.vardas,
					da.pavarde,
					da.stazas,
					da.el_pastas,
					da.tel_nr,
					fil.miestas AS miestas
				FROM
					`{Config.TblPrefix}darbuotojas` da
					LEFT JOIN `{Config.TblPrefix}filialas` fil ON fil.fil_kodas = da.fk_FILIALASfil_kodas
				WHERE
					da.darbuotojo_kodas = ?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.VarChar).Value = id;
				});

			foreach( DataRow item in dt )
			{
				devm.kodas = Convert.ToString(item["darbuotojo_kodas"]);
				devm.vardas = Convert.ToString(item["vardas"]);
				devm.pavarde = Convert.ToString(item["pavarde"]);
                devm.stazas = Convert.ToInt32(item["stazas"]);
                devm.elpastas = Convert.ToString(item["el_pastas"]);
                devm.telnr = Convert.ToString(item["tel_nr"]);
                devm.filialas = Convert.ToString(item["miestas"]);
			}

			return devm;
		}

        public static void Insert(DarbuotojasEditVM darbEVM)
		{
			var query =
				$@"INSERT INTO `{Config.TblPrefix}darbuotojas`
				(
					darbuotojo_kodas,
					vardas,
                    pavarde,
                    stazas,
                    el_pastas,
                    tel_nr,
                    fk_FILIALASfil_kodas
				)
				VALUES(
					?darbkod,
					?vard,
                    ?pavard,
                    ?staz,
                    ?elpast,
                    ?telnr,
                    ?fkfil
				)";

			Sql.Insert(query, args => {
				args.Add("?darbkod", MySqlDbType.VarChar).Value = darbEVM.Model.kodas;
				args.Add("?vard", MySqlDbType.VarChar).Value = darbEVM.Model.vardas;
                args.Add("?pavard", MySqlDbType.VarChar).Value = darbEVM.Model.pavarde;
                args.Add("?staz", MySqlDbType.Int32).Value = darbEVM.Model.stazas;
                args.Add("?elpast", MySqlDbType.VarChar).Value = darbEVM.Model.elpastas;
                args.Add("?telnr", MySqlDbType.VarChar).Value = darbEVM.Model.telnr;
                args.Add("?fkfil", MySqlDbType.VarChar).Value = darbEVM.Model.fkfilialas;
			});
		}

		 public static void Update(DarbuotojasEditVM darbEVM)
		{
			var query =
				$@"UPDATE `{Config.TblPrefix}darbuotojas`
				SET
					vardas = ?vard,
                    pavarde = ?pavard,
                    stazas = ?staz,
                    el_pastas = ?elpast,
                    tel_nr = ?telnr,
                    fk_FILIALASfil_kodas = ?fkfil
                WHERE
					darbuotojo_kodas = ?darbkod";

			Sql.Insert(query, args => {
				args.Add("?darbkod", MySqlDbType.VarChar).Value = darbEVM.Model.kodas;
				args.Add("?vard", MySqlDbType.VarChar).Value = darbEVM.Model.vardas;
                args.Add("?pavard", MySqlDbType.VarChar).Value = darbEVM.Model.pavarde;
                args.Add("?staz", MySqlDbType.Int32).Value = darbEVM.Model.stazas;
                args.Add("?elpast", MySqlDbType.VarChar).Value = darbEVM.Model.elpastas;
                args.Add("?telnr", MySqlDbType.VarChar).Value = darbEVM.Model.telnr;
                args.Add("?fkfil", MySqlDbType.VarChar).Value = darbEVM.Model.fkfilialas;
			});
		}

		public static void Delete(string id)
		{
			var query = $@"DELETE FROM `{Config.TblPrefix}darbuotojas` WHERE darbuotojo_kodas=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});
		}
    }
}
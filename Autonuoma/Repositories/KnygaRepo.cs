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
	public class KnygaRepo
	{
		public static List<KnygaListVM> List()
		{
			var knygos = new List<KnygaListVM>();
			
			string query = 
			$@"SELECT 
				a.bruksninis_kodas,
				a.pavadinimas,
				a.kalba,
				a.puslapiu_kiekis,
				a.viso_kopiju,
				a.turima_kopiju,
				b.fk_ZANRASpavadinimas AS zanras
			FROM
				knyga a
				LEFT JOIN priklauso b ON a.bruksninis_kodas=b.fk_KNYGAbruksninis_kodas";
			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				knygos.Add(new KnygaListVM
				{
					barkodas = Convert.ToString(item["bruksninis_kodas"]),
					pavadinimas = Convert.ToString(item["pavadinimas"]),
                    kalba = Convert.ToString(item["kalba"]),
					pslsk = Convert.ToInt32(item["puslapiu_kiekis"]),
					viso_kop = Convert.ToInt32(item["viso_kopiju"]),
					dabar_kop = Convert.ToInt32(item["turima_kopiju"]),
					zanras = Convert.ToString(item["zanras"]),
				});
			}

			return knygos;
		}

		public static KnygaEditVM Find(string barkodas)
		{
			var result = new KnygaEditVM();
			
			string qlquery =
			$@"SELECT 
				a.bruksninis_kodas,
				a.pavadinimas,
				a.kalba,
				a.puslapiu_kiekis,
				a.viso_kopiju,
				a.turima_kopiju,
				b.fk_ZANRASpavadinimas AS zanras
			FROM
				knyga a
				LEFT JOIN priklauso b ON a.bruksninis_kodas=b.fk_KNYGAbruksninis_kodas
				WHERE bruksninis_kodas=?barkodas";
			var dt = 
				Sql.Query(qlquery, args => {
                    args.Add("?barkodas", MySqlDbType.VarChar).Value = barkodas;
                });

			var sut = result.knyga;

			foreach( DataRow item in dt )
			{
				sut.barkodas = Convert.ToString(item["bruksninis_kodas"]);
				sut.pavadinimas = Convert.ToString(item["pavadinimas"]);
                sut.kalba = Convert.ToString(item["kalba"]);
				sut.pslsk = Convert.ToInt32(item["puslapiu_kiekis"]);
				sut.viso_kop = Convert.ToInt32(item["viso_kopiju"]);
				sut.dabar_kop = Convert.ToInt32(item["turima_kopiju"]);
				sut.fkzanras = Convert.ToString(item["zanras"]);
			}
			
			return result;
		}

		public static string Insert(KnygaEditVM evm)
		{			
			var query = 
				$@"INSERT INTO `{Config.TblPrefix}knyga` 
				(
					bruksninis_kodas,
					pavadinimas,
					kalba,
					puslapiu_kiekis,
					viso_kopiju,
					turima_kopiju
				)
				VALUES(
					?barkod,
					?pav,
					?kalb,
					?pslk,
					?visok,
					?turk
				)";

				Sql.Insert(query, args => {
					args.Add("?barkod", MySqlDbType.VarChar).Value = evm.knyga.barkodas;
					args.Add("?pav", MySqlDbType.VarChar).Value = evm.knyga.pavadinimas;
					args.Add("?kalb", MySqlDbType.VarChar).Value = evm.knyga.kalba;
					args.Add("?pslk", MySqlDbType.Int32).Value = evm.knyga.pslsk;
					args.Add("?visok", MySqlDbType.Int32).Value = evm.knyga.viso_kop;
					args.Add("?turk", MySqlDbType.Int32).Value = evm.knyga.dabar_kop;
				});

			var query1 = 
				$@"INSERT INTO `{Config.TblPrefix}priklauso` 
				(
					fk_ZANRASpavadinimas,
					fk_KNYGAbruksninis_kodas
				)
				VALUES(
					?zanr,
					?barkod
				)";

				Sql.Insert(query1, args => {
					args.Add("?zanr", MySqlDbType.VarChar).Value = evm.knyga.fkzanras;
					args.Add("?barkod", MySqlDbType.VarChar).Value = evm.knyga.barkodas;

				});

			return evm.knyga.barkodas;
		}

		public static void Update(KnygaEditVM evm)
		{
            var query = 
				$@"UPDATE `{Config.TblPrefix}knyga`
				SET
					pavadinimas = ?pav,
					kalba = ?kalb,
					puslapiu_kiekis = ?pslk,
					viso_kopiju = ?visok,
					turima_kopiju = ?turk
				WHERE bruksninis_kodas=?barkod";

            Sql.Update(query, args => {
					args.Add("?barkod", MySqlDbType.VarChar).Value = evm.knyga.barkodas;
					args.Add("?pav", MySqlDbType.VarChar).Value = evm.knyga.pavadinimas;
					args.Add("?kalb", MySqlDbType.VarChar).Value = evm.knyga.kalba;
					args.Add("?pslk", MySqlDbType.Int32).Value = evm.knyga.pslsk;
					args.Add("?visok", MySqlDbType.Int32).Value = evm.knyga.viso_kop;
					args.Add("?turk", MySqlDbType.Int32).Value = evm.knyga.dabar_kop;
            });

			var query1 = 
				$@"UPDATE `{Config.TblPrefix}priklauso`
				SET
					fk_ZANRASpavadinimas = ?zanr
				WHERE fk_KNYGAbruksninis_kodas=?barkod";

            Sql.Update(query1, args => {
					args.Add("?barkod", MySqlDbType.VarChar).Value = evm.knyga.barkodas;
					args.Add("?zanr", MySqlDbType.VarChar).Value = evm.knyga.fkzanras;
			});
		}

		public static void Delete(string barkodas)
		{			
			var query = $@"DELETE FROM `{Config.TblPrefix}knyga` where bruksninis_kodas=?barkodas";
			Sql.Delete(query, args => {
				args.Add("?barkodas", MySqlDbType.VarChar).Value = barkodas;
			});
		}

		//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public static void Insert(string autkodas, AutoriusEditVM.ParasytaKnygaM up)
		{

			var query =
				$@"INSERT INTO `{Config.TblPrefix}knyga`
					(
						bruksninis_kodas,
						pavadinimas,
						kalba
					)
					VALUES(
						?barkodas,
						?pav,
						?kalb
					)";

			Sql.Insert(query, args => {
				args.Add("?barkodas", MySqlDbType.VarChar).Value = up.barkodas;
				args.Add("?pav", MySqlDbType.VarChar).Value = up.pavadinimas;
				args.Add("?kalb", MySqlDbType.VarChar).Value = up.kalba;
			});

			var query1 =
				$@"INSERT INTO `{Config.TblPrefix}parase`
					(
						fk_AUTORIUSautoriaus_kodas,
						fk_KNYGAbruksninis_kodas
					)
					VALUES(
						?autko,
						?barkod
					)";

			Sql.Insert(query1, args => {
				args.Add("?autko", MySqlDbType.VarChar).Value = autkodas;
				args.Add("?barkod", MySqlDbType.VarChar).Value = up.barkodas;
			});

			var query2 =
				$@"INSERT INTO `{Config.TblPrefix}priklauso`
					(
						fk_ZANRASpavadinimas,
						fk_KNYGAbruksninis_kodas
					)
					VALUES(
						?pav,
						?barkod
					)";

			Sql.Insert(query2, args => {
				args.Add("?pav", MySqlDbType.VarChar).Value = up.fkzanras;
				args.Add("?barkod", MySqlDbType.VarChar).Value = up.barkodas;
			});

		}

			/*$@"SELECT 
					s.nr, 
					s.sutarties_data as data, 
					CONCAT(d.vardas,' ', d.pavarde) as darbuotojas, 
					CONCAT(n.vardas,' ',n.pavarde) as nuomininkas, 
					b.name as busena
				FROM 
					`{Config.TblPrefix}sutartys` s
					LEFT JOIN `{Config.TblPrefix}darbuotojai` d ON s.fk_darbuotojas=d.tabelio_nr
					LEFT JOIN `{Config.TblPrefix}klientai` n ON s.fk_klientas=n.asmens_kodas
					LEFT JOIN `{Config.TblPrefix}sutarties_busenos` b ON s.busena=b.id				
				ORDER BY s.nr DESC";*/
		public static List<AutoriusEditVM.ParasytaKnygaM> List(string id)
		{
			var knygos = new List<AutoriusEditVM.ParasytaKnygaM>();

			var query =
				$@"SELECT 
				a.fk_KNYGAbruksninis_kodas AS barkodas,
				b.pavadinimas AS pavadinimas,
				b.kalba AS kalba,
				c.fk_ZANRASpavadinimas AS zanras
				FROM parase a
				LEFT JOIN knyga b ON a.fk_KNYGAbruksninis_kodas = b.bruksninis_kodas
				LEFT JOIN priklauso c ON b.bruksninis_kodas = c.fk_KNYGAbruksninis_kodas
				WHERE a.fk_AUTORIUSautoriaus_kodas = ?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.VarChar).Value = id;
				});

			var inListId = 0;

			foreach( DataRow item in dt )
			{
				knygos.Add(new AutoriusEditVM.ParasytaKnygaM
				{
					InListId = inListId,

					barkodas = Convert.ToString(item["barkodas"]),
					pavadinimas = Convert.ToString(item["pavadinimas"]),
					kalba = Convert.ToString(item["kalba"]),
					fkzanras = Convert.ToString(item["zanras"]),
				});

				//advance in list ID for next entry
				inListId += 1;
			}
			return knygos;
		}

		public static void DeleteForAutorius(string id)
		{
			var query2 = 
			$@"SELECT 
				fk_KNYGAbruksninis_kodas AS kodas
				FROM parase 
				WHERE fk_AUTORIUSautoriaus_kodas = ?id";

			var dt = Sql.Query(query2, args => {
				args.Add("?id", MySqlDbType.VarChar).Value = id;
			});	

			var query =
				$@"DELETE FROM a
				USING `{Config.TblPrefix}parase` as a
				WHERE a.fk_AUTORIUSautoriaus_kodas=?id";

			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.VarChar).Value = id;
			});

			foreach( DataRow item in dt)
			{
				string d = Convert.ToString(item["kodas"]);
				ZanrasRepo.DeleteForKnyga(d);
				var query1 =
					$@"
					DELETE FROM a
					USING knyga as a
					WHERE a.bruksninis_kodas = ?d";

				Sql.Delete(query1, args => {
					args.Add("?d", MySqlDbType.VarChar).Value = d;
				});
			}
		}
		

		/*(SELECT 
				fk_KNYGAbruksninis_kodas AS kodas
				FROM parase 
				WHERE fk_AUTORIUSautoriaus_kodas = ?id)
				
		var query2 = 
			$@"SELECT 
				fk_KNYGAbruksninis_kodas AS kodas
				FROM parase 
				WHERE fk_AUTORIUSautoriaus_kodas = ?id";

			Sql.Query(query2, args => {
				args.Add("?id", MySqlDbType.VarChar).Value = id;
			});	
			*/
    }
}
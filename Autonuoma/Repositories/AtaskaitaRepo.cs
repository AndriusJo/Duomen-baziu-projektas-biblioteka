using System.Data;
using MySql.Data.MySqlClient;

using KnygaReport = Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.KnygaReportVM;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	/// <summary>
	/// Database operations related to reports.
	/// </summary>
	public class AtaskaitaRepo
	{
public static List<KnygaReport.Knyga> GetKnygos(DateTime? dateFrom, DateTime? dateTo, int? skfrom, int? skto, char? nuor, char? ikir)
		{
			var result = new List<KnygaReport.Knyga>();

			var query =
				$@"SELECT
                    nr,
                    leidimo_metai,
                    pavadinimas,
                    bruksninis_kodas,
                    zanr,
                    aut,
                    puslapiu_kiekis,
                    pavkiek
                    FROM knyga LEFT JOIN kopija ON kopija.fk_KNYGAbruksninis_kodas = knyga.bruksninis_kodas
                LEFT JOIN 
                    (
                        SELECT
                            parase.fk_KNYGAbruksninis_kodas as barkodas,
                            CONCAT(autorius.vardas, ' ',autorius.pavarde) as aut
                        FROM
                            parase LEFT JOIN autorius ON autorius.autoriaus_kodas = parase.fk_AUTORIUSautoriaus_kodas
                    ) AS autoriai
                    ON autoriai.barkodas = knyga.bruksninis_kodas
                LEFT JOIN 
                    (
                        SELECT
                            priklauso.fk_KNYGAbruksninis_kodas as barkodas,
                            priklauso.fk_ZANRASpavadinimas as zanr
                        FROM
                            priklauso
                    ) AS zanrai
                    ON zanrai.barkodas = knyga.bruksninis_kodas
                LEFT JOIN
                    (
                        SELECT
                            knyga.bruksninis_kodas as bark,
                            COUNT(*) as pavkiek
                        FROM 
                            knyga LEFT JOIN kopija ON kopija.fk_KNYGAbruksninis_kodas = knyga.bruksninis_kodas
                        GROUP BY
                            bark
                    ) AS kiek
                    ON bruksninis_kodas = kiek.bark
                WHERE
                leidimo_metai >= IFNULL(?nuo, leidimo_metai)
                AND leidimo_metai <= IFNULL(?iki, leidimo_metai)
                AND puslapiu_kiekis >= IFNULL(?nuosk, puslapiu_kiekis)
                AND puslapiu_kiekis <= IFNULL(?ikisk, puslapiu_kiekis)
                AND SUBSTRING(aut, 1, 1) >= IFNULL(?nuoraide, SUBSTRING(aut, 1, 1))
                AND SUBSTRING(aut, 1, 1) <= IFNULL(?ikiraide, SUBSTRING(aut, 1, 1))
                ORDER BY aut";

			var dt =
				Sql.Query(query, args => {
					args.Add("?nuo", MySqlDbType.DateTime).Value = dateFrom;
					args.Add("?iki", MySqlDbType.DateTime).Value = dateTo;
                    args.Add("?nuosk", MySqlDbType.Int32).Value = skfrom;
                    args.Add("?ikisk", MySqlDbType.Int32).Value = skto;
                    args.Add("?nuoraide", MySqlDbType.VarChar).Value = nuor;
                    args.Add("?ikiraide", MySqlDbType.VarChar).Value = ikir;
				});

			foreach (DataRow item in dt)
			{
				result.Add(new KnygaReport.Knyga
				{
					kopnr = Convert.ToInt32(item["nr"]),
					leidmet = Convert.ToDateTime(item["leidimo_metai"]),
					pavadinimas = Convert.ToString(item["pavadinimas"]),
					barkodas = Convert.ToString(item["bruksninis_kodas"]),
                    zanras = Convert.ToString(item["zanr"]),
                    autorius = Convert.ToString(item["aut"]),
                    pslsk = Convert.ToInt32(item["puslapiu_kiekis"]),
                    kopsum = Convert.ToInt32(item["pavkiek"])
				});
			}

			return result;
		}

        public static KnygaReport.Report GetKnygosReport(DateTime? dateFrom, DateTime? dateTo, int? skfrom, int? skto, char? nuor, char? ikir)
		{
			var result = new KnygaReport.Report();

			var query =
				$@"SELECT
                    COUNT(nr) AS visokop,
                    MIN(leidimo_metai) AS seniausia
                FROM
                    kopija LEFT JOIN knyga ON knyga.bruksninis_kodas = kopija.fk_KNYGAbruksninis_kodas
                    LEFT JOIN parase ON parase.fk_KNYGAbruksninis_kodas = knyga.bruksninis_kodas
					LEFT JOIN autorius ON autorius.autoriaus_kodas = fk_AUTORIUSautoriaus_kodas
                WHERE
                    leidimo_metai >= IFNULL(?nuo, leidimo_metai)
                    AND leidimo_metai <= IFNULL(?iki, leidimo_metai)
                    AND puslapiu_kiekis >= IFNULL(?nuosk, puslapiu_kiekis)
                    AND puslapiu_kiekis <= IFNULL(?ikisk, puslapiu_kiekis)
                    AND SUBSTRING(vardas, 1, 1) >= IFNULL(?nuoraide, SUBSTRING(vardas, 1, 1))
                    AND SUBSTRING(vardas, 1, 1) <= IFNULL(?ikiraide, SUBSTRING(vardas, 1, 1))";

			var dt =
				Sql.Query(query, args => {
					args.Add("?nuo", MySqlDbType.DateTime).Value = dateFrom;
					args.Add("?iki", MySqlDbType.DateTime).Value = dateTo;
                    args.Add("?nuosk", MySqlDbType.Int32).Value = skfrom;
                    args.Add("?ikisk", MySqlDbType.Int32).Value = skto;
                    args.Add("?nuoraide", MySqlDbType.VarChar).Value = nuor;
                    args.Add("?ikiraide", MySqlDbType.VarChar).Value = ikir;
				});

			foreach( DataRow item in dt )
			{
				result.VisoKopiju = Convert.ToInt32(item["visokop"] == System.DBNull.Value ? 0 : item["visokop"]);
				result.SeniausiaKopija = Convert.ToDateTime(item["seniausia"] == System.DBNull.Value ? 0 : item["seniausia"]);
			}

            var query1 =
				$@"SELECT
                    SUM(kk.puslapiu_kiekis) AS pslkiekis,
                    AVG(kk.puslapiu_kiekis) AS vidpslkiekis
                FROM
                (
                    SELECT 
                        puslapiu_kiekis,
                        leidimo_metai,
                        vardas
                        FROM
                        knyga INNER JOIN kopija ON kopija.fk_KNYGAbruksninis_kodas = knyga.bruksninis_kodas
                        LEFT JOIN parase ON parase.fk_KNYGAbruksninis_kodas = knyga.bruksninis_kodas
					    LEFT JOIN autorius ON autorius.autoriaus_kodas = fk_AUTORIUSautoriaus_kodas
                        GROUP BY bruksninis_kodas
                ) AS kk
                WHERE
                    leidimo_metai >= IFNULL(?nuo, leidimo_metai)
                    AND leidimo_metai <= IFNULL(?iki, leidimo_metai)
                    AND puslapiu_kiekis >= IFNULL(?nuosk, puslapiu_kiekis)
                    AND puslapiu_kiekis <= IFNULL(?ikisk, puslapiu_kiekis)
                    AND SUBSTRING(vardas, 1, 1) >= IFNULL(?nuoraide, SUBSTRING(vardas, 1, 1))
                    AND SUBSTRING(vardas, 1, 1) <= IFNULL(?ikiraide, SUBSTRING(vardas, 1, 1))";

            var dt1 =
				Sql.Query(query1, args => {
					args.Add("?nuo", MySqlDbType.DateTime).Value = dateFrom;
					args.Add("?iki", MySqlDbType.DateTime).Value = dateTo;
                    args.Add("?nuosk", MySqlDbType.Int32).Value = skfrom;
                    args.Add("?ikisk", MySqlDbType.Int32).Value = skto;
                    args.Add("?nuoraide", MySqlDbType.VarChar).Value = nuor;
                    args.Add("?ikiraide", MySqlDbType.VarChar).Value = ikir;
				});

			foreach( DataRow item in dt1 )
			{
				result.pslkiekis = Convert.ToInt32(item["pslkiekis"] == System.DBNull.Value ? 0 : item["pslkiekis"]);
				result.vidpslkiekis = Convert.ToDecimal(item["vidpslkiekis"] == System.DBNull.Value ? 0 : item["vidpslkiekis"]);
			}

			return result;
		}

   /* 
   SELECT 
	nr,
    leidimo_metai,
    pavadinimas,
    bruksninis_kodas,
    zanr,
    aut,
    puslapiu_kiekis,
    pavkiek
    FROM knyga LEFT JOIN kopija ON kopija.fk_KNYGAbruksninis_kodas = knyga.bruksninis_kodas
LEFT JOIN 
	(
        SELECT
        	parase.fk_KNYGAbruksninis_kodas as barkodas,
       		CONCAT(autorius.vardas, ' ',autorius.pavarde) as aut
        FROM
        	parase LEFT JOIN autorius ON autorius.autoriaus_kodas = parase.fk_AUTORIUSautoriaus_kodas
    ) AS autoriai
    ON autoriai.barkodas = knyga.bruksninis_kodas
LEFT JOIN 
	(
        SELECT
        	priklauso.fk_KNYGAbruksninis_kodas as barkodas,
       		priklauso.fk_ZANRASpavadinimas as zanr
        FROM
        	priklauso
     ) AS zanrai
     ON zanrai.barkodas = knyga.bruksninis_kodas
LEFT JOIN
	(
        SELECT
        	knyga.bruksninis_kodas as bark,
        	COUNT(*) as pavkiek
		FROM 
        	knyga LEFT JOIN kopija ON kopija.fk_KNYGAbruksninis_kodas = knyga.bruksninis_kodas
        GROUP BY
        	bark
    ) AS kiek
    ON bruksninis_kodas = kiek.bark

     
     
     
     
     
     
     
     */






    }
}
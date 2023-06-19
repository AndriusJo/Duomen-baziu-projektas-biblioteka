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
	public class FilialasRepo
	{
		public static List<Filialas> List()
		{
			var filialai = new List<Filialas>();
			
			string query = $@"SELECT * FROM `{Config.TblPrefix}filialas` ORDER BY fil_kodas ASC";
			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				filialai.Add(new Filialas
				{
                filkod = Convert.ToString(item["fil_kodas"]),
				miestas = Convert.ToString(item["miestas"]),
                elpastas = Convert.ToString(item["el_pastas"]),
                telnr = Convert.ToString(item["tel_nr"]),
				});
			}

			return filialai;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
	/// <summary>
	/// Controller for working with 'Knyga' entity.
	/// </summary>
	public class KnygaController : Controller
	{
		/// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
		public ActionResult Index()
		{
			//gražinamas darbuotoju sarašo vaizdas
			return View(KnygaRepo.List());
		}

		public ActionResult Create()
		{
			var knygaEVM = new KnygaEditVM();
			
			PopulateLists(knygaEVM);

			return View(knygaEVM);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the creation form.
		/// </summary>
		/// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
		/// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
		/// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
		/// <param name="sutartisEvm">Entity view model filled with latest data.</param>
		/// <returns>Returns creation from view or redirets back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Create(int? save, int? add, int? remove, KnygaEditVM knygaEVM)
		{
			//addition of new 'UzsakytosPaslaugos' record was requested?
			if( add != null )
			{
				//add entry for the new record
				var up =
					new KnygaEditVM.KopijaM {
						InListId =
							knygaEVM.Kopijos.Count > 0 ?
							knygaEVM.Kopijos.Max(it => it.InListId) + 1 : 0,

						nr = 0,
						leidejas = null,
						leidmet = null,
						busena = null,
						fkbarkodas = knygaEVM.knyga.barkodas,
					};
				knygaEVM.Kopijos.Add(up);

				//make sure @Html helper is not reusing old model state containing the old list
				ModelState.Clear();

				//go back to the form
				PopulateLists(knygaEVM);
				return View(knygaEVM);
			}

			//removal of existing 'UzsakytosPaslaugos' record was requested?
			if( remove != null )
			{
				//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
				knygaEVM.Kopijos =
					knygaEVM.Kopijos
						.Where(it => it.InListId != remove.Value)
						.ToList();

				//make sure @Html helper is not reusing old model state containing the old list
				ModelState.Clear();

				//go back to the form
				PopulateLists(knygaEVM);
				return View(knygaEVM);
			}

			//save of the form data was requested?
			if( save != null )
			{
				//form field validation passed?
				if( ModelState.IsValid )
				{
					//create new 'Sutartis'
					knygaEVM.knyga.barkodas = KnygaRepo.Insert(knygaEVM);

					//create new 'UzsakytosPaslaugos' records
					foreach( var upVm in knygaEVM.Kopijos )
						KopijaRepo.Insert(knygaEVM.knyga.barkodas, upVm);

					//save success, go back to the entity list
					return RedirectToAction("Index");
				}
				//form field validation failed, go back to the form
				else
				{
					PopulateLists(knygaEVM);
					return View(knygaEVM);
				}
			}

			//should not reach here
			throw new Exception("Should not reach here.");
		}

		public ActionResult Edit(string id)
		{
			var knygaEVM = KnygaRepo.Find(id);
			
			knygaEVM.Kopijos = KopijaRepo.List(id);			
			PopulateLists(knygaEVM);

			return View(knygaEVM);
		}

		[HttpPost]
		public ActionResult Edit(int? save, int? add, int? remove, KnygaEditVM knygaEVM)
		{
			//addition of new 'UzsakytosPaslaugos' record was requested?
			if( add != null )
			{
				//add entry for the new record
				var up =
					new KnygaEditVM.KopijaM {
						InListId =
							knygaEVM.Kopijos.Count > 0 ?
							knygaEVM.Kopijos.Max(it => it.InListId) + 1 : 0,

						nr = 0,
						leidejas = null,
						leidmet = null,
						busena = null,
						fkbarkodas = knygaEVM.knyga.barkodas,
					};
				knygaEVM.Kopijos.Add(up);

				//make sure @Html helper is not reusing old model state containing the old list
				ModelState.Clear();

				//go back to the form
				PopulateLists(knygaEVM);
				return View(knygaEVM);
			}

			//removal of existing 'UzsakytosPaslaugos' record was requested?
			if( remove != null )
			{
				//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
				knygaEVM.Kopijos =
					knygaEVM.Kopijos
						.Where(it => it.InListId != remove.Value)
						.ToList();

				//make sure @Html helper is not reusing old model state containing the old list
				ModelState.Clear();

				//go back to the form
				PopulateLists(knygaEVM);
				return View(knygaEVM);
			}

			//save of the form data was requested?
			if( save != null )
			{
				//form field validation passed?
				if( ModelState.IsValid )
				{
					//update 'Knyga'
					KnygaRepo.Update(knygaEVM);

					foreach( var upVm in knygaEVM.Kopijos )
					{
						UzsakyaKopRepo.DeleteForKopija(upVm.nr);
					}

					KopijaRepo.DeleteForKnyga(knygaEVM.knyga.barkodas);

					//create new 'UzsakytosPaslaugos' records
					foreach( var upVm in knygaEVM.Kopijos )
					{
						KopijaRepo.Insert(knygaEVM.knyga.barkodas, upVm);
					}
					//save success, go back to the entity list
					return RedirectToAction("Index");
				}
				//form field validation failed, go back to the form
				else
				{
					PopulateLists(knygaEVM);
					return View(knygaEVM);
				}
			}

			//should not reach here
			throw new Exception("Should not reach here.");
		}

		public ActionResult Delete(string id)
		{
			var knygaEVM = KnygaRepo.Find(id);
			return View(knygaEVM);
		}

		/// <summary>
		/// This is invoked when deletion is confirmed in deletion form
		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view on error, redirects to Index on success.</returns>
		[HttpPost]
		public ActionResult DeleteConfirm(string id)
		{
			//load 'Sutartis'
				var knygaEVM = KnygaRepo.Find(id);
			try
			{
				foreach( var upVm in knygaEVM.Kopijos )
					{
						UzsakyaKopRepo.DeleteForKopija(upVm.nr);
					}

				//delete the entity
				AutoriusRepo.DeleteForKnyga(id);
				ZanrasRepo.DeleteForKnyga(id);
				KopijaRepo.DeleteForKnyga(id);
				KnygaRepo.Delete(id);

				//redired to list form
				return RedirectToAction("Index");
			}
			//entity in use, deletion not permitted
			catch( MySql.Data.MySqlClient.MySqlException )
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;

				knygaEVM = KnygaRepo.Find(id);

				return View("Delete", knygaEVM);
			}
		}

		public void PopulateLists(KnygaEditVM knygEVM)
		{
			//load entities for the select lists
			var zanrai = ZanrasRepo.List();

			//build select lists
			knygEVM.Lists.Zanrai =
				zanrai.Select(it => {
					return
						new SelectListItem() {
							Value = Convert.ToString(it.pavadinimas),
							Text = it.pavadinimas
						};
				})
				.ToList();
		}
    }
}
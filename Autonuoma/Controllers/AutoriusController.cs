using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
	/// <summary>
	/// Controller for working with 'Autorius' entity.
	/// </summary>
	public class AutoriusController : Controller
	{
		/// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
		public ActionResult Index()
		{
			//gražinamas darbuotoju sarašo vaizdas
			return View(AutoriusRepo.List());
		}

		public ActionResult Create()
		{
			var autoriusEVM = new AutoriusEditVM();
			
			PopulateLists(autoriusEVM);

			return View(autoriusEVM);
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
		public ActionResult Create(int? save, int? add, int? remove, AutoriusEditVM autoriusEVM)
		{
			//addition of new 'UzsakytosPaslaugos' record was requested?
			if( add != null )
			{
				//add entry for the new record
				var up =
					new AutoriusEditVM.ParasytaKnygaM {
						InListId =
							autoriusEVM.ParasytaKnyga.Count > 0 ?
							autoriusEVM.ParasytaKnyga.Max(it => it.InListId) + 1 : 0,

						barkodas = null,
						pavadinimas = null,
						kalba = null,
						fkzanras = null,
					};
				autoriusEVM.ParasytaKnyga.Add(up);

				//make sure @Html helper is not reusing old model state containing the old list
				ModelState.Clear();

				//go back to the form
				PopulateLists(autoriusEVM);
				return View(autoriusEVM);
			}

			//removal of existing 'UzsakytosPaslaugos' record was requested?
			if( remove != null )
			{
				//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
				autoriusEVM.ParasytaKnyga =
					autoriusEVM.ParasytaKnyga
						.Where(it => it.InListId != remove.Value)
						.ToList();

				//make sure @Html helper is not reusing old model state containing the old list
				ModelState.Clear();

				//go back to the form
				PopulateLists(autoriusEVM);
				return View(autoriusEVM);
			}

			//save of the form data was requested?
			if( save != null )
			{
				//form field validation passed?
				if( ModelState.IsValid )
				{
					//create new 'Sutartis'
					autoriusEVM.Autorius.id = AutoriusRepo.Insert(autoriusEVM);

					//create new 'UzsakytosPaslaugos' records
					foreach( var upVm in autoriusEVM.ParasytaKnyga )
						KnygaRepo.Insert(autoriusEVM.Autorius.id, upVm);

					//save success, go back to the entity list
					return RedirectToAction("Index");
				}
				//form field validation failed, go back to the form
				else
				{
					PopulateLists(autoriusEVM);
					return View(autoriusEVM);
				}
			}

			//should not reach here
			throw new Exception("Should not reach here.");
		}

		public ActionResult Edit(string id)
		{
			var autoriusEVM = AutoriusRepo.Find(id);
			
			autoriusEVM.ParasytaKnyga = KnygaRepo.List(id);			
			PopulateLists(autoriusEVM);

			return View(autoriusEVM);
		}

		[HttpPost]
		public ActionResult Edit(int? save, int? add, int? remove, AutoriusEditVM autoriusEVM)
		{
			//addition of new 'UzsakytosPaslaugos' record was requested?
			if( add != null )
			{
				//add entry for the new record
				var up =
					new AutoriusEditVM.ParasytaKnygaM {
						InListId =
							autoriusEVM.ParasytaKnyga.Count > 0 ?
							autoriusEVM.ParasytaKnyga.Max(it => it.InListId) + 1 : 0,

						barkodas = null,
						pavadinimas = null,
						kalba = null,
						fkzanras = null,
					};
				autoriusEVM.ParasytaKnyga.Add(up);

				//make sure @Html helper is not reusing old model state containing the old list
				ModelState.Clear();

				//go back to the form
				PopulateLists(autoriusEVM);
				return View(autoriusEVM);
			}

			//removal of existing 'UzsakytosPaslaugos' record was requested?
			if( remove != null )
			{
				//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
				autoriusEVM.ParasytaKnyga =
					autoriusEVM.ParasytaKnyga
						.Where(it => it.InListId != remove.Value)
						.ToList();

				//make sure @Html helper is not reusing old model state containing the old list
				ModelState.Clear();

				//go back to the form
				PopulateLists(autoriusEVM);
				return View(autoriusEVM);
			}

			//save of the form data was requested?
			if( save != null )
			{
				//form field validation passed?
				if( ModelState.IsValid )
				{
					AutoriusRepo.Update(autoriusEVM);

					KnygaRepo.DeleteForAutorius(autoriusEVM.Autorius.id);
					//create new 'UzsakytosPaslaugos' records
					foreach( var upVm in autoriusEVM.ParasytaKnyga )
						KnygaRepo.Insert(autoriusEVM.Autorius.id, upVm);

					//save success, go back to the entity list
					return RedirectToAction("Index");
				}
				//form field validation failed, go back to the form
				else
				{
					PopulateLists(autoriusEVM);
					return View(autoriusEVM);
				}
			}

			//should not reach here
			throw new Exception("Should not reach here.");
		}

		public ActionResult Delete(string id)
		{
			var autoriusEVM = AutoriusRepo.Find(id);
			return View(autoriusEVM);
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
				var autoriusEVM = AutoriusRepo.Find(id);
			try
			{
				//delete the entity
				KnygaRepo.DeleteForAutorius(id);
				AutoriusRepo.Delete(id);
				

				//redired to list form
				return RedirectToAction("Index");
			}
			//entity in use, deletion not permitted
			catch( MySql.Data.MySqlClient.MySqlException )
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;

				autoriusEVM = AutoriusRepo.Find(id);

				return View("Delete", autoriusEVM);
			}
		}

		private void PopulateLists(AutoriusEditVM autoriusEVM)
		{

			//build select list for 'UzsakytosPaslaugos'
			{
				//initialize the destination list
				autoriusEVM.Lists.Zanrai= new List<SelectListItem>();

				//load 'Paslaugos' to use for item groups
				var knygos = KnygaRepo.List();

				//create select list items from 'PaslauguKainos' related to each 'Paslaugos'
				foreach( var knyga in knygos )
				{
					//create list item group for current 'Paslaugos' entity
					var itemGrp = new SelectListGroup() { Name = knyga.pavadinimas };

					//load related 'PaslauguKaina' entities
					var zanrai = ZanrasRepo.LoadForKnyga();

					//build list items for the group
					foreach( var zanras in zanrai )
					{
						var sle =
							new SelectListItem {
								Value = Convert.ToString(zanras.pavadinimas),
								Text = zanras.pavadinimas,
								Group = itemGrp
							};
						autoriusEVM.Lists.Zanrai.Add(sle);
					}					
				}
			}
		}
    }
}
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
	public class DarbuotojasController : Controller
	{
		/// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
		public ActionResult Index()
		{
			//gražinamas darbuotoju sarašo vaizdas
			return View(DarbuotojasRepo.List());
		}

        public ActionResult Create()
		{
			var darbEVM = new DarbuotojasEditVM();
			PopulateSelections(darbEVM);
			return View(darbEVM);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the creation form.
		/// </summary>
		/// <param name="modelisEvm">Entity model filled with latest data.</param>
		/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Create(DarbuotojasEditVM darbEVM)
		{
			//form field validation passed?
			if( ModelState.IsValid )
			{
				DarbuotojasRepo.Insert(darbEVM);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}

			//form field validation failed, go back to the form
			PopulateSelections(darbEVM);
			return View(darbEVM);
		}

		public ActionResult Edit(string id)
		{
			var darbEVM = DarbuotojasRepo.Find(id);

			PopulateSelections(darbEVM);
			return View(darbEVM);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the editing form.
		/// </summary>
		/// <param name="id">ID of the entity being edited</param>
		/// <param name="darbEVM">Entity model filled with latest data.</param>
		/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Edit(string id, DarbuotojasEditVM darbEVM)
		{
			//form field validation passed?
			if( ModelState.IsValid )
			{
				DarbuotojasRepo.Update(darbEVM);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}

			//form field validation failed, go back to the form
			PopulateSelections(darbEVM);
			return View(darbEVM);
		}
        /// <summary>
		/// Populates select lists used to render drop down controls.
		/// </summary>
		/// <param name="modelisEvm">'Automobilis' view model to append to.</param>
		
		public ActionResult Delete(string id)
		{
			var darbEVM = DarbuotojasRepo.FindForDeletion(id);
			return View(darbEVM);
		}

		/// <summary>
		/// This is invoked when deletion is confirmed in deletion form
		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view on error, redirects to Index on success.</returns>
		[HttpPost]
		public ActionResult DeleteConfirm(string id)
		{
			//try deleting, this will fail if foreign key constraint fails
			try
			{
				DarbuotojasRepo.Delete(id);

				//deletion success, redired to list form
				return RedirectToAction("Index");
			}
			//entity in use, deletion not permitted
			catch( MySql.Data.MySqlClient.MySqlException )
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;

				var darbEVM = DarbuotojasRepo.FindForDeletion(id);

				return View("Delete", darbEVM);
			}
		}
		public void PopulateSelections(DarbuotojasEditVM darbEVM)
		{
			//load entities for the select lists
			var filial = FilialasRepo.List();

			//build select lists
			darbEVM.Lists.filialai =
				filial.Select(it => {
					return
						new SelectListItem() {
							Value = Convert.ToString(it.filkod),
							Text = it.miestas
						};
				})
				.ToList();
		}
    }
}
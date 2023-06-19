using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
	/// <summary>
	/// Controller for working with 'Skaitytojas' entity.
	/// </summary>
	public class SkaitytojasController : Controller
	{
		/// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
		public ActionResult Index()
		{
			return View(SkaitytojasRepo.List());
		}

        public ActionResult Create()
		{
			var nskait = new Skaitytojas();
			return View(nskait);
		}

        /// <summary>
		/// This is invoked when buttons are pressed in the creation form.
		/// </summary>
		/// <param name="nskait">Entity model filled with latest data.</param>
		/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Create(Skaitytojas nskait)
		{
			//form field validation passed?
			if( ModelState.IsValid )
			{
				SkaitytojasRepo.Insert(nskait);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}
			
			return View(nskait);
		}

		public ActionResult Edit(string id)
		{
			var skait = SkaitytojasRepo.Find(id);

			return View(skait);
		}

		[HttpPost]
		public ActionResult Edit(string id, Skaitytojas skait)
		{
			//form field validation passed?
			if (ModelState.IsValid)
			{
				SkaitytojasRepo.Update(id, skait);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}

			return View(skait);
		}

		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view.</returns>
		public ActionResult Delete(string id)
		{
			var skait = SkaitytojasRepo.Find(id);
			return View(skait);
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
				SkaitytojasRepo.Delete(id);

				//deletion success, redired to list form
				return RedirectToAction("Index");
			}
			//entity in use, deletion not permitted
			catch( MySql.Data.MySqlClient.MySqlException )
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;

				var skait = SkaitytojasRepo.Find(id);

				return View("Delete", skait);
			}
		}
    }
}
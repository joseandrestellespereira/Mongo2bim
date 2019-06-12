using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mongo2bim.Models;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Mongo2bim.Controllers
{
    public class TurmaController : Controller
    {
		private readonly MongoDBContext _mongoDBContext =
			new MongoDBContext();
		public string test;
		public IActionResult Index()
		{
			return View(_mongoDBContext.turma.Find(s => true)
				.ToList());
		}

		public IActionResult Create()
		{
			ViewBag.membros = new SelectList(_mongoDBContext.GetMembros(), "Id", "nome", 0);
			return View();
		}

		[HttpPost]
		public IActionResult Create(Turma turma)
		{
			if (ModelState.IsValid)
			{
				_mongoDBContext.turma.InsertOne(turma);
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public IActionResult Delete(string Id)
		{
			var servidorDel = _mongoDBContext.turma
				.Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
			return View(servidorDel);
		}

		[HttpGet]
		public IActionResult Details(string Id)
		{
			var servidorDel = _mongoDBContext.turma
				.Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
			return View(servidorDel);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(string Id)
		{
			var servidorDel = _mongoDBContext.turma
				.DeleteOne(s => s.Id == ObjectId.Parse(Id));
			return RedirectToAction("Index");
		}

		public ActionResult Edit(string Id)
		{
			var serv = _mongoDBContext.turma.Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
			return View(serv);
		}

		[HttpPost]
		public ActionResult Edit(Turma turma, string Id)
		{
			if (ModelState.IsValid)
			{
				turma.Id = ObjectId.Parse(Id);
				var filter = new BsonDocument("_id", turma.Id);
				//var filter = Builders<Servidor>.Filter.Eq(s => s.Id, servidor.Id);
				_mongoDBContext.turma.ReplaceOne(filter, turma);

				return RedirectToAction("Index");
			}
			return View();
		}


		
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mongo2bim.Models;
using MongoDB.Bson;
using MongoDB.Driver;
namespace Mongo2bim.Controllers
{
    public class MembroController : Controller
    {
		private readonly MongoDBContext _mongoDBContext =
			new MongoDBContext();

		public IActionResult Index()
		{
			return View(_mongoDBContext.membro.Find(s => true)
				.ToList());
		}

		public IActionResult Create() => View();

		[HttpPost]
		public IActionResult Create(Membro membro)
		{
			if (ModelState.IsValid)
			{
				_mongoDBContext.membro.InsertOne(membro);
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public IActionResult Delete(string Id)
		{
			var servidorDel = _mongoDBContext.membro
				.Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
			return View(servidorDel);
		}

		[HttpGet]
		public IActionResult Details(string Id)
		{
			var servidorDel = _mongoDBContext.membro
				.Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
			return View(servidorDel);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(string Id)
		{
			var servidorDel = _mongoDBContext.membro
				.DeleteOne(s => s.Id == ObjectId.Parse(Id));
			return RedirectToAction("Index");
		}

		public ActionResult Edit(string Id)
		{
			var serv = _mongoDBContext.membro.Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
			return View(serv);
		}

		[HttpPost]
		public ActionResult Edit(Membro membro, string Id)
		{
			if (ModelState.IsValid)
			{
				membro.Id = ObjectId.Parse(Id);
				var filter = new BsonDocument("_id", membro.Id);
				//var filter = Builders<Servidor>.Filter.Eq(s => s.Id, servidor.Id);
				_mongoDBContext.membro.ReplaceOne(filter, membro);

				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
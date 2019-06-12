using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mongo2bim.Models
{
	public class MongoDBContext
	{
		private IMongoDatabase _database { get; }

		public MongoDBContext()
		{
			MongoClientSettings settings =
				MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017"));
			var mongoClient = new MongoClient(settings);
			_database = mongoClient.GetDatabase("escola");
		}

		public IMongoCollection<Turma> turma
		{
			get
			{
				//Recupera colection de documents
				return _database.GetCollection<Turma>("turma");
			}
		}

		public IMongoCollection<Membro> membro
		{
			get
			{
				//Recupera colection de documents
				return _database.GetCollection<Membro>("membro");
			}
		}

		public IEnumerable<Membro> GetMembros()
		{
			return _database.GetCollection<Membro>("membro").Find(r => r.Id != null).ToEnumerable();
		}
	}
}
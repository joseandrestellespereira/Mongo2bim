using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Mongo2bim.Models
{
	public class Turma 
	{
		public ObjectId Id { get; set; }
		[Required]
		public string nome { get; set; }
		public string curso { get; set; }
		public string periodo { get; set; }
		public Boolean ativo { get; set; }
		public Membro  membros { get; set; }

	}
}

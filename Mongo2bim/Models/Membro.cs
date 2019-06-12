using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mongo2bim.Models
{
	public class Membro
	{
		public ObjectId Id { get; set; }
		[Required]
		public string nome { get; set; }
		public int idade { get; set; }
		public string cpf { get; set; }
	}
}

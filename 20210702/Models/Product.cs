using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai4.Models
{
	public class Product
	{
		[Required]

		public string Id { get; set; }
		[Required]

		public string Name { get; set; }
		[Required]
		public double UnitPrice { get; set; }
		public string? Image { get; set; }
		[Required]
		public bool Available { get; set; }
		[Required]
		public int CategoryId { get; set; }
		[ValidateNever]
		public Category Category { get; set; }
		public string? Description { get; set; }

	}
}

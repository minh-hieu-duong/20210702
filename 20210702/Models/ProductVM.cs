using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bai4.Models
{
	public class ProductVM
	{
		public Product Product { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> Category { get; set; }
	}
}

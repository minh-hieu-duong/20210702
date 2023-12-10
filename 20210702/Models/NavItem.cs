using System.ComponentModel.DataAnnotations;

namespace Bai4.Models
{
	public class NavItem
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string NavName { get; set; }
		public string NavNameVN { get; set; }
	}
}

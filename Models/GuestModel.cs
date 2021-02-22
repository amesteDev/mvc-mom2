using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_mom2.Models
{
	public class GuestModel
	{
		public int Id { get; set; }
		[Required]
		public string User { get; set; }

		[Required]
		[MinLength(5, ErrorMessage = "Atleast 5 characters in the title")]
		public string Title { get; set; }

		[Required]
		[MinLength(10, ErrorMessage = "Your message needs to be atleast 10 characters long")]
		public string GuestPost { get; set; }
	}
}
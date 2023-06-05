using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models.Concrete
{
	public class ContactForm
	{
		public ContactForm()
		{
		}
		[Key]
		public int ContactId { get; set; }
		public string Name { get; set; }
		public string  Surname{ get; set; }
		public string PhoneNumber { get; set; }
		public string ContactReason { get; set; }
        public string Mail { get; set; }
    }
}


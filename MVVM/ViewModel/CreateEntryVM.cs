using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.MVVM.ViewModel
{
    internal class CreateEntryVM
    {
		public string Name { get; set; }
		public string Password { get; set; }
		public string Description { get; set; }
		public string URL { get; set; }


		public CreateEntryVM()
		{
			Name = "Name";
			Password = "Password";
			Description = "Description";
			URL = "http://URL";
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Password_Manager.Core;

namespace Password_Manager.MVVM.ViewModel
{
    public class EntryDataVM : ObservableObject
    {
		private string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				OnPropertyChanged("Name");
			}
		}
		public string Password { get; set; }
		public string Description { get; set; }
		public string URL { get; set; }

		public EntryDataVM()
		{
		}
	}
}

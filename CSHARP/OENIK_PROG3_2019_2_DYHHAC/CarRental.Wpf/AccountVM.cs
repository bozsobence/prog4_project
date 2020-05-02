using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Wpf
{
    class AccountVM : ObservableObject
    {
		private int accountId;

		public int AccountId
		{
			get { return accountId; }
			set { Set(ref accountId, value); }
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { Set(ref name, value); }
		}

		private string email;

		public string Email
		{
			get { return email; }
			set { Set(ref email, value); }
		}

		private string address;

		public string Address
		{
			get { return address; }
			set { Set(ref address, value); }
		}

		private DateTime birthDate;

		public DateTime BirthDate
		{
			get { return birthDate; }
			set { Set(ref birthDate, value); }
		}

		private int? minute;

		public int? Minute
		{
			get { return minute; }
			set { Set(ref minute, value); }
		}

		private int? monthly;

		public int? Monthly
		{
			get { return monthly; }
			set { Set(ref monthly, value); }
		}

		public void CopyFrom(AccountVM other)
		{
			if (other == null)
			{
				return;
			}
			this.AccountId = other.AccountId;
			this.Name = other.Name;
			this.Email = other.Email;
			this.Address = other.Address;
			this.BirthDate = other.BirthDate;
			this.Minute = other.Minute;
			this.Monthly = other.Monthly;
		}



	}
}

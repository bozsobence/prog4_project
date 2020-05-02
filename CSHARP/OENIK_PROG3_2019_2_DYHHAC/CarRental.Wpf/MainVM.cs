using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarRental.Wpf
{
    class MainVM : ViewModelBase
    {
        private MainLogic logic;
		private AccountVM selectedAccount;

		public AccountVM SelectedAccount
		{
			get { return selectedAccount; }
			set { Set(ref selectedAccount, value); }
		}

		private ObservableCollection<AccountVM> allAccounts;

		public ObservableCollection<AccountVM> AllAccounts
		{
			get { return allAccounts; }
			set { Set(ref allAccounts, value); }
		}

		public ICommand AddCmd { get; set; }
		public ICommand DelCmd { get; set; }
		public ICommand ModCmd { get; set; }
		public ICommand LoadCmd { get; set; }

		public Func<AccountVM, bool> EditorFunc { get; set; }

		public MainVM()
		{
			logic = new MainLogic();
			DelCmd = new RelayCommand(() => logic.DeleteAccount(selectedAccount));
			AddCmd = new RelayCommand(() => logic.EditAccount(null, EditorFunc));
			ModCmd = new RelayCommand(() => logic.EditAccount(selectedAccount, EditorFunc));
			LoadCmd = new RelayCommand(() => AllAccounts = new ObservableCollection<AccountVM>(logic.GetAccounts()));
		}


	}
}

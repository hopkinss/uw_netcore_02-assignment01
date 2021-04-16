using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace Assignment01
{
    public class MainViewModel:INotifyPropertyChanged
    {
        private string userName;
        private string passWord;
        private string submitMsg;

        public MainViewModel()
        {
            SubmitCommand = new DelegateCommand(OnSubmit, CanSubmit);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string PassWord
        {
            get { return passWord; }
            set
            {
                passWord = value;
                ((DelegateCommand)SubmitCommand).RaiseCanExecuteChanged();
            }
        }
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value; 
                ((DelegateCommand)SubmitCommand).RaiseCanExecuteChanged();
            }
        }

        public string SubmitMsg
        {
            get { return submitMsg; }
            set
            {
                submitMsg = value;
                OnPropertyChanged();
            }
        }
        private void OnSubmit()
        {
            SubmitMsg = $"Thanks {UserName}, your password, \"{PassWord}\", has been sold to hackers";
        }

        private bool CanSubmit()
        {
            return (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(PassWord));

        }

        public ICommand SubmitCommand { get; }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }   
    }
}

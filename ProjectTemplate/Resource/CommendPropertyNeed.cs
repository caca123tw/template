using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectTemplate
{
    public class CommendPropertyNeed : ICommand, INotifyPropertyChanged
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;
        public CommendPropertyNeed() { }

        public CommendPropertyNeed(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetCulture(string cultureName)
        {
            var c = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = c;
            Thread.CurrentThread.CurrentCulture = c;
            Properties.Resources.Culture = c;

            // 通知：索引子(Item[]) 有變、全部會重取
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item[]"));

        }
    }
}

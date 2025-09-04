using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate
{
    public class MainVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<string> _Items;
        public ObservableCollection<string> Items
        {
            get => _Items;
            set
            {
                if (_Items != value)
                {
                    _Items = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _AppName;

        public string AppName
        {
            get { return _AppName; }
            set
            {
                if (_AppName != value)   // 避免重複觸發
                {
                    _AppName = value;
                    OnPropertyChanged(); // 通知綁定的 UI 更新
                }
            }
        }

        public MainVM()
        {
            AppName = "test";
        }
    }
}

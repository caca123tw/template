using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjectTemplate
{
    public class MainVM: CommendPropertyNeed
    {
        private bool _isEngineerMode;

        public bool isEngineerMode
        {
            get { return _isEngineerMode; }
            set
            {
                if (_isEngineerMode != value)   // 避免重複觸發
                {
                    _isEngineerMode = value;
                    OnPropertyChanged(); // 通知綁定的 UI 更新
                }
            }
        }

        private PassWordWindow _aPassWordWindow;

        public PassWordWindow aPassWordWindow
        {
            get { return _aPassWordWindow; }
            set { _aPassWordWindow = value; }
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

        private string _Func1Name;

        public string Func1Name
        {
            get { return _Func1Name; }
            set
            {
                if (_Func1Name != value)   // 避免重複觸發
                {
                    _Func1Name = value;
                    OnPropertyChanged(); // 通知綁定的 UI 更新
                }
            }
        }

        private string _Func2Name;

        public string Func2Name
        {
            get { return _Func2Name; }
            set
            {
                if (_Func2Name != value)   // 避免重複觸發
                {
                    _Func2Name = value;
                    OnPropertyChanged(); // 通知綁定的 UI 更新
                }
            }
        }

        private string _SetUpName;

        public string SetUpName
        {
            get { return _SetUpName; }
            set
            {
                if (_SetUpName != value)   // 避免重複觸發
                {
                    _SetUpName = value;
                    OnPropertyChanged(); // 通知綁定的 UI 更新
                }
            }
        }

        private string _PassWordWrong;

        public string PassWordWrong
        {
            get { return _PassWordWrong; }
            set
            {
                if (_PassWordWrong != value)   // 避免重複觸發
                {
                    _PassWordWrong = value;
                    OnPropertyChanged(); // 通知綁定的 UI 更新
                }
            }
        }

        private string _PassWordNull;

        public string PassWordNull
        {
            get { return _PassWordNull; }
            set
            {
                if (_PassWordNull != value)   // 避免重複觸發
                {
                    _PassWordNull = value;
                    OnPropertyChanged(); // 通知綁定的 UI 更新
                }
            }
        }

        private bool _CanExecute = true;

        private ICommand _Func1Button;

        public ICommand Func1Button
        {
            get
            {
                if (null == _Func1Button)
                {
                    _Func1Button = new CommendPropertyNeed(p => OnFunc1Button(), p => DoOnFunc1Button_CanExecute());
                }
                return _Func1Button;
            }
        }
        private void OnFunc1Button()
        {
            _CanExecute = false;

        }
        private bool DoOnFunc1Button_CanExecute()
        {
            return _CanExecute;
        }

        private ICommand _Func2Button;

        public ICommand Func2Button
        {
            get
            {
                if (null == _Func2Button)
                {
                    _Func2Button = new CommendPropertyNeed(p => OnFunc2Button(), p => DoOnFunc2Button_CanExecute());
                }
                return _Func2Button;
            }
        }
        private void OnFunc2Button()
        {
            _CanExecute = false;

        }
        private bool DoOnFunc2Button_CanExecute()
        {
            return _CanExecute;
        }


        private ICommand _SetUpButton;

        public ICommand SetUpButton
        {
            get
            {
                if (null == _SetUpButton)
                {
                    _SetUpButton = new CommendPropertyNeed(p => OnSetUpButton(), p => DoOnSetUpButton_CanExecute());
                }
                return _SetUpButton;
            }
        }
        private void OnSetUpButton()
        {

        }
        private bool DoOnSetUpButton_CanExecute()
        {
            return true;
        }


        private ICommand _Change2Eng;

        public ICommand Change2Eng
        {
            get
            {
                if (null == _Change2Eng)
                {
                    _Change2Eng = new CommendPropertyNeed(p => OnChange2Eng(), p => DoOnChange2Eng_CanExecute());
                }
                return _Change2Eng;
            }
        }
        private void OnChange2Eng()
        {
            this.SetCulture("en");
            ChangeLanguage();
        }
        private bool DoOnChange2Eng_CanExecute()
        {
            return true;
        }


        private ICommand _Change2Chin;

        public ICommand Change2Chin
        {
            get
            {
                if (null == _Change2Chin)
                {
                    _Change2Chin = new CommendPropertyNeed(p => OnChange2Chin(), p => DoOnChange2Chin_CanExecute());
                }
                return _Change2Chin;
            }
        }
        private void OnChange2Chin()
        {
            this.SetCulture("zh-CHT");
            ChangeLanguage();
        }
        private bool DoOnChange2Chin_CanExecute()
        {
            return true;
        }


        private ICommand _EngineerOnOff;

        public ICommand EngineerOnOff
        {
            get
            {
                if (null == _EngineerOnOff)
                {
                    _EngineerOnOff = new CommendPropertyNeed(p => OnEngineerOnOff(), p => DoEngineerOnOff_CanExecute());
                }
                return _EngineerOnOff;
            }
        }
        private void OnEngineerOnOff()
        {
            if (!isEngineerMode)
            {
                _aPassWordWindow = new PassWordWindow();
                bool? dialogResult = aPassWordWindow.ShowDialog();
                if (dialogResult == true)
                {
                    if (!isEngineerMode)
                    {
                        isEngineerMode = !isEngineerMode;
                        ThemeManager.SetPrimary(PrimaryColor.Red);
                    }
                    else
                        ThemeManager.SetPrimary(PrimaryColor.Blue);
                }
            }
            else
            {
                isEngineerMode = false;
                ThemeManager.SetPrimary(PrimaryColor.Blue);
            }
        }
        private bool DoEngineerOnOff_CanExecute()
        {
            return true;
        }
        public MainVM()
        {
            isEngineerMode = false;
            ChangeLanguage();
            ThemeManager.SetPrimary(PrimaryColor.Blue);
        }

        private void ChangeLanguage()
        {
            AppName = Properties.Resources.appName;
            Func1Name = Properties.Resources.Func1;
            Func2Name = Properties.Resources.Func2;
            SetUpName = Properties.Resources.SetUp;
            PassWordWrong = Properties.Resources.PassWordWrong;
            PassWordNull = Properties.Resources.PassWordNull;
        }

    }
}

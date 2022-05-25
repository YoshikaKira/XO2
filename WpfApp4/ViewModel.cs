using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace WpfApp4
{

    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<string> _area;//при перемени данных внутри оповещает
        Model model;
        public ViewModel()
        {
            _area = new ObservableCollection<string>()
            {
                 " "," "," "," "," "," "," "," "," "//заполняем пробелами, ибо так легче сравнивать
            };
            model = new Model();
        }
        private void NewGame()
        {
            Area = new ObservableCollection<string>()
            {
                 " "," "," "," "," "," "," "," "," "//заполняем пробелами, ибо так легче сравнивать
            };
            model = new Model();
        }
        public ObservableCollection<string> Area
        {
            get { return _area;  }
            set
            {
                _area = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Area"));
            }
        }
        public ICommand NewGameClick
        {
            get { return new ButtonCommand(new Action<object>((obj) => { NewGame(); })); }
        }
        public ICommand ButtonClick

        {
            get
            {
                return new ButtonCommand(new System.Action<object>((obj) =>
                {
                    int num = Convert.ToInt32(obj.ToString());
                    Area[num] = model.Turn(num);
                    if (model.Winner() != null)
                    {
                        MessageBox.Show(model.Winner()); 
                        NewGame();
                    }
                }));
            }
        }
    }
}
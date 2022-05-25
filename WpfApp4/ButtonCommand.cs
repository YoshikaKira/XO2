using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp4
{
    class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<object> _action;//делегат, что принимает в себя функции подобного вида
        public ButtonCommand(Action<object> action)
        {
            _action = action;
        }
        public bool CanExecute(object parameter)//нажимается-ли кнопка, принимает только значение тру или фолс
        {
            return true;
        }

        public void Execute(object parameter)//что происходит при нажатии
        {
            _action(parameter);
        }
    }
}

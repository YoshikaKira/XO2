using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    class Model
    {
        List<string> _area;
        bool _isCross;//ходят или нет крестики
        int _count;
        public Model()
        {
            _area = new List<string>()
            {
                " "," "," "," "," "," "," "," "," "//заполняем пробелами, ибо так легче сравнивать
            };
            _isCross = true;
            _count = 0;
        }
        private bool CheckWinner()//проверка, кто победил, сравнивая индексы всех "клеток"
        {
            if (_area[0] == _area[1] && _area[1] == _area[2] && _area[0]!=" ") return true;
            if (_area[3] == _area[4] && _area[4] == _area[5] && _area[3] != " ") return true;
            if (_area[6] == _area[7] && _area[7] == _area[8] && _area[6] != " ") return true;

            if (_area[0] == _area[3] && _area[3] == _area[6] && _area[0] != " ") return true;
            if (_area[1] == _area[4] && _area[4] == _area[7] && _area[1] != " ") return true;
            if (_area[2] == _area[5] && _area[5] == _area[8] && _area[2] != " ") return true;

            if (_area[0] == _area[4] && _area[4] == _area[8] && _area[0] != " ") return true;
            if (_area[2] == _area[4] && _area[4] == _area[6] && _area[2] != " ") return true;

            return false;
        }
        public string Winner()
        {
            if (CheckWinner() == true)
            
                if (_isCross) 
                    return"Zero Win";
                else 
                    return "Cross Win";
                else if (_count >= 9) 
                    return "Draw";
            return null;
        }
        public string Turn(int num)
        {
            if (_area[num] == " ")//проверка, есть-ли внутри хоть что-то
            {
                if (_isCross)//если ход Х, то ставим нужный знак
                    _area[num] = "X";
                else
                    _area[num] = "O";
                _count++;
                _isCross = !_isCross;//нужно для передачи хода, то-есть если ходили Х, то теперь нет
            }
            return _area[num];
        }
    }
}

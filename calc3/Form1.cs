using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace calc2
{
    public partial class Form1 : Form
    {
        public bool     setDot = false,
                        setOperator = false;
        int leftBracketCount = 0,
            rightBracketCount = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private double getNumAndOpsFromString (string _line)
        { // выделяет из строки список чисел и список операторов
            List<double> _numbers = new List<double>();
            List<char> _operators = new List<char>();

            char[] nums = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',', '(', ')'};
            char[] ops = new char[] { '*', '/', '+', '*', '-', '^', '(', ')' };

            string[] _numbers_s = _line.Split(ops);
            string[] _operators_s = _line.Split(nums);

            for (int tmpA = 0; tmpA < _numbers_s.Length; tmpA++)
            {
                if (_numbers_s[tmpA] != "" && _numbers_s[tmpA] != " ")
                {
                    _numbers.Add(Convert.ToDouble(_numbers_s[tmpA]));
                }
            }
            for (int tmpB = 0; tmpB < _operators_s.Length; tmpB++)
            {
                if (_operators_s[tmpB] != "" && _operators_s[tmpB] != " ")
                {
                    if(_operators_s[tmpB].Length == 2 && _operators_s[tmpB][1] == '-')
                    {
                        _numbers[tmpB] *= -1;
                        _operators.Add(Convert.ToChar(_operators_s[tmpB][0]));
                    } else
                    {
                        _operators.Add(Convert.ToChar(_operators_s[tmpB]));
                    }
                }
            }

            if (_numbers.Count - 1 == _operators.Count)
            {
                return calculator(_numbers, _operators);
            } else if (_numbers.Count  == _operators.Count && _operators[0] == '-')
            {
                _numbers[0] *= -1;
                _operators.Remove(_operators[0]);
                return calculator(_numbers, _operators);
            } else
            {
                return 0;
            }
        }

        private double calculator(List<double> _num, List<char> _oper)
        {// ищет операторы по приоритету, вызывает метод выполняющий операцию, подставляет результат вместо чисел, и рекурсивно вызывается ещё n-раз
            
            
            for (int i = 0; i < _oper.Count; i++)
            {
                if (_oper[i] == '^')
                {
                    _num[i] = doOperation(_num[i], _num[i + 1], _oper[i]);
                    _num.Remove(_num[i + 1]);
                    _oper.Remove(_oper[i]);
                    calculator(_num, _oper);
                }
            }
            for (int i = 0; i < _oper.Count; i++)
            {
                if (_oper[i] == '*' || _oper[i] == '/')
                {
                    _num[i] = doOperation(_num[i], _num[i + 1], _oper[i]);
                    _num.Remove(_num[i + 1]);
                    _oper.Remove(_oper[i]);
                    calculator(_num, _oper);
                }
            }
            for (int i = 0; i < _oper.Count; i++)
            {
                _num[i] = doOperation(_num[i], _num[i + 1], _oper[i]);
                _num.Remove(_num[i + 1]);
                _oper.Remove(_oper[i]);
                calculator(_num, _oper);
            }
            return _num[0];
        }

        private double doOperation (double _x, double _y, char _operator)
        {   // операции + - * / ^   

            switch (_operator)
            {
                case '+':
                    return _x + _y;
                case '/':
                    return _x / _y;
                case '*':
                    return _x * _y;
                case '-':
                    return _x - _y;
                case '^':
                    return Math.Pow(_x, _y);
                default:
                    return 0;
            }
        }

        private double doOperationTring (string _tr, double _x)
        {
            switch (_tr)
            {
                case "cos":
                    return Math.Cos(_x);
                case "sin":
                    return Math.Sin(_x);
                case "ctg":
                    return  1 / Math.Tan(_x);
                case "tg":
                    return Math.Tan(_x);
                default:
                    return 0;
            }
        }

        private void lastOperationInLabel (string textLine)
        {// добивление текста в верхний лэблэ
            lastOperationBox.Items.Add(textLine);
        }

        private bool checkCurrentSymbolForOperator(char symbol)
        {   // проверка всей строки на наличие хоть 1 символа
            switch (symbol)
            {
                case '+':
                    return false;
                case '/':
                    return false;
                case '*':
                    return false;
                case '-':
                    return false;
                case '^':
                    return false;
                default:
                    return true;
            }
        }

        private bool checkForLastOperator(char symbol)
        {   // проверка последнего символа на + - * / ^

            switch (symbol)
            {
                case '+':
                    return true;
                case '-':
                    return true;
                case '*':
                    return true;
                case '/':
                    return true;
                case '^':
                    return true;
                default:
                    return false;
            }
        }

        private double bracketParser(string _line)
        {
            for (int indexMain = 0; indexMain < _line.Length; indexMain++)
            {
                if (_line[indexMain] == ')')
                {
                    for (int indexSubMain = indexMain; indexSubMain >= 0; indexSubMain--)
                    {
                        if (_line[indexSubMain] == '(')
                        {
                            string tmpSubLine = _line.Substring(indexSubMain, indexMain - indexSubMain + 1);
                            double tmpResult = getNumAndOpsFromString(tmpSubLine.Trim('(', ')'));

                            return bracketParser(_line.Replace(tmpSubLine, tmpResult.ToString()));
                        }
                    }
                }
            }
            return getNumAndOpsFromString(_line);
        }

        private void mainTextBox_KeyPress(object sender, KeyPressEventArgs e)
        { // ручной ввод цифр
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        { // ввод textBox3.Text
            if (e.KeyChar <= 47 || e.KeyChar >= 58)
            {
                e.Handled = true;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        { // кнопка clear all
            mainTextBox.Text = "";
            prelabel.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Text = "";
            prelabel.Text = "";
            setDot = false;
        }

        private void button13_Click(object sender, EventArgs e)
        { // кнопка clear last symbol
            if (mainTextBox.Text != "")
            {
                char lastSymbol = mainTextBox.Text[mainTextBox.Text.Length - 1];

                if (lastSymbol == '.')
                {
                    setDot = false;
                }

                mainTextBox.Text = mainTextBox.Text.Remove(mainTextBox.Text.Length - 1);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {   // кнопки + - * / ^
            Button btn = (Button)sender;

            if (mainTextBox.Text != "" && !checkForLastOperator(mainTextBox.Text[mainTextBox.Text.Length - 1])) // добавить проверку последнего символа на оператор
            {
                mainTextBox.Text += btn.Text;
                setDot = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        { // кнопки 1 2 3 4 5 6 7 8 9 (
            Button btn = (Button)sender;

            if (mainTextBox.Text == "0")
            {
                mainTextBox.Text = "";
            }
            if (btn.Text == "(")
            {
                leftBracketCount++;
            }

            mainTextBox.Text += btn.Text;
        }

        private void button22_Click(object sender, EventArgs e)
        {   // кнопка 0
            if (mainTextBox.Text == "0" || mainTextBox.Text == "")
            {
                mainTextBox.Text = "0";
            } else
            {
                mainTextBox.Text += "0";
                setDot = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {   // кнопка x^y
            if (mainTextBox.Text != "" && !checkForLastOperator(mainTextBox.Text[mainTextBox.Text.Length - 1])) // добавить проверку последнего символа на оператор
            {
                mainTextBox.Text += "^";
                setDot = false;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {   // кнопка ","
            if (mainTextBox.Text == "")
            {
                mainTextBox.Text = "0,";
                setDot = true;
            }
            else if (!setDot)
            {
                mainTextBox.Text += ",";
                setDot = true;
            }

        }

        private void button29_Click(object sender, EventArgs e)
        {   // кнопки cos sin ctg tg по нажатию на них
            Button btn = (Button)sender;

            prelabel.Text = btn.Text;
        }

        private void button24_Click(object sender, EventArgs e)
        { // кнопка = 

            if (mainTextBox.Text != "")
            {
                if (rightBracketCount != leftBracketCount)
                {
                    MessageBox.Show("Проверьте кол-во скобок");
                    return;
                }
                if (prelabel.Text == "")
                {
                    double tmpResult = bracketParser(mainTextBox.Text);
                    lastOperationInLabel(mainTextBox.Text + "=" + tmpResult);
                    mainTextBox.Text = tmpResult.ToString();
                }
                else
                {
                    double tmpResult = bracketParser(mainTextBox.Text);
                    double tmpA = doOperationTring(prelabel.Text, tmpResult);

                    if (mainTextBox.Text != tmpResult.ToString())
                    {
                        lastOperationInLabel($"{prelabel.Text}({mainTextBox.Text})={prelabel.Text}({tmpResult})=");
                    }
                    else
                    {
                        lastOperationInLabel($"{prelabel.Text}({tmpResult})={tmpA}");
                    }

                    mainTextBox.Text = tmpA.ToString();
                }

                prelabel.Text = "";
                setDot = false;
            }
            else
            {
                MessageBox.Show("Введите операцию в поле выше");
            }
        }

        private void powbtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                double x = Convert.ToDouble(textBox1.Text);
                double y = Convert.ToDouble(textBox2.Text);
                double z;

                z = Math.Pow(x, 1 / y);


                textBox3.Text = z.ToString();
                lastOperationBox.Items.Add(textBox1.Text + "√" + textBox2.Text + "=" + z);
            }
            else
            {
                MessageBox.Show("Введите степень и число");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
                mainTextBox.Text += textBox3.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        { // кнопка )
            Button btn = (Button)sender;

            if (mainTextBox.Text.Length > 0 && mainTextBox.Text[mainTextBox.Text.Length - 1] != '(' && leftBracketCount > rightBracketCount)
            {
                mainTextBox.Text += btn.Text;
                rightBracketCount++;
            }
        }

    }
}

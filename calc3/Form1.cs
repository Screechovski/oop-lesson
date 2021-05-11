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
        /// <summary>
        /// Выделяет из строки список чисел и список операторов
        /// </summary>
        /// <param name="line"></param>
        /// <returns>Результат</returns>
        private double LineParse (string line)
        {
            List<double> numbers = new List<double>();
            List<char> functions = new List<char>();

            char[] numbersArray = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',', '(', ')'};
            char[] functionsArray = new char[] { '*', '/', '+', '*', '-', '^', '(', ')' };

            string[] numbersArraySplit = line.Split(functionsArray);
            string[] functionsArraySplit = line.Split(numbersArray);

            for (int tmpA = 0; tmpA < numbersArraySplit.Length; tmpA++)
            {
                if (numbersArraySplit[tmpA] != "" && numbersArraySplit[tmpA] != " ")
                {
                    numbers.Add(Convert.ToDouble(numbersArraySplit[tmpA]));
                }
            }
            for (int tmpB = 0; tmpB < functionsArraySplit.Length; tmpB++)
            {
                if (functionsArraySplit[tmpB] != "" && functionsArraySplit[tmpB] != " ")
                {
                    if(functionsArraySplit[tmpB].Length == 2 && functionsArraySplit[tmpB][1] == '-')
                    {
                        numbers[tmpB] *= -1;
                        functions.Add(Convert.ToChar(functionsArraySplit[tmpB][0]));
                    } else
                    {
                        functions.Add(Convert.ToChar(functionsArraySplit[tmpB]));
                    }
                }
            }

            if (numbers.Count - 1 == functions.Count)
            {
                return Сalculator(numbers, functions);
            } else if (numbers.Count  == functions.Count && functions[0] == '-')
            {
                numbers[0] *= -1;
                functions.Remove(functions[0]);
                return Сalculator(numbers, functions);
            } else
            {
                return 0.0;
            }
        }

        /// <summary>
        /// Рабивает строку на простые математические выражения 
        /// и вызывает метода DoOperation для их подсчета, 
        /// и заменяет исходную строку на полученный результат
        /// </summary>
        /// <param name="num"></param>
        /// <param name="oper"></param>
        /// <returns></returns>
        private double Сalculator(List<double> num, List<char> oper)
        {// ищет операторы по приоритету, вызывает метод выполняющий операцию, подставляет результат вместо чисел, и рекурсивно вызывается ещё n-раз
            for (int i = 0; i < oper.Count; i++)
            {
                if (oper[i] == '^')
                {
                    num[i] = DoOperation(num[i], num[i + 1], oper[i]);
                    num.Remove(num[i + 1]);
                    oper.Remove(oper[i]);
                    Сalculator(num, oper);
                }
            }
            for (int i = 0; i < oper.Count; i++)
            {
                if (oper[i] == '*' || oper[i] == '/')
                {
                    num[i] = DoOperation(num[i], num[i + 1], oper[i]);
                    num.Remove(num[i + 1]);
                    oper.Remove(oper[i]);
                    Сalculator(num, oper);
                }
            }
            for (int i = 0; i < oper.Count; i++)
            {
                num[i] = DoOperation(num[i], num[i + 1], oper[i]);
                num.Remove(num[i + 1]);
                oper.Remove(oper[i]);
                Сalculator(num, oper);
            }
            return num[0];
        }
        /// <summary>
        /// Подсчет классических математических операций типа X+Y
        /// </summary>
        /// <param name="x">Первый операнд</param>
        /// <param name="y">Второй операнд операнд</param>
        /// <param name="localOperator">Тип операции (+,-,*,/,^)</param>
        /// <returns>Результат операции с типом double</returns>
        private double DoOperation (double x, double y, char localOperator)
        {   // операции + - * / ^   

            switch (localOperator)
            {
                case '+':
                    return x + y;
                case '/':
                    return x / y;
                case '*':
                    return x * y;
                case '-':
                    return x - y;
                case '^':
                    return Math.Pow(x, y);
                default:
                    return 0;
            }
        }
        /// <summary>
        /// Подсчет тригонометрических операций типа Cos(X)
        /// </summary>
        /// <param name="tr">Тип операции (cos,sin,ctg,tg)</param>
        /// <param name="x">Операнд</param>
        /// <returns>Результат операции с типом double</returns>
        private double DoOperation (string tr, double x)
        {
            switch (tr)
            {
                case "cos":
                    return Math.Cos(x);
                case "sin":
                    return Math.Sin(x);
                case "ctg":
                    return  1 / Math.Tan(x);
                case "tg":
                    return Math.Tan(x);
                default:
                    return 0;
            }
        }
        /// <summary>
        /// Добавление операции в список операций
        /// </summary>
        /// <param name="textLine">Операция которую хотим добавить</param>
        private void AddLastOperationInLabel (string textLine)
        {
            lastOperationBox.Items.Add(textLine);
        }
        /// <summary>
        /// Проверяет символ на оператор '+','*','-','/','^'
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        private bool IsOperator(char symbol)
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
        /// <summary>
        /// Разбивает строку с круглыми скобками и вызывает функцию LineParse для подсчета, заменяет исходню подстроку на результат подсчета
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private double BracketParser(string line)
        {
            for (int indexMain = 0; indexMain < line.Length; indexMain++)
            {
                if (line[indexMain] == ')')
                {
                    for (int indexSubMain = indexMain; indexSubMain >= 0; indexSubMain--)
                    {
                        if (line[indexSubMain] == '(')
                        {
                            string tmpSubLine = line.Substring(indexSubMain, indexMain - indexSubMain + 1);
                            double tmpResult = LineParse(tmpSubLine.Trim('(', ')'));

                            return BracketParser(line.Replace(tmpSubLine, tmpResult.ToString()));
                        }
                    }
                }
            }
            return LineParse(line);
        }
        /// <summary>
        /// Проверяет количество '(' и ')'
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private bool CheckBrackets(string line)
        {
            int numberPairsBrackets = 0;

            foreach (var letter in line)
            {
                if (letter == ')')
                {
                    numberPairsBrackets++;
                }
                else if (letter == '(')
                {
                    numberPairsBrackets--;
                }
            }

            return numberPairsBrackets == 0;
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
        /// <summary>
        /// Метод вызывающийся по нажатию на кнопки: + - * / ^
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (mainTextBox.Text != "" && !IsOperator(mainTextBox.Text[mainTextBox.Text.Length - 1])) // добавить проверку последнего символа на оператор
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
            if (mainTextBox.Text != "" && !IsOperator(mainTextBox.Text[mainTextBox.Text.Length - 1])) // добавить проверку последнего символа на оператор
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
                if (!CheckBrackets(mainTextBox.Text))
                {
                    MessageBox.Show("Проверьте кол-во скобок");
                    return;
                }
                double tmpResult = BracketParser(mainTextBox.Text);
                if (prelabel.Text == "")
                {
                    AddLastOperationInLabel(mainTextBox.Text + "=" + tmpResult);
                    mainTextBox.Text = tmpResult.ToString();
                }
                else
                {
                    double tmpA = DoOperation(prelabel.Text, tmpResult);

                    if (mainTextBox.Text != tmpResult.ToString())
                    {
                        AddLastOperationInLabel($"{prelabel.Text}({mainTextBox.Text})={prelabel.Text}({tmpResult})=");
                    }
                    else
                    {
                        AddLastOperationInLabel($"{prelabel.Text}({tmpResult})={tmpA}");
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
            if (textBox3.Text != "") mainTextBox.Text += textBox3.Text;
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static int b=1;
        public Form1()
        {
            InitializeComponent();
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText("../../log.txt", "");//確保每次執行程式清空之前執行的紀錄
            textBox1.Text = "0";//預設值
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int MAX, MIN, times, duplicate = 0;
            times = int.Parse(textBox1.Text);//抽獎次數 若獎項為0則不可進行抽獎
            string a = System.IO.File.ReadAllText("../../limit.txt");
            string c = System.IO.File.ReadAllText("../../log.txt");
            string t;
            string[] limit = a.Split(SplitWord(a));
            string[] log = new string[100];
            MAX = int.Parse(limit[1]);
            MIN = int.Parse(limit[0]);
            if (b == 0)
            {
                if (times > 0)
                {
                    Random rnd = new Random(Guid.NewGuid().GetHashCode());
                    do
                    {
                        int y = rnd.Next(MIN, MAX + 1);
                        for (int i = log.Length - 1; i >= 0; i--)//驗證是否重複
                        {
                            if (y.ToString() == log[i])
                            {
                                duplicate = 1;
                            }
                        }
                        if (duplicate == 0)
                        {
                            t = y.ToString();
                            if (t.Length < 6)
                            {
                                for (int i = 6 - t.Length; i > 0; i--)
                                {
                                    t = "0" + t;
                                }
                            }
                            label1.Text = t;
                            times = times - 1;
                            textBox1.Text = times.ToString();
                            log[times] = y.ToString();
                            System.IO.File.AppendAllText("../../log.txt", y.ToString() + ",");
                        }
                    } while (duplicate == 1);
                }
                else if (times < 0)
                {
                    MessageBox.Show("請輸入獎項數目");
                }
            }
            else
            {
                if ((MAX - MIN + 1) >= times && times > 0)
                {
                    Random rnd = new Random(Guid.NewGuid().GetHashCode());
                    do
                    {
                        int y = rnd.Next(MIN, MAX + 1);
                        for (int i = log.Length - 1; i >= 0; i--)//驗證是否重複
                        {
                            if (y.ToString() == log[i])
                            {
                                duplicate = 1;
                            }
                        }
                        if (duplicate == 0)
                        {
                            t = y.ToString();
                            if (t.Length < 6)
                            {
                                for (int i = 6 - t.Length; i > 0; i--)
                                {
                                    t = "0" + t;
                                }
                            }
                            label1.Text = t;
                            times = times - 1;
                            textBox1.Text = times.ToString();
                            log[times] = y.ToString();
                            System.IO.File.AppendAllText("../../log.txt", y.ToString() + ",");
                        }
                    } while (duplicate == 1);
                }
                else if (times < 0)
                {
                    MessageBox.Show("請輸入獎項數目");
                }
                else if (times > (MAX - MIN + 1))
                {
                    DialogResult dialogResult = MessageBox.Show("抽獎人數不足，是否自動轉換為抽獎人數", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int Range = MAX - MIN + 1;
                        textBox1.Text = Range.ToString();
                    }
                    if (dialogResult == DialogResult.No)
                    {
                        b = 0;
                    }
                }
            }
        }
        private char[] SplitWord(string a)//選出區隔文字
        {
            int s = 0;
            char[] SplitWord = new char[a.Length / 2];
            for (int i = 0; i < a.Length; i++)
            {
                switch (a[i])
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        break;
                    case '6':
                        break;
                    case '7':
                        break;
                    case '8':
                        break;
                    case '9':
                        break;
                    case '0':
                        break;
                    default:
                        SplitWord[s] = a[i];
                        s++;
                        break;
                }
            }
            return SplitWord;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(System.IO.File.ReadAllText("../../log.txt"), "中獎號碼");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "000000";
            textBox1.Text = "";
            System.IO.File.WriteAllText("../../log.txt", "");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(textBox2.Text) * 1000;
            timer1.Start();
            timer1_Tick(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            if ( int.Parse(textBox1.Text)==0)
            {
                timer1.Stop();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

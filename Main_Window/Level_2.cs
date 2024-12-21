using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Window
{
    public partial class Level_2 : Form
    {
        // Временный флаг для обозначения какую картинку выводить
        public bool flag1 = false;
        public bool flag2 = false;
        // Переменная для таймера окончания игры
        private int countdown = 90;
        // Переменная для отсчета ошибок
        private int mistake = 10;

        public Level_2()
        {
            InitializeComponent();
        }

        // метод перезапуска таймера инцидентов
        private void TimesIncident_function()
        {

            Random random = new Random();
            int randTime = random.Next(1000, 2001);

            Time_Incident.Interval = randTime; // 1-2 сек таймер
            Time_Incident.Start();

        }

        // метод запуска таймера игры
        private void gamesOver_timer_function()
        {

            GameOver.Interval = 1000;
            GameOver.Start();

        }

        // метод для таймера ошибок
        private void PrBar_Timer_function()
        {

            PrBar_Timer.Interval = 1500;
            PrBar_Timer.Start();

        }

        //main()
        private void Level_2_Load(object sender, EventArgs e)
        {
            gamesOver_timer_function();
            TimesIncident_function();

            //label2.Text = mistake.ToString();
            progressBar1.Value = mistake * 10;
        }

        // Когда останавливается таймер выбирается одна из четырех картинок
        private void Time_Incident_Tick(object sender, EventArgs e)
        {
            Time_Incident.Stop();

            Random random = new Random();
            int randMan = random.Next(1, 5);
            if (randMan == 1)
            {
                flag1 = true;
                flag2 = true;
                pictureBox1.Image = Image.FromFile("..\\..\\img3\\lvl_2_3.jpg");
                PrBar_Timer_function();
            }
            else if (randMan == 2)
            {
                flag1 = false;
                flag2 = false;
                pictureBox1.Image = Image.FromFile("..\\..\\img3\\lvl_2_1.jpg");
                PrBar_Timer_function();
            }
            else if (randMan == 3)
            {
                flag1 = true;
                flag2 = false;
                pictureBox1.Image = Image.FromFile("..\\..\\img3\\lvl_2_4.jpg");
                PrBar_Timer_function();
            }
            else if (randMan == 4)
            {
                flag1 = false;
                flag2 = true;
                pictureBox1.Image = Image.FromFile("..\\..\\img3\\lvl_2_2.jpg");
                PrBar_Timer_function();
            }
        }

        //Ведется обратный отсчет до конца игры
        private void GameOver_Tick(object sender, EventArgs e)
        {
            if (countdown == 0)
            {
                GameOver.Stop();
                Time_Incident.Stop();
                MessageBox.Show("Вы победили!", "Поздравляю");
                this.Close();
            }
            else if (countdown > 0)
            {
                countdown--;
                label1.Text = countdown.ToString();
                if (mistake < 1)
                {
                    GameOver.Stop();
                    Time_Incident.Stop();
                    PrBar_Timer.Stop();
                    MessageBox.Show("Вы проиграли...", "Конец");
                    this.Close();
                }
            }
        }

        // Тамер ошибок
        private void PrBar_Timer_Tick(object sender, EventArgs e)
        {
            PrBar_Timer.Stop();
            mistake--;
            progressBar1.Value = mistake * 10;
            pictureBox1.Image = Image.FromFile("..\\..\\img3\\lvl_2.jpg");
            TimesIncident_function();
        }

        // Меняем картинку с первой на изначальную
        private void button1_Click(object sender, EventArgs e)
        {
            if (Time_Incident.Enabled == false && flag1 == true && flag2 == true)
            {
                pictureBox1.Image = Image.FromFile("..\\..\\img3\\lvl_2.jpg");
                TimesIncident_function();
                PrBar_Timer.Stop();
            }
        }

        // Меняем картинку со второй на изначальную
        private void button2_Click(object sender, EventArgs e)
        {
            if (Time_Incident.Enabled == false && flag1 == false && flag2 == false)
            {
                pictureBox1.Image = Image.FromFile("..\\..\\img3\\lvl_2.jpg");
                TimesIncident_function();
                PrBar_Timer.Stop();
            }
        }

        // Меняем картинку с третей на изначальную
        private void button3_Click(object sender, EventArgs e)
        {
            if (Time_Incident.Enabled == false && flag1 == true && flag2 == false)
            {
                pictureBox1.Image = Image.FromFile("..\\..\\img3\\lvl_2.jpg");
                TimesIncident_function();
                PrBar_Timer.Stop();
            }
        }

        // Меняем картинку с четвертой на изначальную
        private void button4_Click(object sender, EventArgs e)
        {
            if (Time_Incident.Enabled == false && flag1 == false && flag2 == true)
            {
                pictureBox1.Image = Image.FromFile("..\\..\\img3\\lvl_2.jpg");
                TimesIncident_function();
                PrBar_Timer.Stop();
            }
        }
    }
}

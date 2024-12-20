using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Main_Window
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
            player.URL = "muzic2.mp3";
        }
        

        // Метод для музыкального таймера
        private void muzikTimer_function()
        {
            muzic_timer.Interval = 1000;
            muzic_timer.Start();
        }

        //main()
        private void Form1_Load(object sender, EventArgs e)
        {
            player.controls.play();
            muzikTimer_function();
        }

        // Первый уровень
        private void button1_Click(object sender, EventArgs e)
        {
            Level_1 settingsForm = new Level_1();
            settingsForm.ShowDialog();
        }

        // Второй уровень
        private void button2_Click(object sender, EventArgs e)
        {
            Level_2 settingsForm = new Level_2();
            settingsForm.ShowDialog();

        }
        

        // При завершение таймера запускается трек повторно
        private void muzik_timer_Tick(object sender, EventArgs e)
        {
            muzic_timer.Stop();
            player.controls.stop();
            player.controls.play();
            muzikTimer_function();
        }

        
    }
}

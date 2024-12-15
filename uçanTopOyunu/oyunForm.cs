using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uçanTopOyunu
{
    public partial class Form1 : Form
    {
        int hareketX = 20, hareketY = 20;
        int hak = 3;
        int puan = 0;
        int sure = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void engel()
        {
            // çarpma
            if (ball.Top <= ustEngel.Bottom)
                hareketY = hareketY * -1;
            //üst engel çarpma
            if (ball.Bottom >= kontrol.Top && ball.Left >= kontrol.Left && ball.Right <= kontrol.Right) hareketY = hareketY * -1;
            //sağ engel
            else if (ball.Right >= sagEngel.Left) hareketX = hareketX * -1;
            //sol engel
            else if (ball.Left <= solEngel.Right) hareketX = hareketX * -1;


        }
        
        private void kaybettme(object sender, EventArgs e)
        {
            if (ball.Top >= sagEngel.Bottom)
            {
                if (hak > 0)
                {
                    timer1.Stop();
                    hak--;
                    MessageBox.Show("yandınız kalan hak=" + hak.ToString());
                    Form1_Load(sender, e);
                }

                if (hak == 0) 
                {
                    timer1.Stop();
                    MessageBox.Show("Oyun Bitti", "", MessageBoxButtons.OK);
                }


            }
            label4.Text = hak.ToString();
        }
        private void oyuncuPuan()
        {
            if (Math.Abs(ball.Bottom - kontrol.Top) <= 5)
            {
                puan += 5; puanLabel.Text = puan.ToString(); this.Refresh();
                switch (puan)
                {
                    case int p when (p >= 50 && p <= 60): hareketX += 5; hareketY += 5; break;
                    case int p when (p >= 100 && p <= 110): hareketX += 5; hareketY += 5; break;
                    case int p when (p >= 150 && p <= 160): hareketX += 5; hareketY += 5; break;
                    case int p when (p >= 200 && p <= 210): hareketX += 5; hareketY += 5; break;
                    case int p when (p >= 500 && p <= 510): hareketX += 15; hareketY += 15; break;
                }
            }

        }

        private void oyunSure()
        {
            if(timer1.Enabled==true)
            {
                sure = sure + 1;
                int saniye = sure / 60;
                sureLabel.Text= saniye.ToString();
            }
            else
            {
                timer1.Enabled = false;

                
            }
        }

        private void topKonum()
        {
            ball.Location = new Point(329, 148);
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
            // mouse kontrolü sağlar
            kontrol.Left = e.X;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            engel();
            kaybettme(sender, e);
            oyunSure();
            oyuncuPuan();
            ball.Location = new Point(ball.Location.X + hareketX, ball.Location.Y + hareketY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Çıkmak istediğinizden emin misiniz","",MessageBoxButtons.YesNo);
            Form1 form1 = new Form1();
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            topKonum();
            timer1.Enabled = true;
        }
    }
}

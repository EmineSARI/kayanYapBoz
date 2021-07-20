﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kayanYapBoz
{
    public partial class Form1 : Form
    {
        PictureBox[] Kutular;
        Point [] dogruKoordinatlar= new Point[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kutular = new PictureBox[] {pb0,pb1,pb2,pb3,pb4,pb5,pb6,pb7,pb8 };
            for (int i=0;i<9;i++)
            {
                dogruKoordinatlar[i] = Kutular[i].Location;
            }
            resmiParcala();

        }

        private void resmiParcala()
        {
            Bitmap resim = new Bitmap(pictureBox10.Image,450,450);

            for (int i=0;i<3;i++)
            {
                for (int j=0;j<3;j++)
                {
                    int indeks = i * 3 + j;

                    Bitmap parca = resim.Clone(new Rectangle(j * 150, j * 150, 150, 150), resim.PixelFormat);
                    Graphics cizer = Graphics.FromImage(parca);
                    cizer.DrawString(indeks.ToString(), Font, Brushes.Red, 15, 15);

                    Kutular[indeks].Image = parca;


                }

            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox10.Image = Image.FromFile(openFileDialog1.FileName);
                resmiParcala();
            }
        }

        private void btnKaristir_Click(object sender, EventArgs e)
        {
            pb8.Visible = false;

            Random rastgele = new Random();
            for(int i = 0; i < 1000; i++)
            {
                int kutuNo = rastgele.Next(8);
                oynat(Kutular[kutuNo]);
            }

        }

        private void pb0_Click(object sender, EventArgs e)
        {
            oynat((PictureBox)sender);

            for (int i = 0; i < 9; i++)
            {
                if (Kutular[i].Location != dogruKoordinatlar[i])
                    return;
            }
            pb8.Visible = true;
            MessageBox.Show("Tebrikler");
        }

        private void oynat(PictureBox kutu)
        {
            if(kutu.Left +102 == pb8.Left && kutu.Top == pb8.Top ||
               kutu.Left - 102 == pb8.Left && kutu.Top == pb8.Top ||
               kutu.Left == pb8.Left && kutu.Top - 102 == pb8.Top ||
               kutu.Left  == pb8.Left && kutu.Top +102== pb8.Top)
            {
                Point gecici = kutu.Location;
                kutu.Location = pb8.Location;
                pb8.Location = gecici;
            }
        }
    }
}

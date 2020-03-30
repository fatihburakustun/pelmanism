using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace esini_bul
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        int kontrol, indeks, z, i, m, kontrolbir, kontrol2, bittimi;
        PictureBox mhmttt;
        PictureBox birincipicbox, ikincipicbox;
        int[] sayilar1 = new int[20];
        int[] sayilar2 = new int[20];

        private void box(PictureBox resimler, int zz)
        {

            resimler.Image = imageList1.Images[(Convert.ToInt32(listBox1.Items[zz])) - 1];
            resimler.Enabled = false;
            kontrol++;

            if (kontrol == 1)
            {
                birincipicbox = resimler;

            }
            else if (kontrol == 2)
            {
                ikincipicbox = resimler;

                timer1.Enabled = true;

                foreach (Control var in this.Controls)
                {
                    if (var is PictureBox)
                    {

                        mhmttt = var as PictureBox;
                        mhmttt.Enabled = false;
                    }

                }

            }
        }
        private void ddd(PictureBox p, PictureBox p2)
        {
            PictureBox al = new PictureBox();
            PictureBox al2 = new PictureBox();

            foreach (Control var in this.Controls)
            {
                if (var is PictureBox)
                {
                    al = var as PictureBox;
                    if (p == al)
                    {
                        int no = Convert.ToInt32(var.Name.Substring(10, var.Name.Length - 10));
                        kontrolbir = Convert.ToInt32(listBox1.Items[no - 1]);
                    }
                }

            }

            foreach (Control var in this.Controls)
            {
                if (var is PictureBox)
                {
                    al2 = var as PictureBox;
                    if (p2 == al2)
                    {
                        int no = Convert.ToInt32(var.Name.Substring(10, var.Name.Length - 10));
                        kontrol2 = Convert.ToInt32(listBox1.Items[no - 1]);
                    }
                }

            }

            if (kontrol2 == kontrolbir)
            {

                this.Controls.Remove(p);
                this.Controls.Remove(p2);
                bittimi++;
                if (bittimi == 20)
                {
                    Application.Exit();
                }
            }

        }

        private void PictureBoxClickleri(object sender, EventArgs e)
        {
            PictureBox p = new PictureBox();
            p = sender as PictureBox;

            box(p, Convert.ToInt32(p.Name.Substring(10, p.Name.Length - 10)) - 1);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            z = 0;
            i = 0;
            m = 0;
            #region foric
            foreach (Control var in this.Controls)
            {
                if (var is PictureBox)
                {

                    mhmttt = var as PictureBox;
                    mhmttt.Image = imageList1.Images[20];
                }

            }
            #endregion

            #region dongu
            while (i <= 19)
            {


                Random rnd = new Random();
                indeks = rnd.Next(1, 21);
                if (Array.IndexOf(sayilar1, indeks) == -1)
                {

                    sayilar1[i] = indeks;
                    i++;
                }

            }
            while (m <= 19)
            {

                Random y = new Random();
                indeks = y.Next(1, 21);
                if (Array.IndexOf(sayilar2, indeks) == -1)
                {

                    sayilar2[m] = indeks;
                    m++;
                }

            }

            while (listBox1.Items.Count < 40)
            {
                listBox1.Items.Add(sayilar1[z]);
                listBox1.Items.Add(sayilar2[z]);
                z++;
            }

            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (kontrol == 2)
            {
                ddd(birincipicbox, ikincipicbox);

                kontrol = 0;
                foreach (Control var in this.Controls)
                {
                    if (var is PictureBox)
                    {

                        mhmttt = var as PictureBox;
                        mhmttt.Image = imageList1.Images[20];
                    }

                }
                foreach (Control var in this.Controls)
                {
                    if (var is PictureBox)
                    {

                        mhmttt = var as PictureBox;
                        mhmttt.Enabled = true;
                    }

                }
                timer1.Enabled = false;
            }
        }
    }
}
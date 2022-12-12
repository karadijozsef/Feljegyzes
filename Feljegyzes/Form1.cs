using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Feljegyzes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_nev.Text))
            {
                MessageBox.Show("Adjon meg egy nevet!!!!");
                return;
            }
            if (string.IsNullOrEmpty(richTextBox_szoveg.Text))
            {
                MessageBox.Show("Nem adott meg szöveget!!!!!");
                return;
            }
            saveFileDialog1.Filter = "Egyszerű szöveg fájl| *.txt| Vesszővel tagolt szövegfájl(*.csv) |*.csv| Minden fájl|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string szov = string.Join(";",textBox_nev.Text, richTextBox_szoveg.Text);
                string kivalasztottFile = saveFileDialog1.FileName;
                File.WriteAllText(kivalasztottFile, szov);
                textBox_nev.Text = "";
                richTextBox_szoveg.Text = "";
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva!!!!!");
            }
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string kivFile = openFileDialog1.FileName;
                string beolvasottSzov = File.ReadAllText(kivFile);
                string[] adatok = beolvasottSzov.Split(';');
                textBox_nev.Text = adatok[0];
                richTextBox_szoveg.Text = adatok[1];
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08052021_AdamAsmaca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> cities;
        string city;
        List<char> guess;
        int live = 0;
        int lineCounter = 0;
        Random random;
        private void Form1_Load(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            live = 5;
            lineCounter = 0;
            lbHarfler.Items.Clear();

            cities = new List<string>() { "İSTANBUL", "İZMİR", "ADANA", "LOS ANGELES" };
            random = new Random();
            city = cities[random.Next(cities.Count)];
            
            guess = new List<char>();

            for (int i = 0; i < city.Length; i++)
            {
                if (city[i] != ' ')
                {
                    guess.Add('_');
                    lineCounter++;
                }
                else
                    guess.Add(' ');
            }
            
            WriteWord();
            this.Text = $"{live} hakkınız var";
            MessageBox.Show("Lütfen bir tuşa basınız.");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letter = char.ToUpper(e.KeyChar);
            MessageBox.Show(letter.ToString());

            if (!char.IsLetter(letter))//harf değilse program sonuna git.
            {
                return;
            }
            if (lbHarfler.Items.Contains(letter) || char.IsWhiteSpace(letter))//listboxta daha önceden varsa veya boşluksa kapat.
            {
                return;
            }
            if (city.Contains(letter))//Kullanıcının girdiği harf şehir içerisinde var mı?
            {
                //Kullanıcı doğru bildi.
                for (int i = 0; i < city.Length; i++)
                {
                    if (city[i] == letter)
                    {
                        guess[i] = letter;
                        lineCounter--;
                    }
                }
                WriteWord();
                lbHarfler.Items.Add(letter);
                if (lineCounter == 0)
                {
                    //MessageBox.Show("Kazandın");
                    //EndGame("Tebrikler kazandınız\n\nTekrar oynamak ister misiniz?");
                }
                
            }
            else
            {
                //Kullanıcı yanlış harf girdi.

                live--;
                this.Text = $"{live} hakkınız var.";
                if (live==0)
                {
                    //MessageBox.Show("Kaybettin");
                    //EndGame("Tebrikler kazandınız\n\nTekrar oynamak ister misiniz?");
                }
            }
        }

        private void WriteWord()
        {
            lblSehir.Text = string.Empty;
            foreach (char item in guess)
            {
                lblSehir.Text += item.ToString() + " ";
            }
        }

        //void EndGame(string message)
        //{
        //    DialogResult dialogResult = new DialogResult();
        //    dialogResult.
        //}
    }
}

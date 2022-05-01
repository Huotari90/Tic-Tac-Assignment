using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ristinollaa
{
    public partial class Form1 : Form
    {

        public enum pelaaja
        {
            X, O

        }
        pelaaja currentpelaaja;

        List<Button> buttons;
        Random rand = new Random();
        int pelaajaVoittaa = 0;
        int tietokoneVoittaa = 0;
        int tasapeli = 0;
        public Form1()
        {
            InitializeComponent();
            resetoiGame();
        }

        private void playerClick(object sender, EventArgs e)
        {
            //Pelaajan valinnat toteutetaan täällä.
            var button = (Button)sender;
            currentpelaaja = pelaaja.X;
            button.Text = currentpelaaja.ToString();
            button.Enabled = false;
            buttons.Remove(button);
            button.BackColor = default;
            check();
            AImoves.Start(); 
        }

        private void AImove(object sender, EventArgs e)
        {
            //Tietokoneen "valinta" toteutuu täällä.
            if (buttons.Count > 0)
            {
                int index = rand.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentpelaaja = pelaaja.O;
                buttons[index].Text = currentpelaaja.ToString();
                buttons.RemoveAt(index);
                check();
                AImoves.Stop();
            }

        }

        private void restartGame(object sender, EventArgs e)
        {
            resetoiGame();

        }

        private void painikkeet()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

        }

        private void resetoiGame()
        {
            //Pelin resetointi "pelaa"- painikkeesta suoritetaan täällä.
            foreach (Control X in this.Controls)
            {
                if (X is Button && X.Tag == "play")
                {
                    ((Button)X).Enabled = true;
                    ((Button)X).Text = "?";
                    ((Button)X).BackColor = default(Color);

                }

            }
            painikkeet();
        }

        private void check()
        {

                //Pelaajan voitto toteutuu täällä.
                if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
               || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
               || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")

               //Pelaajan voiton toteutuessa suoritetaan seuraavat toiminnot.
                {
                    AImoves.Stop();
                    MessageBox.Show("Pelaaja Voittaa!");
                    pelaajaVoittaa++;
                    label1.Text = "Pelaaja       " + pelaajaVoittaa;
                    resetoiGame();

                }
               //Tietokoneen voitto toteutuu täällä.
               else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
                || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")

                //Tietokoneen voiton toteutuessa suoritetaan seuraavat toiminnot.
                {
                    AImoves.Stop();
                    MessageBox.Show("Tietokone Voittaa!");
                    tietokoneVoittaa++;
                    label2.Text = "Tietokone       " + tietokoneVoittaa;
                    resetoiGame();
                }

                // Tasapeli toteutuu täällä.
                else if ((button1.Text == "O" || button1.Text == "X") && (button2.Text == "O" || button2.Text == "X") &&
                (button3.Text == "O" || button3.Text == "X") && (button4.Text == "O" || button4.Text == "X") &&
                (button5.Text == "O" || button5.Text == "X") && (button6.Text == "O" || button6.Text == "X") &&
                (button7.Text == "O" || button7.Text == "X") && (button8.Text == "O" || button8.Text == "X") &&
                (button9.Text == "O" || button9.Text == "X"))


                //Tasapelin toteutuessa suoritetaan seuraavat toiminnot.
                {
                MessageBox.Show("Tasapeli");
                    tasapeli++;
                    label3.Text = "Tasapelit       " + tasapeli;
                    resetoiGame();
                }

            
        }

        //Exit näppäin
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    } 

}

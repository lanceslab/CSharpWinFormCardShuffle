using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4_CardsShuffl
{
    public partial class Form1 : Form
    {

        PlayingCards.Deck myDeck = new PlayingCards.Deck();
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDeal_Click(object sender, EventArgs e)
        {
            labelOutput.Text = "Displaying a deck of cards delt out in order";
            int deckIndex = 0;
                foreach (PictureBox a in this.Controls.OfType<PictureBox>())
                {
                    a.Image = myDeck.Cards.ElementAt(deckIndex).FaceImage;
                    deckIndex += 1;
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            foreach (PlayingCards.CardValues a in Enum.GetValues(typeof(PlayingCards.CardValues)))
            {
                PlayingCards.Card clubCard = new PlayingCards.Card(PlayingCards.CardSuits.Club, a);
                PlayingCards.Card diamondCard = new PlayingCards.Card(PlayingCards.CardSuits.Diamond, a);
                PlayingCards.Card heartCard = new PlayingCards.Card(PlayingCards.CardSuits.Heart, a);
                PlayingCards.Card spadeCard = new PlayingCards.Card(PlayingCards.CardSuits.Spade, a);

                myDeck.Cards.Add(clubCard);
                myDeck.Cards.Add(diamondCard);
                myDeck.Cards.Add(heartCard);
                myDeck.Cards.Add(spadeCard);
            }

            int leftRow2 = 0;
            int leftShift = 20;
            for (int i = 0; i <= myDeck.Cards.Count - 1; i++)
            {
                if (i == 26)
                {
                    leftRow2 = 0;
                }
                PictureBox tempPicBox = new PictureBox();
                tempPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                tempPicBox.Height = 100;
                tempPicBox.Width = 80;
                tempPicBox.Parent = this;
                if (i == 0)
                {
                    tempPicBox.Left = leftShift;
                    tempPicBox.Top = 50;
                }
                else if (i > 0 && i < 26)
                {
                    tempPicBox.Left = leftShift + (i * 20);
                    tempPicBox.Top = 50;
                }
                else if (i >= 26)
                {
                    tempPicBox.Left = leftShift + (leftRow2 * 20);
                    tempPicBox.Top = 180;
                }
                leftRow2++;
            }
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            labelOutput.Text = "Displaying a deck of cards delt out out in a Random order!";
            int myRandomNumber = rand.Next(0, myDeck.Cards.Count);
            PlayingCards.Card tempCard;

            for (int i = 0; i <= myDeck.Cards.Count - 1; i++)           
            {
                tempCard = myDeck.Cards[i];
                myDeck.Cards[i] = myDeck.Cards[myRandomNumber];
                myDeck.Cards[myRandomNumber] = tempCard;
                myRandomNumber = rand.Next(0, myDeck.Cards.Count);
            }


            for (int i = 0; i <= myDeck.Cards.Count - 1; i++)
            {
                tempCard = myDeck.Cards[i];
                myDeck.Cards[i] = myDeck.Cards[myRandomNumber];
                myDeck.Cards[myRandomNumber] = tempCard;
                myRandomNumber = rand.Next(0, myDeck.Cards.Count);
            }
            // re display after shuffling
            int deckIndex = 0;
            foreach (PictureBox a in this.Controls.OfType<PictureBox>())
            {
                a.Image = myDeck.Cards.ElementAt(deckIndex).FaceImage;
                deckIndex += 1;
            }

          
        }

    }
}

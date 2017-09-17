using System;
using System.Drawing;
using System.Windows.Forms;

namespace CateiaMemory
{
    class Card
    {
        Image front;
        Image back;
        string tag;
        public PictureBox pictureBox;

        public Card(PictureBox input1)
        {
            this.back = Properties.Resources.card0;
            this.front = input1.Image;
            this.tag = input1.Tag.ToString();
            this.pictureBox = input1;
        }

        public static void shuffleCards(Panel cardsHolder)
        {
            foreach (PictureBox picture in cardsHolder.Controls)
            {
                int tag = Convert.ToInt32(picture.Tag);
                if (tag <= GameWindow.pairs)
                {
                    int next = RNG.rng.Next(GameWindow.points.Count);
                    Point p = GameWindow.points[next];
                    picture.Location = p;
                    GameWindow.points.Remove(p);
                    picture.Enabled = true;
                }
                else
                {
                    picture.Location = GameWindow.leftovers[0];
                    GameWindow.leftovers.Remove(GameWindow.leftovers[0]);
                }
            }
        }

        public static void createCards(int w, int h, Panel cardsHolder)
        {
            foreach (PictureBox picture in cardsHolder.Controls)
            {
                //will only pick cards that are within the CardsHolder
                picture.Enabled = false;     //ensures all cards are clickable at start
                picture.Image = Properties.Resources.card0; //at start, populates the grid with card backs 
                if ((picture.Location.X < w) && (picture.Location.Y < h))
                {
                    GameWindow.points.Add(picture.Location);               //adds the location of each card inside the search area to list points
                }
                else
                {
                    GameWindow.leftovers.Add(picture.Location);
                }

            }
        }
        //flips cards back to front when clicked, checks if the player found a pair
        public static void flipCard(PictureBox card, Image image, Panel cardsHolder, GameWindow gameWindow)
        {
            card.Image = image;
            Card selectedCard = new Card(card);
            Game.cardValidator(gameWindow, cardsHolder, selectedCard);
        }
    }
}

using System;
using System.Linq;
using System.Windows.Forms;

namespace CateiaMemory
{
    static class Game
    {
        public static PictureBox OpenCard1;   //stores the first and second opened cards
        public static PictureBox OpenCard2;

        public static void cardValidator(GameWindow gameWindow, Panel cardsHolder, Card input)
        {
            if (OpenCard1 == null)
            {
                OpenCard1 = input.pictureBox;  //if no cards are selected, selects this card as the first open card
            }
            else if (OpenCard1 != null && OpenCard2 == null && input.pictureBox != OpenCard1)
            {
                OpenCard2 = input.pictureBox;  //if ONE card is selected, selects this card as the second open card
            }

            if (OpenCard1 != null && OpenCard2 != null) //once two cards are selected, they are compared
            {
                if (OpenCard1.Tag == OpenCard2.Tag) //if two open cards are a pair, do something
                {
                    //give the active player some points
                    foreach (Label label in gameWindow.Controls.OfType<Label>())  //goes through all labels to find the right player' score
                    {
                        if ((label.Name.Contains(gameWindow.players.activePlayer.ToString())) && label.Name.Contains("ScoreCount"))
                        {
                            label.Text = (Convert.ToInt32(label.Text) + 3).ToString(); //gives the player +3 points for finding a pair
                        }
                    }

                    foreach (PictureBox target in cardsHolder.Controls)
                    {
                        if (target.Tag == OpenCard1.Tag)
                        {
                            target.Enabled = false; //once a pair of cards is found, disables them
                        }
                    }
                    OpenCard1 = null;   //sets open card references to null
                    OpenCard2 = null;
                }
                else
                {
                    //takes 1 point from the player if he picks wrong, will not generate negative numbers                   

                    foreach (Label label in gameWindow.Controls.OfType<Label>())  //goes through all labels to find the right player' score
                    {
                        if ((label.Name.Contains(gameWindow.players.activePlayer.ToString())) && label.Name.Contains("ScoreCount"))
                        {
                            if (Convert.ToInt32(label.Text) > 0)
                            {
                                label.Text = (Convert.ToInt32(label.Text) - 1).ToString();
                            }
                        }
                    }

                    gameWindow.timer1.Start(); //if two cards are not identical, starts a timer that resets them after 0.3 seconds

                    gameWindow.players.changePlayer(); //changes the active player

                    gameWindow.players.changeColor(gameWindow);  //changes the active player's color
                }
            }
        }

        public static void zeroScore(GameWindow gameWindow)
        {
            foreach (Label label in gameWindow.Controls.OfType<Label>())
            {
                if (label.Name.Contains("ScoreCount"))
                {
                    label.Text = "0";
                }
            }
        }
    }
}

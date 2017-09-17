using System.Linq;
using System.Windows.Forms;

namespace CateiaMemory
{
    class Players
    {
        public int playerNumber;
        public int activePlayer;

        public Players(int number)
        {
            this.playerNumber = number;
        }

        public void setPlayers(int input, GameWindow gameWindow)
        {
            playerNumber = input;

            //makes all labels invisible first
            foreach (Label label in gameWindow.Controls.OfType<Label>())
            {
                label.Visible = false;
            }

            //then, enables as many labels as there are players 
            foreach (Label label in gameWindow.Controls.OfType<Label>())
            {
                for (int i = 1; i <= input; i++)
                {
                    if (label.Name.Contains(i.ToString()))
                    {
                        label.Visible = true;
                    }
                }
            }

            //checks the right menu item depnding on the number of players
            for (int i = 0; i < GameWindow.menu.Count(); i++)
            {
                if (GameWindow.menu[i].Text.Contains(input.ToString()))
                {
                    GameWindow.menu[i].Checked = true;
                }
                else
                {
                    GameWindow.menu[i].Checked = false;
                }
            }
        }

        public void changePlayer()
        {
            activePlayer++;
            if (activePlayer > playerNumber) activePlayer = 1;
        }

        public void changeColor(GameWindow gameWindow)
        {
            foreach (Label label in gameWindow.Controls.OfType<Label>())  //changes the active player's name and info to green
            {
                label.ForeColor = System.Drawing.Color.Black;
                if (label.Name.Contains(this.activePlayer.ToString()))
                {
                    label.ForeColor = System.Drawing.Color.Green;
                }
            }
        }
    }
}

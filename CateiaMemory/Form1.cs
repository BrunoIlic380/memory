using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CateiaMemory
{
    partial class GameWindow : Form
    {
        #region variables

        public static List<Point> points = new List<Point>(); //list of card locations, used for shuffling
        public static List<Point> leftovers = new List<Point>();  //list of cards outside the search area

        public static List<ToolStripMenuItem> menu = new List<ToolStripMenuItem>(); //list of player menus, eg 1 player 2 players etc

        public Players players = new Players(1);   //creates an instance of the Players class

        public static int pairs;  //how many pairs of cards are used for the game

        #endregion


        public GameWindow()
        {
            InitializeComponent();
            GameWindow_Load(650, 650, 12);
        }

        private void GameWindow_Load(int w, int h, int pair)
        {
            this.Refresh();
            startGame(w, h, pair);
            Card.createCards(w, h, CardsHolder);
            Card.shuffleCards(CardsHolder);
        }

        #region Card Click Handlers       
        //self-explanatory, if adding new cards make sure the click handlers are in this format
        private void Card1_Click(object sender, EventArgs e)
        {
            Card.flipCard(Card1, Properties.Resources.card1, CardsHolder, this);
        }

        private void DupCard1_Click(object sender, EventArgs e)
        {
            Card.flipCard(DupCard1, Properties.Resources.card1, CardsHolder, this);
        }

        private void Card2_Click(object sender, EventArgs e)
        {
            Card.flipCard(Card2, Properties.Resources.card2, CardsHolder, this);
        }

        private void DupCard2_Click(object sender, EventArgs e)
        {
            Card.flipCard(DupCard2, Properties.Resources.card2, CardsHolder, this);
        }

        private void Card3_Click(object sender, EventArgs e)
        {
            Card.flipCard(Card3, Properties.Resources.card3, CardsHolder, this);
        }

        private void DupCard3_Click(object sender, EventArgs e)
        {
            Card.flipCard(DupCard3, Properties.Resources.card3, CardsHolder, this);
        }

        private void Card4_Click(object sender, EventArgs e)
        {
            Card.flipCard(Card4, Properties.Resources.card4, CardsHolder, this);
        }

        private void DupCard4_Click(object sender, EventArgs e)
        {
            Card.flipCard(DupCard4, Properties.Resources.card4, CardsHolder, this);
        }

        private void Card5_Click(object sender, EventArgs e)
        {
            Card.flipCard(Card5, Properties.Resources.card5, CardsHolder, this);
        }
    
        private void DupCard5_Click(object sender, EventArgs e)
        {
            Card.flipCard(DupCard5, Properties.Resources.card5, CardsHolder, this);
        }
    
        private void Card6_Click(object sender, EventArgs e)
        {
            Card.flipCard(Card6, Properties.Resources.card6, CardsHolder, this);
        }

        private void DupCard6_Click(object sender, EventArgs e)
        {
            Card.flipCard(DupCard6, Properties.Resources.card6, CardsHolder, this);
        }

        private void Card7_Click(object sender, EventArgs e)
        {
            Card.flipCard(Card7, Properties.Resources.card7, CardsHolder, this);
        }

        private void DupCard7_Click(object sender, EventArgs e)
        {
            Card.flipCard(DupCard7, Properties.Resources.card7, CardsHolder, this);
        }

        private void Card8_Click(object sender, EventArgs e)
        {
            Card.flipCard(Card8, Properties.Resources.card8, CardsHolder, this);
        }

        private void DupCard8_Click(object sender, EventArgs e)
        {
            Card.flipCard(DupCard8, Properties.Resources.card8, CardsHolder, this);
        }

        private void Card9_Click(object sender, EventArgs e)
        {
            Card.flipCard(Card9, Properties.Resources.card9, CardsHolder, this);
        }

        private void DupCard9_Click(object sender, EventArgs e)
        {
            Card.flipCard(DupCard9, Properties.Resources.card9, CardsHolder, this);
        }

        private void Card10_Click(object sender, EventArgs e)
        {
            Card.flipCard(Card10, Properties.Resources.card10, CardsHolder, this);
        }

        private void DupCard10_Click(object sender, EventArgs e)
        {
            Card.flipCard(DupCard10, Properties.Resources.card10, CardsHolder, this);
        }

        private void Card11_Click(object sender, EventArgs e)
        {
            Card.flipCard(Card11, Properties.Resources.card11, CardsHolder, this);
        }

        private void DupCard11_Click(object sender, EventArgs e)
        {
            Card.flipCard(DupCard11, Properties.Resources.card11, CardsHolder, this);
        }

        private void Card12_Click(object sender, EventArgs e)
        {
            Card.flipCard(Card12, Properties.Resources.card12, CardsHolder, this);
        }

        private void DupCard12_Click(object sender, EventArgs e)
        {
            Card.flipCard(DupCard12, Properties.Resources.card12, CardsHolder, this);
        }
        #endregion

        void startGame(int w, int h, int pair)    //invoked at game start, moved out of the 
        {
            //sets the board size by resizing the card holder object
            CardsHolder.Width = w;
            CardsHolder.Height = h;

            pairs = pair;

            points.Clear(); //clears the lists at game start
            leftovers.Clear();
            menu.Clear();

            menu.Add(playerToolStripMenuItem);
            menu.Add(playersToolStripMenuItem1);
            menu.Add(playersToolStripMenuItem2);
            menu.Add(playersToolStripMenuItem3);

            //sets players to 1 on a new game
            players.setPlayers(1, this);
            players.activePlayer = 0;
            players.changePlayer();

            //sets the active player's color to green
            players.changeColor(this);

            Game.zeroScore(this);

        }

        private void timer1_Tick(object sender, EventArgs e)    //needed to actually see both cards after a mistake
        {
            timer1.Stop();      //after 0.3 seconds, will revert both open cards to card backs
            Game.OpenCard1.Image = Properties.Resources.card0;
            Game.OpenCard2.Image = Properties.Resources.card0;
            Game.OpenCard1 = null;
            Game.OpenCard2 = null;
        }        
        
        #region menu click handlers
        
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {   //new game menu
        }

        private void x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {   //new game with boardsize 6x4
            GameWindow_Load(650, 650, 12);  //WxH = 6x4
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {   //new game with boardsize 6x3
            GameWindow_Load(650, 478, 9);  //WxH = 6x3
        }

        private void x4ToolStripMenuItem1_Click(object sender, EventArgs e)
        {   //new game with boardsize 4x4
            GameWindow_Load(435, 643, 8);  //WxH = 4x4
        }

        private void x3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {   //new game with boardsize 4x3
            GameWindow_Load(435, 478, 6);  //WxH = 4x3
        }

        private void playersToolStripMenuItem_Click(object sender, EventArgs e)
        {   //Player menu

        }

        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {   //set 1 player
            players.setPlayers(1, this);
        }

        private void playersToolStripMenuItem1_Click(object sender, EventArgs e)
        {   //set 2 players
            players.setPlayers(2, this);
        }

        private void playersToolStripMenuItem2_Click(object sender, EventArgs e)
        {   //set 3 players
            players.setPlayers(3, this);
        }

        private void playersToolStripMenuItem3_Click(object sender, EventArgs e)
        {   //set 4 players
            players.setPlayers(4, this);
        }

        #endregion
    }
}

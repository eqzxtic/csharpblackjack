namespace proiect_atestat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

        int bet = 0;
        int balance = 50;
        bool gamestart = false;
        bool cL = false;
        bool cW = false;
        bool cT = false;
        int playerSum = 0;
        int dealerSum = 0;
        int playerSize = 0;
        int dealerSize = 0;

        int[,] carti = new int[13,4];
        // AS DOI TREI PATRU CINCI SASE SAPTE OPT NOUA ZECE REGE DAMA JUVETE
        void addCard(int player)
        {
            Random rnd=new Random();
            int nr=0, rang=0;
            nr = rnd.Next(1, 14);
            rang = rnd.Next(1, 5);
            while (carti[nr,rang]==1)
            {
                nr = rnd.Next(1, 14);
                rang = rnd.Next(1, 5);
            }
            carti[nr, rang] = 1;

        }

        void winlose()
        {
            if (playerSum > 21) cL = true;
            if(playerSum==21)
            {
                if (playerSize < dealerSize) cW = true;
                if (playerSize == dealerSize) cT = true;
                if (playerSize > dealerSize) cL = true;
            }
            if(playerSum<21)
            {
                if (playerSum > dealerSum) cW = true;
                if (playerSum == dealerSum && playerSize > dealerSize) cL = true;
                if(playerSum == dealerSum && playerSize < dealerSize) cW = true;
                if(playerSum == dealerSum && playerSize == dealerSize) cT = true;

            }
        }
        void restart()
        {
            bet = 0;
            balance = 50;
            label5.Text = "Not started";
            label8.Text = "0";
            label4.Text = "50";
        }

        void update()
        {
            if (gamestart == true)
            {
                label5.Text = "In progress";
            }
            if (cL == true)
            {
                label5.Text = "You lost";
                wait(3000);
                restart();
            }
            if (cW == true)
            {
                label5.Text = "You win";
            }
            label8.Text = bet.ToString();
            label4.Text = balance.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (balance >= 1)
            {
                bet += 1;
                balance -= 1;
            }
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (balance >= 5)
            {
                bet += 5;
                balance -= 5;
            }
            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (balance >= 10)
            {
                bet += 10;
                balance -= 10;
            }
            update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (balance >= 50)
            {
                bet += 50;
                balance -= 50;
            }
            update();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int nr = 0, rang = 0;
            nr = rnd.Next(1, 13);
            rang = rnd.Next(1, 5);
            carti[nr, rang] = 1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            balance += bet;
            bet = 0;
            update();
        }
    }
}

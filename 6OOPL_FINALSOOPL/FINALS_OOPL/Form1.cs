using System;
using System.Windows.Forms;

namespace FINALS_OOPL
{
    public partial class Form1 : Form
    {
        static CALCFUNCTIONS func = new CALCFUNCTIONS();
        public int currentLevel = 1;
        public int currentNoMoves = 0;
        public int currentGoal = 0;
        public double currentScore = 0;
        public int guestLevel = 1;
        public string name = "";
        public int numUsers = 0;
        public int i = 0;
        public double total = 0;
        public int currentSlot = 0;
        public string currentUser = "";
        public int[] arrayScore = new int[4];
        public Form1()
        {
            InitializeComponent();
            label2.Text = "0";
            timer1.Interval = 1000;
            firstPlay.Hide();
            withUsers.Hide();
            panel3.Hide();
            panel4.Hide();
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
        }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (func.openConnection() == true)
            {
                MessageBox.Show("Welcome!");
                numUsers = func.checkPlayers();
                panel2.Hide();
            }
            else
            {
                MessageBox.Show("Connection Failed.");
                Application.Exit();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            numUsers = func.checkPlayers();
            if (numUsers <= 0)
            {
                firstPlay.Show();
            }
            else
            {
                
                withUsers.Show();
                func.addPlayersInButtons(ref first, ref second, ref third, ref fourth);
                if (first.Text == "NEW GAME")
                {
                    button12.Enabled = false;
                }
                if (second.Text == "NEW GAME")
                {
                    button13.Enabled = false;
                }
                if (third.Text == "NEW GAME")
                {
                    button14.Enabled = false;
                }
                if (fourth.Text == "NEW GAME")
                {
                    button15.Enabled = false;
                }
            }
            panel1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text != "")
            {
                func.mdasButton(ref button1,ref label2,ref currentNoMoves, ref lblMoves);
                if (label2.Text == currentGoal.ToString())
                {
                    timer1.Stop();
                    currentScore = i > 5 ? func.displayScore(i, currentLevel) : 100;
                    currentScore = currentScore < 0 ? 0 : currentScore;
                    MessageBox.Show("Score = "+currentScore);
                    total += currentScore;
                    lblScore.Text = "Score : " + total;
                    ++currentLevel;
                    func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                    i = 0;
                    lblTime.Text = "Time : 0 sec";
                    timer1.Start();
                }
                else if (currentNoMoves == 0)
                {
                    MessageBox.Show("Out of moves");
                    func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                }
            }          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text != "")
            {
                func.mdasButton(ref button2, ref label2, ref currentNoMoves, ref lblMoves);
                if (label2.Text == currentGoal.ToString())
                {
                    timer1.Stop();
                    currentScore = i > 5 ? func.displayScore(i, currentLevel) : 100;
                    currentScore = currentScore < 0 ? 0 : currentScore;
                    MessageBox.Show("Score = " + currentScore);
                    total += currentScore;
                    lblScore.Text = "Score : " + total;
                    ++currentLevel;
                    func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                    i = 0;
                    lblTime.Text = "Time : 0 sec";
                    timer1.Start();
                }
                else if (currentNoMoves == 0)
                {
                    MessageBox.Show("Out of moves");
                    func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text != "")
            {
                func.mdasButton(ref button4, ref label2, ref currentNoMoves, ref lblMoves);
                if (label2.Text == currentGoal.ToString())
                {
                    timer1.Stop();
                    currentScore = i > 5 ? func.displayScore(i, currentLevel) : 100;
                    currentScore = currentScore < 0 ? 0 : currentScore;
                    MessageBox.Show("Score = " + currentScore);
                    total += currentScore;
                    lblScore.Text = "Score : " + total;
                    ++currentLevel;
                    func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                    i = 0;
                    lblTime.Text = "Time : 0 sec";
                    timer1.Start();
                }
                else if (currentNoMoves == 0)
                {
                    MessageBox.Show("Out of moves");
                    func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            lblTime.Text = "Time : " + i.ToString()+" sec";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //firstPlay.Hide();
            //panel2.Show();
            //func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
            //lblTime.Text = "Time : 0 sec";
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter your username!","Username",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            else
            {
                if (!func.checkUserExistance(txtName.Text))
                {
                    func.addPlayers(currentSlot,txtName.Text);
                    panel1.Show();
                    withUsers.Hide();
                    firstPlay.Hide();
                }
            }
            //timer1.Start();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text != "")
            {
                func.deleteButton(ref button4, ref label2, ref currentNoMoves, ref lblMoves);
                if (label2.Text == currentGoal.ToString())
                {
                    timer1.Stop();
                    currentScore = i > 5 ? func.displayScore(i, currentLevel) : 100;
                    currentScore = currentScore < 0 ? 0 : currentScore;
                    currentScore = currentScore < 0 ? 0 : currentScore;
                    MessageBox.Show("Score = " + currentScore);
                    total += currentScore;
                    lblScore.Text = "Score : " + total;
                    ++currentLevel;
                    func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                    i = 0;
                    lblTime.Text = "Time : 0 sec";
                    timer1.Start();
                }
                else if (currentNoMoves == 0)
                {
                    MessageBox.Show("Out of moves");
                    func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                }
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text != "")
            {
                func.addingNumberButton(ref button5, ref label2, ref currentNoMoves, ref lblMoves);
                if (label2.Text == currentGoal.ToString())
                {
                    timer1.Stop();
                    currentScore = i > 5 ? func.displayScore(i, currentLevel) : 100;
                    currentScore = currentScore < 0 ? 0 : currentScore;
                    MessageBox.Show("Score = " + currentScore);
                    total += currentScore;
                    lblScore.Text = "Score : " + total;
                    ++currentLevel;
                    func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                    i = 0;
                    lblTime.Text = "Time : 0 sec";
                    timer1.Start();
                }
                else if (currentNoMoves == 0)
                {
                    MessageBox.Show("Out of moves");
                    func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text != "")
            {
                func.addingNumberButton(ref button6, ref label2, ref currentNoMoves, ref lblMoves);
                if (label2.Text == currentGoal.ToString())
                {
                    timer1.Stop();
                    currentScore = i > 5 ? func.displayScore(i, currentLevel) : 100;
                    currentScore = currentScore < 0 ? 0 : currentScore;
                    MessageBox.Show("Score = " + currentScore);
                    total += currentScore;
                    lblScore.Text = "Score : " + total;
                    ++currentLevel;
                    func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                    i = 0;
                    lblTime.Text = "Time : 0 sec";
                    timer1.Start();
                }
                else if (currentNoMoves == 0)
                {
                    MessageBox.Show("Out of moves");
                    func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                }
            }
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            if (func.checkDecimal(ref label2))
            {
                MessageBox.Show("Decimal Recieved");
                func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            panel3.Show();
            panel2.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel3.Hide();
            timer1.Start();
        }

        private void first_Click(object sender, EventArgs e)
        {
            int lvlStopped;
            if (first.Text != "NEW GAME")
            {
                lvlStopped = func.getLevelStopped(first);
                currentLevel = lvlStopped;
                MessageBox.Show("LEVEL STOPPED: "+lvlStopped);
                label3.Text = "User : "+first.Text;
                currentScore = func.userScore(first);
                total += currentScore;
                lblScore.Text = "Score : " + currentScore;
                func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                currentUser = first.Text;
                panel2.Show();
                timer1.Start();
                withUsers.Hide();
            }
            else
            {
                currentSlot = 1;
                firstPlay.Show();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to delete " + first.Text + "?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                func.deletePlayer(ref first);
            }
        }

        private void second_Click(object sender, EventArgs e)
        {
            int lvlStopped;
            if (second.Text != "NEW GAME")
            {
                lvlStopped = func.getLevelStopped(second);
                currentLevel = lvlStopped;
                MessageBox.Show("LEVEL STOPPED: " + lvlStopped);
                label3.Text = "User : " + second.Text;
                currentScore = func.userScore(second);
                total += currentScore;
                lblScore.Text = "Score : " + currentScore;
                func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                currentUser = second.Text;
                panel2.Show();
                timer1.Start();
                withUsers.Hide();
            }
            else
            {
                currentSlot = 2;
                firstPlay.Show();
            }
        }

        private void third_Click(object sender, EventArgs e)
        {
            int lvlStopped;
            if (third.Text != "NEW GAME")
            {
                lvlStopped = func.getLevelStopped(third);
                currentLevel = lvlStopped;
                MessageBox.Show("LEVEL STOPPED: " + lvlStopped);
                label3.Text = "User : " + third.Text;
                currentScore = func.userScore(third);
                total += currentScore;
                lblScore.Text = "Score : " + currentScore;
                func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                currentUser = third.Text;
                panel2.Show();
                timer1.Start();
                withUsers.Hide();
            }
            else
            {
                currentSlot = 3;
                firstPlay.Show();
            }
        }

        private void fourth_Click(object sender, EventArgs e)
        {
            int lvlStopped;
            if (fourth.Text != "NEW GAME")
            {
                lvlStopped = func.getLevelStopped(fourth);
                currentLevel = lvlStopped;
                MessageBox.Show("LEVEL STOPPED: " + lvlStopped);
                label3.Text = "User : " + fourth.Text;
                currentScore = func.userScore(fourth);
                total += currentScore;
                lblScore.Text = "Score : " + currentScore;
                func.loadButtons(ref label2, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                currentUser = fourth.Text;
                panel2.Show();
                timer1.Start();
                withUsers.Hide();
            }
            else
            {
                currentSlot = 4;
                firstPlay.Show();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to delete " + second.Text + "?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                func.deletePlayer(ref second);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to delete " + third.Text + "?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                func.deletePlayer(ref third);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to delete " + fourth.Text + "?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                func.deletePlayer(ref fourth);
            }
        }

        private void first_TextChanged(object sender, EventArgs e)
        {
            if (first.Text == "NEW GAME")
            {
                button12.Enabled = false;
            }
            else
            {
                button12.Enabled = true;
            }
        }

        private void second_TextChanged(object sender, EventArgs e)
        {
            if (second.Text == "NEW GAME")
            {
                button13.Enabled = false;
            }
            else
            {
                button13.Enabled = true;
            }
        }

        private void third_TextChanged(object sender, EventArgs e)
        {
            if (third.Text == "NEW GAME")
            {
                button14.Enabled = false;
            }
            else
            {
                button14.Enabled = true;
            }
        }

        private void fourth_TextChanged(object sender, EventArgs e)
        {
            if (fourth.Text == "NEW GAME")
            {
                button15.Enabled = false;
            }
            else
            {
                button15.Enabled = true;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (func.storeCurrentInfo(currentLevel,currentUser,(int)total))
            {
                panel2.Hide();
                timer1.Stop();
                i = 0;
                total = 0;
                currentScore = 0;
                panel1.Show();
                panel3.Hide();
            }
            else
            {
                MessageBox.Show("Error in exit...");
                MessageBox.Show("Game is restarting. On next load, the game will dominate the world MUAHAHAHAHA.");
            }
        }

        private void btnVHS_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            func.getScoreArray(ref arrayScore);
            for (int ctr = 0; ctr < arrayScore.Length; ctr++)
            {
                MessageBox.Show("Scores: "+ func.getScoreName(arrayScore[i]));
                switch (ctr)
                {
                    //case 0: label4.Text = "1st Place : " + func.getScoreName(arrayScore[i]); break;
                    //case 1: label5.Text = "2nd Place : " + func.getScoreName(arrayScore[i]); break;
                    //case 2: label6.Text = "3rd Place : " + func.getScoreName(arrayScore[i]); break;
                    //case 3: label7.Text = "4th Place : " + func.getScoreName(arrayScore[i]); break;
                }
            }

            panel4.Show();
        }
    }
}

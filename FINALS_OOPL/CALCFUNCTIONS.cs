using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FINALS_OOPL
{
    class CALCFUNCTIONS : Form1
    {
        static string connectionString = "server=localhost;user=root;pass=;database=calculatorgame;";
        MySqlConnection connect = new MySqlConnection(connectionString);
        static Parser calc = new Parser();
        public bool openConnection()
        {
            try
            {
                connect.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool closeConnection()
        {
            try
            {
                connect.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void loadButtons(ref Label txtNumber, ref Button btn1, ref Button btn2, ref Button btn3, ref Button btn4, ref Button btn5, ref Button btn6, ref Button btn7, ref Button btn8, ref Button btn9, ref int currentLevel, ref int currentNoMoves, ref int currentGoal, ref Label moves, ref Label level, ref Label goal)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM gamelevels";
            MySqlDataReader reader;
            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (int.Parse(reader["gameLev"].ToString()) == currentLevel)
                    {
                        disableMainButtons(ref btn1, ref btn2, ref btn3, ref btn4, ref btn5, ref btn6, ref btn7, ref btn8, ref btn9);
                        moves.Text = "Moves : " + reader["noOfMoves"].ToString();
                        currentNoMoves = int.Parse(reader["noOfMoves"].ToString());
                        level.Text = "Level : " + reader["gameLev"].ToString();
                        goal.Text = "Goal : " + reader["goal"].ToString();
                        currentGoal = int.Parse(reader["goal"].ToString());
                        btn1.Text = reader["button1"].ToString();
                        btn2.Text = reader["button2"].ToString();
                        btn3.Text = reader["button3"].ToString();
                        btn4.Text = reader["button4"].ToString();
                        btn5.Text = reader["button5"].ToString();
                        btn6.Text = reader["button6"].ToString();
                        btn7.Text = reader["button7"].ToString();
                        btn8.Text = reader["button8"].ToString();
                        btn9.Text = reader["button9"].ToString();
                        txtNumber.Text = reader["startVal"].ToString();
                        enableMainButtons(ref btn1, ref btn2, ref btn3, ref btn4, ref btn5, ref btn6, ref btn7, ref btn8, ref btn9);
                    }
                    }
                }
        }

        public void enableMainButtons(ref Button btn1, ref Button btn2, ref Button btn3, ref Button btn4, ref Button btn5, ref Button btn6, ref Button btn7, ref Button btn8, ref Button btn9)
        {
            if (btn1.Text != "")
            {
                btn1.Enabled = true;
            }
            if (btn2.Text != "")
            {
                btn2.Enabled = true;
            }
            if (btn3.Text != "")
            {
                btn3.Enabled = true;
            }
            if (btn4.Text != "")
            {
                btn4.Enabled = true;
            }
            if (btn5.Text != "")
            {
                btn5.Enabled = true;
            }
            if (btn6.Text != "")
            {
                btn6.Enabled = true;
            }
            if (btn7.Text != "")
            {
                btn7.Enabled = true;
            }
            if (btn8.Text != "")
            {
                btn8.Enabled = true;
            }
            if (btn9.Text != "")
            {
                btn9.Enabled = true;
            }
        }

        public void disableMainButtons(ref Button btn1, ref Button btn2, ref Button btn3, ref Button btn4, ref Button btn5, ref Button btn6, ref Button btn7, ref Button btn8, ref Button btn9)
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
        }

        public void mdasButton(ref Button btn, ref Label txtNumber, ref int currentNoMoves, ref Label lblMoves)
        {
            --currentNoMoves;
            string eq = txtNumber.Text + btn.Text;
            double num = calc.evaluate(eq);
            txtNumber.Text = "" + num;
            lblMoves.Text = "Moves : "+currentNoMoves;
        }

        public void deleteButton(ref Button btn, ref Label txtNumber, ref int currentNoMoves, ref Label lblMoves)
        {
            --currentNoMoves;
            if (txtNumber.Text != "0")
            {
                txtNumber.Text = txtNumber.Text.Remove(txtNumber.Text.Length-1);
            }
            lblMoves.Text = "Moves : " + currentNoMoves;
        }

        public bool checkDecimal(ref Label txtNumber)
        {
            int i = 0;
            while (i < txtNumber.Text.Length)
            {
                if (txtNumber.Text[i] == '.')
                {
                    return true;
                }
                i++;
            }

            return false;
        }

        public double displayScore(int i, int currentlevel)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM gamelevels";
            MySqlDataReader reader;

            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader["gameLev"].ToString() == currentLevel.ToString())
                    {
                        double score = int.Parse(reader["score"].ToString()) - i;
                        return score;
                    }
                }
            }

            return 0;
        }

        public void updatingScores()
        {
               
        }

        public int checkPlayers()
        {
            int i = 0;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM listusers";
            MySqlDataReader reader;

            using(reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    i++;
                }
            }

            return i;
        }

        public void addingNumberButton(ref Button btn, ref Label txtNumber, ref int currentNoMoves, ref Label lblMoves)
        {
            --currentNoMoves;
            if (txtNumber.Text == "0")
            {
                txtNumber.Text = btn.Text;
            }
            else
            {
                txtNumber.Text = txtNumber.Text + btn.Text;
            }
            lblMoves.Text = "Moves : " + currentNoMoves;
        }
        
        public void addPlayersInButtons(ref Button btn1, ref Button btn2, ref Button btn3, ref Button btn4)
        {
            int i = 0;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM listusers";
            MySqlDataReader reader;

            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    i++;
                    if (reader["userName"].ToString() != "null")
                    {
                        switch (i)
                        {
                            case 1: btn1.Text = reader["userName"].ToString(); break;
                            case 2: btn2.Text = reader["userName"].ToString(); break;
                            case 3: btn3.Text = reader["userName"].ToString(); break;
                            case 4: btn4.Text = reader["userName"].ToString(); break;
                        }
                    }
                }
            }
        }

        public int getLevelStopped(Button btn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM listusers WHERE userName = @userName";
            MySqlParameter userName = new MySqlParameter("@userName",MySqlDbType.Text);
            userName.Value = btn.Text;
            cmd.Parameters.Add(userName);
            MySqlDataReader reader;

            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    return int.Parse(reader["levelStopped"].ToString());
                }
            }
                return 0;
        }

        public void deletePlayer(ref Button btn)
        {
            MySqlParameter userName = new MySqlParameter("@userName",MySqlDbType.Text);
            userName.Value = btn.Text;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "UPDATE listusers SET userName = 'null', levelStopped = 0 WHERE userName = @userName";
            cmd.Parameters.Add(userName);

            try
            {
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                btn.Text = "NEW GAME";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in deletion: "+ex.Message);
            }
        }

        public int userScore(Button btn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM listusers WHERE userName = @userName";
            MySqlParameter userName = new MySqlParameter("@userName",MySqlDbType.Text);
            userName.Value = btn.Text;
            cmd.Parameters.Add(userName);
            MySqlDataReader reader;

            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    return int.Parse(reader["currentHS"].ToString());
                }
            }

            return 0;
        }

        public bool stopGuestGame(int i)
        {
            if (i == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkUserExistance(string user)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM listusers WHERE userName = @userName";
            MySqlParameter userName = new MySqlParameter("@userName",MySqlDbType.Text);
            userName.Value = user;
            cmd.Parameters.Add(userName);
            MySqlDataReader reader;

            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    MessageBox.Show("User Exist");
                    return true;
                }
            }

                return false;
        }

        public void addPlayers(int currentSlot, string userName)
        {
            int i = 0;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM listusers";
            MySqlDataReader reader;

            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    i++;
                    if (i == currentSlot)
                    {
                        reader.Close();
                        cmd.CommandText = "UPDATE `listusers` SET `userName` = @userName , `levelStopped` = 1 WHERE `listusers`.`userID` = @userID";
                        MySqlParameter user = new MySqlParameter("@userName",MySqlDbType.Text);
                        MySqlParameter userID = new MySqlParameter("@userID",MySqlDbType.Int32);

                        user.Value = userName;
                        userID.Value = currentSlot;

                        cmd.Parameters.Add(user);
                        cmd.Parameters.Add(userID);

                        try
                        {
                            cmd.Prepare();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("User Creation Successful");
                            break;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("User Creation Failed");
                            break;
                        }
                    }
                }
            }
        }

        public bool storeCurrentInfo(int levelStopped, string userName, int scoreStopped)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "UPDATE listusers SET levelStopped = @levelStopped, currentHS = @currentScore WHERE userName = @userName;";
            MySqlParameter level = new MySqlParameter("@levelStopped",MySqlDbType.Int32);
            MySqlParameter name = new MySqlParameter("@userName",MySqlDbType.Text);
            MySqlParameter score = new MySqlParameter("@currentScore",MySqlDbType.Int32);

            level.Value = levelStopped;
            name.Value = userName;
            score.Value = scoreStopped;

            cmd.Parameters.Add(level);
            cmd.Parameters.Add(name);
            cmd.Parameters.Add(score);

            try
            {
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                MessageBox.Show("Information Stored");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Information Storing Failed");
                return false;
            }
        }

        public void getScoreArray(ref int[] array)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM listusers";
            MySqlDataReader reader;
            int i = 0;
            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader["userName"].ToString() != "null")
                    {
                        array[i] = int.Parse(reader["currentHS"].ToString()) > 0 ? int.Parse(reader["currentHS"].ToString()) : 0;
                        MessageBox.Show(""+array[i]);
                        i++;
                    }
                }
            }

            Array.Sort(array);
        }

        public string getScoreName(int score)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM listusers";
            MySqlDataReader reader;

            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (int.Parse(reader["currentHS"].ToString()) == score)
                    {
                        return reader["userName"].ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return null;
        }
    }
}

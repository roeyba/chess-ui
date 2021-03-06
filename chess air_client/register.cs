using connect4_client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chessair_client
{
    public partial class register : Form
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="f"></param>
        public register(Form f,bool keep_reading =true)
        {
            Program.receive_message_handler = this.ReceiveMessage;
            Program.Close_form(f);
            InitializeComponent();
            if(keep_reading)
                Program.Keep_reading();
        }
        /// <summary>
        /// send all the registration data to the server(if the data is valid)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Regist_Click(object sender, EventArgs e)
        {
            try
            {
                if (rpassword.Text.Length > 0 && rusername.Text.Length > 0 && remail.Text.Length > 0 && remail.Text.Contains("@")) // אם הכל הוכנס
                {
                    if (rusername.Text.Length < 5)
                        outputtext.Text = "username must contain at least five characters";
                    else if (rpassword.Text.Length < 5)
                        outputtext.Text = "password must contain at least five characters";
                    else if (rpassword.Text.StartsWith("'")|| rpassword.Text.StartsWith("/")|| rusername.Text.StartsWith("'")|| rusername.Text.StartsWith("/"))
                    {
                        outputtext.Text = "you cant put ' or / at the begging of the information";
                    }
                    else if (rpassword.Text.EndsWith("'") || rpassword.Text.EndsWith("/") || rusername.Text.EndsWith("'") || rusername.Text.EndsWith("/"))
                    {
                        outputtext.Text = "you cant put ' or / at the end of the information";
                    }
                    else {
                        outputtext.Text = "";
                        Program.SendMessage("###regist###" + rusername.Text + "&" + rpassword.Text + "&" + rnickname.Text + "&" + remail.Text + "&" + rage.Text + "&" + rcountry.Text + "&" + rcity.Text);
                    }
                }
                else{ // מציג מה לא הוכנס
                    outputtext.ResetText();
                    if(!(remail.Text.Length > 0) || !(remail.Text.Contains("@")))
                    {
                        outputtext.Text = "you must enter a valid mail adress";
                    }
                    else
                    {
                        String[] erroutput = new string[3];
                        if (rusername.Text.Length == 0) { erroutput[0] = "username"; } //if there is no username
                        if (rpassword.Text.Length == 0) { erroutput[1] = "password"; } //if there is no password
                                                                                       //
                        String correction1 = "";
                        if (erroutput[0] != null && erroutput[1] != null) { correction1 = " and "; }
                        outputtext.Text = erroutput[0] + correction1 + erroutput[1] + " must be inserted!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// handle messages from the server
        /// </summary>
        private void ReceiveMessage(string textFromServer)
        {
            // what happen after the cliant register - what the server returns and what happen as a result
            if (textFromServer == "regist complited")
            {
                outputtext.BeginInvoke((MethodInvoker)delegate () {
                    outputtext.Text = "registration complete!";
                });
                System.Threading.Thread.Sleep(1000);
                Application.Run(new Login(this,false));
            }
            else if (textFromServer == "regist mail incorrect")
            {
                outputtext.BeginInvoke((MethodInvoker)delegate () { outputtext.Text = "server couldnt confirm youre mail"; });
            }
            else if (textFromServer == "username already exist!")
            {
                outputtext.BeginInvoke((MethodInvoker)delegate () { outputtext.Text = textFromServer; });
            }
            else
                outputtext.BeginInvoke((MethodInvoker)delegate () { outputtext.Text = textFromServer; });
        }

        /// <summary>
        /// close the form handler - close the TCP connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Disconnect_server();
        }
        /// <summary>
        /// close the form, shows the login form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, EventArgs e)
        {
            Login login = new Login(this,false);
            login.ShowDialog();
        }

    }
}

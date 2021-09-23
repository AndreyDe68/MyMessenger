using MyMessenger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsClient
{
    public partial class Form1 : Form
    {
        private static int MessageID = 0;
        private static string UserName;
        private static MessengerClientAPI API = new MessengerClientAPI(); 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string UserName = UserNameTB.Text;
            string Message = MessageTB.Text;
            if ((UserName.Length > 0))
            {
                MyMessenger.Message msg = new MyMessenger.Message(UserName, Message, DateTime.Now);
                API.SendMessageRestSharp(msg); 
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var getMessage = new Func<Task>(async () =>
            {
                MyMessenger.Message msg = await API.GetMessageHttpAsync(MessageID);
                while (msg != null)
                {
                    MessagesLB.Items.Add(msg);
                    MessageID++;
                    msg = await API.GetMessageHttpAsync(MessageID);
                }
            });
            getMessage.Invoke();
        }
    }
}

using Microsoft.Exchange.WebServices.Data;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applied_Accounts.Forms
{
    public partial class frmEmails : Form
    {
        StringBuilder MyEmails = new StringBuilder();
        List<MimeMessage> emailMessages = new List<MimeMessage>();

        public frmEmails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Applied_Accounts.Classes.AppliedEmail _EmailClass = new Applied_Accounts.Classes.AppliedEmail();
            emailMessages = _EmailClass.ReceiveEmail(100);

            foreach (MimeMessage message in emailMessages)
            {
                ListSubject.Items.Add(message.Subject);
            }
        }

        private void ListSubject_SelectedValueChanged(object sender, EventArgs e)
        {
            MimeMessage message = emailMessages[ListSubject.SelectedIndex];
            string messageIP = GetMessageIP(message);

            if (message.TextBody != null)
            {
                txtEmails.Text = messageIP;  //message.TextBody;
            }
            else
            {
                txtEmails.Text = string.Empty;
            }
        }

        private string GetMessageIP(MimeMessage _Message)
        {
            string _MessageIP = "";
            string _Received = _Message.Headers[HeaderId.Received];

            if (_Received != null)
            {
                int _First = _Received.IndexOf("(");
                int _Last = _Received.IndexOf(")");
                _MessageIP = _Received.Substring(_First + 2, (_Last - _First) - 3);
            }
            return _MessageIP;
        }
    }
}

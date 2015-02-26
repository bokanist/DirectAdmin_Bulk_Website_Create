using System;
using System.Collections.Specialized;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace DirectAdminCreateSites
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCreateWebsites_Click(object sender, EventArgs e)
        {
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            using (var client = new CookieAwareWebClient())
            {
                var values = new NameValueCollection
                             {
                                 {"username", textBoxUser.Text},
                                 {"password", textBoxPassWord.Text},
                             };
                //client.UploadValues(textBoxURL.Text + "/CMD_LOGIN", values);
                client.UploadValues(textBoxURL.Text + "/CMD_LOGIN", values);


                string[] sites = textBoxSites.Text.Replace("\r\n", "#").Split('#');
                foreach (string site in sites)
                {
                    var values2 = new NameValueCollection
                                  {
                                      {"action", "create"},
                                      {"domain", site},
                                      {"ubandwidth", "unlimited"},
                                      {"uquota", "unlimited"},
                                      {"cgi", "OFF"},
                                      {"php", "ON"},
                                  };
                    //client.UploadValues(textBoxURL.Text + "/CMD_LOGIN", values);
                    client.UploadValues("http://37.59.47.46:2222" + "/CMD_DOMAIN", values2);
                    textBox1.AppendText("Domain " + site + " added\r\n");
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using WindowsClient.AuthService;

namespace WindowsClient
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Obter a lista de utilizadores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGetUsers_Click(object sender, EventArgs e)
        {
            AuthServiceClient client = new AuthServiceClient();

            var login = txtLogin.Text;
            var password = txtPassword.Text;

            //var users = client.GetUsers(login, password);
            var message = client.GetUsers(login,password);

            //if (users == null) //na função GetUsers a gente manda null se não tiver autenticado
            //{
            //    MessageBox.Show("Not Authenticated"); 
             //   return;
            //}

            if(message.Status != "OK")
            {
                MessageBox.Show(message.Message);
                return;
            }

            //ListBox dos Users
            //// versão 1
            lboxUsers.DataSource = message.Users;
            lboxUsers.DisplayMember = "Name"; //o que querenos que mostre na ListBox
            lboxUsers.ValueMember = "Login"; //o que queremos obter quando pedimos o valor do que está selecionado

            client.Close();

            //// versão 2
            //lboxUsers.Items.Clear();
            //foreach (User user in users)
            //{
            //  lboxUsers.Items.Add(user.Login);
            //}
        }


        /// <summary>
        /// Obter a descrição de um utilizador 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGetDescription_Click(object sender, EventArgs e)
        {
            // proteção para que não se execute esta funcionalidade sem que um utilizador esteja selecionado
            if (lboxUsers.SelectedIndex == -1)
            {
                MessageBox.Show("tem que escolher um utilizador!");
                return;
            }

            //todo: linha selecionada na listbox.... ((string)lboxUsers.SelectedValue)


            var login = (String) lboxUsers.SelectedValue; //vai buscar o valor do que está selecionado

            //login = ((User)lboxUsers.SelectedItem).Login; //isto devolve o objeto todo (neste caso um User inteiro)

            AuthServiceClient client = new AuthServiceClient();

            var message = client.GetUserDescription(login);
            if (message.Status == "OK")
            {
                txtDescription.Text = message.Description;
            }
            else
            {
                MessageBox.Show(message.Message);
            }

            //txtDescription.Text = client.GetUserDescription(login);

            client.Close();

        }

        /// <summary>
        /// Atualizar a descrição de um utilizador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetDescription_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                // lembrar de usar o "using"

                using (AuthServiceClient client = new AuthServiceClient() ) //o using faz o dispose sozinho, mas é "quando quer"
                {
                    var login = txtLogin.Text;
                    var password = txtPassword.Text;
                    var description = txtMyDescription.Text;

                    var response = client.SetUserDescription(login,password,description);
                    MessageBox.Show(response.Message);
              
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnGetUsersCertificate_Click(object sender, EventArgs e)
        {
            AuthServiceClient client = new AuthServiceClient();

            X509Certificate2 certificate = new X509Certificate2("estg.ei.si.b.pfx", "ei.si");

            ContentInfo contentInfo = new ContentInfo(Encoding.UTF8.GetBytes("Authentication Request")); //o que vamos assinar

            CmsSigner cmsSigner = new CmsSigner(certificate);

            SignedCms signed = new SignedCms(contentInfo);

            signed.ComputeSignature(cmsSigner);

            var pkcs7 = signed.Encode();

            var pkcs7Base64 = Convert.ToBase64String(pkcs7);

            var message = client.GetUsersByThumbprint(pkcs7Base64);


            if (message.Status != "OK")
            {
                MessageBox.Show(message.Message);
                return;
            }

            //ListBox dos Users
            //// versão 1
            lboxUsers.DataSource = message.Users;
            lboxUsers.DisplayMember = "Name"; //o que querenos que mostre na ListBox
            lboxUsers.ValueMember = "Login"; //o que queremos obter quando pedimos o valor do que está selecionado

            client.Close();
        }
    }
}

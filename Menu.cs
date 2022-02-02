using System;
using System.Threading;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            this.Hide();
            clients.Closed += (s, args) => this.Close();
            clients.Show();
        }
    }
}

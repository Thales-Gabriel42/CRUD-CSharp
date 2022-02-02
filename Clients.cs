using System;
using CRUD.Models;
using CRUD.BLL;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                ClientInformation client = new ClientInformation();
                client.Id = int.Parse(txbId.Text);
                client.Name = txbName.Text;
                client.Phone = mtxbPhone.Text;
                client.Email = txbEmail.Text;
                client.Address = txbAddress.Text;
                client.BirthDate = dtpBirthDate.Value;
                client.RegisterDate = DateTime.Now;

                ClientsBLL cb = new ClientsBLL();
                cb.Insert(client);
                MessageBox.Show("Succesfully registered!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClientsBLL cb = new ClientsBLL();
            ClientInformation client = cb.Search(int.Parse(txbSearch.Text));

            txbId.Text = client.Id.ToString();
            txbName.Text = client.Name;
            mtxbPhone.Text = client.Phone;
            txbEmail.Text = client.Email;
            txbAddress.Text = client.Address;
            dtpBirthDate.Value = client.BirthDate.ToUniversalTime();
            txbRegisterDate.Text = client.RegisterDate.ToUniversalTime().ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ClientInformation client = new ClientInformation();
            client.Id = int.Parse(txbId.Text);
            client.Name = txbName.Text;
            client.Phone = mtxbPhone.Text;
            client.Address = txbAddress.Text;
            client.Email = txbEmail.Text;
            client.BirthDate = dtpBirthDate.Value;

            ClientsBLL cb = new ClientsBLL();
            cb.Update(client);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClientsBLL cb = new ClientsBLL();
            cb.Delete(int.Parse(txbId.Text));
        }
    }
}

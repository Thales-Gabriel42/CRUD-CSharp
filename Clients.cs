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

        private void Clients_Load(object sender, EventArgs e)
        {
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            TextBoxesEnabled(false);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnInsert.Enabled = true;
            btnCancel.Visible = true;
            btnCancel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSearch.Enabled = false;
            txbSearch.Enabled = false;
            TextBoxesEnabled(true);
            ClearInformation();
            txbId.Text = (ClientsBLL.RegisterCount() + 1).ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                ClientInformation client = CreateClient();

                ClientsBLL.Insert(client);
                MessageBox.Show("Succesfully registered!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnInsert.Enabled = false;
            btnCancel.Enabled = false;
            btnCancel.Visible = false;
            btnSearch.Enabled = true;
            txbSearch.Enabled = true;
            ClearInformation();
            TextBoxesEnabled(false);
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ClientInformation client = ClientsBLL.Search(int.Parse(txbSearch.Text));
                txbId.Text = client.Id.ToString();
                txbName.Text = client.Name;
                mtxbPhone.Text = client.Phone;
                txbEmail.Text = client.Email;
                txbAddress.Text = client.Address;
                dtpBirthDate.Value = client.BirthDate.ToUniversalTime();
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnCancel.Visible = true;
            btnCancel.Enabled = true;
            TextBoxesEnabled(true);
            btnUpdate.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ClientInformation client = CreateClient();
            ClearInformation();

            ClientsBLL.Update(client);
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            MessageBox.Show("Changes saved successfully!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ClientInformation client = CreateClient();
                ClientsBLL.Delete(client);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInformation();
            btnSearch.Enabled = true;
            txbSearch.Enabled = true;
            btnInsert.Enabled = false;
            if (btnUpdate.Enabled)
            {
                btnUpdate.Enabled = false;
                btnSave.Enabled = false;
            }
            btnCancel.Enabled = false;
            btnCancel.Visible = false;
            TextBoxesEnabled(false);
        }

        private void ClearInformation()
        {
            txbId.Text = "";
            txbName.Text = "";
            mtxbPhone.Text = "";
            dtpBirthDate.Value = DateTime.Today;
            txbEmail.Text = "";
            txbAddress.Text = "";
        }

        private void TextBoxesEnabled(bool state)
        {
            txbName.Enabled = state;
            mtxbPhone.Enabled = state;
            dtpBirthDate.Enabled = state;
            txbEmail.Enabled = state;
            txbAddress.Enabled = state;
        }

        private ClientInformation CreateClient()
        {
            ClientInformation client = new ClientInformation(int.Parse(txbId.Text), txbName.Text, mtxbPhone.Text, txbEmail.Text, txbAddress.Text, dtpBirthDate.Value.ToUniversalTime(), DateTime.Now);
            return client;
        }
    }
}

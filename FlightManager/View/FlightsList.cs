using System;
using System.Data.Entity.Migrations;
using System.Windows.Forms;
using FlightManager.Model;

namespace FlightManager
{
    public partial class FlightsList : Form
    {
        ControllerConsumers controllerConsumers = new  ControllerConsumers();

        public FlightsList()
        {
            InitializeComponent();
        }

        public void RefreshDatabase()
        {
            dgvConsumers.DataSource = controllerConsumers.GetAllConsumers();
            dgvConsumers.Update();
            dgvConsumers.Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvConsumers.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //ADD
            Consumer consumer = new Consumer();
            consumer.Username = txtUsername.Text;
            consumer.Password = txtPassword.Text;
            controllerConsumers.InsertConsumerss(consumer);
            MessageBox.Show("You succesfuly added");
            RefreshDatabase();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //DELETE
            var consumer = (Consumer)dgvConsumers.CurrentRow.DataBoundItem;
            var id = consumer.Id;
            controllerConsumers.Delete((int)id);
            RefreshDatabase();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //EDIT
            var consumers = (Consumer)dgvConsumers.CurrentRow.DataBoundItem;
            controllerConsumers.Edit(consumers);
            RefreshDatabase();
        }

        private void FlightsList_Load(object sender, EventArgs e)
        {
            RefreshDatabase();
        }
        private void RefreshTable()
        {
            dgvConsumers.DataSource = controllerConsumers.GetAllConsumers();
        }
    }
}

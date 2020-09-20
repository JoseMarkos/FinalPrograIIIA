using FinalApp.apps.Controllers;
using FinalApp.src.Registros.Infrastructure.Persistance;
using FinalApp.src.Telefonos.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalApp.apps.Templates
{
    public partial class Dashboard : Form
    {
        private readonly Dictionary<string, IController> MenuItems;
        public Dashboard(Dictionary<string, object> data)
        {
            MenuItems = (Dictionary<string, IController>)data["menuItems"];
            InitializeComponent();
            PopulateComboRegistro();
            PopulateGrid();
        }

        private void comboRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenFormDialog(comboRegistros.SelectedItem.ToString());
        }

        private void OpenFormDialog(string key)
        {
            var controller = MenuItems[key];
            var form = controller.GetForm();

            this.Hide();
            form.ShowDialog();
        }

        private void PopulateComboRegistro()
        {
            var itemNames = from item in MenuItems
                            select item.Key;

            foreach (var item in itemNames)
            {
                comboRegistros.Items.Add(item);
            }
        }

        private void PopulateGrid()
        {
            var repository = new SQLServerTelefonoRepository();
            var all = repository.SearchAll().ToList();

            var dataBinding = new BindingSource()
            {
                DataSource = all
             };

            dataGridView1.DataSource = dataBinding;
            dataGridView1.Refresh();
        }

        protected void Exit(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}

using FinalApp.src.Shared.Infrastructure.Persistance;
using FinalApp.src.Telefonos.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalApp.apps.Templates.Reportes
{
    public partial class ReporteGama : Form
    {
        public ReporteGama()
        {
            InitializeComponent();
            PopulateComboGama();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewMethod2();
        }

        private void NewMethod2()
        {
            var controller = Routes.GetRoutes()["Dashboard"];
            var form = controller.GetForm();

            form.Show();
            this.Close();
        }

        private void PopulateComboGama()
        {
            using var context = new IPearContext();

            var list = context.TelefonoGamas.ToList();

            var listNames = from x in list
                            select x.Name;

            foreach (var item in listNames)
            {
                comboGama.Items.Add(item);
            }
        }

        private int GetComboGamaValue()
        {
            if (comboGama.SelectedIndex == -1)
            {
                return comboGama.SelectedIndex;
            }
            return comboGama.SelectedIndex + 1;
        }

        private void comboGama_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            var repository = new SQLServerTelefonoRepository();
            var all = repository.SearchAll().ToList();

            var filtered = from item in all
                           where item.TelefonoGamaId == GetComboGamaValue()
                           select item;

            var dataBinding = new BindingSource()
            {
                DataSource = filtered
            };

            dataGridView1.DataSource = dataBinding;
            dataGridView1.Refresh();
        }
    }
}

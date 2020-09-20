using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FinalApp.apps.Templates.Reportes
{
    public partial class ReporteGama : Form
    {
        public ReporteGama()
        {
            InitializeComponent();
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
    }
}

using FinalApp.src.Data.Telefonos;
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
    public partial class ReporteMultiparametro : Form
    {
        public ReporteMultiparametro()
        {
            InitializeComponent();
            PopulateComboCity();
            PopulateComboGama();
            PopulateComboColor();
        }

        private void BtnRegrasar_Click(object sender, EventArgs e)
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

        private void PopulateComboCity()
        {
            using var context = new IPearContext();

            var list = context.TelefonoCiudadEnsanblajes.ToList();

            var listNames = from x in list
                            select x.Name;

            foreach (var item in listNames)
            {
                comboCity.Items.Add(item);
            }
        }

        private void PopulateComboColor()
        {
            using var context = new IPearContext();

            var list = context.TelefonoColores.ToList();

            var listNames = from x in list
                            select x.Name;

            foreach (var item in listNames)
            {
                comboColor.Items.Add(item);
            }
        }

        private int GetComboGamaValue()
        {
            return NewMethod(comboGama.SelectedIndex);
        }

        private int GetComboCityValue()
        {
            return NewMethod(comboCity.SelectedIndex);
        }

        private int GetComboColorValue()
        {
            return NewMethod(comboColor.SelectedIndex);
        }

        private int NewMethod(int value)
        {
            if (value == -1)
            {
                return value;
            }
            return value + 1;
        }

        private void PopulateGrid()
        {
            var repository = new SQLServerTelefonoRepository();
            var all = repository.SearchAll().ToList();

            if (GetComboGamaValue() != -1)
            {
                all = FilterGama(all);
            }

            if (GetComboCityValue() != -1)
            {
                all = FilterCity(all);
            }
            if (GetComboColorValue() != -1)
            {
                all = FilterColor(all);
            }

            var dataBinding = new BindingSource()
            {
                DataSource = all
            };

            dataGridView1.DataSource = dataBinding;
            dataGridView1.Refresh();
        }

        private List<Telefono> FilterGama(List<Telefono> list)
        {
            var matches = from item in list
                   where item.TelefonoGamaId == GetComboGamaValue()
                   select item;

            return matches.ToList();
        }

        private List<Telefono> FilterCity(List<Telefono> list)
        {
            var matches = from item in list
                          where item.TelefonoCiudadEnsanblajeId == GetComboCityValue()
                          select item;

            return matches.ToList();
        }

        private List<Telefono> FilterColor(List<Telefono> list)
        {
            var matches = from item in list
                          where item.TelefonoColorId == GetComboColorValue()
                          select item;

            return matches.ToList();
        }

        private void comboCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void comboGama_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void comboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboCity.SelectedIndex = -1;
            comboColor.SelectedIndex = -1;
            comboGama.SelectedIndex = -1;
        }
    }
}

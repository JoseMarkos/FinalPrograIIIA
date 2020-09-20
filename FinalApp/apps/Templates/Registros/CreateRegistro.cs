using FinalApp.src.Registros.Application.Create;
using FinalApp.src.Shared.Infrastructure.Persistance;
using FinalApp.src.Telefonos.Application.Create;
using FinalApp.src.Telefonos.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalApp.apps.Templates.Registros
{
    public partial class CreateRegistro : Form
    {
        private readonly TelefonoCreateCommandHandler telefonoCreateCommandHandler;
        private readonly CrearRegistroCommandHandler crearRegistroCommandHandler;
        public CreateRegistro(Dictionary<string, object> data)
        {
            InitializeComponent();

            telefonoCreateCommandHandler = (TelefonoCreateCommandHandler)data["telefonoCreatorHandler"];
            crearRegistroCommandHandler = (CrearRegistroCommandHandler)data["registerCreatorHandler"];
            PopulateComboCiudad();
            PopulateComboGama();
            PopulateComboColor();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                CreateTelefono();
                CrearRegistro();
                NewMethod2();
            }
            catch (Exception createRegistroE)
            {
                labelError.Text = createRegistroE.Message;
            }
        }

        private void CreateTelefono()
        {
            var command = new TelefonoCreateCommand(
                GetComboCityValue(),
                GetComboGamaValue(),
                GetComboColorValue(),
                decimal.Parse(txtPrecioTotal.Text)
            );
            telefonoCreateCommandHandler.Trigger(command);
        }

        private void CrearRegistro()
        {
            var repository = new SQLServerTelefonoRepository();
            var last  = repository.SearchAll().ToList().Last();

            var command = new CrearRegistroCommand(dateTimePicker1.Value, last.Id);
            crearRegistroCommandHandler.Trigger(command);
        }

        private void TxtPrecio_TextChanged(object sender, EventArgs e)
        {
            NewMethod1();
        }

        private void NewMethod1()
        {
            try
            {
                NewMethod();
            }
            catch (Exception priceE)
            {
                labelError.Text = priceE.Message;
            }
        }

        private void NewMethod()
        {
            int value = GetComboCityValue();

            decimal price = decimal.Parse(txtPrecio.Text);
            decimal totalPrice = 0;


            if (value != -1)
            {
                switch (value)
                {
                    case 0:
                        totalPrice = price + (decimal)((double)price * 0.3);
                        break;

                    case 1:
                        totalPrice = price + (decimal)((double)price * (0.3 *2));
                        break;
                    case 2:
                        totalPrice = price + (decimal)((double)price * (0.3 * 3));
                        break;
                    case 3:
                        totalPrice = price + (decimal)((double)price * (0.3 * 4));
                        break;
                    default:
                        break;
                }

                txtPrecioTotal.Text = totalPrice.ToString();
            }

        }

        private int GetComboCityValue()
        {
            return comboCity.SelectedIndex;
        }

        private int GetComboGamaValue()
        {
            return comboGama.SelectedIndex;
        }

        private int GetComboColorValue()
        {
            return comboColor.SelectedIndex;
        }

        private void PopulateComboCiudad()
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

        private void comboCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtPrecio.Text != String.Empty)
            {
                NewMethod1();
            }
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
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
    }
}

using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL.src.Reportes.Application.SearchTelefnoGamasAll;
using Modelos.Telefonos;
using DAL.Shared.Infrastructure.Persistance;
using DAL.Telefonos.Infrastructure;

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
            var listNames = TelefonoGamaSearcher.Trigger();

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

        private void ComboCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void ComboGama_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void ComboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            comboCity.SelectedIndex = -1;
            comboColor.SelectedIndex = -1;
            comboGama.SelectedIndex = -1;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "PDF (*.pdf)|*.pdf",
                    FileName = "reporte.pdf"
                };
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count - 3 );
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));

                                if ((column.Index != 2)
                                    && (column.Index != 6)
                                    && (column.Index != 4))
                                {
                                    pdfTable.AddCell(cell);
                                }
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (!(cell.Value is null))
                                    {
                                        if ((cell.ColumnIndex != 2)
                                        && (cell.ColumnIndex != 6)
                                        && (cell.ColumnIndex != 4))
                                        {
                                            pdfTable.AddCell(cell.Value.ToString());
                                        }
                                    }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Se exporto exitosamente", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay informacion.", "Info");
            }
        }
    }
}

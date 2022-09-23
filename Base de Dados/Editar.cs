using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base_de_Dados
{
    public partial class Editar : Form
    {
        public Editar()
        {
            InitializeComponent();
        }

        private void dadosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dadosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.projeto_FinalDataSet1);

        }

        private void Editar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projeto_FinalDataSet1.Dados' table. You can move, or remove it, as needed.
            this.dadosTableAdapter.Fill(this.projeto_FinalDataSet1.Dados);

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var row = dadosTableAdapter.GetDataByID(Convert.ToInt32(textBoxID.Text)).Rows[0];
                textBoxNomeDI.Text = (row["Nome"].ToString());
                textBoxMoradaDI.Text = (row["Morada"].ToString());
                dateTimePicker1.Value = (Convert.ToDateTime(row["Data de Nascimento"]));
                textBoxCC_DI.Text = (row["CC"].ToString());
                comboBoxEstado.SelectedItem = (row["Estado Civil"].ToString());
                textBox1.Text = (row["Nº Titulares"].ToString());
                textBox2.Text = (row["Nº Dependentes"].ToString());
                comboBoxDelega.SelectedItem = (row["Delegação"].ToString());
                textBoxSB_DI.Text = (row["Salário Base"].ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("ID em falta ou inválido.", "Erro ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void buttonGravarDI_Click(object sender, EventArgs e)
        {
            try
            {
                dadosTableAdapter.UpdateQueryTeste(textBoxNomeDI.Text, textBoxMoradaDI.Text, dateTimePicker1.Value.ToString(), Convert.ToInt32(textBoxCC_DI.Text), comboBoxEstado.Text, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), comboBoxDelega.Text, Convert.ToDouble(textBoxSB_DI.Text), Convert.ToInt32(textBoxID.Text), 1);
                textBox1.Clear();
                textBox2.Clear();
                textBoxCC_DI.Clear();
                textBoxID.Clear();
                textBoxSB_DI.Clear();
                textBoxMoradaDI.Clear();
                textBoxNomeDI.Clear();
                comboBoxDelega.Text = "";
                comboBoxEstado.Text = "";
                dateTimePicker1.ResetText();
                MessageBox.Show("Editado com Sucesso");
                    
            }
            catch (Exception)
            {
                MessageBox.Show("Dados em falta ou inválidos.", "Erro Gravar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(textBox6.Text);

                DialogResult dr = MessageBox.Show("Tem a certeza que quer eliminar?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                {
                    Close();
                }
                else
                {
                    dadosTableAdapter.DeleteQueryByID(ID);
                    textBox6.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ID em falta ou inválido.", "Erro Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dadosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dadosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.projeto_FinalDataSet11);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projeto_FinalDataSet11.Dados' table. You can move, or remove it, as needed.
            this.dadosTableAdapter.Fill(this.projeto_FinalDataSet11.Dados);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

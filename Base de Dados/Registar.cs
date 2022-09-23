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
    public partial class Registar : Form
    {
        public Registar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == "admin1234")
                {

                    if (textBox2.Text == textBox3.Text)
                    {
                        utilizadorTableAdapter.Insert(textBox1.Text, textBox2.Text);
                        MessageBox.Show("Registado com sucesso", "Registo");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Passwords não coincidem", "Passwords", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox2.Clear();
                        textBox3.Clear();
                    }

                }
                else

                    MessageBox.Show("Chave de Admin incorreta", "Chave de Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Clear();

            }
            catch (Exception)
            {
                MessageBox.Show("Dados em falta ou inválidos.", "Erro Dados", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void utilizadorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.utilizadorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.projeto_FinalDataSet2);

        }

        private void Registar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projeto_FinalDataSet2.Utilizador' table. You can move, or remove it, as needed.
            this.utilizadorTableAdapter.Fill(this.projeto_FinalDataSet2.Utilizador);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

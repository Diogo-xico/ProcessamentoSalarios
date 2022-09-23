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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(textBox6.Text);

                DialogResult dr = MessageBox.Show("Tem a certeza que quer Remover?", "Remover", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                {
                    Close();
                }
                else
                {
                    ficheiro_MensalTableAdapter.DeleteQueryById(ID);
                    textBox6.Clear();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("ID de processamento em falta ou inválido.", "Erro Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            
        }

        private void ficheiro_MensalBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ficheiro_MensalBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.projeto_FinalDataSet1);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projeto_FinalDataSet1.Ficheiro_Mensal' table. You can move, or remove it, as needed.
            this.ficheiro_MensalTableAdapter.Fill(this.projeto_FinalDataSet1.Ficheiro_Mensal);

        }
    }
}

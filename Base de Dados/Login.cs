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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public string User { get; set; }


        private void utilizadorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.utilizadorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.projeto_FinalDataSet2);

        }

        private void Login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projeto_FinalDataSet2.Utilizador' table. You can move, or remove it, as needed.
            this.utilizadorTableAdapter.Fill(this.projeto_FinalDataSet2.Utilizador);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int contar = utilizadorTableAdapter.GetDataBy(textBox1.Text, textBox2.Text).Count;

            if (contar > 0)
            {
                User = utilizadorTableAdapter.GetDataBy(textBox1.Text, textBox2.Text).First().Nome;             
                

                Form1 form = new Form1();

                this.Hide();
                form.ShowDialog();
                form.Dispose();
                
            }
            else
            {
                MessageBox.Show("Login Inválido","Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Clear();
                textBox2.Clear();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registar form = new Registar();
            
            form.ShowDialog();
            form.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }
    }
}

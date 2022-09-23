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
    public partial class Importar : Form
    {
        public Importar()
        {
            InitializeComponent();
        }

        private void importarBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.importarBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.projeto_FinalDataSet1);

        }

        private void Importar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projeto_FinalDataSet1.Importar' table. You can move, or remove it, as needed.
            this.importarTableAdapter.Fill(this.projeto_FinalDataSet1.Importar);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

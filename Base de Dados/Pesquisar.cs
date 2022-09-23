using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace Base_de_Dados
{
    public partial class Pesquisar : Form
    {
        public Pesquisar()
        {
            InitializeComponent();
        }

        private void ficheiro_MensalBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ficheiro_MensalBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.projeto_FinalDataSet1);

        }

        private void Pesquisar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projeto_FinalDataSet1.Importar' table. You can move, or remove it, as needed.
            this.importarTableAdapter.Fill(this.projeto_FinalDataSet1.Importar);
            // TODO: This line of code loads data into the 'projeto_FinalDataSet1.Importar' table. You can move, or remove it, as needed.
            this.importarTableAdapter.Fill(this.projeto_FinalDataSet1.Importar);
            // TODO: This line of code loads data into the 'projeto_FinalDataSet1.Ficheiro_Mensal' table. You can move, or remove it, as needed.
            this.ficheiro_MensalTableAdapter.Fill(this.projeto_FinalDataSet1.Ficheiro_Mensal);

        }

        private void panelDI_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ficheiro_MensalTableAdapter.FillByDadosID(projeto_FinalDataSet1.Ficheiro_Mensal, Convert.ToInt32(textBoxID.Text));
            }
            catch (Exception)
            {

                MessageBox.Show("ID introduzido em falta inválido.", "ID Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ficheiro_MensalTableAdapter.FillByMesAno(projeto_FinalDataSet1.Ficheiro_Mensal, comboBox1.Text, Convert.ToInt32(textBox1.Text));

            }
            catch (Exception)
            {

                MessageBox.Show("Mês/Ano Inválido ou não existe processamento", "Erro Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ficheiro_MensalTableAdapter.GetDataBy2MesAno(comboBox1.Text, Convert.ToInt32(textBox1.Text)).Rows.Count != 0)

            {
                try
                {

                    string FileName = comboBox1.Text.ToString() + textBox1.Text.ToString() + ".bin";

                    DialogResult dr = MessageBox.Show("Deseja exportar para binário?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {

                        FileStream fs = new FileStream(FileName, FileMode.Create);

                        BinaryWriter bw = new BinaryWriter(fs);

                        foreach (Projeto_FinalDataSet1.Ficheiro_MensalRow row in ficheiro_MensalTableAdapter.GetDataBy2MesAno(comboBox1.Text, Convert.ToInt32(textBox1.Text)).Rows)
                        {
                            bw.Write(row.Estado_Civil);
                            bw.Write(row.Nº_de_Titulares);
                            bw.Write(row.Nº_de_Dependentes);
                            bw.Write(row.Delegação);
                            bw.Write(row.Salário_Base);
                            bw.Write(row.Nº_de_faltas);
                            bw.Write(row.Valor_Hora);
                            bw.Write(row.Nª_de_horas_extra);
                            bw.Write(row.Valor_total_das_horas_extra);
                            bw.Write(row.Contribuição_SS);
                            bw.Write(row.Valor_total_sub__refeição);
                            bw.Write(row._Taxa_de_retenção_IRS____);
                            bw.Write(row.Valor_de_retenção_IRS);
                            bw.Write(row.Salário_Líquido);
                            bw.Write(row.DadosID);
                            bw.Write(row.Ano);
                            bw.Write(row.Mês);

                        }
                        fs.Close();
                        bw.Close();

                        MessageBox.Show("Exportado com sucesso", "Exportar", MessageBoxButtons.OK);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro ao exportar dados, Ano ou Mês em falta.", "Erro Exportar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show("Não há preocessamentos para este mês");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Close();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ficheiro_MensalTableAdapter.Fill(projeto_FinalDataSet1.Ficheiro_Mensal);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deseja Consultar " + comboBox1.Text + textBox1.Text + "?");
            string nome_ficheiro = "" + comboBox1.Text + textBox1.Text + ".bin";

            try
            {
                FileStream fs = new FileStream(nome_ficheiro, FileMode.Open,FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                

                //while (fs.ReadByte()>0)   //SÓ ESTÁ A LER UMA PESSOA DO FICHEIRO BINÁRIO
                //{
                    string estado = br.ReadString();
                    int titulares = br.ReadInt32();
                    int dependentes = br.ReadInt32();
                    string delegação = br.ReadString();
                    double sb = br.ReadDouble();
                    int faltas = br.ReadInt32();
                    double vhora = br.ReadDouble();
                    int horasextra = br.ReadInt32();
                    double totalhoras = br.ReadDouble();
                    double ss = br.ReadDouble();
                    double sub_refeicao = br.ReadDouble();
                    double taxaIrs = br.ReadDouble();
                    double valorretencao = br.ReadDouble();
                    double salarioliquido = br.ReadDouble();
                    int dadosId = br.ReadInt32();
                    int ano = br.ReadInt32();
                    string mes = br.ReadString();



                    importarTableAdapter.Insert(estado, titulares, dependentes, delegação, sb, faltas, vhora, horasextra, totalhoras, ss, sub_refeicao, taxaIrs, valorretencao, salarioliquido, dadosId, ano, mes);
                    
                //}
                
              
                    br.Close();
                    fs.Close();
                    
                


                importarTableAdapter.Fill(projeto_FinalDataSet1.Importar);
                Importar f1 = new Importar();
                f1.ShowDialog();
                f1.Dispose();
                

            }
            catch (Exception exp)
            {
                //MessageBox.Show("Ficheiro não encontrado");
                MessageBox.Show(exp.Message);
            }
        }
    }
}

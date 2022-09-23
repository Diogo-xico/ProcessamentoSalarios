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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PanelGesPess.Visible = false;
            panelDI.Visible = false;
            panelGS.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projeto_FinalDataSet1.Dados' table. You can move, or remove it, as needed.
            this.dadosTableAdapter.Fill(this.projeto_FinalDataSet1.Dados);
            // TODO: This line of code loads data into the 'projeto_FinalDataSet1.Ficheiro_Mensal' table. You can move, or remove it, as needed.
            this.ficheiro_MensalTableAdapter.Fill(this.projeto_FinalDataSet1.Ficheiro_Mensal);
            webBrowser1.Navigate("infordocente.ipc.pt/nonio/security/login.do?locale=PT");
            timer1.Start();


        }


        static int CalcularDiasUteis(int d)
        {
            int diasuteis=0;
       
            switch (d)
            {

                case 0:
                    diasuteis = 21;
                    
                    break;

                case 1:
                    diasuteis = 21;
                    
                    break;
                case 2:
                    diasuteis = 24;
                    
                    break;
                case 3:
                    diasuteis = 21;
                    
                    break;
                case 4:
                    diasuteis = 22;
                    
                    break;
                case 5:
                    diasuteis = 21;
                    
                    break;
                case 6:
                    diasuteis = 22;
                    
                    break;
                case 7:
                    diasuteis = 23;
                    
                    break;
                case 8:
                    diasuteis = 23;
                    
                    break;
                case 9:
                    diasuteis = 20;
                    
                    break;
                case 10:
                    diasuteis = 21;
                    
                    break;
                case 11:
                    diasuteis = 21;
                    
                    break;


                default:

                    break;
            }

            return diasuteis;
        }


        static double TaxaContinente(int tit, int dep, string estado, double salario)
        {
            int n = 0;
            double taxa = 0;
            if (estado == "Solteiro" || estado == "Divorciado" || estado == "Viúvo")
                n = 1;

            if (estado == "Casado" && tit==1)
                n = 2;

            if (estado == "Casado" && tit == 2)
                n = 3;

            switch (n)
            {
                case 1:
                    try
                    {
                        string linha;
                        double salariotabela = 0;
                        StreamReader sr = new StreamReader("Continente-NaoCasado.txt");
                        while ((linha = sr.ReadLine()) != null)
                        {
                            salariotabela = Convert.ToDouble(linha.Substring(0, 9));

                            if (salario <= salariotabela)
                            {
                                if (dep == 0)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(9, 5));
                                    break;
                                }
                                if (dep == 1)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(14, 5));
                                    break;
                                }
                                if (dep == 2)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(19, 5)); 
                                    break;
                                }
                                if (dep == 3)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(24, 5));
                                    break;
                                }
                                if (dep == 4)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(29, 5));
                                    break;
                                }
                                if (dep >= 5)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(34, 4));
                                    break;
                                }
                            }
                        }
                        sr.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro na leitura da taxa!");
                    }

                    break;

                case 2:
                    try
                    {
                        string linha;
                        double salariotabela = 0;
                        StreamReader sr = new StreamReader("Continente-CasadoUni.txt");
                        while ((linha = sr.ReadLine()) != null)
                        {
                            salariotabela = Convert.ToDouble(linha.Substring(0, 9));

                            if (salario <= salariotabela)
                            {
                                if (dep == 0)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(9, 5));
                                    break;
                                }
                                if (dep == 1)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(14, 5));
                                    break;
                                }
                                if (dep == 2)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(19, 5));
                                    break;
                                }
                                if (dep == 3)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(24, 5));
                                    break;
                                }
                                if (dep == 4)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(29, 5));
                                    break;
                                }
                                if (dep >= 5)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(34, 4));
                                    break;
                                }
                            }
                        }
                        sr.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro na leitura da taxa!");
                    }

                    break;

                case 3:
                    try
                    {
                        string linha;
                        double salariotabela = 0;
                        StreamReader sr = new StreamReader("Continente-CasadoDois.txt");
                        while ((linha = sr.ReadLine()) != null)
                        {
                            salariotabela = Convert.ToDouble(linha.Substring(0, 9));

                            if (salario <= salariotabela)
                            {
                                if (dep == 0)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(9, 5));
                                    break;
                                }
                                if (dep == 1)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(14, 5));
                                    break;
                                }
                                if (dep == 2)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(19, 5));
                                    break;
                                }
                                if (dep == 3)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(24, 5));
                                    break;
                                }
                                if (dep == 4)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(29, 5));
                                    break;
                                }
                                if (dep >= 5)
                                {
                                    taxa = Convert.ToDouble(linha.Substring(34, 4));
                                    break;
                                }
                            }
                        }
                        sr.Close();
                    }
                    catch (Exception a)
                    {
                        MessageBox.Show(a.Message);
                        //MessageBox.Show("Erro na leitura da taxa!");
                    }

                    break;

            }
            return taxa;

        }
        static double TaxaMadeira(int tit, int dep, string estado, double salario)
        {
            int n = 0;
            double taxa = 0;
            if (estado == "Solteiro" || estado == "Divorciado" || estado == "Viúvo")
                n = 1;

            if (estado == "Casado" && tit == 1)
                n = 2;

            if (estado == "Casado" && tit == 2)
                n = 3;

            switch (n)
            {
                case 1:
                    try
                    {
                        string linha = "";
                        StreamReader sr = new StreamReader("Madeira-NaoCasado.txt");
                        while ((linha = sr.ReadLine()) != null)
                        {
                            string[] salarios = linha.Split('*');
                            double salariotabela = Convert.ToDouble(salarios[0]);
                            if (salario <= salariotabela)
                            {
                                if (dep <= 4)
                                {
                                    taxa = Convert.ToDouble(salarios[dep + 1]);
                                    break;
                                }
                                else
                                {
                                    taxa = Convert.ToDouble(salarios[6]);
                                    break;
                                }
                            }
                        }
                        sr.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro na leitura da taxa!");
                    }

                    break;

                case 2:
                    try
                    {
                        string linha = "";
                        StreamReader sr = new StreamReader("Madeira-CasadoUni.txt");
                        while ((linha = sr.ReadLine()) != null)
                        {
                            string[] salarios = linha.Split('*');
                            double salariotabela = Convert.ToDouble(salarios[0]);
                            if (salario <= salariotabela)
                            {
                                if (dep <= 4)
                                {
                                    taxa = Convert.ToDouble(salarios[dep + 1]);
                                    break;
                                }
                                else
                                {
                                    taxa = Convert.ToDouble(salarios[6]);
                                    break;
                                }
                            }
                        }
                        sr.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro na leitura da taxa!");
                    }

                    break;
                case 3:
                    try
                    {
                        string linha = "";
                        StreamReader sr = new StreamReader("Madeira-CasadoDois.txt");
                        while ((linha = sr.ReadLine()) != null)
                        {
                            string[] salarios = linha.Split('*');
                            double salariotabela = Convert.ToDouble(salarios[0]);
                            if (salario <= salariotabela)
                            {
                                if (dep <= 4)
                                {
                                    taxa = Convert.ToDouble(salarios[dep + 1]);
                                    break;
                                }
                                else
                                {
                                    taxa = Convert.ToDouble(salarios[6]);
                                    break;
                                }
                            }
                        }
                        sr.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro na leitura da taxa!");
                    }

                    break;

            }
            return taxa;
        }
        static double TaxaAçores(int tit, int dep, string estado, double salario)
        {
            int n = 0;
            double taxa = 0;
            if (estado == "Solteiro" || estado == "Divorciado" || estado == "Viúvo")

                n = 1;

            if (estado == "Casado" && tit == 1)
                n = 2;

            if (estado == "Casado" && tit == 2)
                n = 3;

            switch (n)
            {
                case 1:
                    try
                    {
                        string linha = "";
                        StreamReader sr = new StreamReader("Açores-NaoCasado.txt");
                        while ((linha = sr.ReadLine()) != null)
                        {
                            string[] salarios = linha.Split('*');
                            double salariotabela = Convert.ToDouble(salarios[0]);
                            if (salario <= salariotabela)
                            {
                                if (dep <= 4)
                                {
                                    taxa = Convert.ToDouble(salarios[dep + 1]);
                                    break;
                                }
                                else
                                {
                                    taxa = Convert.ToDouble(salarios[6]);
                                    break;
                                }
                            }
                        }
                        sr.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro na leitura da taxa!");
                    }

                    break;

                case 2:
                    try
                    {
                        string linha = "";
                        StreamReader sr = new StreamReader("Açores-CasadoUni.txt");
                        while ((linha = sr.ReadLine()) != null)
                        {
                            string[] salarios = linha.Split('*');
                            double salariotabela = Convert.ToDouble(salarios[0]);
                            if (salario <= salariotabela)
                            {
                                if (dep <= 4)
                                {
                                    taxa = Convert.ToDouble(salarios[dep+1]);
                                    break;
                                }
                                else
                                {
                                    taxa = Convert.ToDouble(salarios[6]);
                                    break;
                                }
                            }
                        }
                        sr.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro na leitura da taxa!");
                    }

                    break;
                case 3:
                    try
                    {
                        string linha = "";
                        StreamReader sr = new StreamReader("Açores-CasadoDois.txt");
                        while ((linha = sr.ReadLine()) != null)
                        {
                            string[] salarios = linha.Split('*');
                            double salariotabela = Convert.ToDouble(salarios[0]);
                            if (salario <= salariotabela)
                            {
                                if (dep <= 4)
                                {
                                    taxa = Convert.ToDouble(salarios[dep + 1]);
                                    break;
                                }
                                else
                                {
                                    taxa = Convert.ToDouble(salarios[6]);
                                    break;
                                }
                            }
                        }
                        sr.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro na leitura da taxa!");
                    }

                    break;

            }
            return taxa;
        }

        static double TaxaDeIRS(int tit, int dep, string estado, double salario, string delegacao)
        {
            double taxa=0;

            int n=-1;
            if (delegacao == "Coimbra" || delegacao == "Lisboa" || delegacao == "Porto")
                n = 0;
            if (delegacao == "Funchal")
                n = 1;
            if (delegacao == "Ponta Delgada")
                n = 2;


            switch (n)
            {
                case 0:

                    taxa = TaxaContinente( tit,  dep,  estado, salario);
                    MessageBox.Show("Processado com sucesso!");
                    break;

                case 1:

                    taxa = TaxaMadeira( tit, dep,  estado,  salario);
                    MessageBox.Show("Processado com sucesso!");
                    break;
                case 2:

                    taxa = TaxaAçores( tit,  dep,  estado,  salario);
                    MessageBox.Show("Processado com sucesso!");
                    break;
            }

            return taxa;
        }

        private void ObterInformacaoIDePreencherFicheiroMensal(int idDados, int faltas, int horasextra, int mes, int ano, string mestab)
        {
            double valorhora, valorhorasextra, contribuicaoSS, valorrefeicao, valorretencao, salarioliq;

            var row = dadosTableAdapter.GetDataByID(Convert.ToInt32(idDados)).Rows[0];

            string estado = (row["Estado Civil"].ToString());
            int titulares = (Convert.ToInt32(row["Nº Titulares"]));
            int dependentes = (Convert.ToInt32(row["Nº Dependentes"]));
            string delegacao = (row["Delegação"].ToString());
            double sb = (Convert.ToDouble(row["Salário Base"]));

            valorhora = (sb * 12) / (40 * 52);

            valorhorasextra = (1.5 * valorhora) * horasextra;

            contribuicaoSS = 0.11 * sb;

            valorrefeicao = ((CalcularDiasUteis(mes) - faltas) * 4.27);

            double taxa = TaxaDeIRS(titulares, dependentes, estado, sb, delegacao)/100;

            valorretencao = (sb * taxa);

            salarioliq = sb + valorrefeicao + valorhorasextra - contribuicaoSS - valorretencao;


            ficheiro_MensalTableAdapter.InsertQuerySalario(estado,titulares,dependentes,delegacao,sb,faltas,valorhora,horasextra,valorhorasextra,contribuicaoSS,valorrefeicao,taxa,valorretencao,salarioliq,idDados,ano,mestab);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Login f1 = new Login();

            //f1.ShowDialog();
            //f1.Dispose();
            Application.Exit();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            PanelGesPess.Visible = true;
            panelDI.Visible = false;
            panelGS.Visible = false;
            panel14.Visible = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            PanelGesPess.Visible = false;
            panelDI.Visible = false;
            panelGS.Visible = true;
            panel14.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            PanelGesPess.Visible = false;
            panelDI.Visible = true;
            panelGS.Visible = false;
            panel14.Visible = false;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PanelGesPess.Visible = false;
            panelDI.Visible = false;
            panelGS.Visible = false;
            panel14.Visible = true;
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNumDep_TextChanged(object sender, EventArgs e)
        {

        }

        private void PanelGesPess_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void PanelGesSal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Adicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxEstado.SelectedIndex == 0)
                    numericUpDownTitulares.Value = 0;

                dadosTableAdapter.Insert(textBoxNome.Text, textBoxMorada.Text, dateTimePicker1.Value, Convert.ToInt32(textBoxNumCC.Text), comboBoxEstado.Text, (int)numericUpDownTitulares.Value, (int)numericUpDownDependentes.Value, comboBoxDelega.Text, Convert.ToDouble(textBoxSB.Text));

                comboBoxDelega.Text = "";
                comboBoxEstado.Text = "";
                numericUpDownTitulares.ResetText();
                numericUpDownDependentes.ResetText();
                textBoxNome.Clear();
                textBoxNumCC.Clear();
                textBoxMorada.Clear();
                textBoxSB.Clear();
                dateTimePicker1.ResetText();

                dadosTableAdapter.Fill(projeto_FinalDataSet1.Dados);
            }
            catch (Exception)
            {
                MessageBox.Show("Dados em falta ou inválidos.", "Erro Dados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Imprimir?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                    {
                        printDocument1.Print();

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ID em falta ou inválido.", "Erro Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();             
            f2.ShowDialog();
            f2.Dispose();
            dadosTableAdapter.Fill(projeto_FinalDataSet1.Dados);

        }

        private void buttonPesquisarDI_Click(object sender, EventArgs e)
        {

            try
            {
                var row = dadosTableAdapter.GetDataByID(Convert.ToInt32(textBoxID.Text)).Rows[0];
                textBoxNomeDI.Text = (row["Nome"].ToString());
                textBoxMoradaDI.Text = (row["Morada"].ToString());
                textBoxData_DI.Text = (row["Data de Nascimento"].ToString());
                textBoxCC_DI.Text = (row["CC"].ToString());
                textBoxEstado_DI.Text = (row["Estado Civil"].ToString());
                textBoxNT_DI.Text = (row["Nº Titulares"].ToString());
                textBoxND_DI.Text = (row["Nº Dependentes"].ToString());
                textBoxDelegação_DI.Text = (row["Delegação"].ToString());
                textBoxSB_DI.Text = (row["Salário Base"].ToString());
            }
            catch (Exception)
            {

                MessageBox.Show("ID em falta ou inválido.", "Erro ID", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                ObterInformacaoIDePreencherFicheiroMensal(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox5.Text), comboBox1.SelectedIndex, Convert.ToInt32(textBox1.Text), comboBox1.Text);
                ficheiro_MensalTableAdapter.Fill(projeto_FinalDataSet1.Ficheiro_Mensal);

                textBox6.Clear();
                textBox3.Clear();
                textBox1.Clear();
                textBox5.Clear();
                comboBox1.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("ID inválido ou dados em falta.", "Erro Processar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("=======FICHEIRO INDIVIDUAL=======", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(170));
            e.Graphics.DrawString("Nome: " + textBoxNomeDI.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(20,100));
            e.Graphics.DrawString("Morada: " + textBoxMoradaDI.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(20, 130));
            e.Graphics.DrawString("Nº Cartão de Cidadão: " + textBoxCC_DI.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(20, 160));
            e.Graphics.DrawString("Data de Nascimento: " + textBoxData_DI.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(20, 190));
            e.Graphics.DrawString("Salário Base: " + textBoxSB_DI.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(20, 220));
            e.Graphics.DrawString("Nº de Dependentes: " + textBoxND_DI.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(20, 250));
            e.Graphics.DrawString("Nº de Titulares: " + textBoxNT_DI.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(20, 280));
            e.Graphics.DrawString("Estado Civil: " + textBoxEstado_DI.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(20, 310));
            e.Graphics.DrawString("Delegação: " + textBoxDelegação_DI.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(20, 340));

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Deseja exportar para texto?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    StreamWriter sw = new StreamWriter("ListaDeFuncionarios.txt");
                    foreach (Projeto_FinalDataSet1.DadosRow row in dadosTableAdapter.GetData().Rows)
                    {
                        sw.WriteLine("Nome: {0} Morada: {1} CC: {2} Data de Nascimento: {3} Salário Base: {4} Nº de Dependentes: {5} Nº de Titulares: {6} Estado: {7} Delegação: {8}", row.Nome, row.Morada, row.CC, row.Data_de_Nascimento, row.Salário_Base, row.Nº_Dependentes, row.Nº_Titulares, row.Estado_Civil, row.Delegação);

                    }
                    sw.Close();

                    MessageBox.Show("Exportado com sucesso", "Exportar", MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao exportar dados", "Erro Exportar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            
            Editar f3 = new Editar();
            f3.ShowDialog();
            f3.Dispose();
            dadosTableAdapter.Fill(projeto_FinalDataSet1.Dados);
            

        }

        private void buttonEditarDI_Click(object sender, EventArgs e)
        {           

            //Editar f3 = new Editar();
            //f3.ShowDialog();
            //f3.Dispose();

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
            f3.Dispose();
            ficheiro_MensalTableAdapter.Fill(projeto_FinalDataSet1.Ficheiro_Mensal);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pesquisar f1 = new Pesquisar();
            f1.ShowDialog();
            f1.Dispose();
            ficheiro_MensalTableAdapter.Fill(projeto_FinalDataSet1.Ficheiro_Mensal);

        }

        private void panelGS_Paint(object sender, PaintEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //label13.Text = DateTime.Now.ToString("hh:mm:ss"); //tem um timer da toolbox
            //data.Text = DateTime.Now.ToString("dddd, MM/dd/yyyy");
        }

        private void label13_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label13.Text = DateTime.Now.ToString("HH:mm"); //tem um timer da toolbox
            label18.Text = DateTime.Now.ToString("dddd");
            label19.Text = DateTime.Now.ToString("dd MMM yy");
        }
    }
}

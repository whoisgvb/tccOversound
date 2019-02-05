using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Oversound_TCC
{
    /// <summary>
    /// Interaction logic for Cadastro.xaml
    /// </summary>
    public partial class Cadastro : Window
    {
        public Cadastro()
        {
            InitializeComponent();
        }
        /*Visible para mostrar ao passar o mouse
         * Collapsed para esconder ao tirar o mouse
         * Height's para aumentar o tamanho e diminuir ao passar e tirar o mouse, criando uma animação
         */
        private void LimparCad_MouseLeave(object sender, MouseEventArgs e)
        {
            RLimparCad.Visibility = Visibility.Collapsed;
        }

        private void LimparCad_MouseMove(object sender, MouseEventArgs e)
        {
            RLimparCad.Visibility = Visibility.Visible;
        }

        private void LimparCad_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {//limpa os campos
            txtNome.Clear();
            txtUsuario.Clear();
            txtSenha.Clear();
            txtEmail.Clear();
            txtNomeBanda.Clear();
        }

        private void lblCadastrar_MouseLeave(object sender, MouseEventArgs e)
        {
            RcadastrarCad.Height = 22;
        }

        private void lblCadastrar_MouseMove(object sender, MouseEventArgs e)
        {
            RcadastrarCad.Height = 32;
        }

        private void btnFecharLoginCad_MouseLeave(object sender, MouseEventArgs e)
        {
            RfecharLoginCad.Visibility = Visibility.Collapsed;
        }

        private void btnFecharLoginCad_MouseMove(object sender, MouseEventArgs e)
        {
            RfecharLoginCad.Visibility = Visibility.Visible;
        }

        private void btnFecharLoginCad_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void txtNomeBanda_MouseLeave(object sender, MouseEventArgs e)
        { //Popula a combo box ao passar o mouse na ultima text
            cboEstado.Items.Add("AC");
            cboEstado.Items.Add("AL");
            cboEstado.Items.Add("AP");
            cboEstado.Items.Add("AM");
            cboEstado.Items.Add("BA");
            cboEstado.Items.Add("CE");
            cboEstado.Items.Add("DF");
            cboEstado.Items.Add("ES");
            cboEstado.Items.Add("GO");
            cboEstado.Items.Add("MA");
            cboEstado.Items.Add("MT");
            cboEstado.Items.Add("MS");
            cboEstado.Items.Add("MG");
            cboEstado.Items.Add("PA");
            cboEstado.Items.Add("PB");
            cboEstado.Items.Add("PR");
            cboEstado.Items.Add("PE");
            cboEstado.Items.Add("PI");
            cboEstado.Items.Add("RJ");
            cboEstado.Items.Add("RN");
            cboEstado.Items.Add("RS");
            cboEstado.Items.Add("RO");
            cboEstado.Items.Add("RR");
            cboEstado.Items.Add("SC");
            cboEstado.Items.Add("SP");
            cboEstado.Items.Add("SE");
            cboEstado.Items.Add("TO");
            

        }

        
    }
}

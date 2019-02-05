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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            
         
        }
        
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
              //Para sair do programa
            if (MessageBox.Show("Deseja Realmente Sair ?", "Mensagem OverSound", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
            }
            
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Evento para mover a Janela
            this.DragMove();
        }
        /*Visible para mostrar ao passar o mouse
         * Collapsed para esconder ao tirar o mouse
         * Height's para aumentar o tamanho e diminuir ao passar e tirar o mouse, criando uma animação
         */
        private void btnFecharLogin_MouseMove(object sender, MouseEventArgs e)
        {
            RfecharLogin.Visibility = Visibility.Visible;
        }

        private void btnFecharLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            RfecharLogin.Visibility = Visibility.Collapsed;
        }

        private void Cadastrar_MouseMove(object sender, MouseEventArgs e)
        {
            Rcadastrar.Height = 32;
            
        }

        private void lblCadastrar_MouseLeave(object sender, MouseEventArgs e)
        {
            Rcadastrar.Height = 22;
            

        }

        private void lblCadastrar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Inicia o Formulário Cadastro
            Cadastro Cad = new Cadastro();

            Cad.ShowDialog();
        }

        private void lblFace_MouseMove(object sender, MouseEventArgs e)
        {
            Rface1.Visibility = Visibility.Visible;
            Rface2.Visibility = Visibility.Visible;
        }

        private void lblFace_MouseLeave(object sender, MouseEventArgs e)
        {
            Rface1.Visibility = Visibility.Collapsed;
            Rface2.Visibility = Visibility.Collapsed;
        }

        private void Limpar_MouseMove(object sender, MouseEventArgs e)
        {
            RLimpar.Visibility = Visibility.Visible;
        }

        private void Limpar_MouseLeave(object sender, MouseEventArgs e)
        {
            RLimpar.Visibility = Visibility.Collapsed;
        }

        private void lblEntrar_MouseLeave(object sender, MouseEventArgs e)
        {
            Rentrar.Height = 22;
        }

        private void lblEntrar_MouseMove(object sender, MouseEventArgs e)
        {
            Rentrar.Height = 32;
        }

        private void Limpar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Limpas os campos
            txtLogin.Clear();
            txtSenha.Clear();

        }

        

        private void lblEntrar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Fecha o Formulário Login e Abre o Software
            MainWindow Oversound = new MainWindow();
           
            

            //se o Login e senha forem igual a ADMIN a pagina de administração do sistema é mostrada
            if (txtLogin.Text == "Admin" && txtSenha.Password == "Admin")
            {
                MessageBox.Show("BEM VINDO MESTRE");
                Administrador adm = new Administrador();
                adm.ShowDialog();
                this.Close();
                
            }
                //caso for um login normal o programa é iniciado e o login fechado
            else
            {
               this.Close();
               Oversound.ShowDialog();
            }
            //exibe a mensagem caso só a txt login for nula
            if (txtLogin.Text == "")
            {
                MessageBox.Show("Preencha o campo Login", "Mensagem OverSound", MessageBoxButton.OK, MessageBoxImage.Information);

            }//exibe a mensagem caso as outras txts(no caso a txtsenha) for nula
            else
            {
                MessageBox.Show("Preencha o campo senha", "Mensagem OverSound", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
            

            
            
            


        }

        private void lblFace_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        { //linha para quando houver o click na label abrir o navegador com a URL do nossa fanpage
            System.Diagnostics.Process.Start("https://www.facebook.com/batatasoft");
        }

        
       
    }
}

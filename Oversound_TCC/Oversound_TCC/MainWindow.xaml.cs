using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;



namespace Oversound_TCC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        
        
       //Inicio de variaveis que vamos precisar
        Random random = new Random();
        private MediaPlayer media = new MediaPlayer();
        ListBoxItem AtualMusica;
        ListBoxItem AnteriorMusica;
        Brush AtualMusicaIndicador;
        Brush CorMusica;
        DispatcherTimer Tempo = new DispatcherTimer();


        public MainWindow()
        {
            this.InitializeComponent();
            //igualando as variaveis a nulo
            AtualMusica = null;
            AnteriorMusica = null;
            AtualMusicaIndicador = Brushes.Blue;
            CorMusica = ListaDeReproducao.Foreground;


            Tempo.Interval = TimeSpan.FromSeconds(1);
            Tempo.Tick += ticktempo;
            Tempo.Start(); // Tempo para disparar a cada segundo

           
            //começando o programa com volume maximo
            SliderVolume.Value = 100;


            imgPlay.Visibility = Visibility.Collapsed;
        }

        private void ticktempo(object sender, EventArgs e)
        {
            
            if (OSmusicPlayer.Source != null) 
            {   //Para mostrar a posição do slider
                SlrMusica.Value = OSmusicPlayer.Position.TotalSeconds;
                TamanhoMusica();

            }
        }

        private void ListBox_DragEnter(object sender, DragEventArgs e)
        {
            //Este evento copia as músicas jogadas para a listbox
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Para mover a Janela
            this.DragMove();
        }

        private void BtnVolume_Click(object sender, RoutedEventArgs e)
        {
            //Ao clicar no botão volume o SlrVolume é mutado
            SliderVolume.Value = 0;


        }
        public void ListadeReproducao_Drop(object sender, DragEventArgs e)
        {
            //Matriz Para tocar as musicas

            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (string fileName in s)
            {
                if (System.IO.Path.GetExtension(fileName) == ".mp3" ||
                    System.IO.Path.GetExtension(fileName) == ".MP3")
                {
                    ListBoxItem lstItem = new ListBoxItem();
                    lstItem.Content = System.IO.Path.GetFileNameWithoutExtension(fileName);
                    lstItem.Tag = fileName;
                    ListaDeReproducao.Items.Add(lstItem);
                }//se o formato da música for diferente de mp3 ou MP3 exibe o aviso
                if (System.IO.Path.GetExtension(fileName) != ".mp3" &&
                  System.IO.Path.GetExtension(fileName) != ".MP3")
                 {
                    MessageBox.Show("Insira Somente Músicas","ERRO",MessageBoxButton.OK,MessageBoxImage.Information);
   
                 }


            }
            
            if (AtualMusica == null)//A Listbox começa em -1, caso seja 0(primeira música) ela será tocada
            {
                ListaDeReproducao.SelectedIndex = 0;
                PlayTrack();
            }
            //Balão é a mensagem de inicio "Para Escutar Músicas arraste-as  para o programa"
            Balao.Visibility = Visibility.Collapsed;
            txtBalao.Visibility = Visibility.Collapsed;

        }
       

        private void OSmusicPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {//Quando a música é começada (Media Open) 
            if (OSmusicPlayer.NaturalDuration.HasTimeSpan)
            {
                TimeSpan ts = OSmusicPlayer.NaturalDuration.TimeSpan;
                SlrMusica.Maximum = ts.TotalSeconds;
                SlrMusica.SmallChange = 1;
                PrgMusica.Maximum = ts.TotalSeconds;
                PrgMusica.SmallChange = 1;
            }
            //Inicia o Slider
            Tempo.Start();
        }
        private void OSmusicPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {   //Zerar o slider
            SlrMusica.Value = 0;
           
          
            //se o modo repetir estiver ativo, quando o slider for == a 0 o play se dará novamente, caso contrário proxima musica será ativada
           if (imgRepetirAtivado.Visibility == Visibility.Visible)
           {
               ModoRepetir();
           }
           else
           {
               ProximaMusica();
           }
           if (imgAleatorioAtivado.Visibility == Visibility.Visible)
           {
               ModoAleatorio();
           }
           else
           {
               ProximaMusica();
           }
           
           
        }
        private void ProximaMusica()
        {
            /*se a lista for menor que -1 o listbox acrescentará mais um, se for identico a -1 o programa retorna 0,[
            assim pulando música e quando chegar ao final da lista ele retornar para a primeira*/
            if (ListaDeReproducao.Items.IndexOf(AtualMusica) < ListaDeReproducao.Items.Count - 1)
            {
                ListaDeReproducao.SelectedIndex = ListaDeReproducao.Items.IndexOf(AtualMusica) + 1;
                PlayTrack();
                return;
            }
            else if (ListaDeReproducao.Items.IndexOf(AtualMusica) == ListaDeReproducao.Items.Count - 1)
            {
                ListaDeReproducao.SelectedIndex = 0;
                PlayTrack();
                return;
            }

        }
        
        private void VoltaMusica()
        { /*aqui acontece o contrário do método acima, quando a listbox for maior q 0 ele ira retroceder um,
           quando for igual a zero também*/
            if (ListaDeReproducao.Items.IndexOf(AtualMusica) > 0)
            {
                ListaDeReproducao.SelectedIndex = ListaDeReproducao.Items.IndexOf(AtualMusica) - 1;
                PlayTrack();
            }
            else if (ListaDeReproducao.Items.IndexOf(AtualMusica) == 0)
            {
                ListaDeReproducao.SelectedIndex = ListaDeReproducao.Items.Count - 1;
                PlayTrack();
            }

        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            /*Se conter itens na listbox ele dará o play, monstrando a imagem pause e ocultando a imagem play, o Retangulo Principal
            serve para mostrar se o mouse está em cima do botão ou não*/
            if (ListaDeReproducao.HasItems)
            {
                PlayTrack();
                imgPause.Visibility = Visibility.Visible;
                imgPlay.Visibility = Visibility.Collapsed;
                RPrincipal.Opacity = 100;
            }

        }

        private void PlayTrack()
        {
            //se for diferente da música atual e a mesma for diferente de nula é selecionada 
            if (ListaDeReproducao.SelectedItem != AtualMusica)
            {
                if (AtualMusica != null)
                {
                    AnteriorMusica = AtualMusica;
                    AnteriorMusica.Foreground = CorMusica;
                }
                //a musica atual é igual ao item selecionado na listbox; aqui convertemos a mesma para string, para o programa reconhecer
                AtualMusica = (ListBoxItem)ListaDeReproducao.SelectedItem;
                AtualMusica.Foreground = AtualMusicaIndicador;
                OSmusicPlayer.Source = new Uri(AtualMusica.Tag.ToString());
                SlrMusica.Value = 0;
                OSmusicPlayer.Play();
                //Mostrando a progress bar
                PrgMusica.Visibility = Visibility.Visible;
            }
            else
            { // caso contrário, o programa só da play na música
                OSmusicPlayer.Play();
            }

        }


        private void BtnPause_Click(object sender, RoutedEventArgs e)
        { // se a lista tiver itens, o pause será ativado
            if (ListaDeReproducao.HasItems)
            {
                OSmusicPlayer.Pause();
                imgPlay.Visibility = Visibility.Visible;
                imgPause.Visibility = Visibility.Collapsed;
                RPrincipal.Opacity = 100;
                
            }
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        { // se a lista tiver itens voltará uma música
            if (ListaDeReproducao.HasItems)
            {
                VoltaMusica();
                ListaDeReproducao.Focus();
            }
        }
        private void BtnAvancar_Click(object sender, MouseButtonEventArgs e)
        { // se a lista tiver itens o método ProximaMusica() se torna verdadeiro e avança, Focus para a list estar selecionada
            if (ListaDeReproducao.HasItems)
            {
                ProximaMusica();
                ListaDeReproducao.Focus();
            }
        }

        private void SlrMusica_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {//dragcompleted é o evento para quando a musíca acaba, o TimeSpan se encarrega de mostrar a posição, dizendo se acabou ou não
            
            OSmusicPlayer.Position = TimeSpan.FromSeconds(SlrMusica.Value);
           
        }

        private void SlrMusica_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        { // Este evento acontece quando o botão esquerdo do mouse é liberado enquanto o ponteiro do mouse está sobre esse elemento.
            OSmusicPlayer.Position = TimeSpan.FromSeconds(SlrMusica.Value);
        }

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        { // fecha o programa e retorna a lbltempo ao original para não bugar
            this.Close();
            lblTempo.Text = "00:00                                                                                         00:00";
        }
        private void btnMinimizar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        { // Minimizar a janela
            this.WindowState = WindowState.Minimized;
        }
       
        private void ListaDeReproducao_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {//se o usuário preferir dar o double click, ele também conseguirá escutar músicas
            PlayTrack();
            ListaDeReproducao.Focus();
        }

        /*As opacidades com valor de 100 no evento MouseMove foram usadas para mostrar os retangulos
         * e as opacidades igual a 0 no evento MouseLeave foram usadas para esconde-los;
         * ou seja, quando eu passar o mouse ele mostrará e quando eu tirar o mouse de cima ele se esconderá
         */
        private void btnFechar_MouseMove(object sender, MouseEventArgs e)
        {
            Rfechar.Opacity = 100;
        }

        private void btnFechar_MouseLeave(object sender, MouseEventArgs e)
        {
            Rfechar.Opacity = 0;
        }

        private void btnMinimizar_MouseLeave(object sender, MouseEventArgs e)
        {
            Rminizar.Opacity = 0;
        }

        private void btnMinimizar_MouseMove(object sender, MouseEventArgs e)
        {
            Rminizar.Opacity = 100;
        }

        private void SliderVolume_MouseMove(object sender, MouseEventArgs e)
        {
            Rvolume.Opacity = 100;

        }

        private void SliderVolume_MouseLeave(object sender, MouseEventArgs e)
        {
            Rvolume.Opacity = 0;

        }

        private void imgPlay_MouseMove(object sender, MouseEventArgs e)
        {

            RPrincipal.Opacity = 100;
        }

        private void BtnRepetir_MouseMove(object sender, MouseEventArgs e)
        {
            Rrepetir.Opacity = 100;
        }

        private void BtnRepetir_MouseLeave(object sender, MouseEventArgs e)
        {
            Rrepetir.Opacity = 0;
        }

        private void imgRepetir_MouseMove(object sender, MouseEventArgs e)
        {
            Rrepetir.Opacity = 100;
        }

        private void imgRepetir_MouseLeave(object sender, MouseEventArgs e)
        {
            Rrepetir.Opacity = 0;
        }

        private void imgAleatorio_MouseMove(object sender, MouseEventArgs e)
        {
            Raleatorio.Opacity = 100;
        }

        private void imgAleatorio_MouseLeave(object sender, MouseEventArgs e)
        {
            Raleatorio.Opacity = 0;
        }
        private void ListaDeReproducao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SlrMusica_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {

        }

       
        private void imgAvancar_MouseLeave(object sender, MouseEventArgs e)
        {
            Ravancar.Opacity = 0;
        }

        private void imgAvancar_MouseMove(object sender, MouseEventArgs e)
        {
            Ravancar.Opacity = 100;
        }

        private void imgRecuar_MouseLeave(object sender, MouseEventArgs e)
        {
            Rvoltar.Opacity = 0;
        }

        private void imgRecuar_MouseMove(object sender, MouseEventArgs e)
        {
            Rvoltar.Opacity = 100;
        }

        private void imgPlay_MouseLeave(object sender, MouseEventArgs e)
        {
            RPrincipal.Opacity = 0;
        }

        private void imgPause_MouseLeave(object sender, MouseEventArgs e)
        {
            RPrincipal.Opacity = 0;
        }

        private void imgPause_MouseMove(object sender, MouseEventArgs e)
        {
            RPrincipal.Opacity = 100;

        }
        private void imgAvancar_Repetir_MouseLeave(object sender, MouseEventArgs e)
        {
            Ravancar.Opacity = 0;
        }

        private void imgAvancar_Repetir_MouseMove(object sender, MouseEventArgs e)
        {
            Ravancar.Opacity = 100;
        }
        private void btnFechar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        { // fecha o programa
            this.Close();
        }

        private void imgVolume_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //se o usuário clicar na imagem volume o slider volume é mutado;
            SliderVolume.Value = 0;
            Rvolume.Opacity = 100;

        }

        
       

        private void imgAleatorio_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // se o modo aleatório for ativado, as imagens que não participarão do evento serão escondidas e as q participarão serão visiveis
            imgAleatorio.Visibility = Visibility.Collapsed;
            imgAleatorioAtivado.Visibility = Visibility.Visible;
            imgAvancar.Visibility = Visibility.Collapsed;
            
            imgAvancar_aleatório.Visibility = Visibility.Visible;

            if (imgRepetirAtivado.Visibility == Visibility.Visible)
            {
                imgRepetirAtivado.Visibility = Visibility.Collapsed;
                imgRepetir.Visibility = Visibility.Visible;
                
                imgAvancar.Visibility = Visibility.Visible;

            }

            
        }

        private void imgAleatorioAtivado_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        { // se o modo aleatório for desativado, as imagens que não participarão do evento serão escondidas e as q participarão serão visiveis
            imgAleatorio.Visibility = Visibility.Visible;
            imgAleatorioAtivado.Visibility = Visibility.Collapsed;
            imgAvancar.Visibility = Visibility.Visible;
            imgAvancar_aleatório.Visibility = Visibility.Collapsed;
          

           


        }

        

        private void imgRepetir_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        { // se o modo repetir for ativado, as imagens que não participarão do evento serão escondidas e as q participarão serão visiveis
            imgRepetir.Visibility = Visibility.Collapsed;
            imgRepetirAtivado.Visibility = Visibility.Visible;
          
            imgAvancar_aleatório.Visibility = Visibility.Collapsed;
            

            if (imgAleatorioAtivado.Visibility == Visibility.Visible)
            {
                imgAleatorioAtivado.Visibility = Visibility.Collapsed;
                imgAleatorio.Visibility = Visibility.Visible;
                imgAvancar_aleatório.Visibility = Visibility.Collapsed;
                imgAvancar.Visibility = Visibility.Visible;

            }
          

        }

        private void imgRepetirAtivado_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        { // se o modo aleatório for desativado, as imagens que não participarão do evento serão escondidas e as q participarão serão visiveis
            imgRepetir.Visibility = Visibility.Visible;
            imgRepetirAtivado.Visibility = Visibility.Collapsed;
          
            imgAvancar_aleatório.Visibility = Visibility.Collapsed;
            imgAvancar.Visibility = Visibility.Visible;

            
            
            
        }

        private void Balao_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {//se o usuário clicar no balão, ele desaparecerá
            Balao.Visibility = Visibility.Collapsed;
            txtBalao.Visibility = Visibility.Collapsed;
        }

        private void txtBalao_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {//se o usuário clicar no balão, ele desaparecerá
            Balao.Visibility = Visibility.Collapsed;
            txtBalao.Visibility = Visibility.Collapsed;
        }
        private void ModoAleatorio()
        {
           /*aqui o programa sorteia um numero, de acordo com o tamanho da lista
            * assim focando a mesma e dando play
            */
            ListaDeReproducao.SelectedIndex = random.Next(0, ListaDeReproducao.Items.Count);
            ListaDeReproducao.Focus();
            PlayTrack();
            

        }

     

        private void imgAvancar_aleatório_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {//chama o evento aleatório
            ModoAleatorio();
          

                
            
            
        }
        private void TamanhoMusica()
        { //retorna o tamanho da música
            lblTempo.Visibility = Visibility.Visible;
            if (ListaDeReproducao.HasItems)
            {
                lblTempo.Text =
                    String.Format(
                    "{0}                                                                                         {1}",
                    OSmusicPlayer.Position.ToString(@"mm\:ss"),
                    OSmusicPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));

            }
            else
            {
                lblTempo.Text = "00:00                                                                                         00:00";

            }

        }
      
        private void btnLimpa_Click(object sender, RoutedEventArgs e)
        { //limpa a listbox, retorna aos valores originais e para a música
            ListaDeReproducao.Items.Clear();
            imgPlay.Visibility = Visibility.Collapsed;
            imgPause.Visibility = Visibility.Visible;
            OSmusicPlayer.Stop();

        }

        private void ModoRepetir()
        {//quando a posição do slider for 0, o programa dará play, assim criando um laço infinito
            OSmusicPlayer.Position = TimeSpan.FromSeconds(0);
            PlayTrack();
        }

       

      

        

        
    }
}




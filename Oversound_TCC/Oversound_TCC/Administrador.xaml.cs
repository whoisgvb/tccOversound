using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Administrador.xaml
    /// </summary>
    public partial class Administrador : Window
    {
        ObservableCollection<clsOperadores> lista = new ObservableCollection<clsOperadores>();

        private void Carregar()
        {
            lista.Add(new clsOperadores {Nome = "Gustavo",Nome_Usuario = "Gvb097", Senha="1234", Nome_Banda="The GVBS" });
            lista.Add(new clsOperadores { Nome = "Ale", Nome_Usuario = "Ale024", Senha = "12345", Nome_Banda = "Dhe Alexis" });
            lista.Add(new clsOperadores { Nome = "Ale", Nome_Usuario = "Ale024", Senha = "12345", Nome_Banda = "Alexis" });
        }
        public Administrador()
        {
            InitializeComponent();
            Carregar();
            ListDados.ItemsSource = lista;

        }

        private void txtBusca_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*var query = from it in lista
                        where it.Nome_Banda.Contains(txtBusca.Text)
                        select it;*/
            var query2 = lista.Where(it => (it.Nome_Banda?? "").ToUpper().Contains(txtBusca.Text.ToUpper()));

            

            if(grpNomeBanda.IsChecked.Value)
            {
                query2 = query2.OrderBy(it => it.Nome_Banda);
            }
            else if (grpNomeBanda.IsChecked.Value)
            {
                query2 = query2.OrderBy(it => it.Nome);
            }

            txtTot.Text = query2.Count().ToString();

            var Resultado = query2.ToList();

            ListDados.ItemsSource = Resultado;
            
           /* foreach (var item in Resultado)
            {
                lista.Add(item);
            }*/
        }
    }
}

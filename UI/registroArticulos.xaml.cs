using AnaMPrimerParcial.BLL;
using AnaMPrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnaMPrimerParcial.UI
{
    /// <summary>
    /// Interaction logic for registroArticulos.xaml
    /// </summary>
    public partial class registroArticulos : Window
    {
        Articulos articulo = new Articulos();
        public registroArticulos()
        {
            InitializeComponent();
            this.DataContext = articulo;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            articulo = new Articulos();
            this.DataContext = articulo;

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = ArticulosBLL.Buscar(int.Parse(ArticuloIDTextBox.Text));

            if (encontrado != null)
            {
                this.articulo = encontrado;

                this.DataContext = encontrado;
            }

            else
                this.articulo = new Articulos();


        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            ValorTextBox.Text = (Convert.ToInt32(ExistenciasTextBox.Text) * Convert.ToDecimal(CostoTextBox.Text)).ToString();
            var paso = ArticulosBLL.Guardar(articulo);

            if (paso)
            {
                
                MessageBox.Show("Transaccione exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArticulosBLL.Eliminar(Convert.ToInt32(ArticuloIDTextBox.Text)))
            {
                
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void ExistenciasTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int num = 0;
            if (ExistenciasTextBox.Text != String.Empty && CostoTextBox.Text!=String.Empty)
            ValorTextBox.Text = (Convert.ToInt32(ExistenciasTextBox.Text) * Convert.ToDecimal(CostoTextBox.Text)).ToString();
        }

        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ExistenciasTextBox.Text != String.Empty && CostoTextBox.Text != String.Empty)
                ValorTextBox.Text = (Convert.ToInt32(ExistenciasTextBox.Text) * Convert.ToDecimal(CostoTextBox.Text)).ToString();
        }
    }
}






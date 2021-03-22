using BancoSimple.Agencias.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BancoSimple.Agencias
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       private readonly ListBox lstAgencias;

        public MainWindow()
        {
            InitializeComponent();

            lstAgencias = new ListBox();

            AtualizarControles();
            AtualizarListaDeAgencias();
        }

        private void AtualizarControles()
        {
            lstAgencias.Width = 270;
            lstAgencias.Height = 290;

            Canvas.SetTop(lstAgencias, 15);
            Canvas.SetLeft(lstAgencias, 15);

            /*  
                += Adiciona um comportamento quando um evento acontece
                Esta atribuindo ao evento SelectionChanged, da lista, um delegate, que chama o evento.
            */

            lstAgencias.SelectionChanged += new SelectionChangedEventHandler(lstAgencias_SelectionChanged);

            container.Children.Add(lstAgencias);

            btnEditar.Click += new RoutedEventHandler(btnEditar_Click);
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            var agenciaAtual = (Agencia)lstAgencias.SelectedItem;
            var janelaEdicao = new EdicaoAgencia(agenciaAtual);

            /*
                    Enquanto a janela não é fechada, nao se pode manipular
                a outra que abriu ela
            */
            var resultado = janelaEdicao.ShowDialog().Value;

            if (resultado)
            {
                // Usuario clicou em Ok
            }
            else
            {
                // Usuario clicou em Cancelar
            }

        }

        private void AtualizarListaDeAgencias()
        {
            lstAgencias.Items.Clear();
            var agencias = BuscarListaAgencias();
            foreach (var agencia in agencias)
                lstAgencias.Items.Add(agencia);
        }

        private List<Agencia> BuscarListaAgencias()
        {
            return new List<Agencia>()
            {
                new Agencia("123", "Agencia São Paulo", "Agencia São Paulo", "Av. Paulista, nº 1550", "(11) 2590-8097"),
                new Agencia("123", "Agencia Rio de Janeiro", "Agencia Rio de Janeiro", "Rua Leblon , nº 500", "(12) 2894-9547"),
            };
        }

        private void lstAgencias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var agenciaSelecionada = (Agencia) lstAgencias.SelectedItem;

            txtNumero.Text = agenciaSelecionada.Numero;
            txtNome.Text = agenciaSelecionada.Nome;
            txtTelefone.Text = agenciaSelecionada.Telefone;
            txtEndereco.Text = agenciaSelecionada.Endereco;
            txtDescricao.Text = agenciaSelecionada.Descricao;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var confirmacao = 
                MessageBox.Show(
                    "Você deseja realmente excluir este item?",
                    "Confirmação",
                    MessageBoxButton.YesNo);
            if (confirmacao == MessageBoxResult.Yes)
            {
                //Excluir
            }
            else
            {
                //Não faz nada
            }
        }
    }
}

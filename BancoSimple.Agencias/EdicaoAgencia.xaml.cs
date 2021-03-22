using BancoSimple.Agencias.DAL;
using System;
using System.Linq;
using System.Windows;

namespace BancoSimple.Agencias
{
    /// <summary>
    /// Interaction logic for EdicaoAgencia.xaml
    /// </summary>
    public partial class EdicaoAgencia : Window
    {
        private readonly Agencia _agencia;

        public EdicaoAgencia(Agencia agencia)
        {
            InitializeComponent();

            /*
                Verificando se o parametro esta nullo com ??, se ele estiver é lançada a exceção ArgumentNullException
            */
            _agencia = agencia ?? throw new ArgumentNullException(nameof(agencia));


            AtualizarCamposDeTexto();
            AtualizarControles();

            /*
             
                    Se eu quisesse chamar o método: ValidarCampoNulo(txtNumero, EventArgs.Empty); 
                Usarioa o Empty para indicar que nao existem argumentos adicionais no evento
            
             */
        }

        private void AtualizarCamposDeTexto()
        {
            txtNumero.Text = _agencia.Numero;
            txtNome.Text = _agencia.Nome;
            txtTelefone.Text = _agencia.Telefone;
            txtEndereco.Text = _agencia.Endereco;
            txtDescricao.Text = _agencia.Descricao;
        }

        /*
            
                A sintaxe de criação de Delegates fortemente tipados 
            é a mesma para qualquer outro objeto, usamos o operador 
            new! Mas, o argumento do construtor do delegate 
            fortemente tipado é uma referência para um método que 
            respeita sua assinatura. 
            
        */
        private void AtualizarControles()
        {
            RoutedEventHandler dialogResultTrue = (o, e) => DialogResult = true;
            RoutedEventHandler dialogResultFalse = (o, e) => DialogResult = false;

            //Manipulcao de Delegates
            //1ª Forma
            var okEventHandler = dialogResultTrue + Fechar;

            //Essa variavel é do tipo RoutedEventHandler que é Delegate
            var cancelarEventHandler = dialogResultFalse + Fechar;

            //2ª Forma, mais longa
            //Delegate Combine concatena dois delegates Dlegate.Combine(delegate a, delegate b)

            /* var cancelarEventHandlerSegundaForma = (RoutedEventHandler)Delegate.Combine(
                (RoutedEventHandler)btnCancelar_Click, -- segunda forma, mas como esse metodo btnCancelar_Click, decidi comentar
                (RoutedEventHandler)Fechar);
            */

            btnOk.Click += okEventHandler;
            btnCancelar.Click += cancelarEventHandler;

            //Esse .Validacao é o evento por nós criado
            txtNumero.Validacao += ValidarCampoNulo;
            txtNumero.Validacao += ValidarSomenteDigito;

            txtNome.Validacao += ValidarCampoNulo;
            txtDescricao.Validacao += ValidarCampoNulo;
            txtEndereco.Validacao += ValidarCampoNulo;
            txtTelefone.Validacao += ValidarCampoNulo;
        }
        
        private void ValidarSomenteDigito(object sender, ValidacaoEventArgs e)
        {
            /*
                Func -- recebe char/passa char e retorna bool 
                
                    //Func<char, bool> verificaSeEhDigito = caractere =>
                    //{
                    //    return Char.IsDigit(caractere);
                    };
            */


            var ehValido = e.Texto.All(Char.IsDigit);
            e.EhValido = ehValido;
        }

        private void ValidarCampoNulo(object sender, ValidacaoEventArgs e)
        {
            var ehValido = !String.IsNullOrEmpty(e.Texto);
            e.EhValido = ehValido;
        }

        //Quando o método só tem uma linha eu posso simplesmente utilizar o operador de lambda, sem abrir um bloco inteiro
        private void Fechar(object sender, EventArgs e) =>
            Close();
    }
}
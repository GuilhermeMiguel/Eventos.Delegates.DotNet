using System.Windows.Controls;
using System.Windows.Media;

namespace BancoSimple.Agencias
{
    /*
            Criação de um delegate
          Por padrão no dot net, um delegate:
            Não tem retorno -- void
            Recebe como primeiro parametro um object sender
            Recebe como segundo parametro um derivado de EventArgs, ou ele prórpio

    */
    public delegate void ValidacaoEventHandler(object sender, ValidacaoEventArgs e);

    public class ValidacaoTextBox : TextBox
    {
        private ValidacaoEventHandler _validacao;

        /*
        
            Criação de um event:
            Utiliza-se a palavra reservada event e coloca-se como tipo o delegate

            Um evento tem os metodos add e remove, como uma especie de get e set
        */

        public event ValidacaoEventHandler Validacao
        {
            add
            {
                //Adicionando uma ação
                _validacao += value;
                OnValidacao();
            }
            remove
            {
                //Removendo uma ação
                _validacao -= value;
            }
        }

        //Dispara quando o valor dos input texts é alterado
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            OnValidacao();
        }

        /*
            Realiza a validação
        */
        protected virtual void OnValidacao()
        {
            if (_validacao != null)
            {
                var listaValidacao = _validacao.GetInvocationList();
                var eventArgs = new ValidacaoEventArgs(Text);
                var ehValido = true;

                foreach (ValidacaoEventHandler validacao in listaValidacao)
                {
                    //Passando o object sender e o EventArgs, que no caso é o texto do input text
                    validacao(this, eventArgs);

                    if (!eventArgs.EhValido)
                    {
                        ehValido = false;
                        break;
                    }
                }

                Background = ehValido
                    ? new SolidColorBrush(Colors.White)
                    : new SolidColorBrush(Colors.OrangeRed);
            }
        }
    }
}

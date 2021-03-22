namespace BancoSimple.Agencias.DAL
{


    /*
    
         Em classes comuns tudo deve ser definido nelas, atributos, metodos, ou seja, tudo mesmo, deve ser codado naquele arquivo.

        Em classes partials (parciais)
            Pode-se codar em mais de um arquivo, por exemplo atributos numa classe e metodos em outra.
          O arquivo pode até ter nomes diferentes, porém a classe interna precisa ter o mesmo nome 
         




                Ao inserirmos o partial na definição de classe, poderemos ter o arquivo ClasseExemplo.cs, e outro como ClasseExempoMetodos.cs .
           Na segunda classe podemos escrever todos os seus métodos específicos. 
                Quando o Visual Studio compilar nosso código, todos os arquivos que possuem a definição parcial serão lidos e unificados, como um arquivo só. 
          Esse recurso torna a leitura e criação de código muito mais fácil.




                Isso acontece muito com o Entity Framework, a criação de classes parciais.
            Então se o Entity cria uma classe (partial) e precisamos aplicar alterações nela,
          podemos fazer uma classe com o mesmo nome, com o partial tambem e nela faço as alterações que desejo, 
          pois nao é seguro codar na classe gerada pelo Entity, pois se ele precisa fazer alguma alteração naquela classe ele apaga tudo o que fizemos.
         
    */
    public partial class Agencia
    {
        //Sobrescrita do metodo To string, com retorno em uma só linha
        public override string ToString() =>
            $"{Numero} - {Nome}".Trim();
    }
}

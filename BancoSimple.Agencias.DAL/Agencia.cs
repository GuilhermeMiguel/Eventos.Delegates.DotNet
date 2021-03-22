namespace BancoSimple.Agencias.DAL
{
    public partial class Agencia
    {
        public string Numero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public Agencia(string numero, string nome, string descricao, string endereco, string telefone)
        {
            Numero = numero;
            Nome = nome;
            Descricao = descricao;
            Endereco = endereco;
            Telefone = telefone;
        }
    }
}

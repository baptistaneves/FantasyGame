namespace FantasyGame.Domain.Entities
{
    public class Equipe : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataCadastro { get; private set; }

        private Equipe() {}


        /// <summary>
        /// Criar uma nova Equipe
        /// </summary>
        /// <param name="nome"> Nome da Equipe</param>
        /// <param name="descricao"> Alguma Descrição sobre a Equipe</param>
        /// <returns see cref="Equipe"></returns>
        /// Factory
        public static Equipe NovaEquipe(string nome, string descricao)
        {
            return new Equipe
            {
                Nome = nome,
                Descricao = descricao,
                DataCadastro = DateTime.UtcNow,
            };
        }

        /// <summary>
        /// Atualizar os dados da Equipe
        /// </summary>
        /// <param name="nome"> Nome da Equipe</param>
        /// <param name="descricao"> Alguma Descrição sobre a Equipe</param>
        public void AtualizarEquipe(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}

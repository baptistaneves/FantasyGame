namespace FantasyGame.Application.Campeonatos.Models
{
    public class Campeonato
    {
        public List<Partida> Partidas { get; set; } = new List<Partida>();
        public string Campeao { get; set; }
        public string Vice { get; set; }
        public string Terceiro { get; set; }
    }
}

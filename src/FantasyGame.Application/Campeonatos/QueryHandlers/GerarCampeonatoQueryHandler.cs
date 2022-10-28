using FantasyGame.Application.Campeonatos.Commands;
using FantasyGame.Application.Campeonatos.Models;
using FantasyGame.Domain.Interfaces.Notifications;
using FantasyGame.Domain.Interfaces.Repository;
using FantasyGame.Domain.Notifications;
using MediatR;

namespace FantasyGame.Application.Campeonatos.CommandHandlers
{
    public class GerarCampeonatoQueryHandler : IRequestHandler<GerarCampeonatoQuery, Campeonato>
    {
        private readonly IEquipeRepository _equipeRepository;
        private readonly INotificador _notificador;
        private readonly Campeonato _campeonato;
        private List<Pontuacao> _pontuacoes;
        public GerarCampeonatoQueryHandler(IEquipeRepository equipeRepository, INotificador notificador)
        {
            _equipeRepository = equipeRepository;
            _campeonato = new Campeonato();
            _pontuacoes = new List<Pontuacao>();
            _notificador = notificador;
        }

        public async Task<Campeonato> Handle(GerarCampeonatoQuery command, CancellationToken cancellationToken)
        {
            var random = new Random();
            var equipes = await _equipeRepository.ObterEquipesAleatorias();

            if(equipes.Count < 4)
            {
                _notificador.publicarNotificacao(new Notificacao("Devem cadastradas pelo menos 4 equipes"));
                return null;
            }

            for (var i = 0; i < equipes.Count; i++)
            {
                for (var j = 0; j < equipes.Count; j++)
                {
                    if (equipes[i] != equipes[j])
                    {
                        if (!_campeonato.Partidas.Any(p=> p.Equipes.Contains(equipes[i].Nome) && p.Equipes.Contains(equipes[j].Nome))) 
                        {
                            var pontuacaoParaPrimeiraEquipe = random.Next(0, 5);
                            var pontuacaoParaSegundaEquipe = random.Next(6, 10);

                            _campeonato.Partidas.Add(new Partida
                            {
                                Equipes = equipes[i].Nome + " x " + equipes[j].Nome,
                                Resultado = pontuacaoParaPrimeiraEquipe + " x " + pontuacaoParaSegundaEquipe
                            });

                            if(pontuacaoParaPrimeiraEquipe > pontuacaoParaSegundaEquipe)
                            {
                                AtribuirPontosAoVencedor(equipes[i].Nome);
                                AtribuirPontosAoPerdedor(equipes[j].Nome);
                            }
                            else if(pontuacaoParaPrimeiraEquipe == pontuacaoParaSegundaEquipe)
                            {
                                AtribuirPontosAosEmpatados(equipes[i].Nome, equipes[j].Nome);
                            }
                            else
                            {
                                AtribuirPontosAoVencedor(equipes[j].Nome);
                                AtribuirPontosAoPerdedor(equipes[i].Nome);
                            }
                        }
                    }
                }
            }

            OrdenarTabelaClassificativa();

            return _campeonato;
        }

        private void AtribuirPontosAoVencedor(string equipe)
        {
            if (_pontuacoes.Any(p => p.Equipe == equipe))
            {
                var selecionaEquipe = _pontuacoes.FirstOrDefault(p => p.Equipe == equipe);
                selecionaEquipe.Pontos += 3;
            }
            else
            {
                _pontuacoes.Add(new Pontuacao { Equipe = equipe, Pontos = 3 });
            }
        }

        private void AtribuirPontosAosEmpatados(string equipe1, string equipe2)
        {
            if (_pontuacoes.Any(p => p.Equipe == equipe1))
            {
                var selecionaEquipe = _pontuacoes.FirstOrDefault(p => p.Equipe == equipe1);
                selecionaEquipe.Pontos += 1;
            }
            else if (_pontuacoes.Any(p => p.Equipe == equipe2))
            {
                var selecionaEquipe = _pontuacoes.FirstOrDefault(p => p.Equipe == equipe2);
                selecionaEquipe.Pontos += 1;
            }
            else
            {
                _pontuacoes.Add(new Pontuacao { Equipe = equipe1, Pontos = 1 });
                _pontuacoes.Add(new Pontuacao { Equipe = equipe2, Pontos = 1 });
            }
        }

        private void AtribuirPontosAoPerdedor(string equipe)
        {
            if (_pontuacoes.Any(p => p.Equipe == equipe))
            {
                var selecionaEquipe = _pontuacoes.FirstOrDefault(p => p.Equipe == equipe);
                selecionaEquipe.Pontos += 0;
            }
            else
            {
                _pontuacoes.Add(new Pontuacao { Equipe = equipe, Pontos = 0 });
            }
        }

        private void OrdenarTabelaClassificativa()
        {
            int primeiro = 0, segundo = 0, terceiro = 0;

            for (var i = 0; i < _pontuacoes.Count; i++)
            {
                if (_pontuacoes[i].Pontos > primeiro)
                {
                    terceiro = segundo;
                    segundo = primeiro;
                    primeiro = _pontuacoes[i].Pontos;
                }
                else if (_pontuacoes[i].Pontos > segundo && _pontuacoes[i].Pontos != primeiro)
                {
                    terceiro = segundo;
                    segundo = _pontuacoes[i].Pontos;
                }
                else if (_pontuacoes[i].Pontos > terceiro && _pontuacoes[i].Pontos != segundo)
                    terceiro = _pontuacoes[i].Pontos;
            }


            for (int i = 0; i < _pontuacoes.Count; i++)
            {
                if(primeiro == _pontuacoes[i].Pontos)
                {
                    _campeonato.Campeao = _pontuacoes[i].Equipe;
                }

                if (segundo == _pontuacoes[i].Pontos)
                {
                    _campeonato.Vice = _pontuacoes[i].Equipe;
                }

                if (terceiro == _pontuacoes[i].Pontos)
                {
                    _campeonato.Terceiro = _pontuacoes[i].Equipe;
                }
            }
        }
    }
}

using PeneiraAraxa.Models;

namespace PeneiraAraxa.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        private static List<Jogador> _jogadores = new List<Jogador>();

        public void Adicionar(Jogador jogador)
        {
            _jogadores.Add(jogador);
        }

        public List<Jogador> ListarTodos()
        {
            return _jogadores;
        }

        public Jogador BuscarPorCpf(string cpf)
        {
            return _jogadores.FirstOrDefault(j => j.Cpf == cpf);
        }

        public List<Jogador> ListarAprovados()
        {
            return _jogadores.Where(j => j.Aprovado == true).ToList();
        }
    }
}

using PeneiraAraxa.Models;

namespace PeneiraAraxa.Repositories
{
    public interface IJogadorRepository
    {
        void Adicionar(Jogador jogador);
        List<Jogador> ListarTodos();
        Jogador BuscarPorCpf(string cpf);
        List<Jogador> ListarAprovados();
    }
}

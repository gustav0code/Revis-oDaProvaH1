using Microsoft.AspNetCore.Mvc;
using PeneiraAraxa.Models;
using PeneiraAraxa.Repositories;

namespace PeneiraAraxa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogadorController : ControllerBase
    {
        private readonly IJogadorRepository _repository;

        public JogadorController(IJogadorRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(Jogador jogador)
        {
            if (_repository.BuscarPorCpf(jogador.Cpf) != null)
            {
                return BadRequest("Já existe um jogador cadastrado com esse CPF.");
            }

            jogador.Posicao = jogador.Posicao.ToUpper();
            jogador.Aprovado = null;
            _repository.Adicionar(jogador);
            return Ok(jogador);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_repository.ListarTodos());
        }

        [HttpPost("resultado")]
        public IActionResult RegistrarResultado(Resultado resultado)
        {
            var jogador = _repository.BuscarPorCpf(resultado.Cpf);

            if (jogador == null)
            {
                return NotFound("Jogador não encontrado, por isso o resultado não pode ser registrado.");
            }

            if (jogador.Aprovado != null)
            {
                return BadRequest("O resultado desse jogador já foi registrado.");
            }

            jogador.Aprovado = resultado.Aprovado;
            return Ok(jogador);
        }

        [HttpGet("aprovados")]
        public IActionResult ListarAprovados()
        {
            return Ok(_repository.ListarAprovados());
        }
    }
}

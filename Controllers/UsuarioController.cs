using Microsoft.AspNetCore.Mvc;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _repository.BuscaUsuarios();

            return usuarios.Any() ?
                    Ok(usuarios) :
                    NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _repository.BuscaUsuario(id);

            return usuario != null ?
                    Ok(usuario) :
                    NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            _repository.AdicionaUsuario(usuario);

            return await _repository.SaveChangesAsync() ?
                    Ok("Usuário Adicionado!") :
                    BadRequest("Erro ao Adcionar Usuário!");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario usuario)
        {
            var usur = await _repository.BuscaUsuario(id);
            if (usur == null) return NotFound("Usuário Não Encontrado!");

            usur.Nome = usuario.Nome ?? usur.Nome;
            usur.DataNascimento = usuario.DataNascimento != new DateTime() ? usuario.DataNascimento : usur.DataNascimento;

            _repository.AtualizaUsuario(usur);

            return await _repository.SaveChangesAsync() ?
                   Ok("Usuário Atualizado!") :
                   BadRequest("Erro ao Atualizar Usuário!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usur = await _repository.BuscaUsuario(id);
            if (usur == null) return NotFound("Usuário Não Encontrado!");

            _repository.DeleteUsuario(usur);

            return await _repository.SaveChangesAsync() ?
                   Ok("Usuário Deletado!") :
                   BadRequest("Erro ao Deletar Usuário!");


        }

    }
}
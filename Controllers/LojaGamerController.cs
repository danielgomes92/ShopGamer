using Microsoft.AspNetCore.Mvc;
using ShopGamer.Context;
using ShopGamer.Models;

namespace ShopGamer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LojaGamerController : Controller
    {
        private readonly LojinhaContext _context;

        public LojaGamerController(LojinhaContext context)
        {
            _context = context;
        }

        [HttpPost("CriarContato")]
        public IActionResult AdicionarItensDeVenda(LojaGamer lojaGamer)
        {
            _context.Add(lojaGamer);
            _context.SaveChanges();

            return Ok(lojaGamer);
        }

        [HttpGet("ConsultarPorNome/{name}")] // endpoint para a busca definina no parâmetro NAME.
        public IActionResult DetalharItens(string name)
        {
            var itemDaLoja = _context.LojaGamers.Where(x => x.Name.Contains(name)); // _context.LojaGamers.Find(Name); -- encontrar no banco por nome cadastrado e detalhar.

            if (name.ToUpper() == name.ToLower())
                return Ok(name);

            if (itemDaLoja == null)
                return NotFound("Este item não exite na loja");

            return Ok(itemDaLoja);
        }
        [HttpGet("ConsultarPorID/{id}")] // busca por parâmetro ID
        public IActionResult ConsultarNome(int id)
        {
            var buscarItemNoBanco = _context.LojaGamers.Find(id);
            
            if (buscarItemNoBanco == null)
                return NotFound("Usuário não existe em nossos dados");

            return Ok(buscarItemNoBanco);
        }
        [HttpGet("ConsultarTodosItens")] // Obter uma lista de todos os itens.
        public IActionResult ConsultarTodosItens(int id)
        {
            var buscarTodosItensNoBanco = _context.LojaGamers.ToList();

            if (buscarTodosItensNoBanco == null)
                return NotFound("Usuário não existe em nossos dados");

            return Ok(buscarTodosItensNoBanco);
        }

        // Buscar e Atualizar itens por id
        [HttpPut("AtualizarPorID/alterarItemGamer/{id}")] // - ? - verificar com o time se esse parâmetro se enquadra corretamente na busca - ? -
        public IActionResult AlterarInformacaoDosItens(LojaGamer alterarItemGamer)
        {
            if (alterarItemGamer == null)
                return NotFound("Este item não existe nos dados da lojaGamer!");
            
            var AlterarItemBancoLoja = _context.LojaGamers.Find(alterarItemGamer.Id);

            AlterarItemBancoLoja.Name = alterarItemGamer.Name;
            AlterarItemBancoLoja.Preco = alterarItemGamer.Preco;

            _context.Update(AlterarItemBancoLoja);
            _context.SaveChanges();

            return Ok(AlterarItemBancoLoja);
        }

        //Buscar e excluir itens por id
        [HttpDelete("ExcluirPorID/{id}")]
        public IActionResult RemoverItens(int id)
        {
            var ExcluirItemBancoLoja = _context.LojaGamers.Find(id);

            if(ExcluirItemBancoLoja == null)
                return NotFound("Este item já não existe no banco da loja!");

            _context.LojaGamers.Remove(ExcluirItemBancoLoja);
            _context.SaveChanges();

            return Ok(ExcluirItemBancoLoja);
        }
    }
}

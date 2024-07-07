using Lanches_Mac.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Lanches_Mac.Models
{
    public class CarrinhoCompra
    {

        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }

        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //Define uma sessão
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            //obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //obtem ou gera o ID do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na Sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retona o carrinho com o contexto e o Id atribuido puo obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }
        public void AdicionarAoCarrinho(Lanche lanche)
        {
            var carrinhocompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                  s => s.Lanche.LancheId == lanche.LancheId
                  && s.CarrinhoCompraId == CarrinhoCompraId);
            if (carrinhocompraItem == null)
            {
                carrinhocompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhocompraItem);

            }
            else
            {
                carrinhocompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }
        public int RemoverDoCarrinho(Lanche lanche)
        {
            var carrinhocompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                  s => s.Lanche.LancheId == lanche.LancheId
                  && s.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if (carrinhocompraItem != null)
            {
                if (carrinhocompraItem.Quantidade > 1)
                {
                    carrinhocompraItem.Quantidade--;
                    quantidadeLocal = carrinhocompraItem.Quantidade;
                }
                else
                {
                    _context.CarrinhoCompraItens.Remove(carrinhocompraItem);

                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }
        public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
        {
            return CarrinhoCompraItems ??
                (CarrinhoCompraItems =
                _context.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Include(s => s.Lanche)
                .ToList());
        }
    
        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompraItens
                .Where(carrinho => 
                carrinho.CarrinhoCompraId == CarrinhoCompraId); ;
            _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
            _context.SaveChanges();

        }
        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompraItens
              .Where(c => c.CarrinhoCompraId==CarrinhoCompraId)
              .Select(c => c.Lanche.Preco * c.Quantidade).Sum();
            return total;
        }
    }
}

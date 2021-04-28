using DapperUnitOfWork.Models;
using DapperUnitOfWork.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DapperUnitOfWork.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="pedidoRepository"></param>
        /// <param name="pedidoItemRepository"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/add")]
        public IActionResult Post(
            [FromServices] IUnitOfWork unitOfWork,
            [FromServices] PedidoRepository pedidoRepository,
            [FromServices] PedidoItemRepository pedidoItemRepository)
        {

            try
            {
                unitOfWork.BeginTransaction();

                // Em um projeto este codigo estaria no application services 

                Pedido pedido = new Pedido { Data = DateTime.Now };
                int idPedido = pedidoRepository.Save(pedido);

                List<PedidoItem> itens = new List<PedidoItem>();
                itens.Add(new PedidoItem { Produto = "Cotonete", Quantidade = 10, Preco = 7.99 });
                itens.Add(new PedidoItem { Produto = "Coca Cola", Quantidade = 6, Preco = 2.69 });
                itens.Add(new PedidoItem { Produto = "Halls", Quantidade = 1, Preco = 4.50 });
                pedidoItemRepository.Save(itens, idPedido);

                unitOfWork.Commit();

                return Ok();

            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                return BadRequest(ex.Message);
            }
        }


    }
}

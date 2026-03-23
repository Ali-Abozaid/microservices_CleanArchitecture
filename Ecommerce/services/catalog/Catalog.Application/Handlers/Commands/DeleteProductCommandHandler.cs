using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            

        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            // 1) Get existing product
            var existingProduct = await _productRepository.GetProductById(request.Id);

            if (existingProduct == null)
                return false;
            return await _productRepository.DeleteProduct(existingProduct.Id);

        }
    }
}

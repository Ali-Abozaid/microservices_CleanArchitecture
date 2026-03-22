using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Queries
{
    public class GetProductsByBrandQueryHandler : IRequestHandler<GetProductsByBrandQuery, IList<ProductResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public GetProductsByBrandQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IList<ProductResponseDto>> Handle(GetProductsByBrandQuery request, CancellationToken cancellationToken)
        {
           var products = await _productRepository.GetAllProductsByBrand(request.ProductBrand);
           var productsResponse = _mapper.Map<IList<ProductResponseDto>>(products);
              return productsResponse;
        }
    }
}

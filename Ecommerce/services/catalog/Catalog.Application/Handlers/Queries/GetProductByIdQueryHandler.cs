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
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<ProductResponseDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            /* request is an object from the GetProductByIdQuery class,
             * which contains the Id of the product we want to retrieve.
             * We use the _productRepository to get the product from the database,
             * and then we use AutoMapper to map the Product entity to a ProductResponseDto,
             * which is returned as the response.
             */
            var Product = await _productRepository.GetProductById(request.Id);
            var ProductResponseDto = _mapper.Map<ProductResponseDto>(Product);
            return ProductResponseDto;

        }
    }
}

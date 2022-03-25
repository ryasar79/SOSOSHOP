﻿namespace SOSOSHOP.Business.Handlers
{
    using AutoMapper;
    using SOSOSHOP.Business.Commands;
    using SOSOSHOP.Business.DTO.Response;
    using SOSOSHOP.
        DAL.Concrete.EntityFramework.GenericRepository;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductResponse>
    {
        #region fields

        private readonly IGenericRepository<Entity.Concrete.Customer> _repository;
        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public UpdateProductCommandHandler(IGenericRepository<Entity.Concrete.Customer> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region methods

        public async Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = await _repository.Get(x => x.Id == request.UpdateCustomerRequest.Id);
            if (response != null)
            {
                var customer = _mapper.Map<Entity.Concrete.Customer>(request.UpdateCustomerRequest);
                var updateResult = await _repository.Update(customer);
                var entityResponse = await _repository.SaveChangesAsync();
                if (entityResponse > 0)
                {
                    return _mapper.Map<UpdateProductResponse>(response);
                }
            }

            throw new System.Exception("Update Fail!");
        }

        #endregion
    }
}

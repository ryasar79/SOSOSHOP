﻿namespace SOSOSHOP.Business.Commands
{
    using MediatR;

    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteCustomerCommand(int id)
        {
            Id = id;
        }
    }
}

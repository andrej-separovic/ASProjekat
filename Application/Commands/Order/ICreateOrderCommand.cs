using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Order
{
    public interface ICreateOrderCommand : ICommand<OrderCreateDto>
    {
    }
}

using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Brand
{
    public interface ICreateBrandCommand : ICommand<BrandCreateDto>
    {
    }
}

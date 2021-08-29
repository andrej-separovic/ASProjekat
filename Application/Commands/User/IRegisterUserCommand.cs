﻿using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.User
{
    public interface IRegisterUserCommand : ICommand<UserCreateDto>
    {
    }
}

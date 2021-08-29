using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Core
{
    public class UnauthorizedActor : IApplicationActor
    {
        public int Id => 0;
        public string Identity => "Unauthorized user";
        public IEnumerable<int> AllowedUseCases =>
            new int[] { 1, 2, 3, 4, 5};
    }
}

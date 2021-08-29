using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class BrandNoIdDto
    {
        public string Name { get; set; }
    }

    public class BrandCreateDto
    {
        public string Name { get; set; }
    }
}

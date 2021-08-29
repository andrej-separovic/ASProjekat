using Application.Commands.Brand;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class DeleteBrandCommand : IDeleteBrandCommand
    {
        private readonly Context _context;

        public DeleteBrandCommand(Context context)
        {
            _context = context;
        }

        public int Id => 17;

        public string Name => "Deleteing brand.";

        public void Execute(int request)
        {
            var brand = _context.Brands.Find(request);

            if (brand == null)
            {
                throw new EntityNotFoundException(request, typeof(Brand));
            }

            brand.DeletedAt = DateTime.UtcNow;
            brand.IsDeleted = true;

            _context.SaveChanges();
        }
    }
}

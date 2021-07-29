﻿using Microsoft.EntityFrameworkCore;
using PaymentServices.DataAccess.DomainRepository.IRepository.Security;
using PaymentServices.Models.API.Request.Security;
using PaymentServices.Models.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.Repository.Security
{
    public class BlockCountryRepository : Repository<BlockCountry> , IBlockCountryRepository
    {
        private readonly MiddlewareDbContext _context;
        public BlockCountryRepository(MiddlewareDbContext _db):base(_db)
        {
            _context = _db;
        }

        public async Task AddManyItems(List<BlockCountry> blockCountries)
        {
            var _blockCountry = new BlockCountry();
            _context.BlockCountry.AddRange(blockCountries.Where(x=>x.id <= 0));
            foreach (var item in blockCountries.Where(x=> x.id >0 && !x.isDeleted))
            {
                _blockCountry = await _context.BlockCountry.FirstOrDefaultAsync(x=>x.id == item.id);

                if (_blockCountry != null)
                {
                    _blockCountry.countryId = item.countryId;
                    _blockCountry.modifiedAt = DateTime.UtcNow;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMany(List<DeleteRequest> Ids)
        {
            foreach (var item in Ids)
            {
                var currentCountry = await _context.BlockCountry.FirstOrDefaultAsync(x => x.id == item.Id);

                if (currentCountry != null)
                {
                    currentCountry.isDeleted = true;

                }
            }
            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PaymentServices.DataAccess.DomainRepository.IRepository.Lookups;
using PaymentServices.Models.Domain.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.Repository.Lookups
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        private readonly MiddlewareDbContext _context;
        public LanguageRepository(MiddlewareDbContext _context):base(_context)
        {
            this._context = _context;
        }

        public async Task<Language> ManageLanguage(Language language)
        {
            if(language.languageid <=0)
            {
                _context.Language.Add(language);
            }
            else
            {
                var _temp = await _context.Language.FirstOrDefaultAsync(x=>x.languageid == language.languageid);

                if(_temp != null)
                {
                    _temp.name = language.name;
                    _temp.isoCode = language.isoCode;
                    _temp.modifiedAt = DateTime.UtcNow;
                }
            }

            await _context.SaveChangesAsync();

            return language;
        }
    }
}

using ExchangeR.Application.Dtos;
using ExchangeR.Domain;
using ExchangeR.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeR.Application
{
    public interface ICurrencyService
    {
        Task<IEnumerable<CurrencyResponse>> GetCurrencies();
        Task<GenericResult> CreateCurrency(Currency request);

    }
    public class CurrencyService : ICurrencyService
    {
        private readonly IBaseRepository<Currency> _currencyRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CurrencyService(IUnitOfWork unitOfWork, IBaseRepository<Currency> currencyRepository)
        {
            _unitOfWork = unitOfWork;
            _currencyRepository = currencyRepository;
        }
        public Task<IEnumerable<CurrencyResponse>> GetCurrencies()
        {
            var currencies = (from currency in _currencyRepository.Query(true)
                              where currency.isActive
                              select new CurrencyResponse(
                                  currency.Id,
                                  currency.Name,
                                  currency.Abbreviation,
                                  currency.Description)
                             );
            return Task.FromResult(currencies.AsEnumerable());
        }

        public async Task<GenericResult> CreateCurrency(Currency request)
        {
            var result = new GenericResult();
            //Validaciones
            //TODO: Llevar a FluentValidation

            //var currencyToSave = new Currency(request.Name, request.Abreviature);

            //currencyToSave.SetCreateAudit(DateTime.Now, request.RegistredBy);

            var resultAdd = _currencyRepository.Add(request);

            var saved = await _unitOfWork.SaveChangesAsync();

            return result;
        }

    }
}

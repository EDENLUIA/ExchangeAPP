using ExchangeR.Application.Dtos;
using ExchangeR.Domain.Repositories;
using ExchangeR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ExchangeR.Domain.Dtos;

namespace ExchangeR.Application
{
    public class ExchangeRateService
    {
        private readonly IBaseRepository<Currency> _currencyRepository;
        private readonly IBaseRepository<ExchangeRate> _exchangeRateRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ExchangeRateService(IUnitOfWork unitOfWork, IBaseRepository<Currency> currencyRepository, IBaseRepository<ExchangeRate> ExchangeRateRepository)
        {
            _unitOfWork = unitOfWork;
            _currencyRepository = currencyRepository;
            _exchangeRateRepository = ExchangeRateRepository;
        }
        public Task<IEnumerable<ExchangeRateResponse>> GetExchangeRates()
        {
            var currencies = (from exchangeRateQuery in _exchangeRateRepository.Query(true)
                              join currencyFromQuery in _currencyRepository.Query(true) on exchangeRateQuery.CurrencyFromId equals currencyFromQuery.Id
                              join currencyToQuery in _currencyRepository.Query(true) on exchangeRateQuery.CurrencyToId equals currencyToQuery.Id
                              where exchangeRateQuery.IsActive
                              select new ExchangeRateResponse(
                                      exchangeRateQuery.Id,
                                      currencyFromQuery.Name,
                                      currencyToQuery.Name,
                                      exchangeRateQuery.Exchange
                                  )
                                   );
            return Task.FromResult(currencies.AsEnumerable());
        }

        public async Task<GenericResult> CreateExchangeRate(ExchangeRate request)
        {
            var result = new GenericResult();
           
            var resultAdd = _exchangeRateRepository.Add(request);

            var saved = await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<GenericResult> UpdateExchangeRate(ExchangeRate request)
        {
            var result = new GenericResult();
            //Validaciones
            //TODO: Llevar a FluentValidation
            if (request.Id == Guid.Empty)
            {
                result.AddError("No ingreso identificador de ExchangeRate");
                return result;
            }

            if (request.Exchange < 0)
            {
                result.AddError("El tipo de cambio deber ser mayor a 0.");
                return result;
            }

            var currencyExchangeRateToUpdate = _exchangeRateRepository.FindBy(x => x.Id == request.Id).FirstOrDefault();
            if (currencyExchangeRateToUpdate is null)
            {
                result.AddError("No existe ExchangeRate");
                return result;
            }

            _exchangeRateRepository.Update(request);
            var saved = await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<GenericResult<CurrencyExchangeResponse>> CalculateExchange(RequestCalculateExchange request)
        {
            var result = new GenericResult<CurrencyExchangeResponse>();
           
            if (request.CurrencyToId == Guid.Empty || request.CurrencyFromId == Guid.Empty)
            {
                result.AddError("No existe alguna de las monedas.");
                return result;
            }
            if (request.CurrencyToId == request.CurrencyFromId)
            {
                result.AddError("Debe ingresar monedas diferentes.");
                return result;
            }
            if (request.Amount <= 0)
            {
                result.AddError("Monto debe ser mayor a cero.");
                return result;
            }

            var currentCurrencyExchange = (from exchangeRateQuery in _exchangeRateRepository.Query(true)
                                           join currencyFromQuery in _currencyRepository.Query(true) on exchangeRateQuery.CurrencyFromId equals currencyFromQuery.Id
                                           join currencyToQuery in _currencyRepository.Query(true) on exchangeRateQuery.CurrencyToId equals currencyToQuery.Id
                                           where exchangeRateQuery.CurrencyFromId == request.CurrencyFromId && exchangeRateQuery.CurrencyToId == request.CurrencyToId && exchangeRateQuery.IsActive 
                                           select new CurrencyExchangeResponse(
                                                   request.Amount,
                                                   0,
                                                   currencyFromQuery.Name,
                                                   currencyToQuery.Name,
                                                   exchangeRateQuery.Exchange
                                               )).FirstOrDefault();

            if (currentCurrencyExchange is null)
            {
                result.AddError("No existe un tipo de cambio para estas monedas.");
                return result;
            }

          
            var exchangeRate = request.Amount * currentCurrencyExchange.ExchangeRate;
            currentCurrencyExchange!.AmountExchange = exchangeRate;
            

            result.DataObject = currentCurrencyExchange;

            return result;
        }


    }
}

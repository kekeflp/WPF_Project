using System;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Exceptions;
using WPF_SimpleTrader.Domain.Services;
using WPF_SimpleTrader.WPF.Commands;
using WPF_SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
    public class SearchSymbolCommand : AsyncCommandBase
    {
        private readonly ISearchSymbolViewModel _viewModel;
        private readonly IStockService _stockPriceService;

        public SearchSymbolCommand(ISearchSymbolViewModel viewModel, IStockService stockPriceService)
        {
            _viewModel = viewModel;
            _stockPriceService = stockPriceService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                double stockPrice = await _stockPriceService.GetPrice(_viewModel.Symbol);

                _viewModel.ResultOfSymbol = _viewModel.Symbol.ToUpper();
                _viewModel.StockPrice = stockPrice;
            }
            catch (InvalidSymbolException)
            {
                _viewModel.ErrorMessage = "Symbol does not exist.";
            }
            catch (Exception)
            {
                _viewModel.ErrorMessage = "Failed to get symbol information.";
            }
        }
    }
}
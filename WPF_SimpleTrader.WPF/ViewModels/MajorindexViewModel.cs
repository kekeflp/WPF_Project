using WPF_SimpleTrader.Domain.Models.API;
using WPF_SimpleTrader.Domain.Services;

namespace WPF_SimpleTrader.WPF.ViewModels
{
    public class MajorindexViewModel : ViewModelBase
    {
        private readonly IMajorindexService _majorindexService;

        private Majorindex _dowJones;

        public Majorindex DowJones
        {
            get { return _dowJones; }
            set { _dowJones = value; OnPropertyChanged(); }
        }

        private Majorindex _sP500;

        public Majorindex SP500
        {
            get { return _sP500; }
            set { _sP500 = value; OnPropertyChanged(); }
        }

        private Majorindex _nASDAQ;

        public Majorindex NASDAQ
        {
            get { return _nASDAQ; }
            set { _nASDAQ = value; OnPropertyChanged(); }
        }

        public MajorindexViewModel(IMajorindexService majorindexService)
        {
            _majorindexService = majorindexService;
            // 不能直接调用异步，会无法终结await
            //LoadMajorindexes();
        }

        public static MajorindexViewModel LoadMajorindexViewModel(IMajorindexService majorindexService)
        {
            var mivm = new MajorindexViewModel(majorindexService);
            mivm.LoadMajorindexes();
            return mivm;
        }

        #region Async Load

        //private async Task LoadMajorindexes()
        //{
        //    DowJones = await _majorindexService.GetMajorindices(MajorindexType.DowJones);
        //    SP500 = await _majorindexService.GetMajorindices(MajorindexType.SP500);
        //    NASDAQ = await _majorindexService.GetMajorindices(MajorindexType.NASDAQ);
        //}

        #endregion Async Load

        private void LoadMajorindexes()
        {
            // 目标线程结束时创建一个异步可执行的事务
            _majorindexService.GetMajorindices(MajorindexType.DowJones).ContinueWith((task) =>
            {
                if (task.Exception == null)
                {
                    DowJones = task.Result;
                }
            });

            _majorindexService.GetMajorindices(MajorindexType.SP500).ContinueWith((task) =>
            {
                if (task.Exception == null)
                {
                    SP500 = task.Result;
                }
            });

            _majorindexService.GetMajorindices(MajorindexType.NASDAQ).ContinueWith((task) =>
            {
                if (task.Exception == null)
                {
                    NASDAQ = task.Result;
                }
            });
        }
    }
}
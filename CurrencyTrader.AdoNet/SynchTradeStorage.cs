using CurrencyTrader.AdoNet;
using CurrencyTrader.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple.AdoNet
{
    public class SynchTradeStorage : ITradeStorage
    {
        ITradeStorage synchTradeStroage;
        private ILogger logger;

        public SynchTradeStorage(ILogger logger)
        {
            this.logger = logger;
            synchTradeStroage = new AdoNetTradeStorage(logger);
        }

        public void Persist(IEnumerable<TradeRecord> trades)
        {
            Task.Run(() => synchTradeStroage.Persist(trades));
        }
    }
}

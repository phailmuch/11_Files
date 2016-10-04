using System.Collections;

namespace _11_Files
{
    internal interface IStockRepository
    {
        long NextId();
        void SaveStock(Stock s);
        Stock LoadStock(long l);
        void Clear();
        ICollection FindAllStocks();
    }
}
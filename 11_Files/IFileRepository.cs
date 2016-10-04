namespace _11_Files
{
    internal interface IFileRepository
    {
        string StockFileName(Stock s);
        string StockFileName(int i);

        void SaveStock(Stock s);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace _11_Files
{
    internal class FileStockRepository : IStockRepository, IFileRepository
    {
        string nl = Environment.NewLine;

        Dictionary<long, Stock> fileList = new Dictionary<long, Stock>();

        public long Id { get; set; }

        private DirectoryInfo direct { get; set; }


        public FileStockRepository(DirectoryInfo dir)
        {
            direct = dir;
            dir.Create();
        }

        public long NextId()
        {
            Id++;
            return Id;

        }

        public string StockFileName(Stock s)
        {
            string fileId = s.Id.ToString();
            string fileName = "stock";
            return fileName + fileId + ".txt";
        }

        public string StockFileName(int id)
        {
            string fileId = id.ToString();
            string fileName = "stock";
            return fileName + fileId + ".txt";
        }

        public void SaveStock(Stock s)
        {
            if (!File.Exists("stock" + s.Id + ".txt"))
            {
                NextId();
            }

            s.Id = Convert.ToInt32(Id);
            StreamWriter sw = new StreamWriter(direct + "stock" + s.Id + ".txt");
            sw.WriteLine(s.Symbol + nl + s.PricePerShare + nl + s.NumShares);
            sw.Close();

            fileList.Add(s.Id, s);



        }

        public Stock LoadStock(long id)
        {
            StreamReader sr = new StreamReader(direct + "stock" + id + ".txt");
            string sy = sr.ReadLine();

            double pps = Convert.ToDouble(sr.ReadLine());
            int ns = Convert.ToInt32(sr.ReadLine());
            sr.Close();
            Stock newStock = new Stock(sy, pps, ns);
            return newStock;
        }

        public void Clear()
        {
            foreach (FileInfo item in direct.GetFiles())
            {
                item.Delete();
                
            }
            fileList.Clear();
        }

        public ICollection FindAllStocks()
        {
            return fileList;
        }

    }
}
using System;
using System.IO;

namespace _11_Files
{
    internal class StockIO
    {
        public void WriteStock(StringWriter sw, Stock s)
        {
            string nl = Environment.NewLine;
            sw.Write(s.Symbol + nl + s.PricePerShare + nl + s.NumShares + nl);
            sw.Close();

        }


        public void WriteStock(FileInfo file, Stock s)
        {
            string nl = Environment.NewLine;
            StreamWriter sw = file.CreateText();
            sw.WriteLine(s.Symbol + nl + s.PricePerShare + nl + s.NumShares);
            sw.Close();


        }
        public Stock ReadStock(StringReader sr)
        {
            string sy = sr.ReadLine();

            double pps = Convert.ToDouble(sr.ReadLine());
            int ns = Convert.ToInt32(sr.ReadLine());
            Stock newStock = new Stock(sy, pps, ns);
            return newStock;

        }

        public Stock ReadStock(FileInfo file)
        {

            StreamReader reader = file.OpenText();
            string sy = reader.ReadLine();
            double pps = Convert.ToDouble(reader.ReadLine());
            int ns = Convert.ToInt32(reader.ReadLine());
            Stock s = new Stock(sy, pps, ns);
            reader.Close();
            return s;

        }

    }


}
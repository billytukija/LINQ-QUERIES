using System;
using System.IO;
using System.Linq;

namespace LINQ_QUERIES
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = from arquivo in Directory.GetFiles(@"c:\windows\system32")
                        let infoArquivo = new FileInfo(arquivo)
                        group infoArquivo by infoArquivo.Extension.ToUpper() into g
                        let Extention = g.Key
                        orderby Extention
                        select new
                        {
                            Extention = Extention,
                            TotalFiles = g.Count(),
                            SiseFileKB = g.Sum(fi => fi.Length) / 1024M
                        };
        }
    }
}

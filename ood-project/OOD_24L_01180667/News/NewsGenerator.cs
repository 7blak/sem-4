using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OOD1.News
{
    public class NewsGenerator
    {
        private List<INewsProviders> newsProviders;
        private List<IReportable> reportableObjects;
        private CartesianProdEnum<INewsProviders, IReportable> cartesianProdEnum;
        public NewsGenerator(List<INewsProviders> newsProviders, List<IReportable> reportableObjects)
        {
            this.newsProviders = newsProviders;
            this.reportableObjects = reportableObjects;
            cartesianProdEnum = new(newsProviders, reportableObjects);
        }
        public string? GenerateNextNews()
        {
            if (!cartesianProdEnum.MoveNext())
                return null;
            return cartesianProdEnum.Current.Item2.Report(cartesianProdEnum.Current.Item1);
        }
    }
}

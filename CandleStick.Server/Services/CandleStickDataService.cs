using AutoMapper;
using CandleStick.Server.Models;
using CandleStick.Server.Models.Configuration;
using CandleStick.Server.Models.ViewModels;
using CandleStick.Server.Services.Interfaces;
using System.Globalization;

namespace CandleStick.Server.Services
{
    public class CandleStickDataService : ICandleStickDataService
    {
        #region Implementation / Members

        private readonly IMapper _mapper;
        private readonly CandleStickDataConfiguration _candleStickDataConfiguration;

        private IEnumerable<CandleStickDataItem> _data = new List<CandleStickDataItem>();

        private IEnumerable<CandleStickDataItem> Data
        {
            get
            {
                if (!_data.Any())
                {
                    _data = GetMarketListDataFromCsv();
                }

                return _data;
            }
        }

        #endregion

        public CandleStickDataService(IConfiguration configuration, IMapper mapper)
        {
            _mapper = mapper;
            var candleStickSectionSettings = configuration.GetSection(CandleStickDataConfiguration.SECTION_NAME)
                .Get<CandleStickDataConfiguration>();

            if (candleStickSectionSettings != null)
            {
                _candleStickDataConfiguration = candleStickSectionSettings;
            }
            else
            {
                throw new NullReferenceException($"Missing {CandleStickDataConfiguration.SECTION_NAME} configuration section. Please, add it to appsettings.json");
            }
        }


        public IEnumerable<CandleStickDataItem> GetData()
        {
            return Data.OrderBy(i => i.Time);
        }

        public IEnumerable<CandleStickTreeItem> GetTree()
        {
            var list = (from x in Data.OrderBy(i => i.Time)
                        let dt = new DateTime(new DateOnly(x.Time.Date.Year, x.Time.Date.Month, x.Time.Date.Day), new TimeOnly(x.Time.Hour, x.Time.Minute))
                        group x by dt into g
                        select new CandleStickTreeItem
                        {
                            TimeRange = g.Key,
                            ListDataGroup = g.ToList()
                        }).ToList();

            return list;
        }

        public IEnumerable<CandleStickTreeViewModel> GetTreeViewOnly()
        {
            var treeItems = GetTree().ToList();
            return _mapper.Map<List<CandleStickTreeItem>, List<CandleStickTreeViewModel>>(treeItems);
        }

        #region Helper Methods

        private IEnumerable<CandleStickDataItem> GetMarketListDataFromCsv()
        {
            var marketList = File.ReadAllLines(_candleStickDataConfiguration.FilePath)
                .Skip(1)
                .Select(csvLine =>
                {
                    string[] arrLine = csvLine.Split(_candleStickDataConfiguration.Delimiter);
                    var marketLine = new CandleStickDataItem(DateTime.ParseExact(arrLine[0], _candleStickDataConfiguration.TimeFormat, CultureInfo.InvariantCulture), long.Parse(arrLine[1]), decimal.Parse(arrLine[2]));
                    return marketLine;
                });

            return marketList;
        }

        #endregion
    }
}

using CandleStick.Server.Models;
using CandleStick.Server.Models.ViewModels;

namespace CandleStick.Server.Services.Interfaces;

public interface ICandleStickDataService
{
    IEnumerable<CandleStickDataItem> GetData();
    IEnumerable<CandleStickTreeItem> GetTree();
    IEnumerable<CandleStickTreeViewModel> GetTreeViewOnly();
}
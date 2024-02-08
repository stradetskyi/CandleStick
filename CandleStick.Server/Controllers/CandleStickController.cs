using CandleStick.Server.Models;
using CandleStick.Server.Models.ViewModels;
using CandleStick.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CandleStick.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandleStickController : ControllerBase
    {
        private readonly ILogger<CandleStickController> _logger;
        private readonly ICandleStickDataService _candleStickDataService;

        public CandleStickController(ILogger<CandleStickController> logger, ICandleStickDataService candleStickDataService)
        {
            _logger = logger;
            _candleStickDataService = candleStickDataService;
        }

        [HttpGet(template:"get-initial-data", Name = "GetData")]
        public List<CandleStickDataItem> GetData()
        {
            return _candleStickDataService.GetData().ToList();
        }
        
        [HttpGet(template: "get-full-data-tree", Name = "GetTree")]
        public List<CandleStickTreeItem> GetTree()
        {
            return _candleStickDataService.GetTree().ToList();
        }

        [HttpGet(template: "get-tree-view", Name = "GetTreeViewOnly")]
        public List<CandleStickTreeViewModel> GetTreeViewOnly()
        {
            return _candleStickDataService.GetTreeViewOnly().ToList();
        }
    }
}

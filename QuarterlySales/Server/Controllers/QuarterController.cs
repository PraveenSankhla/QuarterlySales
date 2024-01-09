using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuarterlySales.Server.Bussiness;
using QuarterlySales.Shared;
using QuarterlySales.Shared.Model;

namespace QuarterlySales.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuarterController : ControllerBase
    {
        [HttpGet]
        public async Task<List<AddSale>> GetQuarter()
        {
            List<AddSale> Quarter = new();
            Quarter = QuarterManager.GetQuarter();
            return Quarter;
        }
    }
}

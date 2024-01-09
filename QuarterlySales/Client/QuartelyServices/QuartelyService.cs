using QuarterlySales.Shared.Model;
using System.Net.Http.Json;

namespace QuarterlySales.Client.QuartelyServices
{
    public interface IQuarter
    {
        Task<List<AddSale>> GetQuarter(AddSale saledtl);
        Task<List<AddSale>> GetemployeeList();
        Task<List<AddSale>> GeteQuarterList();
        Task<List<AddSale>> GetYear();
    }

    public class QuarterServices : IQuarter
    {
        private readonly HttpClient httpClient;
        public QuarterServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        List<AddSale> result = new List<AddSale>
         {
             new AddSale
             {
                 year = 2019,
                 Quarter = 1,
                 employee = "Grace Hopper",
                 amount = 664.83
             },
             new AddSale
             {
                 year = 2019,
                 Quarter = 2,
                 employee = "Grace Hopper",
                 amount = 458.23
             },
             new AddSale
             {
                 year = 2019,
                 Quarter = 3,
                 employee = "Grace Hopper",
                 amount = 8847.45
             },
             new AddSale
             {
                 year = 2019,
                 Quarter = 4,
                 employee = "Grace Hopper",
                 amount = 152.52
             },
             new AddSale
             {
                 year = 2019,
                 Quarter = 1,
                 employee = "Katherine Johnson",
                 amount = 369.23
             },
             new AddSale
             {
                 year = 2019,
                 Quarter = 2,
                 employee = "Katherine Johnson",
                 amount = 749.23
             },
             new AddSale
             {
                 year = 2019,
                 Quarter = 3,
                 employee = "Katherine Johnson",
                 amount = 29.23
             },
             new AddSale
             {
                 year = 2019,
                 Quarter = 4,
                 employee = "Katherine Johnson",
                 amount = 519.23
             },
         };


        public async Task<List<AddSale>> GetQuarter(AddSale saledtl)
        {
            List<AddSale> Sale = new List<AddSale>();
            try
            {
                if (saledtl.employee == "All" && saledtl.year == null && saledtl.Quarter == null)
                {
                    Sale = await httpClient.GetFromJsonAsync<List<AddSale>>("Quarter");
                    //Sale = result.ToList();
                }
                else
                {
                    if(saledtl.year == null && saledtl.Quarter == null)
                    {
                        Sale = result.Where(result => result.employee == saledtl.employee).ToList();
                    }
                    else if(saledtl.year == null && saledtl.employee != "All")
                    {
                        Sale = result.Where(result => result.employee == saledtl.employee && result.Quarter == saledtl.Quarter).ToList();
                    }
                    else if(saledtl.Quarter == null && saledtl.employee != "All")
                    {
                        Sale = result.Where(result => result.employee == saledtl.employee && result.year == saledtl.year).ToList();
                    }
                    else if(saledtl.employee == "All" && saledtl.year == null)
                    {
                        Sale = result.Where(result =>  result.Quarter == saledtl.Quarter).ToList();
                    }
                    else if (saledtl.employee == "All" && saledtl.Quarter == null)
                    {
                        Sale = result.Where(result => result.year == saledtl.year).ToList();
                    }
                    else if (saledtl.employee == "All")
                    {
                        Sale = result.Where(result => result.year == saledtl.year && result.Quarter == saledtl.Quarter).ToList();
                    }
                    else
                    {
                        Sale = result.Where(result => result.employee == saledtl.employee && result.year == saledtl.year && result.Quarter == saledtl.Quarter).ToList();
                    }
                }
                //Sale = await httpClient.GetFromJsonAsync<List<AddSale>>("Quarter");
                return Sale;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<AddSale>> GetemployeeList()
        {
            List<AddSale> Sale = new List<AddSale>();
            try
            {
                var filter = result.DistinctBy(i => i.employee).ToList();
                foreach (var item in filter)
                {
                    Sale.Add(item);
                }
                return Sale;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<AddSale>> GeteQuarterList()
        {
            List<AddSale> Sale = new List<AddSale>();
            try
            {
                var filter = result.DistinctBy(i => i.Quarter).ToList();
                foreach (var item in filter)
                {
                    Sale.Add(item);
                }
                return Sale;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<AddSale>> GetYear()
        {
            List<AddSale> Sale = new List<AddSale>();
            try
            {
                var filter = result.DistinctBy(i => i.year).ToList();
                foreach (var item in filter)
                {
                    Sale.Add(item);
                }
                return Sale;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

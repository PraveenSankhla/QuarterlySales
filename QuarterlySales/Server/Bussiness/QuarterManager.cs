using QuarterlySales.Shared.Model;

namespace QuarterlySales.Server.Bussiness
{
    public class QuarterManager
    {
        public static List<AddSale> result()
        {
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
            return result;
        }
        

        public static List<AddSale> GetQuarter()
        {
            List<AddSale> list = new List<AddSale>();
            try
            {
                //List<AddSale> result = new List<AddSale>
                //{
                //    new AddSale
                //    {
                //        year = 2019,
                //        Quarter = 1,
                //        employee = "Grace Hopper",
                //        amount = 664.83
                //    },
                //    new AddSale
                //    {
                //        year = 2019,
                //        Quarter = 2,
                //        employee = "Grace Hopper",
                //        amount = 458.23
                //    },
                //    new AddSale
                //    {
                //        year = 2019,
                //        Quarter = 3,
                //        employee = "Grace Hopper",
                //        amount = 8847.45
                //    },
                //    new AddSale
                //    {
                //        year = 2019,
                //        Quarter = 4,
                //        employee = "Grace Hopper",
                //        amount = 152.52
                //    },
                //    new AddSale
                //    {
                //        year = 2019,
                //        Quarter = 1,
                //        employee = "Katherine Johnson",
                //        amount = 369.23
                //    },
                //    new AddSale
                //    {
                //        year = 2019,
                //        Quarter = 2,
                //        employee = "Katherine Johnson",
                //        amount = 749.23
                //    },
                //    new AddSale
                //    {
                //        year = 2019,
                //        Quarter = 3,
                //        employee = "Katherine Johnson",
                //        amount = 29.23
                //    },
                //    new AddSale
                //    {
                //        year = 2019,
                //        Quarter = 4,
                //        employee = "Katherine Johnson",
                //        amount = 519.23
                //    },
                //};

                list = QuarterManager.result();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

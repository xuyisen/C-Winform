using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseExample.Entity
{
    public class CustomerService
    {
        List<Customer> customers = new List<Customer>();
        int num = 0;
        public CustomerService()
        {
            Customer customer1 = new Customer("许宜森",CustomerType.PERSONAL,CustomerArea.SOUTH,"山东","13277032800","阿里","董事长",DateTime.Today);
            Customer customer2 = new Customer("浦帆", CustomerType.GOVERMENT, CustomerArea.NORTH, "安徽", "13277032801", "腾讯", "总经理", DateTime.Today);
            Customer customer3 = new Customer("贾柯", CustomerType.COMPANY, CustomerArea.WEST, "山西", "13277032802", "百度", "人资部", DateTime.Today);
            Customer customer4 = new Customer("吕超", CustomerType.PERSONAL, CustomerArea.EAST, "贵州", "13277032803", "华为", "外联部", DateTime.Today);
            this.CreateCustomer(customer1);
            this.CreateCustomer(customer2);
            this.CreateCustomer(customer3);
            this.CreateCustomer(customer4);
            
        }

        public string CreateCustomer(Customer customer)
        {
            num++;
            customer.Id = string.Format("{0:yyyyMMdd}{1:D3}", customer.CreateTime, num);
            customers.Add(customer);
            return customer.Id;
        }

        public Customer getCustomers(String customerId)
        {
            return customers.Find(o => o.Id == customerId);
        }

        public List<Customer> findAllCustomer()
        {
            return customers;
        }
        public List<Customer> findCustomers(Dictionary<string, string> condition)
        {
            var result = customers.AsQueryable();
            foreach (KeyValuePair<string, string> kvp in condition)
            {
                string lkey = kvp.Key.ToLower();
                if (lkey.Equals("id"))
                {
                    result = result.Where(o => o.Id == kvp.Value);
                }
                else if (lkey.Equals("name"))
                {
                    result = result.Where(o => o.Name == kvp.Value);
                }
                else if (lkey.Equals("area"))
                {
                   
                    result = result.Where(o => o.Area.ToString()==(kvp.Value));
                }
                else if (lkey.Equals("address"))
                {
                    result = result.Where(o => o.Address==(kvp.Value));
                }
                else if (lkey.Equals("tell"))
                {
                    result = result.Where(o => o.Tell==(kvp.Value));
                }
                else if (lkey.Equals("type"))
                {
                
                    result = result.Where(o => o.Type.ToString().Equals(kvp.Value));
                }
                else if (lkey.Equals("workpalce"))
                {
                    result = result.Where(o => o.WorkPlace==(kvp.Value));
                }
                else if (lkey.Equals("startdate"))
                {
                    result=result.Where(o=> o.CreateTime>=DateTime.Parse(kvp.Value));
                }
                else if (lkey.Equals("enddate"))
                {
                    result = result.Where(o => o.CreateTime <= DateTime.Parse(kvp.Value));
                }
               

            }
            return result.ToList<Customer>();
        }
    }
}

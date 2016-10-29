using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseExample.Entity
{
    public enum CustomerType { PERSONAL,COMPANY,GOVERMENT}
    public enum CustomerArea { EAST,WEST,NORTH,SOUTH}
    public class Customer
    {
        
        public string Name { get; set; }
        public string Id { get; set; }
        public CustomerType Type { get; set; }
        public CustomerArea Area { get; set; }
        public string Address { get; set; }
        public string Tell { get; set; }
        public string WorkPlace { get; set; }
        public string RemarksInfo { get; set; }
        public DateTime CreateTime { get; set; }

       
        public Customer(string name, CustomerType type, CustomerArea area, string address, string tell, string workPlace, string remarkInfo, DateTime createTime)
        {
            Name = name;
            Type = type;
            Area = area;
            Address = address;
            Tell = tell;
            WorkPlace = workPlace;
            RemarksInfo = remarkInfo;
            CreateTime = createTime;
        }

       
    }
}

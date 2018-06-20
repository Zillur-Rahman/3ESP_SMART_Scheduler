using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_Scheduler
{
    public class SMTransaction
    {
            public string error { get; set; }
            public string status { get; set; }
            public string transaction_id { get; set; }
    }

    public class Customer
    {
        public string code { get; set; }
        public string credit_balance { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class GetCustomerInfo
    {
        public List<Customer> customers { get; set; }
        public string error { get; set; }
        public string status { get; set; }
    }
}

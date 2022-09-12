using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanService.Models
{
    public class ReqLoanCreation
    {
        public int ?ProductId { get; set; }
        public int ?CustomerId { get; set; }
        public int ?ShopId { get; set; }
        public double TotalLoanAmount { get; set; }
        public double DailyRate { get; set; }
    }
}

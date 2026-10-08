using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSupermarket.WinForms.Models;

namespace MiniSupermarket.WinForms.Models
{
    internal class ReportDto
    {
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public required string BestSellerProduct { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAGStore.Model.Models;

namespace DAGStore.Web.ViewModels
{
    public class OrderViewModels
    {
        public Customer Customer { get; set; }

        public Order Order { get; set; }
    }
}
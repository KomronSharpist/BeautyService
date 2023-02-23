using BeautyServices.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServices.Service.DTOs
{
    public class plannerDTo
    {
        public long UserId { get; set; }
        public long WorkerId { get; set; }
        public string Description { get; set; }
        public OrderTypes statusType { get; set; } = OrderTypes.planned;
    }
}

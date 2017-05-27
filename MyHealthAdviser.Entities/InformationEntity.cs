using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHealthAdviser.Entities
{
    public class InformationEntity
    {
        public long UserId { get; set; }
        public long StatisticsId { get; set; }
        public double BP { get; set; }
        public double Glucose { get; set; }

        public decimal HeartBeat { get; set; }
    }
}

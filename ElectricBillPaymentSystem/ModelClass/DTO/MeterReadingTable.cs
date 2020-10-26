using System;
using System.Collections.Generic;
using System.Text;

namespace BillPayment.DTO.DTO
{
   public class MeterReadingTable
    {
        public int MeterReadingId { get; set; }
        public int CustomerId { get; set; }
        public int MeterId { get; set; }
        public double CurrentUnit { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual MeterTable MeterTable { get; set; }
    }
}

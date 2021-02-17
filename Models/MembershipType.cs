using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignupFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
        public String Name { get; set; }
    }
}
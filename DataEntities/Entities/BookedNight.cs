using DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class BookedNight
    {
        public int BookedNightId { get; set; }
        public Property Property { get; set; }
        public DateTime Night { get; set; }
    }
}

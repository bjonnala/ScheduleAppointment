using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppiontment
{
    public class AvailableTimeSlots
    {
        public int slotId { get; set; }
        public DateTime dateTime { get; set; }

        public bool isScheduled { get; set; }
    }
}

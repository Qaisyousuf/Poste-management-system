using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Models
{
    public class BuildingAddress:EntityBase
    {
        public string BuildingName { get; set; }

        public int FloorId { get; set; }
        [ForeignKey("FloorId")]
        public FloorsAddress Floors { get; set; }

        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Rooms { get; set; }

    }
}

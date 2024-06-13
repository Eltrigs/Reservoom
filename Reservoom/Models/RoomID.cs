using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class RoomID
    {
        public int floorNumber { get; }
        public int roomNumber { get; }

        public RoomID(int floorNumber, int roomNumber)
        {
            this.floorNumber = floorNumber;
            this.roomNumber = roomNumber;
        }

        public override string ToString()
        {
            return $"{floorNumber}{roomNumber}";
        }

        public override bool Equals(object obj)
        {
            return obj is RoomID roomID &&
                floorNumber == roomID.floorNumber &&
                roomNumber == roomID.roomNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(floorNumber, roomNumber);
        }

        public static bool operator ==(RoomID left, RoomID right) 
        { 
            if(left is null && right is null)
            {
                return true;
            }

            return !(left is null) && left.Equals(left);
        }

        public static bool operator !=(RoomID left, RoomID right)
        {
            return !(left == right);
        }
    }
}

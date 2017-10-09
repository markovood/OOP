using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Rock : StaticObject, IResource
    {
        private int quantity;

        public Rock(int hitpoints, Point position) : 
            base(position)
        {
            this.HitPoints = hitpoints;
            this.quantity = this.HitPoints / 2;
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
        }

        public ResourceType Type
        {
            get
            {
                return ResourceType.Stone;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuatroGameEngine.Component
{
    public class GameComponent
    {
        public Guid GuidID = Guid.NewGuid();

        public GameComponent() { }

        public GameComponent GetComponent()
        {
            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampLichtknop
{
    public class Lichtknop
    {
        int id;
        public bool aanUit;
        Lamp lamp;

        public Lichtknop()
        {
            aanUit = false;
            lamp = new Lamp();
        }

        public void Omzetten()
        {
            aanUit = !aanUit;
            if (aanUit)
            {
                lamp.AanGaan();
            }
            else
            {
                lamp.UitGaan();
            }

        }
    }
}

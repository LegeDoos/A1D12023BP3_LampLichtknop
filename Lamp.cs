using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampLichtknop
{
    public class Lamp
    {
        // eigenschappen
        int id;
        bool aanUit;
        string beschrijving;
        Lichtknop lichtknop;


        // gedrag
        public Lamp()
        {
            aanUit = false;
            beschrijving = "Nieuwe lamp";
        }



        /// <summary>
        /// Deze method zet de lamp aan
        /// </summary>
        public void AanGaan()
        {
            aanUit = true;
        }

        /// <summary>
        /// Zet de lamp uit
        /// </summary>
        public void UitGaan()
        {
            aanUit = false;
        }

    }
}

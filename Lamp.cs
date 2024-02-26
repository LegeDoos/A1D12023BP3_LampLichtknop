using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampLichtknop
{
    public class Lamp
    {
        public int Id { get; set; }
        public bool AanUit { get; private set; }
        
        private string _beschrijving;
        public string Beschrijving {
            get { 
                return _beschrijving; 
            }
            private set
            {
                _beschrijving = value.ToUpper();
            } 
        }

        public Lichtknop Lichtknop { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lichtknop">De lichtknop</param>
        public Lamp(Lichtknop lichtknop)
        {
            AanUit = false;
            _beschrijving = "Nieuwe lamp";
            Lichtknop = lichtknop;
        }

        /// <summary>
        /// Deze method zet de lamp aan
        /// </summary>
        public void AanGaan()
        {
            AanUit = true;
        }

        /// <summary>
        /// Zet de lamp uit
        /// </summary>
        public void UitGaan()
        {
            AanUit = false;
        }

    }
}

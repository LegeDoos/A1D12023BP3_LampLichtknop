using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampLichtknop
{
    /// <summary>
    /// Dit representeert de dimschakelaar
    /// </summary>
    public class DimSchakelaar : Lichtknop
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="beschrijving"></param>
        public DimSchakelaar(int id, string beschrijving, int dimpercentage) : base(id, beschrijving)
        {
            DimPercentage = dimpercentage;
        }

        /// <summary>
        /// Het ingestelde dimpercentage
        /// </summary>
        public int DimPercentage { get; private set; }

        /// <summary>
        /// Instellen van de dimfactor zodat de lampen kunnen dimmen
        /// </summary>
        /// <param name="factor">De factor waarop de schakelaar wordt ingesteld</param>
        public void DimFactorInstellen(int factor)
        {
            // todo Controleer hier eventueel of de factor tussen 0 en 100 is!

            DimPercentage = factor;
        
            
            // lampen instellen
            foreach (var lamp in Lampen)
            {
                lamp.Percentage = DimPercentage;
            }

        }

    }
}

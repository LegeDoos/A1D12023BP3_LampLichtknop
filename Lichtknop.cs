﻿using LampLichtknop.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampLichtknop
{
    /// <summary>
    /// Representeert de lichtknop
    /// </summary>
    public class Lichtknop
    {
        public int Id { get; private set; }
        
        /// <summary>
        /// Geeft aan of de schakelaar aan of uit staat
        /// </summary>
        public bool AanUit { get; private set; }

        public string Beschrijving { get; set; }
        
        /// <summary>
        /// De lijst met lampen, property met getter en setter
        /// </summary>
        public List<Lamp> Lampen { get; set; }

        /// <summary>
        /// Standaard constructor
        /// </summary>
        public Lichtknop(int id, string beschrijving)
        {
            Id = id;
            AanUit = false;
            Lampen = new List<Lamp>();
            Beschrijving = beschrijving;
        }
        /// <summary>
        /// Voeg een lamp toe aan de lichtknop
        /// </summary>
        /// <param name="lamp">De lamp die je wilt toevoegen</param>
        public void LampToevoegen(Lamp lamp)
        {
            Lampen.Add(lamp);
        }

        /// <summary>
        /// Zet de schakelaar om. Als alles aan stond staat erna alles uit, en andersom.
        /// </summary>
        public void Omzetten()
        {
            AanUit = !AanUit;
            if (AanUit)
            {
                foreach (var lamp in Lampen)
                {
                    lamp.AanGaan();
                }
            }
            else
            {
                foreach (var lamp in Lampen)
                {
                    lamp.UitGaan();
                }
            }
        }

        // data access methods

        public void AddToDatabase()
        {
            DAL dal = new DAL();
            dal.CreateLightswitch(this);            
        }

        public static List<Lichtknop> ReadLightSwitches()
        {
            DAL dal = new DAL();
            dal.ReadLightswitches();
            return dal.Lichtknoppen;
        }
    }
}

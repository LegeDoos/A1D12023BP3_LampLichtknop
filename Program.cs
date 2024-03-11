﻿namespace LampLichtknop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Lichtknop> lichtknoppen = new List<Lichtknop>();

            Lichtknop lichtknop = new Lichtknop();
            lichtknoppen.Add(lichtknop);

            Lamp lamp1 = new Lamp(lichtknop);
            Lamp lamp2 = new Lamp(lichtknop);
            lichtknop.LampToevoegen(lamp1);
            lichtknop.LampToevoegen(lamp2);

            for (int i = 0; i < 5; i++)
            {
                // maak een instantie van een lamp aan
                Lamp lampToevoegen = new Lamp(lichtknop);
                // voeg toe aan de lijst van lampen van de lichtknop
                lichtknop.LampToevoegen(lampToevoegen);
            }

            lichtknop.Omzetten();
           
            Console.WriteLine($"De lichtknop staat: {lichtknop.AanUit}");
            foreach (var lamp in lichtknop.Lampen)
            {
                Console.WriteLine($"Lamp staat aan = {lamp.AanUit} en brandt met {lamp.Percentage}%");
            }

            lichtknop.Omzetten();

            Console.WriteLine($"De lichtknop staat: {lichtknop.AanUit}");
            foreach (var lamp in lichtknop.Lampen)
            {
                Console.WriteLine($"Lamp staat aan = {lamp.AanUit} en brandt met {lamp.Percentage}%");
            }

            DimSchakelaar dimSchakelaar = new DimSchakelaar();
            lichtknoppen.Add(dimSchakelaar);
            Lamp specialeLamp = new Lamp(dimSchakelaar);
            dimSchakelaar.LampToevoegen(specialeLamp);
            
            Console.WriteLine("Initiele status");
            Console.WriteLine($"de speciale lamp staat aan = {specialeLamp.AanUit} en brandt met {specialeLamp.Percentage}%");

            
            dimSchakelaar.Omzetten();
            Console.WriteLine("Aanzetten:");
            Console.WriteLine($"de speciale lamp staat aan = {specialeLamp.AanUit} en brandt met {specialeLamp.Percentage}%");

            dimSchakelaar.DimFactorInstellen(50);
            Console.WriteLine("Dimmen");
            Console.WriteLine($"de speciale lamp staat aan = {specialeLamp.AanUit} en brandt met {specialeLamp.Percentage}%");

            dimSchakelaar.Omzetten();
            Console.WriteLine("uitzetten:");
            Console.WriteLine($"de speciale lamp staat aan = {specialeLamp.AanUit} en brandt met {specialeLamp.Percentage}%");

            // toon lichtknoppen
            Console.WriteLine("\n\nLichtknoppen:");
            int j = 1;
            foreach (Lichtknop knop in lichtknoppen)
            {
                Console.WriteLine($"Lichtknop {j} staat aan: {knop.AanUit} en heeft {knop.Lampen.Count} lampen en heeft als type {knop.GetType()}");
                j++;    
            }


        }
    }
}

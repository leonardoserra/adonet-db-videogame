﻿namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------Gestionale Videogames per i Tornei------------------------");
            bool programExecuting = true;
            while (programExecuting)
            {
                Console.WriteLine(@"Seleziona l'operazione da effettuare: 

            1. Inserire un nuovo videogioco
            2. Cerca per id 
            3. Cerca per nome (anche parziale)
            4. Cancellare un videogioco
            5. Chiudere il programma

            ");

                int selectedOperation = int.Parse(Console.ReadLine());
                switch (selectedOperation)
                {
                    case 1:
                        {
                            try
                            {
                                //Inserire un nuovo videogioco
                                Console.WriteLine("Inserisci i dati del videogioco");
                                Console.WriteLine();
                                Console.Write("\tNome: ");
                                string name = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("\tInfo: ");
                                string overview = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("\tData rilascio: ");
                                DateTime releaseDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Console.Write("\tid Software House(da 0 a 6): ");
                                long softwareHouseId = long.Parse(Console.ReadLine());
                                Console.WriteLine();

                                bool success = VideogameManager.InsertVideogame(name, overview, releaseDate, softwareHouseId);
                                if (success)
                                    Console.WriteLine("Videogioco aggiunto al Torneo!");
                                else
                                    Console.WriteLine("Problema con l'aggiunta del videgioco al torneo...");

                                Console.WriteLine();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                continue;
                            }
                        }
                        break;
                    case 2:
                        //Cerca per id
                        try
                        {
                            Console.Write("Digita l'id del gioco che vuoi cercare: ");
                            long id= long.Parse(Console.ReadLine());
                            Console.WriteLine();
                            Console.WriteLine(VideogameManager.SearchVideogameById(id));
                          
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        //Cerca per nome (anche parziale)
                        try
                        {
                            Console.Write("Digita il nome del gioco che vuoi cercare o una parte del nome:");
                            string name = Console.ReadLine();
                            Console.WriteLine();
                            List<Videogame> videogames = VideogameManager.SearchVideogameByName(name);
                            foreach (Videogame v in videogames)
                            {
                                Console.WriteLine(v);
                            }
                        }catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 4:
                        //Cancellare un videogioco
                        try
                        {
                            Console.WriteLine("Digita l'id del videogioco da cancellare");
                            long idToDelete = long.Parse(Console.ReadLine());
                            bool success = VideogameManager.DeleteVideogame(idToDelete);
                            if (success)
                                Console.WriteLine("Videogame rimosso dal torneo!");
                            else
                                Console.WriteLine("Problema con l'eliminazione...");
                                Console.WriteLine();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 5:
                        //Chiudere il programma
                        programExecuting = false;
                        ExitAnimation();
                        break;
                    case 0555:
                        //stampa debug lista
                        try
                        {
                            List<Videogame> videogames = VideogameManager.GetVideogamesList();
                            foreach (Videogame v in videogames)
                            {
                                Console.WriteLine(v);
                            }
                        }catch (Exception ex) {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default:
                        Console.WriteLine("Comando non valido");
                        Console.WriteLine("Vuoi uscire? y/n");
                        string answer = Console.ReadLine().ToLower();
                        if(answer == "y" || answer == "yes" || answer == "s" || answer == "si")
                        {
                            programExecuting = false;
                            ExitAnimation();
                        }
                        break;
                }
            }
        }
        public static void ExitAnimation()
        {
            Console.WriteLine("Chiusura programma in corso...");
            Thread.Sleep(1000);
            Console.WriteLine("......");
            Thread.Sleep(500);
            Console.WriteLine("....");
            Thread.Sleep(555);
            Console.WriteLine("Alla prossima! ;)");
            Thread.Sleep(1000);
        }
    }
}
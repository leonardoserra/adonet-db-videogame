namespace adonet_db_videogame
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
                        //Inserire un nuovo videogioco

                        break;
                    case 2:
                        //Cerca per id
                        break;
                    case 3:
                        //Cerca per nome (anche parziale)
                        break;
                    case 4:
                        //Cancellare un videogioco
                        break;
                    case 5:
                        //Chiudere il programma
                        programExecuting = false;
                        ExitAnimation();
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
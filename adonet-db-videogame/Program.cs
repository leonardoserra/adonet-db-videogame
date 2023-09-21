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
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        programExecuting = false;
                        Console.WriteLine("Chiusura programma in corso...");
                        Thread.Sleep(1000);
                        Console.WriteLine("......");
                        Thread.Sleep(500);
                        Console.WriteLine("....");
                        Thread.Sleep(555);
                        Console.WriteLine("Alla prossima! ;)");
                        Thread.Sleep(1000);

                        break;
                    default:
                        Console.WriteLine("");
                        break;
                }
            }
        }
    }
}
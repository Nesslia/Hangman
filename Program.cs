using HangmanAndy;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // MeinBaum();
            Andy.AndyBaum();
        }
        internal static void MeinBaum()
        {
            //Programmiere das Spiel Hangman. User 1 soll ein Wort eingeben.
            //User 2 muss danach eine Eingabe machen entweder für einen Buchstaben oder das gesuchte Wort.
            //User 2 Gewinnt wenn er entweder alle Buchstaben oder das richte Wort erraten hat.
            //Ansonsten baut sich der Galgen auf mit folgender Ausgabe als Finale:

            //
            //"  ======||  "
            //"  |     ||  "
            //"  O     ||  "
            //" -x-    ||  "
            //"  x     ||  "
            //" | |    ||  "
            //"        ||  "
            //"============"
            //
            //Ist der Galgen fertig aufgebaut hat User 2 Verloren und User 1 Gewinnt 
            //Am Ende soll eine weitere Spielrunde angeboten werden.

            bool spielVorbei = false;
            int versuche = 0;
            int maxVersuche = 11;

            Console.WriteLine("Hallo zusammen, lasst uns eine Runde Hangman spielen.");
            Console.WriteLine("User 1, bitte überlege dir ein Wort und gebe dies ein");
            string secretWord = Console.ReadLine();

            Console.Clear();

            while (true)
            {

                for (int i = 0; i < secretWord.Length; i++)
                {
                    Console.Write("_");
                }
                Console.WriteLine();
                Console.WriteLine("User 2, bitte gebe ein Buchstaben oder ein Wort ein.");
                string user2input = Console.ReadLine();

                if (user2input.Length > 1)
                {
                    if (user2input == secretWord)
                    {
                        Console.WriteLine("User 2, du hast gewonnen.");
                        spielVorbei = true;
                    }
                }
                else if (user2input.Length == 1)
                {
                    bool gefunden = false;

                    Console.Clear();
                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        if (secretWord[i].ToString() == user2input)
                        {
                            Console.Write(secretWord[i]);
                            gefunden = true;
                        }
                        else
                        {
                            Console.Write("_");
                        }
                    }
                    if (!gefunden)
                    {
                        versuche--;
                    }
                }
                else
                {
                    Console.WriteLine("User 2 du hast nichts eingegeben");
                }


                if (maxVersuche == 0)
                {
                    Console.WriteLine("User 2, du hast verloren.");
                    Console.WriteLine(@"
              ======||  
              |     ||  
              O     ||  
             -x-    ||  
              x     ||  
             | |    ||  
                    ||  
            ============
");
                }


                Console.WriteLine("\nMöchtest du noch eine Runde spielen? (y/n)");
                string neueRunde = Console.ReadLine().ToLower();

                if (neueRunde != "y")
                {
                    Console.WriteLine("Vielen Dank für's spielen!");
                    break;
                }

            }

        }
    }
}

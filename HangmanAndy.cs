namespace HangmanAndy
{
    internal static class Andy
    {
        internal static void AndyBaum()
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

            string[] hangman = new string[12];
            hangman[0] = "            ";
            hangman[1] = "============";
            hangman[2] = "        ||  \n        ||  \n        ||  \n        ||  \n        ||  \n        ||  \n        ||  \n============";
            hangman[3] = "  ======||  \n        ||  \n        ||  \n        ||  \n        ||  \n        ||  \n        ||  \n============";
            hangman[4] = "  ======||  \n  |     ||  \n        ||  \n        ||  \n        ||  \n        ||  \n        ||  \n============";
            hangman[5] = "  ======||  \n  |     ||  \n  O     ||  \n        ||  \n        ||  \n        ||  \n        ||  \n============";
            hangman[6] = "  ======||  \n  |     ||  \n  O     ||  \n  x     ||  \n        ||  \n        ||  \n        ||  \n============";
            hangman[7] = "  ======||  \n  |     ||  \n  O     ||  \n -x     ||  \n        ||  \n        ||  \n        ||  \n============";
            hangman[8] = "  ======||  \n  |     ||  \n  O     ||  \n -x-    ||  \n        ||  \n        ||  \n        ||  \n============";
            hangman[9] = "  ======||  \n  |     ||  \n  O     ||  \n -x-    ||  \n  x     ||  \n        ||  \n        ||  \n============";
            hangman[10] = "  ======||  \n  |     ||  \n  O     ||  \n -x-    ||  \n  x     ||  \n |      ||  \n        ||  \n============";
            hangman[11] = "  ======||  \n  |     ||  \n  O     ||  \n -x-    ||  \n  x     ||  \n | |    ||  \n        ||  \n============";


            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Hallo User 1 und User 2!\nLasst uns eine Runde Hangman spielen.");

            while (true)
            {
                int versuche = 0;
                int maximaleVersuche = 11;
                bool gewonnen = false;

                Console.WriteLine("\nWillkommen bei Hangman.\nUser 1 bitte gebe nun ein Wort ein das User 2 erraten muss und bestätige deine Eingabe mit Enter:");
                string lsg = Console.ReadLine().ToLower();
                Console.Clear();

                char[] geratenesWort = new string('_', lsg.Length).ToCharArray();   //Fügt pro buchstabe im lösungswort ein "_" ein
                List<char> gerateneBuchstaben = new List<char>();

                while (versuche < maximaleVersuche)
                {
                    Console.Clear();

                    Console.WriteLine(hangman[versuche]);
                    Console.WriteLine($"Gesuchtes Wort: {new string(geratenesWort)}");
                    Console.WriteLine($"Diese Buchstaben wurden bereits geraten: {string.Join(", ", gerateneBuchstaben)}");

                    Console.WriteLine($"User 2.\nTippe entweder einen Buchstaben ein oder ein Wort ein:");
                    string raten = Console.ReadLine().ToLower();

                    if (raten.Length == 1)
                    {
                        char buchstabe = raten[0];
                        if (gerateneBuchstaben.Contains(buchstabe))
                        {
                            Console.WriteLine("Der Buchstabe wurde von dir schon geraten.\nVersuche einen anderen");
                            continue;
                        }

                        gerateneBuchstaben.Add(buchstabe);

                        if (lsg.Contains(buchstabe))
                        {
                            for (int i = 0; i < lsg.Length; i++)
                            {
                                if (lsg[i] == buchstabe)
                                {
                                    geratenesWort[i] = buchstabe;
                                }
                            }
                            if (new string(geratenesWort) == lsg)
                            {
                                gewonnen = true;
                                break;
                            }
                        }
                        else
                        {
                            versuche++;
                        }
                    }
                    else if (raten == lsg)
                    {
                        gewonnen = true;
                        break;
                    }
                    else
                    {
                        versuche++;
                    }
                }
                Console.Clear();

                if (gewonnen)
                {
                    Console.WriteLine($"Herzlichen Glückwunsch!\nDu hast das Wort: '{lsg}' erraten");
                }
                else
                {
                    Console.WriteLine(hangman[versuche]);
                    Console.WriteLine($"Schade du hast das gesuchte wort: '{lsg}' leider nicht erraten!");
                }

                Console.WriteLine("Erneut spielen? (j/n)");
                string nochmal = Console.ReadLine().ToLower();
                if (nochmal != "j")
                {
                    break;
                }


            }

        }
    }
}
using System;
namespace Calcul_et_intégration_FINAL
{
    class Program
    {
        static void Main(string[] args)
        {
            string gameChoice = GameChoice("Quel jeu voulez-vous jouer? ");
            switch (gameChoice.ToLower())
            {
                //JEU DE NIM CLASSIQUE 
                case "classique":
                case "jeu de nim classique":
                    bool tourSUPERNIMEURPRO;
                    int k;
                    int allumettesTotal;
                    int reste;
                    int allumettesSUPERNIMEURPRO = 0;
                    k = ReadUserInput("Choisissez le nombre maximal d'allumettes que l'on peut enlever par tour. ", "nullcheck", 2147483647, " ");
                    allumettesTotal = ReadUserInput("Choisissez le nombre d'allumettes avec lequel vous voulez jouer. ", "nullcheck", 2147483647, " ");
                    Console.WriteLine(" ");
                    //Règles du jeu 
                    if (k == 1)
                    {
                        Console.WriteLine("Le jeu de Nim consiste à enlever tour à tour une allumette. Le joueur qui a enlevé la dernière allumette remportera la partie.");
                        Console.WriteLine(" ");
                    }
                    else if (k == 2)
                    {
                        Console.WriteLine("Le jeu de Nim consiste à enlever tour à tour 1 ou 2 allumettes. Le joueur qui a enlevé la dernière allumette remportera la partie.");
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        Console.WriteLine("Le jeu de Nim consiste à enlever tour à tour un nombre d'allumettes allant de 1 à " + k + ". Le joueur qui a enlevé la dernière allumette remportera la partie.");
                        Console.WriteLine(" ");
                    }
                    reste = allumettesTotal % (k + 1);
                    Console.WriteLine("Voici avec quoi vous allez jouer.");
                    ImprimerClassique(allumettesTotal);
                    //Choisir qui joue en premier 
                    if (reste == 0)
                    {
                        tourSUPERNIMEURPRO = false;
                        Console.WriteLine("Vous avez choisi de jouer avec " + allumettesTotal + " allumettes, c'est à vous de commencer.");
                    }
                    else
                    {
                        tourSUPERNIMEURPRO = true;
                        Console.WriteLine("Vous avez choisi de jouer avec " + allumettesTotal + " allumettes, SUPERNIMEURPRO++ va commencer.");
                    }
                    //LE JEU 
                    while (allumettesTotal > 0)
                    {
                        //Tour du joueur 
                        while (tourSUPERNIMEURPRO == false)
                        {
                            allumettesTotal = allumettesTotal - ReadUserInput("Combien d'allumettes voulez-vous enlever? ", "nullcheck", k, "k");
                            reste = allumettesTotal % (k + 1);
                            Console.WriteLine("Il reste " + allumettesTotal + " allumettes.");
                            ImprimerClassique(allumettesTotal);
                            tourSUPERNIMEURPRO = true;
                        }
                        //Tour de SUPERNIMEURPRO++ 
                        while (tourSUPERNIMEURPRO == true)
                        {
                            while (reste > 0)
                            {
                                allumettesTotal--; //allumettesTotal = allumettesTotal - 1; 
                                allumettesSUPERNIMEURPRO++; //allumettesSUPERNIMEURPRO = allumettesSUPERNIMEURPRO + 1; 
                                reste = allumettesTotal % (k + 1);
                            }
                            if (allumettesTotal > 0)
                            {
                                Console.WriteLine("SUPERNIMEURPRO++ a enlevé " + allumettesSUPERNIMEURPRO + " allumettes.");
                                ImprimerClassique(allumettesTotal);
                                Console.WriteLine("Il reste " + allumettesTotal + " allumettes.");
                                allumettesSUPERNIMEURPRO = 0;
                            }
                            tourSUPERNIMEURPRO = false;
                            /* CODE k=3 
                             switch (reste) 
                            { 
                                case 1: 
                                    allumettesTotal = allumettesTotal - 1; 
                                    Console.WriteLine("SUPERNIMEURPRO++ a enlevé 1 allumette."); 
                                    break; 
                                case 2: 
                                    allumettesTotal = allumettesTotal - 2; 
                                    Console.WriteLine("SUPERNIMEURPRO++ a enlevé 2 allumettes."); 
                                    break; 
                                case 3: 
                                    allumettesTotal = allumettesTotal - 3; 
                                    Console.WriteLine("SUPERNIMEURPRO++ a enlevé 3 allumettes."); 
                                    break; 
                            } 
                            Console.WriteLine("Il reste " + allumettesTotal + " allumettes."); 
                            Console.WriteLine(" "); 
                            tourSUPERNIMEURPRO = false; 
                            */
                        }
                    }
                    if (allumettesTotal == 0)
                    {
                        if (allumettesSUPERNIMEURPRO == 1)
                        {
                            Console.WriteLine("SUPERNIMEURPRO++ a enlevé la dernière allumette.");
                        }
                        else
                        {
                            Console.WriteLine("SUPERNIMEURPRO++ a enlevé les " + allumettesSUPERNIMEURPRO + " dernières allumettes.");
                        }
                        Console.WriteLine("Vous avez perdu!");
                    }
                    Console.ReadLine();
                    break;
                //JEU DE MARIENBAD 
                case "marienbad":
                case "jeu de marienbad":
                    bool tourMarienbadPRO;
                    int allumettesEnleveMarienbad = 0;
                    int[] lignes = new int[ReadUserInput("Combien de lignes voulez vous? ", "nullcheck", 2147483647, " ")];
                    for (int i = 0; i < lignes.Length; i++)
                    {
                        lignes[i] = ReadUserInput("Combien d'allumettes voulez-vous dans la ligne " + (i + 1) + "? ", "nonullcheck", 2147483647, " ");
                        //Checking that the game doesn't start with no matches 
                    }
                    while (TableauVide(lignes))
                    {
                        Console.Write("Vous ne pouvez pas jouer avec aucune allumettes. Veuillez rentrer au moins une allumette pour la ligne " + lignes.Length + ". ");
                        lignes[(lignes.Length - 1)] = ReadUserInput("Combien d'allumettes voulez-vous dans la ligne " + lignes.Length + "? ", "nonullcheck", 2147483647, " ");
                    }
                    Console.WriteLine("Le jeu de Marienbad présente " + lignes.Length + " lignes contenant un nombre d'allumettes quelconques. Le jeu consiste à enlever tour à tour des allumettes. Le joueur qui enleve la dernière allumette remporter la partie.");
                    Console.WriteLine("Vous pouvez enlevez le nombre d'allumettes que vous voulez sur une même ligne. Vous ne pouvez pas enlever des allumettes sur plusieurs lignes.");
                    Console.WriteLine(" ");
                    Console.WriteLine("Voici avec quoi vous allez jouer.");
                    ImprimerMarienbad(lignes);
                    //Who starts? 
                    if (GouP(lignes))
                    {
                        Console.WriteLine("SUPERMARIENBADDEURPRO++ va commencer.");
                        tourMarienbadPRO = true;
                    }
                    else
                    {
                        Console.WriteLine("Vous allez commencer en premier.");
                        tourMarienbadPRO = false;
                    }
                    //Let's play 
                    while (!TableauVide(lignes))
                    {
                        //User turn 
                        if (tourMarienbadPRO == false)
                        {
                            int ligneJoueur;
                            int allumettesSurLigne;
                            //Checks if line is empty 
                            while (true)
                            {
                                ligneJoueur = ReadUserInput("Sur quelle ligne voulez vous enlever des allumettes? ", "nullcheck", lignes.Length, "lignes");
                                allumettesSurLigne = lignes[(ligneJoueur) - 1];
                                if (!EmptyLineVerification((ligneJoueur) - 1, allumettesSurLigne))
                                {
                                    break;
                                }
                            }
                            int allumettesJoueur = ReadUserInput("Combien d'allumettes voulez-vous enlever? ", "nullcheck", allumettesSurLigne, "allumettes");
                            lignes[(ligneJoueur) - 1] -= allumettesJoueur;
                            Console.WriteLine("Vous avez enlever " + allumettesJoueur + " allumettes de la ligne " + ligneJoueur + ".");
                            ImprimerMarienbad(lignes);
                            tourMarienbadPRO = true;
                        }
                        //MarienbadPRO turn 
                        if (tourMarienbadPRO == true)
                        {
                            System.Diagnostics.Debug.Assert(GouP(lignes));
                            for (int i = 0; i < lignes.Length; i++)
                            {
                                allumettesEnleveMarienbad = 0;
                                while (GouP(lignes) && lignes[i] > 0)
                                {
                                    lignes[i]--;
                                    allumettesEnleveMarienbad++;
                                }
                                if (GouP(lignes))
                                {
                                    lignes[i] = allumettesEnleveMarienbad;
                                    allumettesEnleveMarienbad = 0;
                                }
                                else //if (!GouP(lignes)) 
                                {
                                    Console.WriteLine("SUPERMARIENBADDDEURPRO++ a enlevé " + allumettesEnleveMarienbad + " allumettes sur la ligne " + (i + 1) + ".");
                                    ImprimerMarienbad(lignes);
                                    tourMarienbadPRO = false;
                                    break;
                                }
                            }
                        }
                    }
                    if (allumettesEnleveMarienbad == 1)
                    {
                        Console.WriteLine("SUPERMARIENBADDEURPRO++ a enlevé la dernière allumette.");
                    }
                    else
                    {
                        Console.WriteLine("SUPERMARIENBADDEURPRO++ a enlevé les " + allumettesEnleveMarienbad + " dernières allumettes.");
                    }
                    Console.WriteLine("Vous avez perdu!");
                    Console.ReadLine();
                    break;
            }
        }
        //Calculation of NimSum 
        public static bool GouP(int[] lignes)
        {
            bool gagnante;
            int nombre = 0;
            int[] binaire = new int[lignes.Length];
            for (int i = 0; i < lignes.Length; i++)
            {
                binaire[i] = Convert.ToInt32(Convert.ToString(lignes[i], 2));
            }
            int biggestValue = 0;
            for (int i = 0; i < binaire.Length; i++)
            {
                if (binaire[i] > biggestValue)
                {
                    biggestValue = binaire[i];
                }
            }
            int colonnes = Convert.ToInt32(biggestValue.ToString().Length);
            int[] sommeNim = new int[(colonnes)];
            //for (int j = (sommeNim.Length - 1); j >= 0; j--) 
            for (int j = 0; j < sommeNim.Length; j++)
            {
                for (int i = 0; i < lignes.Length; i++)
                {
                    nombre = nombre + ((binaire[i] / Convert.ToInt32(Math.Pow(10, j))) % 10);
                    nombre = nombre % 2;
                }
                sommeNim[j] = nombre;
                nombre = 0;
            }
            if (TableauVide(sommeNim))
            {
                gagnante = false;
            }
            else
            {
                gagnante = true;
            }
            return gagnante;
        }
        public static int Modulo(int nombre)
        {
            return nombre % 2;
        }
        public static void ImprimerClassique(int allumettes)
        {
            Console.Write("Allumettes(" + allumettes + "):");
            for (int i = 0; i < allumettes; i++)
            {
                Console.Write("| ");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
        public static void ImprimerMarienbad(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("Ligne " + (i + 1) + "(" + a[i] + "):");
                for (int j = 0; j < a[i]; j++)
                {
                    Console.Write("| ");
                }
                Console.Write("\n");
            }
        }
        public static bool TableauVide(int[] tableau)
        {
            bool vide = true;
            for (int i = 0; i < tableau.Length; i++)
            {
                if (tableau[i] > 0)
                {
                    vide = false;
                    break;
                }
            }
            return vide;
        }
        public static int ReadUserInput(string question, string extracheck, int max, string strMax)
        {
            int value;
            while (true)
            {
                Console.Write(question);
                string strUserInput = Console.ReadLine();
                if (Verification(strUserInput, extracheck, max, strMax))
                {
                    value = Convert.ToInt32(strUserInput);
                    break;
                }
                Console.WriteLine(" ");
            }
            return value;
        }
        public static string GameChoice(string question)
        {
            string gameChoice;
            while (true)
            {
                Console.Write(question);
                string strUserInput = Console.ReadLine();
                if (GameVerification(strUserInput))
                {
                    gameChoice = strUserInput;
                    break;
                }
                Console.WriteLine(" ");
            }
            return gameChoice;
        }
        //Verification of user input 
        public static bool GameVerification(string StrUserInput)
        {
            bool game = false;
            string gameChoice = StrUserInput.ToLower();
            if (gameChoice == "classique" || gameChoice == "jeu de nim classique" || gameChoice == "marienbad" || gameChoice == "jeu de marienbad")
            {
                game = true;
            }
            else
            {
                Console.WriteLine("Veuillez choisir entre le jeu de nim classique ou le jeu de Marienbad.");
            }
            return game;
        }
        public static bool Verification(string StrUserInput, string extracheck, int max, string strMax)
        {
            bool goodAnswer = false;
            if (NumberVerification(StrUserInput))
            {
                int userInput = Convert.ToInt32(StrUserInput);
                if (!NegativeVerification(userInput))
                {
                    if (!HigherThanMaxVerification(userInput, max, strMax))
                    {
                        if (extracheck == "nullcheck")
                        {
                            if (!NullVerification(userInput, strMax))
                            {
                                goodAnswer = true;
                            }
                        }
                        else
                        {
                            goodAnswer = true;
                        }
                    }
                }
            }
            return goodAnswer;
        }
        public static bool NumberVerification(string userinput)
        {
            int i = 0;
            bool notANumber = true;
            //Checking if the number is a number 
            if (!int.TryParse(userinput, out i))
            {
                Console.WriteLine(userinput + " n'est pas un nombre.");
                Console.WriteLine("Veuillez entrez un nombre.");
                notANumber = true;
            }
            else
            {
                notANumber = false;
            }
            return !notANumber;
        }
        public static bool NegativeVerification(int userinput)
        {
            bool negativeNumber = true;
            // Checking if the number is smaller than 0 
            if (userinput < 0)
            {
                Console.WriteLine("Le nombre entré est un nombre négatif.");
                Console.WriteLine("Veuillez choisir un nombre plus grand que 0.");
                negativeNumber = true;
            }
            else
            {
                negativeNumber = false;
            }
            return negativeNumber;
        }
        public static bool NullVerification(int userinput, string aOuL)
        {
            bool nullNumber = true;
            //Checking if number is null 
            if (userinput == 0)
            {
                if (aOuL == "allumettes") //marienbad 
                {
                    Console.WriteLine("Vous devez enlever au moins une allumette.");
                }
                else if (aOuL == "lignes") // marienbad 
                {
                    Console.WriteLine("Il n'y a pas de ligne 0.");
                }
                Console.WriteLine("Veuillez choisir un nombre plus grand que 0.");
            }
            else
            {
                nullNumber = false;
            }
            return nullNumber;
        }
        public static bool HigherThanMaxVerification(int userinput, int max, string aOuL)
        {
            bool higherThanMax = true;
            //Checking if the number is higher than the maximum limit 
            if (userinput > max)
            {
                if (aOuL == "k") //nim classique 
                {
                    Console.WriteLine("Le nombre entré dépasse le nombre maximal d'allumettes que vous pouvez enlever.");
                    Console.WriteLine("Veuillez choisir un nombre plus petit ou égal à " + max + ".");
                }
                else if (aOuL == "allumettes") //marienbad 
                {
                    Console.WriteLine("Le nombre entré dépasse le nombre d'allumettes disponible sur la ligne.");
                    Console.WriteLine("Veuillez choisir un nombre plus petit ou égal à " + max + ".");
                }
                else if (aOuL == "lignes") // marienbad 
                {
                    Console.WriteLine("Le nombre entré dépasse le nombre de lignes disponibles.");
                    Console.WriteLine("Veuillez choisir un nombre plus petit ou égal à " + max + ".");
                }
            }
            else
            {
                higherThanMax = false;
            }
            return higherThanMax;
        }
        public static bool EmptyLineVerification(int l, int allumettes)
        {
            bool emptyLine = true;
            //Checking if the line is empty 
            if (allumettes == 0)
            {
                Console.WriteLine("La ligne " + (l + 1) + " est vide. Veuillez choisir une nouvelle ligne.");
            }
            else
            {
                emptyLine = false;
            }
            return emptyLine;
        }
    }
}

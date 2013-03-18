using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intestazione
{

    public class Intestazione
    {
        /// <summary>
        /// Crea un menu dinamico che chiede all'utente quale punto preferisce, ogni punto è distanziato di una riga, si puo anche avere il menu centrato
        /// </summary>
        /// <param name="testo">Inserire le possibilità</param>
        /// <param name="incentra">True per incentrare il menu, False per lasciarlo a destra</param>
        /// <returns></returns>
        public static int menu(string[] testo, bool incentra)
        {

            int punto = 0;
            ConsoleKeyInfo tasto;
            bool fine = false;
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < testo.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                if (i == punto)
                {

                    if (incentra)
                        centra(testo[i], "verde", "blu");
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(testo[i]);

                    }
                    Console.ResetColor();

                }
                else
                {
                    if (incentra)
                        centra(testo[i], "verde", "nero");
                    else
                        Console.Write(testo[i]);
                    Console.ResetColor();
                }

                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
            }
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - testo.Length);
            do
            {
                tasto = Console.ReadKey(true);

                if (tasto.Key == ConsoleKey.Enter)
                {
                    fine = true;
                }
                else if (tasto.Key == ConsoleKey.UpArrow || tasto.Key == ConsoleKey.DownArrow)
                {

                    if (tasto.Key == ConsoleKey.DownArrow)
                        punto++;
                    else
                        punto--;
                    if (punto == testo.Length)
                        punto = 0;
                    else if (punto == -1)
                        punto = testo.Length - 1;
                    for (int i = 0; i < testo.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        if (i == punto)
                        {

                            if (incentra)
                                centra(testo[i], "verde", "blu");
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write(testo[i]);
                            }
                            Console.ResetColor();

                        }
                        else
                        {
                            if (incentra)
                                centra(testo[i], "verde", "");
                            else
                                Console.WriteLine(testo[i]);
                            Console.ResetColor();
                        }
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                    }
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - testo.Length);
                }

            } while (!fine);
            for (int i = 0; i < testo.Length; i++)
            {
                Console.ResetColor();
                if (i == punto)
                {

                    if (incentra)
                        centra(creaStringaDiSpazi(testo[i].Length), " ", " ");
                    else
                    {

                        Console.Write(creaStringaDiSpazi(testo[i].Length));

                    }
                    Console.ResetColor();

                }
                else
                {
                    if (incentra)
                        centra(creaStringaDiSpazi(testo[i].Length), " ", " ");
                    else
                        Console.Write(creaStringaDiSpazi(testo[i].Length));

                }

                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
            }
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
            return punto;
        }


        //

        /// <summary>
        /// Menu dinamico che chiede all'utente quale punto preferisce, ogni punto è distanziato di una tabulazione.
        /// </summary>
        /// <param name="testo"></param>
        /// <param name="incentra"></param>
        /// <returns></returns>
        public static int menuTabulazione(string[] testo, string coloretesto, string coloresfondo)
        {
            int puntoXIniziale = Console.CursorLeft;
            int puntoYIniziale = Console.CursorTop;
            int punto = 0;
            coloretesto = colore(coloretesto, 0);
            coloresfondo = colore(coloresfondo, 1);
            ConsoleColor color1 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), coloretesto);
            ConsoleColor color2 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), coloresfondo);
            Console.ForegroundColor = color1;
            ConsoleColor coloreSfondoVecchio = Console.BackgroundColor;
            ConsoleColor coloreTestoVecchio = Console.ForegroundColor;
            ConsoleKeyInfo tasto;
            bool fine = false, primaEntrata = true;
            for (int i = 0; i < testo.Length; i++)
            {
                if (Console.CursorLeft > Console.BufferWidth - 2 - testo[i].Length)
                {
                    Console.SetCursorPosition(0, Console.CursorTop + 1);
                }
                else
                {
                    if (!primaEntrata)
                        Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop);
                }


                Console.ForegroundColor = color1;

                if (i == punto)
                {


                    Console.BackgroundColor = color2;
                    Console.Write(testo[i]);
                    Console.ResetColor();

                }
                else
                {
                    Console.BackgroundColor = coloreSfondoVecchio;
                    Console.Write(testo[i]);
                    Console.ResetColor();
                }
                primaEntrata = false;
            }

            Console.SetCursorPosition(puntoXIniziale, puntoYIniziale);
            do
            {
                primaEntrata = true;
                tasto = Console.ReadKey(true);

                if (tasto.Key == ConsoleKey.Enter)
                {
                    fine = true;
                }
                else if (tasto.Key == ConsoleKey.LeftArrow || tasto.Key == ConsoleKey.RightArrow)
                {

                    if (tasto.Key == ConsoleKey.RightArrow)
                        punto++;
                    else
                        punto--;
                    if (punto == testo.Length)
                        punto = 0;
                    else if (punto == -1)
                        punto = testo.Length - 1;
                    for (int i = 0; i < testo.Length; i++)
                    {
                        if (Console.CursorLeft > Console.BufferWidth - 2 - testo[i].Length)
                        {
                            Console.SetCursorPosition(0, Console.CursorTop + 1);
                        }
                        else
                        {
                            if (!primaEntrata)
                                Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop);
                        }

                        Console.ForegroundColor = color1;

                        if (i == punto)
                        {


                            Console.BackgroundColor = color2;
                            Console.Write(testo[i]);
                            Console.ResetColor();

                        }
                        else
                        {
                            Console.BackgroundColor = coloreSfondoVecchio;
                            Console.Write(testo[i]);
                            Console.ResetColor();
                        }
                        primaEntrata = false;
                    }
                    Console.SetCursorPosition(puntoXIniziale, puntoYIniziale);
                }

            } while (!fine);
            primaEntrata = true;
            for (int i = 0; i < testo.Length; i++)
            {
                if (Console.CursorLeft > Console.BufferWidth - 2 - testo[i].Length)
                {
                    Console.SetCursorPosition(0, Console.CursorTop + 1);
                }
                else
                {
                    if (!primaEntrata)
                        Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop);
                }
                Console.BackgroundColor = coloreSfondoVecchio;
                if (i == punto)
                {


                    Console.Write(creaStringaDiSpazi(testo[i].Length));

                    Console.ResetColor();

                }
                else
                {

                    Console.Write(creaStringaDiSpazi(testo[i].Length));
                }
                primaEntrata = false;


            }
            Console.BackgroundColor = coloreSfondoVecchio;
            Console.ForegroundColor = coloreTestoVecchio;
            Console.SetCursorPosition(puntoXIniziale, puntoYIniziale);
            return punto;
        }
        public static int menuScritto2volte(string[] testo)
        {

            int punto = 0;
            ConsoleKeyInfo tasto;
            bool fine = false;
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < testo.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                if (i == punto)
                {


                    centraScritto2volte(testo[i], "verde", "blu");

                    Console.ResetColor();

                }
                else
                {
                    centraScritto2volte(testo[i], "verde", "nero");
                    Console.ResetColor();
                }

                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
            }
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - testo.Length);
            do
            {
                tasto = Console.ReadKey(true);

                if (tasto.Key == ConsoleKey.Enter)
                {
                    fine = true;
                }
                else if (tasto.Key == ConsoleKey.UpArrow || tasto.Key == ConsoleKey.DownArrow)
                {

                    if (tasto.Key == ConsoleKey.DownArrow)
                        punto++;
                    else
                        punto--;
                    if (punto == testo.Length)
                        punto = 0;
                    else if (punto == -1)
                        punto = testo.Length - 1;
                    for (int i = 0; i < testo.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        if (i == punto)
                        {

                            centraScritto2volte(testo[i], "verde", "blu");
                            Console.ResetColor();

                        }
                        else
                        {
                            centraScritto2volte(testo[i], "verde", "");
                            Console.ResetColor();
                        }
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                    }
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - testo.Length);
                }

            } while (!fine);

            for (int i = 0; i < testo.Length; i++)
            {
                Console.ResetColor();
                if (i == punto)
                {
                    centraScritto2volte(creaStringaDiSpazi(testo[i].Length), " ", " ");
                    Console.ResetColor();

                }

                centraScritto2volte(creaStringaDiSpazi(testo[i].Length), " ", " ");
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
            }

            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
            return punto;
        }
        public static string creaStringaDiSpazi(int larghezzaStringa)
        {
            string output = "";
            for (int i = 0; i < larghezzaStringa; i++)
            {
                output += " ";
            }
            return output;
        }

        public static void centra(string input, string coloretesto, string coloresfondo)
        {
            int larghezzaWindow = Console.BufferWidth;
            coloretesto = colore(coloretesto, 0);
            coloresfondo = colore(coloresfondo, 1);
            ConsoleColor color1 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), coloretesto);
            ConsoleColor color2 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), coloresfondo);
            Console.ForegroundColor = color1;
            string paddingString = "";
            int padding;
            string output;
            if (input.Length < larghezzaWindow)
            {
                padding = larghezzaWindow / 2 - (input.Length / 2);
                Console.SetCursorPosition(padding, Console.CursorTop);
                Console.BackgroundColor = color2;
                Console.Write(input);
                Console.ResetColor();
                Console.ForegroundColor = color1;
            }
            else
            {
                output = input.Substring(input.Length - (input.Length % larghezzaWindow), (input.Length % larghezzaWindow));
                input = input.Remove(input.Length - (input.Length % larghezzaWindow));
                padding = larghezzaWindow / 2 - output.Length / 2;
                Console.BackgroundColor = color2;
                Console.Write(input);
                Console.SetCursorPosition(padding, Console.CursorTop);
                Console.ForegroundColor = color1;
                Console.BackgroundColor = color2;
                Console.WriteLine(output);
                Console.BackgroundColor = color2;
                Console.ResetColor();
                Console.ForegroundColor = color1;

            }


        }
        /// <summary>
        /// Utilizzo in Console, incentra il testo inserito.
        /// </summary>
        /// <param name="input">Testo da scrivere</param>
        /// <param name="arretra">Scentra il testo, sposta di n caselle il testo centrato</param>
        /// <param name="coloretesto">Colore del testo</param>
        /// <param name="coloresfondo">Colore dello Sfondo</param>
        public static void centra(string input,int arretra, string coloretesto, string coloresfondo)
        {
            int larghezzaWindow = Console.BufferWidth;
            coloretesto = colore(coloretesto, 0);
            coloresfondo = colore(coloresfondo, 1);
            ConsoleColor color1 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), coloretesto);
            ConsoleColor color2 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), coloresfondo);
            Console.ForegroundColor = color1;
            string paddingString = "";
            int padding;
            string output;
            if (input.Length < larghezzaWindow)
            {
                padding = larghezzaWindow / 2 - (input.Length / 2)-arretra;
                Console.SetCursorPosition(padding, Console.CursorTop);
                Console.BackgroundColor = color2;
                Console.Write(input);
                Console.ResetColor();
                Console.ForegroundColor = color1;
            }
            else
            {
                output = input.Substring(input.Length - (input.Length % larghezzaWindow), (input.Length % larghezzaWindow));
                input = input.Remove(input.Length - (input.Length % larghezzaWindow));
                padding = (larghezzaWindow / 2 - output.Length / 2) - arretra;
                Console.BackgroundColor = color2;
                Console.Write(input);
                Console.SetCursorPosition(padding, Console.CursorTop);
                Console.ForegroundColor = color1;
                Console.BackgroundColor = color2;
                Console.WriteLine(output);
                Console.BackgroundColor = color2;
                Console.ResetColor();
                Console.ForegroundColor = color1;

            }


        }
        public static void aspetta(int tempo)
        {
            System.Threading.Thread.Sleep(tempo);

        }
        public static void centraScritto2volte(string input, string coloretesto, string coloresfondo)
        {
            int larghezzaWindow = Console.BufferWidth;
            coloretesto = colore(coloretesto, 0);
            coloresfondo = colore(coloresfondo, 1);
            ConsoleColor color1 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), coloretesto);
            ConsoleColor color2 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), coloresfondo);
            Console.ForegroundColor = color1;
            string paddingString = "";
            int padding;
            string output;
            if (input.Length < larghezzaWindow / 2)
            {
                padding = larghezzaWindow / 4 - (input.Length / 2 + 1);
                Console.SetCursorPosition(padding, Console.CursorTop);
                Console.BackgroundColor = color2;
                Console.Write(input);
                Console.SetCursorPosition(Console.CursorLeft + padding * 2 - 1, Console.CursorTop);
                Console.Write(input);
                Console.ResetColor();
                Console.ForegroundColor = color1;
            }
            else
            {
                Console.BackgroundColor = color2;
                for (int i = 0; i <= input.Length / Console.BufferWidth / 2; i++)
                {
                    Console.Write(input.Substring(i * Console.BufferWidth / 2, Console.BufferWidth / 2) + input.Substring(i * Console.BufferWidth / 2, Console.BufferWidth / 2));
                }

                input = input.Substring(input.Length - input.Length % Console.BufferWidth / 2, input.Length % Console.BufferWidth / 2);
                padding = larghezzaWindow / 4 - (input.Length / 2);
                Console.SetCursorPosition(padding, Console.CursorTop);
                Console.BackgroundColor = color2;
                Console.Write(input);
                Console.SetCursorPosition(Console.CursorLeft + padding * 2, Console.CursorTop);
                Console.Write(input);
                Console.ResetColor();
                Console.ForegroundColor = color1;
            }


        }

        public static void intestazione1(string input, string coloretesto, string coloresfondo)
        {
            coloretesto = colore(coloretesto, 0);
            coloresfondo = colore(coloresfondo, 1);
            ConsoleColor color1 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), coloretesto);
            ConsoleColor color2 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), coloresfondo);
            Console.ForegroundColor = color1;
            string output, output2, porzione;
            int righe = (input.Length / 78) + 1, i = 0, padding;
            Console.Write("╔══════════════════════════════════════════════════════════════════════════════╗");
            do
            {
                if (righe == 1)
                {
                    porzione = input.Substring(input.Length - input.Length % 78, input.Length % 78);

                    padding = input.Length % 2 == 0 ? (39 - ((input.Length % 78) / 2) + input.Length % 78) : (39 - ((input.Length % 78) / 2)) - 1 + input.Length % 78;

                    output = porzione.PadLeft(padding);
                    output = output.Replace(input.Substring(input.Length - input.Length % 78, input.Length % 78), "");
                    output2 = porzione.PadRight(input.Length % 2 == 0 ? padding : padding + 1);
                    output = output + output2;
                    Console.BackgroundColor = color2;

                    Console.Write("║" + output + "║");
                    Console.ResetColor();
                    Console.ForegroundColor = color1;
                    break;
                }
                else
                {
                    Console.BackgroundColor = color2;
                    Console.Write("║" + input.Substring(77 * i, 78) + "║");
                    Console.ResetColor();
                    Console.ForegroundColor = color1;
                    righe--;
                }

                i++;
            } while (righe != 0);
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");

        }
        public static void intestazione1(string input, string input2, string coloretesto, string coloresfondo)
        {
            coloretesto = colore(coloretesto, 0);
            coloresfondo = colore(coloresfondo, 1);
            ConsoleColor color1 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), coloretesto);
            ConsoleColor color2 = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), coloresfondo);

            string output, output2, porzione;
            int righe = (input.Length / 78) + 1, i = 0, padding;
            Console.ForegroundColor = color1;
            Console.Write("╔══════════════════════════════════════════════════════════════════════════════╗");
            do
            {
                if (righe == 1)
                {
                    porzione = input.Substring(input.Length - input.Length % 78, input.Length % 78);

                    padding = input.Length % 2 == 0 ? (39 - ((input.Length % 78) / 2) + input.Length % 78) : (39 - ((input.Length % 78) / 2)) - 1 + input.Length % 78;

                    output = porzione.PadLeft(padding);
                    output = output.Replace(input.Substring(input.Length - input.Length % 78, input.Length % 78), "");
                    output2 = porzione.PadRight(input.Length % 2 == 0 ? padding : padding + 1);
                    output = output + output2;
                    Console.BackgroundColor = color2;
                    Console.Write("║" + output + "║");
                    Console.ResetColor();
                    Console.ForegroundColor = color1;
                    righe--;
                }
                else
                {
                    Console.BackgroundColor = color2;
                    Console.Write("║" + input.Substring(77 * i, 78) + "║");

                    Console.ResetColor();
                    Console.ForegroundColor = color1;
                    righe--;
                }

                i++;
            } while (righe != 0);
            Console.Write("╚══════════════════════════════════════════════════════════════════════════════╝");
            righe = (input2.Length / 78) + 1;
            i = 0;
            do
            {
                if (righe == 1)
                {
                    porzione = input2.Substring(input2.Length - input2.Length % 78, input2.Length % 78);

                    padding = input2.Length % 2 == 0 ? (39 - ((input2.Length % 78) / 2) + input2.Length % 78) : (39 - ((input2.Length % 78) / 2)) - 1 + input2.Length % 78;

                    output = porzione.PadLeft(padding);
                    output = output.Replace(input2.Substring(input2.Length - input2.Length % 78, input2.Length % 78), "");
                    output2 = porzione.PadRight(input2.Length % 2 == 0 ? padding : padding + 1);
                    output = output + output2;
                    Console.BackgroundColor = color2;
                    Console.Write("│" + output + "│");
                    Console.ResetColor();
                    Console.ForegroundColor = color1;

                    righe--;
                }
                else
                {
                    Console.BackgroundColor = color2;
                    Console.Write("│" + input2.Substring(77 * i, 78) + "│");

                    Console.ResetColor();
                    Console.ForegroundColor = color1;
                    righe--;
                }

                i++;
            } while (righe != 0);

            Console.Write("└──────────────────────────────────────────────────────────────────────────────┘");
        }
        public static string colore(string colore, int testoOSfondo)
        {

            colore = colore.ToLower();
            switch (colore)
            {
                case "rosso":
                    colore = "Red";
                    break;
                case "azzurro":
                    colore = "Cyan";
                    break;
                case "blu":
                    colore = "Blue";
                    break;
                case "blu scuro":
                    colore = "DarkBlue";
                    break;
                case "verde scuro":
                    colore = "DarkGreen";
                    break;
                case "verde":
                    colore = "Green";
                    break;
                case "bianco":
                    colore = "White";
                    break;
                case "grigio":
                    colore = "Gray";
                    break;
                case "giallo":
                    colore = "Yellow";
                    break;
                case "giallo scuro":
                    colore = "DarkYellow";
                    break;
                case "grigio scuro":
                    colore = "DarkGray";
                    break;
                case "azzurro scuro":
                    colore = "DarkCyan";
                    break;
                case "magenta":
                    colore = "Magenta";
                    break;
                case "magenta scuro":
                    colore = "DarkMagenta";
                    break;
                case "rosso scuro":
                    colore = "DarkRed";
                    break;
                case "nero":
                    colore = "Black";
                    break;
                default:
                    if (testoOSfondo == 0)
                        colore = "White";
                    else
                        colore = "Black";
                    break;
            }
            return colore;






        }
    }
}
/*
 ██░ ██ ▓█████  ██▀███   ███▄ ▄███▓ ▄▄▄       ███▄    █  ███▄    █     ██▓ ███▄    █  ▄████▄       
▓██░ ██▒▓█   ▀ ▓██ ▒ ██▒▓██▒▀█▀ ██▒▒████▄     ██ ▀█   █  ██ ▀█   █    ▓██▒ ██ ▀█   █ ▒██▀ ▀█       
▒██▀▀██░▒███   ▓██ ░▄█ ▒▓██    ▓██░▒██  ▀█▄  ▓██  ▀█ ██▒▓██  ▀█ ██▒   ▒██▒▓██  ▀█ ██▒▒▓█    ▄      
░▓█ ░██ ▒▓█  ▄ ▒██▀▀█▄  ▒██    ▒██ ░██▄▄▄▄██ ▓██▒  ▐▌██▒▓██▒  ▐▌██▒   ░██░▓██▒  ▐▌██▒▒▓▓▄ ▄██▒     
░▓█▒░██▓░▒████▒░██▓ ▒██▒▒██▒   ░██▒ ▓█   ▓██▒▒██░   ▓██░▒██░   ▓██░   ░██░▒██░   ▓██░▒ ▓███▀ ░ ██▓ 
 ▒ ░░▒░▒░░ ▒░ ░░ ▒▓ ░▒▓░░ ▒░   ░  ░ ▒▒   ▓▒█░░ ▒░   ▒ ▒ ░ ▒░   ▒ ▒    ░▓  ░ ▒░   ▒ ▒ ░ ░▒ ▒  ░ ▒▓▒ 
 ▒ ░▒░ ░ ░ ░  ░  ░▒ ░ ▒░░  ░      ░  ▒   ▒▒ ░░ ░░   ░ ▒░░ ░░   ░ ▒░    ▒ ░░ ░░   ░ ▒░  ░  ▒    ░▒  
 ░  ░░ ░   ░     ░░   ░ ░      ░     ░   ▒      ░   ░ ░    ░   ░ ░     ▒ ░   ░   ░ ░ ░         ░   
 ░  ░  ░   ░  ░   ░            ░         ░  ░         ░          ░     ░           ░ ░ ░        ░  
                                                                                     ░          ░
*/

using System;

namespace Hermann_Fuessel_MAK;

internal class Program {
    static void PrintMenue(ref int top, int left) {
        string[] menuItems = {
            "a. Dreick",
            "b. Anzahl der Unterrichtseinheiten",
            "c. Programm beenden",
        };
        for (int i = 0; i < menuItems.Count(); i++) {
            Console.SetCursorPosition(left, top++);
            Console.Write(menuItems[i]);
        }
    }

    static string ReadString(string prefix, int left, ref int top) {
        string? txt = null;
        do {
            Console.SetCursorPosition(left, top);
            Console.Write(prefix);
            txt = Console.ReadLine();
        } while (txt == "" || string.IsNullOrEmpty(txt) || string.IsNullOrWhiteSpace(txt));
        top++;
        return txt;
    }

    static string ReadPath(string prefix, int left, ref int top) {
        string? path = null;
        do {
            path = ReadString(prefix, left, ref top);
        } while (!File.Exists(path));
        top++;
        return path;
    }

    static char ReadChar(string prefix, int left, ref int top) {
        char result = new char();
        string? txt = null;
        do {
            Console.SetCursorPosition(left, top);
            Console.Write(prefix);
            txt = Console.ReadLine();
        } while (!char.TryParse(txt, out result));
        top++;
        return result;
    }

    static int ReadInt(string prefix, int left, ref int top) {
        int result = 0;
        string? txt = null;
        do {
            Console.SetCursorPosition(left, top);
            Console.Write(prefix);
            txt = Console.ReadLine();
        } while (!int.TryParse(txt, out result));
        top++;
        return result;
    }

    static void HandleMenuA(int left, int top) {
        int dim = ReadInt("Größe: ", left, ref top);
        char drawChar = ReadChar("Zeichen: ", left, ref top);
        Console.Clear();
        DrawTriangle(dim, drawChar);
    }

    static void DrawTriangle(int dim, char drawChar) {
        string printStr = "";

        for (int i = 0; i <= dim; i++) printStr += drawChar;

        for (int i = 0; i < dim; i++) {
            string tmpStr = printStr;
            printStr = "";
            foreach (char c in tmpStr.SkipLast(1)) printStr += c;
            Console.WriteLine(printStr);
        }
    }

    static void HandleMenuB(int left, int top) {
        string path = ReadPath("Dateipfad: ", left, ref top);
        string teacher = ReadString("Lehrer: ", left, ref top);
        Console.Clear();
        string text = File.ReadAllText(path);
        int nOfLessons = GetNOfLessonsForTeacher(text, teacher);

        Console.WriteLine($"Lehrer \"{teacher}\" hat {nOfLessons} Unterrichtsstunden.");
    }

    static int GetNOfLessonsForTeacher(string text, string teacher) {
        int res = 0;

        string[] lines = text.Split('\n');
        foreach (string line in lines) {
            string tmpLine = line.Replace(" ", "");
            if (!tmpLine.Contains(':')) continue;
            tmpLine = tmpLine.Split(':')[1];
            
            string[] lineParts = tmpLine.Split(';');
            foreach (string part in lineParts) {
                string tmpPart = part.Split('{')[1];
                tmpPart = tmpPart.Split('}')[0];
                string t = tmpPart.Split(',')[1];
                if (t == teacher) res++;
            }
        }

        return res;
    }

    static void Main(string[] args) {
        char? c = null;
        int top = 0,
            origTop = top;
        int left = 0;
        bool wait = false;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();

        bool clear = true;
        do {
            if (clear) Console.Clear();
            clear = true;
            top = origTop;
            PrintMenue(ref top, left);

            Console.SetCursorPosition(left, top++);
            Console.Write("> ");
            c = Console.ReadKey().KeyChar;
            Console.SetCursorPosition(left, ++top);
            switch (c) {
                case 'a':
                    Console.Clear();
                    HandleMenuA(left, top);
                    wait = true;
                    break;
                case 'b':
                    Console.Clear();
                    HandleMenuB(left, top);
                    wait = true;
                    break;
                default:
                    Console.WriteLine("Unbekannte Auswahl!");
                    clear = false;
                    break;

                case 'c': break;
            }
            if(wait) {
                Console.WriteLine("Bitte eine beliebige Taste drücken um zurückzukehren.");
                Console.ReadKey();
                wait = false;
            }
            top--;
            Console.SetCursorPosition(left, top--);

        } while (c != 'c');
    }
}
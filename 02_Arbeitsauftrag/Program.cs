namespace Arbeitsauftrag02
{
    internal class Program
    {
        static void PrintMenue(ref int top, int left)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(left, top++);
                switch (i)
                {
                    case 0:
                        Console.WriteLine("1. Zeichnen einer vertikalen Linie");
                        break;
                    case 1:
                        Console.WriteLine("2. Zeichnen einer horizontalen Linie");
                        break;
                    case 2:
                        Console.WriteLine("3. Zeichnen eines Rechtecks");
                        break;
                    case 3:
                        Console.WriteLine("4. Zeichnen eines Grids");
                        break;
                    case 4:
                        Console.WriteLine("5. Programm beenden");
                        break;
                }
            }
        }

        static int ReadInt(string prefix, int left, ref int top)
        {
            int result;
            string? txt;
            do
            {
                Console.SetCursorPosition(left, top);
                Console.Write(prefix);
                txt = Console.ReadLine();
            } while (!int.TryParse(txt, out result));
            top++;
            return result;
        }

        static void DrawPixel(int left, int top)
        {
            try
            {
                Console.SetCursorPosition(left, top);
                Console.Write("*");
            } catch(Exception)
            { return; }
            
        }

        static void DrawVLine(int left, int top)
        {
            int tmpHeight = ReadInt("Höhe: ", left, ref top);
            Console.Clear();
            DrawVLine(left, top, tmpHeight);
            Thread.Sleep(2000);
        }

        static void DrawVLine(int left, int top, int height)
        {
            for (int i = 0; i < height; i++)
            {
                DrawPixel(left, top + i);
            }
        }

        static void DrawHLine(int left, int top)
        {
            int tmpWidth = ReadInt("Breite: ", left, ref top);
            Console.Clear();
            DrawHLine(left, top, tmpWidth);
            Thread.Sleep(2000);
        }

        static void DrawHLine(int left, int top, int width)
        {
            for (int i = 0; i < width; i++)
            {
                DrawPixel(left + i, top);
            }
        }

        static void DrawRectangle(int left, int top)
        {
            int tmpHeight = ReadInt("Höhe: ", left, ref top);
            int tmpWidth = ReadInt("Breite: ", left, ref top);
            Console.Clear();
            DrawRectangle(left, top, (int)tmpWidth, (int)tmpHeight);
            Thread.Sleep(2000);
        }

        static void DrawRectangle(int left, int top, int width, int height)
        {
            DrawHLine(left, top, width);
            DrawHLine(left, top + height - 1, width);
            DrawVLine(left, top, height);
            DrawVLine(left + width - 1, top, height);
        }

        static void DrawGrid(int top, int left)
        {
            int tmpCellSize = ReadInt("Zellengröße: ", left, ref top);
            int tmpRows = ReadInt("Zeilen: ", left, ref top);
            int tmpCols = ReadInt("Spalten: ", left, ref top);
            Console.Clear();
            DrawGrid(left, top, (int)tmpCellSize, (int)tmpRows, (int)tmpCols);
            Thread.Sleep(2000);
        }

        static void DrawGrid(int top, int left, int cellSize, int nOfRows, int nOfCols)
        {
            for (int i = 0; i < nOfRows; i++)
            {
                for (int j = 0; j < nOfCols; j++)
                {
                    DrawRectangle(left + j * cellSize, top + i * cellSize, cellSize+1, cellSize+1);
                }
            }
        }

        static void Main()
        {
            char? c;
            int top = 10,
                origTop = top;
            int left = 10;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();

            bool clear = true;
            do
            {
                if (clear) Console.Clear();
                clear = true;
                top = origTop;
                PrintMenue(ref top, left);

                Console.SetCursorPosition(left, top++);
                Console.Write("> ");
                c = Console.ReadKey().KeyChar;
                Console.SetCursorPosition(left, ++top);
                switch (c)
                {
                    case '1':
                        Console.Clear();
                        DrawVLine(left, top);
                        break;
                    case '2':
                        Console.Clear();
                        DrawHLine(left, top);
                        break;
                    case '3':
                        Console.Clear();
                        DrawRectangle(left, top);
                        break;
                    case '4':
                        Console.Clear();
                        DrawGrid(left, top);
                        break;

                    default:

                        Console.WriteLine("Unbekannte Auswahl!");
                        clear = false;
                        break;

                    case '5': break;
                }
                top--;
                Console.SetCursorPosition(left, top--);

            } while (c != '5');
        }
    }
}
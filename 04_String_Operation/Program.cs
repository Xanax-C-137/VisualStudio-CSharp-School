namespace TextContentAnalyser;

internal class Program {
    static void Main() {
        string? path = string.Empty;
        while(true) {

        
            do {
                Console.Clear();
                if (!string.IsNullOrEmpty(path) && !File.Exists(path)) { Console.WriteLine($"Die Datei existiert nicht!\n"); }
                Console.WriteLine("Geben Sie einen Dateipfad ein:");
                Console.Write("> ");
                path = Console.ReadLine();
            } while (!File.Exists(path));

            FileInfo f = OpenFile(path);

            string text = ReadTextFile(f);

            Console.WriteLine($"Anzahl der Zeilen: {CountLines(text)}");
            Console.WriteLine($"Anzahl der Wörter: {CountWords(text)}");
            Console.WriteLine($"Anzahl der Buchstaben: {CountLetters(text)}");

            int[] marks = CountPunctuationMarks(path);

            Console.WriteLine($"Anzahl der Punkte: {marks[0]}");
            Console.WriteLine($"Anzahl der Beistriche: {marks[1]}");
            Console.ReadLine();
        }
    }

    static FileInfo OpenFile(string path) {
        return new FileInfo(path);
    }

    static string ReadTextFile(FileInfo f) {
        if(!f.Exists) {
            return string.Empty;
        }
        return File.ReadAllText(f.FullName);
    }

    static int CountLines(string filetext) {
        return filetext.Split(new char[] { '\n' }).Length;
    }

    static int CountWords(string filetext) {
        return filetext.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries).Length;
    }

    static int CountLetters(string filetext) {
        int count = 0;
        foreach (char item in filetext) {
            if (!char.IsLetter(item)) continue;
            count++;
        }
        return count;
    }

    static int[] CountPunctuationMarks(string path) {
        int[] parts = new int[2] {0, 0};

        string text = ReadTextFile(OpenFile(path));

        foreach (char c in text) {
            switch(c) {
                case '.':
                    parts[0]++;
                    break;
                case ',':
                    parts[1]++;
                    break;
            }
        }

        return parts;
    }
}
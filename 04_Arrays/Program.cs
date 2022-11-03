namespace Arrays;

class Program {
    static void Array(string[] args) {
        int[] arr = new int[10];

        int[] arr2 = { 1, 3, 4, 4 };

        Console.Write(arr[1]);

        arr[2] = 10;

        for (int i = 0; i < arr2.Length; i++) {
            Console.Write(arr2[i]);
        }

        foreach (int i in arr2) {
            Console.Write(i);
        }
    }

    static void Matrix(string[] args) {
        int[,] matrix = new int[2, 3];

        int[,] matrix2 = { { 120, 125}, { 14, 25 }, { 12, 12 } };

        matrix2[1, 0] = 100;

        for(int row = 0; row < matrix2.GetLength(0); row++) {
            for (int col = 0; col < matrix2.GetLength(1); col++) {
                Console.WriteLine(matrix2[row,col]);
            }
        }
    }

    static void Main(string[] args) {
        int[][] matrix = new int[2][];

        matrix[0] = new int[] { 10, 20 };

        matrix[1] = new int[] { 10, 20, 30 };

        Random r = new Random();

        for (int row = 0; row < matrix.Length; row++) {
            for(int col = 0; col < matrix[row].Length; col++) {
                matrix[row][col] = r.Next(1000)+1;
                Console.Write($"{matrix[row][col]}, ");
            }
            Console.WriteLine();
        }
    }
}
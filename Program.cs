using System;

class Program
{
    static void Main()
    {
        // TASK 2
        Console.WriteLine("===== TASK 2 =====");

        int[,] arr = new int[5, 5];
        Random random = new Random();

        int min = 0;
        int max = 0;

        int minIndex = 0;
        int maxIndex = 0;

        Console.WriteLine("Array:");

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                arr[i, j] = random.Next(-100, 101);

                Console.Write(arr[i, j] + "\t");

                int currentIndex = i * 5 + j;

                if (i == 0 && j == 0)
                {
                    min = arr[i, j];
                    max = arr[i, j];
                    minIndex = currentIndex;
                    maxIndex = currentIndex;
                }

                if (arr[i, j] < min)
                {
                    min = arr[i, j];
                    minIndex = currentIndex;
                }

                if (arr[i, j] > max)
                {
                    max = arr[i, j];
                    maxIndex = currentIndex;
                }
            }

            Console.WriteLine();
        }

        int start = minIndex;
        int end = maxIndex;

        if (start > end)
        {
            int temp = start;
            start = end;
            end = temp;
        }

        int sum = 0;

        for (int index = start + 1; index < end; index++)
        {
            int row = index / 5;
            int col = index % 5;

            sum += arr[row, col];
        }

        Console.WriteLine();
        Console.WriteLine("Minimum element: " + min);
        Console.WriteLine("Maximum element: " + max);
        Console.WriteLine("Sum between min and max: " + sum);

        Console.WriteLine();


        // TASK 3
        Console.WriteLine("===== TASK 3 =====");

        Console.Write("Enter text: ");
        string text = Console.ReadLine();

        Console.Write("Enter shift: ");
        int shift = int.Parse(Console.ReadLine());

        string encrypted = "";
        string decrypted = "";

        for (int i = 0; i < text.Length; i++)
        {
            char ch = text[i];

            if (ch >= 'A' && ch <= 'Z')
            {
                char newChar = (char)((ch - 'A' + shift) % 26 + 'A');
                encrypted += newChar;
            }
            else if (ch >= 'a' && ch <= 'z')
            {
                char newChar = (char)((ch - 'a' + shift) % 26 + 'a');
                encrypted += newChar;
            }
            else
            {
                encrypted += ch;
            }
        }

        for (int i = 0; i < encrypted.Length; i++)
        {
            char ch = encrypted[i];

            if (ch >= 'A' && ch <= 'Z')
            {
                char newChar = (char)((ch - 'A' - shift + 26) % 26 + 'A');
                decrypted += newChar;
            }
            else if (ch >= 'a' && ch <= 'z')
            {
                char newChar = (char)((ch - 'a' - shift + 26) % 26 + 'a');
                decrypted += newChar;
            }
            else
            {
                decrypted += ch;
            }
        }

        Console.WriteLine("Encrypted text: " + encrypted);
        Console.WriteLine("Decrypted text: " + decrypted);
    }
}
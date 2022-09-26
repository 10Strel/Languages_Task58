/*
Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

int rows = 0, columns = 0;
Random random = new Random();

if (!InputControl("Задайте размерность матриц (m n)", ref rows, ref columns))
    return;

int[,] matrixA = InitMatrix(rows, columns);

int[,] matrixB = InitMatrix(rows, columns);

int[,] matrixAB = DoMultiplication(matrixA, matrixB);

Console.WriteLine("Матрица А:");
PrintMatrix(matrixA);

Console.WriteLine("Матрица B:");
PrintMatrix(matrixB);

Console.WriteLine("Результат AB:");
PrintMatrix(matrixAB);


# region methods

bool InputControl(string caption, ref int m, ref int n)
{
    int tryCount = 3;
    string inputStr = string.Empty;
    bool resultInputCheck = false;

    while (!resultInputCheck)
    {
        Console.WriteLine($"\r\n{caption} (количество попыток: {tryCount}):");
        inputStr = Console.ReadLine() ?? string.Empty;

        string[] inputStringArray = inputStr.Split(new char[] { ' ', ';' });

        resultInputCheck =
            inputStringArray.Length == 2 &&
            int.TryParse(inputStringArray[0], out m) &&
            m > 0 &&
            int.TryParse(inputStringArray[1], out n) &&
            n > 0;

        if (!resultInputCheck)
        {
            tryCount--;

            if (tryCount == 0)
            {
                Console.WriteLine("\r\nВы исчерпали все попытки.\r\nВыполнение программы будет остановлено.");
                return false;
            }
        }
    }

    return true;
}

int[,] InitMatrix(int m, int n)
{
    int[,] array = new int[m, n];

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            array[i, j] = random.Next(0, 10);
        }
    }

    return array;
}

int[,] DoMultiplication(int[,] matrix0, int[,] matrix1)
{
    int[,] result = new int[matrix0.GetLength(0), matrix0.GetLength(1)];

    for (int i = 0; i < matrix0.GetLength(0); i++)
    {
        for (int j = 0; j < matrix1.GetLength(1); j++)
        {
            for (int k = 0; k < matrix1.GetLength(0); k++)
            {
                result[i, j] += matrix0[i, k] * matrix1[k, j];
            }
        }
    }

    return result;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}\t");
        }

        Console.WriteLine();
    }

    Console.WriteLine();
}

# endregion





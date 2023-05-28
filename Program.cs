//-------------------------------------------------------------------------------------------------------------------------------------------
// Задача 1: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

//------functions------
double[,] CreateArray(int rows, int columns)
{
    double[,] array = new double[rows, columns];
    double random;
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
        {
            random = new Random().Next(10, 100);
            array[i, j] = random;
        }
    return array;
}

void ShowArray(double[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write(array[i, j] + " ");
        Console.WriteLine();
    }
    Console.WriteLine();
}

//bubble method
void SortRowsBubble(double[,] array)
{
    double temp;
    for (int rowIndex = 0; rowIndex < array.GetLength(0); rowIndex++)
        for (int i = 0; i < array.GetLength(1) - 1; i++)
        {
            for (int j = i + 1; j < array.GetLength(1); j++)
            {
                if (array[rowIndex, i] < array[rowIndex, j])
                {
                    temp = array[rowIndex, i];
                    array[rowIndex, i] = array[rowIndex, j];
                    array[rowIndex, j] = temp;
                }
            }
        }
}

// ------main------
Console.Write("Введите количество строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());

double[,] arr = CreateArray(rows, columns);
ShowArray(arr);
SortRowsBubble(arr);
ShowArray(arr);

//-------------------------------------------------------------------------------------------------------------------------------------------
// Задача 2: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

//------functions------
double[,] CreateArray(int rows, int columns)
{
    double[,] array = new double[rows, columns];
    double random;
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
        {
            random = new Random().Next(10, 100);
            array[i, j] = random;
        }
    return array;
}

void ShowArray(double[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write(array[i, j] + " ");
        Console.WriteLine();
    }
    Console.WriteLine();
}

void FindMinSumRow(double[,] array)
{
    double sumRow = 0;
    double currentMinRow = 100000;
    int currentMinRowIndex = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            sumRow += array[i, j];
        Console.WriteLine("SumRow" + i + " = " + sumRow);
        if (sumRow < currentMinRow)
        {
            currentMinRow = sumRow;
            currentMinRowIndex = i + 1;
        }
        sumRow = 0;
    }
    Console.WriteLine("Minimum sum: " + currentMinRow + " in " + currentMinRowIndex + " row");
}

// ------main------
Console.Write("Введите количество строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());

double[,] arr = CreateArray(rows, columns);
ShowArray(arr);
FindMinSumRow(arr);

//-------------------------------------------------------------------------------------------------------------------------------------------
// Задача 3: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

//------functions------
int[,] CreateArray(int rows, int columns)
{
    int[,] array = new int[rows, columns];
    int random;
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
        {
            random = new Random().Next(0, 10);
            array[i, j] = random;
        }
    return array;
}

void ShowArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write(array[i, j] + " ");
        Console.WriteLine();
    }
    Console.WriteLine();
}

int RowsCount(int[,] array)
{
    return array.GetUpperBound(0) + 1;
}

int ColumnsCount(int[,] array)
{
    return array.GetUpperBound(1) + 1;
}

int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB)
{
    if (ColumnsCount(matrixA) != RowsCount(matrixB))
    {
        throw new Exception("Умножение невозможно! Количество столбцов первой матрицы должно равняться количеству строк второй матрицы.");
    }

    var matrixC = new int[RowsCount(matrixA), ColumnsCount(matrixB)];

    for (var i = 0; i < RowsCount(matrixA); i++)
    {
        for (var j = 0; j < ColumnsCount(matrixB); j++)
        {
            matrixC[i, j] = 0;

            for (var k = 0; k < ColumnsCount(matrixA); k++)
            {
                matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
            }
        }
    }

    return matrixC;
}

//------main------
Console.Write("Введите количество строк первой матрицы: ");
int rowsMatrixA = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов первой матрицы: ");
int columnsMatrixA = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество строк второй матрицы: ");
int rowsMatrixB = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов второй матрицы: ");
int columnsMatrixB = Convert.ToInt32(Console.ReadLine());
int[,] matrixA = CreateArray(rowsMatrixA, columnsMatrixA);
int[,] matrixB = CreateArray(rowsMatrixB, columnsMatrixB);
ShowArray(matrixA);
ShowArray(matrixB);
ShowArray(MatrixMultiplication(matrixA, matrixB));

//-------------------------------------------------------------------------------------------------------------------------------------------
// Задача 4. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить 
//массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

//------functions------
double[,,] CreateArray(int rows, int columns, int zCount)
{
    double[,,] array = new double[rows, columns, zCount];
    double number = 10;
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
            for (int k = 0; k < zCount; k++)
            {
                array[i, j, k] = number;
                number++;
            }
    return array;
}

void ShowArray(double[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            for (int k = 0; k < array.GetLength(2); k++)
                Console.Write($"{array[i, j, k]}({i},{j},{k}) ");
        Console.WriteLine();
    }
    Console.WriteLine();
}


// ------main------
Console.Write("Введите количество строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество Z: ");
int zCount = Convert.ToInt32(Console.ReadLine());

double[,,] arr = CreateArray(rows, columns, zCount);
ShowArray(arr);

//-------------------------------------------------------------------------------------------------------------------------------------------
// Задача 5. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

//------functions------
double[,] CreateArray(int rows, int columns)
{
    double[,] array = new double[rows, columns];
    double countArray = rows + columns;

    int iStart = 0, iEnd = 0, jStart = 0, jEnd = 0;

    int k = 10;
    int i = 0;
    int j = 0;

    while (k <= rows * columns + 9)
    {
        array[i, j] = k;
        if (i == iStart && j < columns - jEnd - 1)
            j++;
        else if (j == columns - jEnd - 1 && i < rows - iEnd - 1)
            i++;
        else if (i == rows - iEnd - 1 && j > jStart)
            j--;
        else
            i--;

        if ((i == iStart + 1) && (j == jStart) && (jStart != columns - jEnd - 1))
        {
            iStart++;
            iEnd++;
            jStart++;
            jEnd++;
        }
        k++;
    }

    return array;
}

void ShowArray(double[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write(array[i, j] + " ");
        Console.WriteLine();
    }
    Console.WriteLine();
}

// ------main------
Console.Write("Введите количество строк: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
int columns = Convert.ToInt32(Console.ReadLine());

double[,] arr = CreateArray(rows, columns);
ShowArray(arr);
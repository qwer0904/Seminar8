Console.Write("Введите номер задачи: ");
int a = 0;
try{
a = Convert.ToInt32(Console.ReadLine());
} catch (System.FormatException){
    Console.Write("Это не номер");
    return;
}

switch (a){

    case 54:
    task54();
    break;

    case 56:
    task56();
    break;

    case 58:
    task58();
    break;

    case 60:
    task60();
    break;

    case 62:
    task62();
    break;

    default: 
    Console.WriteLine("Нет такой задачи(");
    break;
}

// Task 54. Задайте двумерный массив. Напишите программу, которая упорядочит
// по убыванию элементы каждой строки двумерного массива

void task54(){
        int[,] array = {
            {1, 4, 7, 2},
            {5, 9, 2, 3},
            {8, 4, 2, 4}
        };

        int numRows = array.GetLength(0);
        int numColumns = array.GetLength(1);

        for (int rowIndex = 0; rowIndex < numRows; rowIndex++)
        {
            for (int i = 0; i < numColumns - 1; i++)
            {
                for (int j = 0; j < numColumns - i - 1; j++)
                {
                    if (array[rowIndex, j] < array[rowIndex, j + 1])
                    {
                        int temp = array[rowIndex, j];
                        array[rowIndex, j] = array[rowIndex, j + 1];
                        array[rowIndex, j + 1] = temp;
                    }
                }
            }
        }

        Console.WriteLine("Упорядоченный массив по убыванию:");
        for (int rowIndex = 0; rowIndex < numRows; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < numColumns; columnIndex++)
            {
                Console.Write(array[rowIndex, columnIndex] + " ");
            }
            Console.WriteLine();
        }

        Console.ReadLine();
}

// Task 56. Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов

void task56(){
        int[,] array = {
            {1, 4, 7, 2},
            {5, 9, 2, 3},
            {8, 4, 2, 4},
            {5, 2, 6, 7}
        };

        int numRows = array.GetLength(0);
        int numColumns = array.GetLength(1);

        int minRowIndex = 0;
        int minRowSum = int.MaxValue;

        for (int rowIndex = 0; rowIndex < numRows; rowIndex++)
        {
            int currentRowSum = 0;
            for (int columnIndex = 0; columnIndex < numColumns; columnIndex++)
            {
                currentRowSum += array[rowIndex, columnIndex];
            }

            if (currentRowSum < minRowSum)
            {
                minRowSum = currentRowSum;
                minRowIndex = rowIndex;
            }
        }

        Console.WriteLine("Строка с наименьшей суммой элементов: " + (minRowIndex + 1));

        Console.ReadLine();
}

// Task 58. Задайте две матрицы. Напишите программу, которая будет 
// находить произведение двух матриц.

void task58(){

        int[,] matrix1 = {
            {2, 4},
            {3, 2},
        };

        int[,] matrix2 = {
            {3, 4},
            {3, 3}
        };

        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1); 
        int cols2 = matrix2.GetLength(1); 

        if (cols1 != matrix2.GetLength(0))
        {
            Console.WriteLine("Умножение матриц невозможно. Количество столбцов в первой матрице должно быть равно количеству строк во второй матрице.");
        }
        else
        {
            int[,] resultMatrix = new int[rows1, cols2];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < cols1; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    resultMatrix[i, j] = sum;
                }
            }

            Console.WriteLine("Результат умножения матриц:");
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    Console.Write(resultMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        Console.ReadLine();
}

// Task 60. Сформируйте трёхмерный массив из неповторяющихся двузначных
// чисел. Напишите программу, которая будет построчно выводить массив,
// добавляя индексы каждого элемента.

void task60(){
        Random random = new Random();

        int[,,] threeDimensionalArray = new int[2, 2, 2];
        bool[] usedNumbers = new bool[90];

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    int randomNumber;
                    do
                    {
                        randomNumber = random.Next(10, 100);
                    } while (usedNumbers[randomNumber - 10]);

                    threeDimensionalArray[i, j, k] = randomNumber;
                    usedNumbers[randomNumber - 10] = true;
                }
            }
        }

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    Console.WriteLine(threeDimensionalArray[i, j, k] + "(" + i + "," + j + "," + k + ")");
                }
            }
        }

        Console.ReadLine();
}

// Task62. Напишите программу, которая заполнит спирально массив 4 на 4

void task62(){
        int[,] array = new int[4, 4];
        int value = 1;
        int top = 0, bottom = 3, left = 0, right = 3;

        while (value <= 16)
        {
            for (int i = left; i <= right; i++)
            {
                array[top, i] = value++;
            }
            top++;

            for (int i = top; i <= bottom; i++)
            {
                array[i, right] = value++;
            }
            right--;

            for (int i = right; i >= left; i--)
            {
                array[bottom, i] = value++;
            }
            bottom--;

            for (int i = bottom; i >= top; i--)
            {
                array[i, left] = value++;
            }
            left++;
        }

        Console.WriteLine("Спирально заполненный массив 4x4:");
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }

        Console.ReadLine();
}
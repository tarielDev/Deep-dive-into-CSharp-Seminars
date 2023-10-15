namespace Array2DSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Исходный двумерный массив
            int[,] arr2d = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } };

            // Получаем размеры массива
            int rows = arr2d.GetLength(0);
            int cols = arr2d.GetLength(1);

            // Преобразуем двумерный массив в одномерный для сортировки
            int[] arr1d = new int[rows * cols];
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr1d[index] = arr2d[i, j];
                    index++;
                }
            }

            // Сортируем одномерный массив
            Array.Sort(arr1d);

            // Восстанавливаем отсортированные значения в новый двумерный массив
            int[,] arrSorted = new int[rows, cols];
            index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arrSorted[i, j] = arr1d[index];
                    index++;
                }
            }

            // Выводим отсортированный двумерный массив в консоль
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(arrSorted[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
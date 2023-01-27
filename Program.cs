class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the name of the file:\n");
        string fileName = Console.ReadLine();
        int[] result = ReadArrayFromFile(fileName);
        Console.WriteLine("The following array: ");
        foreach(int el in result)
        {
            Console.Write(el + " ");
        }
        if (IsSorted(result) == true)
            Console.WriteLine(" is sorted.");

        else Console.WriteLine(" is NOT sorted.");
        int triplets = CountTriplets(result);
        Console.WriteLine($"\nThere are {triplets} triplets in the array");
    }


    static int[] ReadArrayFromFile(string filePath)
    {
        string content = File.ReadAllText($"{filePath}.txt");
        string[] elements = content.Split(new char[] { '\t' });
        int[] array = new int[elements.Length];

        for (int i = 0 ; i < elements.Length; i++)
        {
            array[i] = int.Parse(elements[i]);
        }
        return array;
        
    }
    static bool IsSorted(int[] array)
    {
        for(int i = 0; i < array.Length - 1; i++)
        {
            for(int j = i + 1; j < array.Length; j++)
            {   
                if (array[i] > array[j])
                {
                    return false;

                }
                
            }
        }
        return true;
    }

    static int CountTriplets(int[] array)
    {
        int count = 0;
        for(int i = 0; i < array.Length - 2;i++) 
        {
            for(int j = i + 1; j < array.Length - 1; j++)
            {
                for(int k = j + 1; k < array.Length; k++)
                {
                    if ((array[i] == array[j]) && (array[j] == array[k]))
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }
}
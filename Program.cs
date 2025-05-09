using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class Algoritms
{
    private int[] array = GenerateSortedArray(1000);
    private int value = 78;

    [Benchmark(Baseline = true)]
    public int FindIndexLinear()
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] == value)
                return i;
        }

        return -1;
    }

    [Benchmark]
    public int FindIndexBinary()
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (array[mid] < value)
            {
                left = mid + 1;
            }
            if (array[mid] > value)
            {
                right = mid - 1;
            }
            else
            {
                return array[mid];
            }
        }

        return -1;
    }

    static int[] GenerateSortedArray(int length)
    {
        int[] array = new int[length];

        for (int i = 0; i < length - 1; i++)
        {
            array[i] = i + 1;
        }

        return array;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<Algoritms>();
    }
}

using SFML.Graphics;
using SFML.Window;



class AlgorithmVisualizer
{
    static void AlgoVisualizer(List<int> arr, RenderWindow win, int i, int j)
    {

    }

    static int Main()
    {
        int start = 1;
        int end = 100;

        List<int> arr = Enumerable.Range(start, end - start + 1).OrderBy(x => Guid.NewGuid()).ToList();
        RenderWindow window = new RenderWindow(new VideoMode(1600, 900), "Algorithm Visualizer");
        window.Closed += (sender, e) => window.Close();

        int n = arr.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Swap arr[j] and arr[j+1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
                window.DispatchEvents();
                window.Clear(Color.Black);

                AlgoVisualizer(arr, window, i, j);
                window.Display();
                
            }
        }

        return 0;
    }
}
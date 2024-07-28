using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Threading;
using System.Collections.Generic;


class AlgorithmVisualizer
{
    static void AlgoVisualizer(List<int> arr, RenderWindow win, int i, int j)
    {
        int index = 0;
        foreach (int a in arr)
        {
            Color c = Color.Green;
            if (a == i)
            {
                c = Color.Red;
            }
            if (a == j)
            {
                c = Color.Blue;
            }
           
            
            VertexArray quad = new VertexArray(PrimitiveType.Quads, 4);
            quad[3] = new Vertex(new Vector2f(index, 700), c);
            quad[2] = new Vertex(new Vector2f(index + 4, 700), c);
            quad[1] = new Vertex(new Vector2f(index + 4, a), c);
            quad[0] = new Vertex(new Vector2f(index, a), c);

            index += 5;
            win.Draw(quad);
        }
    }

    static bool IsSorted(List<int> arr)
    {
        for (int i = 0; i < arr.Count - 1; i++)
        {
            if (arr[i] > arr[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    static int Main()
    {
        int start = 1;
        int end = 100;

        List<int> arr = Enumerable.Range(start, end - start + 1).OrderBy(x => Guid.NewGuid()).ToList();
        List<int> arr1 = Enumerable.Range(start, end - start + 1).OrderBy(x => Guid.NewGuid()).ToList();
        List<int> arr2 = Enumerable.Range(start, end - start + 1).OrderBy(x => Guid.NewGuid()).ToList();    
        RenderWindow window = new RenderWindow(new VideoMode(1600, 900), "Algorithm Visualizer");
        window.Closed += (sender, e) => window.Close();

        int n = arr1.Count;
        for (int i = 1; i < n; ++i)
        {
            int key = arr1[i];
            int j = i - 1;

            // Move elements of arr[0..i-1], that are greater than key,
            // to one position ahead of their current position
            while (j >= 0 && arr1[j] > key)
            {
                arr1[j + 1] = arr1[j];
                j = j - 1;
            }
            arr1[j + 1] = key;
            window.DispatchEvents();
            window.Clear(Color.Black);

            AlgoVisualizer(arr1, window, i, j);
            window.Display();
            Thread.Sleep(10);
        }
        window.Clear(Color.Transparent);
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr2[j] > arr2[j + 1])
                {
                    // Swap arr[j] and arr[j+1]
                    int temp = arr2[j];
                    arr2[j] = arr2[j + 1];
                    arr2[j + 1] = temp;
                }
                window.DispatchEvents();
                window.Clear(Color.Black);

                AlgoVisualizer(arr2, window, i, j);
                window.Display();
                Thread.Sleep(10);
            }

        }
        window.Clear(Color.Magenta);
        Random rand = new Random();
        while (!IsSorted(arr))
        {
            for (int i = arr.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                window.DispatchEvents();
                window.Clear(Color.Black);

                AlgoVisualizer(arr, window, i, j);
                window.Display();
                Thread.Sleep(10);
            }
        }


        return 0;
    }
}

using System;
using System.Collections.Generic;

namespace ConsecutiveTasks
{
    class ConsecutiveTasks
    {
        static void Main()
        {
            List<int> tasks = new List<int>() { 1, 2, 3, 4, 5, 6 };

            //to mark that the way from 2 to 5 is faster than the way from
            //2 to 4 we have to make weighted graph, bigger number means
            //faster way
            int[,] graph = {
                               {0,0,0,0,0,0,0},
                               {0,0,1,0,0,0,0},
                               {0,0,0,0,1,3,2},
                               {0,1,0,0,0,0,0},
                               {0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0},
                               {0,0,0,0,0,0,0}
                           };

            FindSequence(tasks, graph);
        }

        private static void FindSequence(List<int> tasks, int[,] graph)
        {
            bool sequenceFound = false;

            for (int i = 2; i < tasks.Count; i++)
            {
                List<int> currentSequence = new List<int>();

                TraverseGraph(tasks[i], graph, currentSequence);

                //we make this array to check if in the last iteration we have gone 
                //through all the nodes in the graph
                int[] currentSeqSorted = new int[currentSequence.Count];
                currentSequence.CopyTo(currentSeqSorted);

                Array.Sort(currentSeqSorted);
                if (AreArraysEqual(currentSeqSorted, tasks.ToArray()))
                {
                    sequenceFound = true;
                    Console.WriteLine("The right sequence found:");
                    Console.WriteLine(string.Join(",", currentSequence.ToArray()));
                    return;
                }
            }

            if (!sequenceFound)
                Console.WriteLine("Such sequence was not found!");
        }

        private static void TraverseGraph(int currentNode, int[,] graph,
           List<int> currentSequence)
        {
            if (!currentSequence.Contains(currentNode))
                currentSequence.Add(currentNode);

            int maxWeight = 0;
            int nextNode = 0;
            bool haveMoreVertices = true;
            bool vertexFound = false;

            //we will iterate until finding the fastest vertex, after that
            //the next fastest vertex and so on
            while (haveMoreVertices)
            {
                haveMoreVertices = false;
                int currentMaxWeight = 0;

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    //find the closest connection to other node
                    if (graph[currentNode,i] > 0)
                    {
                        if (!vertexFound && graph[currentNode, i] > maxWeight)
                        {
                            maxWeight = graph[currentNode, i];
                            nextNode = i;
                            haveMoreVertices = true;
                        }
                        else if (vertexFound && graph[currentNode, i] < maxWeight
                            && graph[currentNode, i] > currentMaxWeight)
                        {            
                            currentMaxWeight = graph[currentNode, i];
                            nextNode = i;
                            haveMoreVertices = true;
                        }
                    }
                }

                if (maxWeight != 0)
                {
                    maxWeight = graph[currentNode, nextNode];
                    vertexFound = true;
                    TraverseGraph(nextNode, graph, currentSequence);
                }
            }

        }

        //this method will check if two arrays are the same
        private static bool AreArraysEqual(int[] array1, int[] array2)
        {
            if (array1.Length != array2.Length)
                return false;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                    return false;
            }

            return true;
        }
    }
}

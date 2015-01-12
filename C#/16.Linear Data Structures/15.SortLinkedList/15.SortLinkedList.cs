using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLinkedList
{
    class SortLinkedList
    {
        static void Main()
        {
            int[] array = {-9, -8, 6, -6, 4, 2, 0, 10, 3, 1, -1000};
            LinkedList<int> listToSort = new LinkedList<int>(array);

            LinkedList<int> sortedList = SortList(listToSort);

            Console.WriteLine("The sorted list is: ");
            PrintList(sortedList);

        }

        private static LinkedList<int> SortList(LinkedList<int> listToSort)
        {
            bool hasSwapped = true;

            while (hasSwapped)
            {
                hasSwapped = false;

                LinkedListNode<int> currentNode = listToSort.First;
                while (currentNode != null && currentNode.Next != null)
                {
                    if (currentNode.Value > currentNode.Next.Value)
                    {
                        Swap(currentNode, currentNode.Next, listToSort);
                        hasSwapped = true;
                    }

                    currentNode = currentNode.Next;
                }
            }

            return listToSort;
        }

        private static void Swap(LinkedListNode<int> currentNode, LinkedListNode<int> nextNode, 
            LinkedList<int> listToSort)
        {
            listToSort.Remove(currentNode);
            listToSort.AddAfter(nextNode, currentNode);
        }

        private static void PrintList(LinkedList<int> sortedList)
        {
            LinkedListNode<int> currentNode = sortedList.First;
            while (currentNode != null)
            {
                Console.Write(currentNode.Value + " ");
                currentNode = currentNode.Next;
            }
            Console.WriteLine();
        }
    }
}

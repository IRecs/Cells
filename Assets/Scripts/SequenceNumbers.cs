using System.Collections.Generic;
using UnityEngine;

public static class SequenceNumbers
{
    public static List<int> Create(int count, int maxValue)
    {
        List<int> numbersFillers = new List<int>();

        while (numbersFillers.Count < count)
        {
            int number = Random.Range(0, maxValue);

            if (CheckForDuplication(numbersFillers, number))
                numbersFillers.Add(number);
        }

        return numbersFillers;
    }

    private static bool CheckForDuplication(List<int> numbersFillers, int number)
    {
        for (int i = 0; i < numbersFillers.Count; i++)
        {
            if (numbersFillers[i] == number)
                return false;
        }

        return true;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    Console.Write(string.Join(' ', nums));
                    break;
                }

                string[] parts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string comand = parts[0];
                int paintNumber; //
                int changeNumber;

                if (comand == "Change")
                {
                    paintNumber = int.Parse(parts[1]);

                    if (nums.Contains(paintNumber))  // if exists
                    {
                        changeNumber = int.Parse(parts[2]);
                        int idx = nums.IndexOf(paintNumber);
                        nums[idx] = changeNumber;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (comand == "Hide")
                {
                    paintNumber = int.Parse(parts[1]);

                    if (nums.Contains(paintNumber))
                    {
                        int idx = nums.IndexOf(paintNumber);
                        nums.RemoveAt(idx);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (comand == "Switch")
                {
                    paintNumber = int.Parse(parts[1]);
                    changeNumber = int.Parse(parts[2]);

                    if (nums.Contains(paintNumber) && nums.Contains(changeNumber))
                    {
                        int firstNum = paintNumber;
                        int idxFirst = nums.IndexOf(paintNumber);
                        int idxSec = nums.IndexOf(changeNumber);
                        nums[idxFirst] = changeNumber;
                        nums[idxSec] = firstNum;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (comand == "Insert")
                {
                    int existIdx = int.Parse(parts[1]);
                    changeNumber = int.Parse(parts[2]);

                    if (existIdx < -1 || existIdx >= nums.Count - 1)
                    {
                        continue;
                    }

                    nums.Insert(existIdx + 1, changeNumber);
                }
                else //if (comand == "Reverse")
                {
                    List<int> reversedNums = new List<int>();

                    for (int i = nums.Count - 1; i >= 0; i--)
                    {
                        reversedNums.Add(nums[i]);
                    }

                    nums = reversedNums;
                   // nums.Reverse();
                }
            }
        }
    }
}

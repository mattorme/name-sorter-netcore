using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterIO
{
    class Functions
    {

        public static string LastNameFirst(string fullName)
        {
            var namesArray = fullName.Split(' ');
            string lastName = namesArray[namesArray.Length - 1];
            for (int i = namesArray.Length - 1; i > 0; i--)
                namesArray[i] = namesArray[i - 1];
            namesArray[0] = lastName;
            return string.Join(" ", namesArray);
        }

        public static string FirstNameLast(string fullName)
        {
            var namesArray = fullName.Split(' ');
            string firstName = namesArray[0];
            for (int i = 0; i < namesArray.Length - 1; i++)
                namesArray[i] = namesArray[i + 1];
            namesArray[namesArray.Length - 1] = firstName;
            return string.Join(" ", namesArray);
        }

    }
    class MainClass
    {

        public static void Main()
        {
            string loadFilePath = String.Format(@"{0}/unsorted-names-list.txt", Environment.CurrentDirectory); 
            string saveFilePath = String.Format(@"{0}/sorted-names-list.txt", Environment.CurrentDirectory);  
            string[] namesList = File.ReadAllLines(loadFilePath);

            var namesWithSurnameFirst = Array.ConvertAll(namesList, n => Functions.LastNameFirst(n.Trim()));

            var sortedNamesOriginalFormat = namesWithSurnameFirst
                .OrderBy(s => s)
                .Select(fullName => Functions.FirstNameLast(fullName));

            Console.WriteLine("Sorted list of names:");
            foreach(string names in sortedNamesOriginalFormat)
            {
                Console.WriteLine(names);
            }

            File.WriteAllLines(saveFilePath, sortedNamesOriginalFormat);
            

        }
    }
}
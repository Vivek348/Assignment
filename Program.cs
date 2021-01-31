using System;
using System.Collections.Generic;
using System.Linq;


namespace Assignment1_Spring2021
 {
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Question 1
                Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
                int n = Convert.ToInt32(Console.ReadLine());
                PrintTriangle(n);
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a valid Integer from 1 to N");
            }
            try
            {
                //Question 2:
                Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
                int n2 = Convert.ToInt32(Console.ReadLine());
                PrintPellSeries(n2);
                Console.WriteLine();
             }
            catch
            {
                Console.WriteLine("Enter a valid Integer from 1 to N");
            }
            try
            {
                //Question 3:
                Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
                int n3 = Convert.ToInt32(Console.ReadLine());
                bool flag = SquareSums(n3);
                if (flag)
                {
                    Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
                }
                else
                {
                    Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
                }
            }
            catch
            {
                Console.WriteLine("Enter a valid Integer from 1 to N");
            }
                //Question 4:
                int[] arr = new int[] { 1, 3, 1, 5, 4 };
                Console.WriteLine("Q4: Enter the absolute difference to check");
                int k = Convert.ToInt32(Console.ReadLine());
                int n4 = DiffPairs(arr, k);
                Console.WriteLine("There exists {0} pairs with the given difference", n4);
                //Question 5:
                List<string> emails = new List<string>();
                emails.Add("dis.email + bull@usf.com");
                emails.Add("dis.e.mail+bob.cathy@usf.com");
                emails.Add("disemail+david@us.f.com");
                int ans5 = UniqueEmails(emails);
                Console.WriteLine("Q5:");
                Console.WriteLine("The number of unique emails is " + ans5);
                //Quesiton 6:
                string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" }, { "Delhi", "London" } };
                string destination = DestCity(paths);
                Console.WriteLine("Q6:");
                Console.WriteLine("Destination city is " + destination);
        }

        private static void PrintTriangle(int n)
        {
            try
            {
                //For filtering out the negative values of the given input
                if (n > 0)
                {
                    for (int i = 1; i <= n; i++)
                    {
                        //for columns and spaces
                        for (int j = 1; j <= n-i; j++)
                        {
                            Console.Write(" ");
                        }
                        //for printing the stars
                        for (int k = 1;  k <= (2 * i) -1; k++)
                        {
                            Console.Write("*");
                        }
                        Console.Write("\n");
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Please enter a Valid integer from 1 to N");
            }
        }
        private static void PrintPellSeries(int n2)
        {
            try
            {
                //For filtering out the negative values of the given input
                if (n2 > 0)
                {

                    int a = 0;
                    int b = 1;
                    int c;
                    //if Input is 1 print 0
                    if (n2 == 1)
                    {
                        Console.Write(a);
                    }
                    //if Input is 2 print 0 1
                    else if (n2 == 2)
                    {
                        Console.Write(a + " " + b + " ");
                    }
                    //if input is greater than 2 then print out pellseries
                    else
                    {
                        Console.Write(a + " " + b + " ");
                        for (int i = 0; i < n2 - 2; i++)
                        {
                            c = 2 * b + a;
                            Console.Write(c + " ");
                            a = b;
                            b = c;
                        }
                    }
                }
                else 
                {
                    throw new Exception();
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Please enter a Valid integer from 1 to N");
            }
        }
        private static bool SquareSums(int n3)
        {
            try
            {
                if(n3>0)
                {
                    for (int a = 0; a <= n3; a++)
                    {
                        for (int b = 0; b <= n3; b++)
                        {
                            int sum = a * a + b * b;
                            //Checking whether Sum is equal to given number
                            if (sum == n3)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Please enter a Valid integer from 1 to N");
                throw;
            }
        }
        private static int DiffPairs(int[] arr, int k)
        {
            try
            {
                // Sorting the array for ease of the problem
                Array.Sort(arr);
                Dictionary<int, int> Dict = new Dictionary<int, int>();
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        // Check if the difference of ith and jth and if found as k, add them as a tuple to target dictionary
                        if (arr[j] - arr[i] == k)
                        {
                            // Adding if the key doesn't exist already
                            if (!(Dict.Keys.ToList().Contains(arr[i])))
                            {
                                Dict.Add(arr[i], arr[j]);
                            }
                            break;
                        }
                    }
                }
                // Returning the size of map keys.
                return Dict.Keys.ToList().Count();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }
        }
        private static int UniqueEmails(List<string> emails)
        {
            try
            {
                //Saving the result in hastset so that we will get only unique mails
                ISet<string> res = new HashSet<string>();
                foreach (var email in emails)
                {
                    //Spliting the mail into local and domain names.
                    var split = email.Split(new char[] { '@' });
                    int plus = split[0].IndexOf('+');
                    if (plus >= 0)
                    {
                        //Taking the string after "+" sign into a different substring
                        split[0] = split[0].Substring(0, plus);
                    }
                    //Replacing all the dots in the local name
                    split[0] = split[0].Replace(".", "");
                    //Removing the spaces if any
                    string trim = split[0].TrimEnd();
                    //Pushing the each output into hastset
                    res.Add($"{trim}@{split[1]}");
                }
                //Returning the count of unique emails
                return res.Count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        private static string DestCity(string[,] paths)
        {
            try
            {
                //Spilting the Given list into two different lists(source and destiation)for ease of the problem
                List<string> source = new List<string>();
                List<string> destination = new List<string>();
                int i = 0;
                foreach (string temp in paths)
                {
                    if ((i % 2) != 0)
                    {
                        destination.Add(temp);
                        i++;
                    }
                    else if (i % 2 == 0)
                    {
                        source.Add(temp);
                        i++;
                    }
                }
                //Checking if the given destinations are present in source list
                foreach (string dest in destination)
                {
                    if (source.Contains(dest) == false)
                    {
                        string output = dest;
                        return output;
                    }
                }
                return "No Destination found";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
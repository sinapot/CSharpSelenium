
using System.Collections;

//dynamic list of elements
ArrayList a = new ArrayList();
a.Add("Hello");
a.Add("Bye");
a.Add("Edison");
a.Add("Maningat");


foreach(String item in a)
{
    Console.WriteLine(item);

}
//if array contains a string
Console.WriteLine(a.Contains("Maningat"));

Console.WriteLine("After Sorting");

a.Sort();
foreach (String item in a)
{
    Console.WriteLine(item);

}
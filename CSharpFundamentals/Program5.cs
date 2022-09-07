using System;

String[] a = { "hello", "hi", "edison", "manigat" };
int[] b = { 1,2,3,4,5};


//declaring an array
String[] a1 = new String[4];
a1[0] = "hello";
a1[1] = "second";
a1[2] = "third";
a1[3] = "fourth";

Console.WriteLine(a1[1]);

for(int i = 0; i < a.Length; i++)
{
    Console.WriteLine(a[i]);
    if (a[i]=="manigat")
    {
        Console.WriteLine("Match found");
        break;
    }
}
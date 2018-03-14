using System;
using Man;

class Program
{
    static void Main()
    {
        Student student = new Student();
        GoodStudent goodStudent = new GoodStudent();
        BadStudent badStudent = new BadStudent();

        Console.WriteLine("Typical Student: ");
        student.say();
        Console.WriteLine("Good Student: ");
        goodStudent.say();
        Console.WriteLine("Bad Student: ");
        badStudent.say();

        Console.ReadKey();
    }
}
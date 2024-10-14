// See https://aka.ms/new-console-template for more information
using MyDate_Namespace;



MyDate date1 = new MyDate(2023,11,28);
MyDate date2 = new MyDate();

Console.WriteLine(date1.DatesDifference(date2));

date1 = date1.PlusDays(5);

date1.PrintDate();



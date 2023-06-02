using System;
using System.Globalization;
using System.Xml;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using PrimeiroProjeto.Entities;
using PrimeiroProjeto.Entities.Enums;

namespace PrimeiroProjeto
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the department's name: ");

            string deptName = Console.ReadLine();

            Console.Write("Enter worker name: ");

            string name = Console.ReadLine();

            Console.Write("Enter the worker level: ");

            WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base salary: ");

            double baseSalary = double.Parse(Console.ReadLine());

            Department department = new Department(name);
            Worker worker = new Worker(name, workerLevel, baseSalary, department);

            Console.Write("How many contracts will have?: ");
            int contractNum = int.Parse(Console.ReadLine());

            for(int i = 1; i <= contractNum; i++)
            {
                Console.WriteLine($"Enter the {i} contract data: ");

                Console.WriteLine("DD/MM/Yyyy");

                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("per hour value: ");
                double perHour = double.Parse(Console.ReadLine());

                Console.Write("duration: ");
                int duration = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, perHour, duration);
                worker.AddContract(contract);
            }

            Console.WriteLine("Enter the month and year to calculate the income (MM/Yyyy): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine($"Name: {worker.Name}, department: {worker.Department.Name}, income: {worker.Income(month, year)}");
        }
    }
}

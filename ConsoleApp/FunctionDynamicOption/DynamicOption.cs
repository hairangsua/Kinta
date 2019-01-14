using Kinta.Framework.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.FunctionDynamicOption
{
    public class DynamicOption
    {
        public static List<Person> List = new List<Person>();

        public static void Run()
        {
            List.Add(new Person { Name = "A", Age = 22, BirthDate = new DateTime(2017, 11, 22) });
            List.Add(new Person { Name = "B", Age = 11, BirthDate = new DateTime(1993, 11, 22) });
            List.Add(new Person { Name = "C", Age = 12, BirthDate = new DateTime(2000, 11, 22) });
            List.Add(new Person { Name = "D", Age = 62, BirthDate = new DateTime(2014, 11, 22) });
            List.Add(new Person { Name = "E", Age = 73, BirthDate = new DateTime(1990, 11, 22) });

            var builder = OptionBuilder.Create();

            var persons = GetPerson(builder.ByAge(22).ByName("A"));
        }

        public static List<Person> GetPerson(OptionBuilder builder)
        {
            var lst = new List<Person>();

            bool isNullBuilder = !builder.IsByName && !builder.IsByBirthDate && !builder.IsByAge;
            if (isNullBuilder)
            {
                return new List<Person>();
            }

            if (builder.IsByAge)
            {
                lst = List.FindAll(x => x.Age == builder.Age);
            }

            if (builder.IsByName)
            {
                if (lst.IsNullOrEmpty())
                {
                    lst = List.FindAll(x => x.Name == builder.Name);
                }
                else
                {
                    lst = lst.FindAll(x => x.Name == builder.Name);
                }
            }

            if (builder.IsByBirthDate)
            {
                if (lst.IsNullOrEmpty())
                {
                    lst = List.FindAll(x => x.BirthDate == builder.BirthDate);
                }
                else
                {
                    lst = lst.FindAll(x => x.BirthDate == builder.BirthDate);
                }
            }

            return lst;
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime BirthDate { get; set; }
        }
    }

    public class OptionBuilder
    {
        public static OptionBuilder Create()
        {
            return new OptionBuilder();
        }

        public bool IsByName { get; set; }
        public string Name { get; set; }

        public bool IsByAge { get; set; }
        public int Age { get; set; }

        public bool IsByBirthDate { get; set; }
        public DateTime BirthDate { get; set; }

    }

    public static class OptionBuilderExtension
    {
        public static OptionBuilder ByName(this OptionBuilder builder, string name)
        {
            if (builder == null)
            {
                builder = new OptionBuilder();
            }

            builder.IsByName = true;
            builder.Name = name;

            return builder;
        }

        public static OptionBuilder ByAge(this OptionBuilder builder, int age)
        {
            if (builder == null)
            {
                builder = new OptionBuilder();
            }

            builder.IsByAge = true;
            builder.Age = age;

            return builder;
        }

        public static OptionBuilder ByBirthDate(this OptionBuilder builder, DateTime birthDate)
        {
            if (builder == null)
            {
                builder = new OptionBuilder();
            }

            builder.IsByBirthDate = true;
            builder.BirthDate = birthDate;

            return builder;
        }
    }
}

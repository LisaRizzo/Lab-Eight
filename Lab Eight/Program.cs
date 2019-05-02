using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Eight
{
  class Program
  {
    public static string[] Names = new string[9];
    public static string[] FavoriteFoods = new string[9];
    public static string[] HomeTowns = new string[9];
    static void Main(string[] args)
    {
      AddStudent("Lisa Rizzo", "Sokcho, South Korea", "Fruit", 0);
      AddStudent("Brad Kapteyn", "Kentwood, MI", "Sushi", 1);
      AddStudent("Nathan Jefferis", "Grand Rapids, MI", "Burgers", 2);
      AddStudent("Steven Vallarsa", "Sudbury, Ontario", "Risotto", 3);
      AddStudent("Miguel Gomez Jr", "Chicago, IL", "BBQ Ribs", 4);
      AddStudent("Callista Gloss", "Traverse City, MI", "Crab Rangoon", 5);
      AddStudent("Andre Otte", "St Catherines, Ontario", "Veggie Burgers", 6);
      AddStudent("Tommy Waalkes", "Raleigh, NC", "Chicken Curry", 7);
      AddStudent("Yeni Diaz", "Havana, Cuba", "Vegan Salted Caramel Icecream", 8);

      Console.WriteLine("Welcome to our C# class.");
      Console.WriteLine("Which student would you like to learn more about?");
      GetInput();
    }

    public static void AddStudent(string name, string town, string food, int index)
    {
      Names[index] = name;
      FavoriteFoods[index] = food;
      HomeTowns[index] = town;
    }

    public static string GetStudent(int index)
    {
      try
      {
        if (index >= 9)
        {
          throw new IndexOutOfRangeException("Student not found, try another index");
        }
        else
        {
          return $"{Names[index]}  {FavoriteFoods[index]}  {HomeTowns[index]}";
        }
      }
      catch (IndexOutOfRangeException e)
      {
        return e.Message;
      }
    }

    public static void PrintMenu()
    {
      //names.Length is the sized of the array
      for (int i = 0; i < Names.Length; i++)
      {
        string name = Names[i];
        if (name != null)
        {
          Console.WriteLine(i + ") " + Names[i]);
        }
      }
    }

    public static void GetInput()
    {
      bool validUserInput = false;
      int index = 0;
      string userInput;

      while (!validUserInput)
      {
        PrintMenu();
        Console.WriteLine("Please select index of the student you want to learn about");
        userInput = Console.ReadLine();

        try
        {
          index = int.Parse(userInput);
          if (index < Names.Length)
          {
            validUserInput = true;
          }
          else
          {
            throw new IndexOutOfRangeException("That student does not exist.  Please try again.");
          }
        }
        catch (FormatException e)
        {
          Console.WriteLine("Not a valid number please try again.");
        }
        catch (IndexOutOfRangeException e)
        {
          Console.WriteLine(e.Message);
        }
      }
      string student = GetStudent(index);
      Console.WriteLine($"Student {index} is {Names[index]}. What would you like to know about {Names[index]}? (enter or “hometown” or “favorite food”)");
      LearnMore(index);
    }

    public static void LearnMore(int index)
    {
      string name = Names[index];
      string food = name + "'s favorite food is " + FavoriteFoods[index] + ".";
      string homeTown = name + "'s hometown is " + HomeTowns[index] + ".";
      bool validInput = false;
      while (!validInput)
      {
        string userInput = Console.ReadLine();
        bool validAnswer = false;

        if (userInput.ToLower() == "hometown")
        {
          string studentHomeTown = homeTown + " Would you like to know more? (enter “yes” or “no”): ";
          Console.WriteLine(studentHomeTown);
          while (!validAnswer)
          {
            string userAnswer = Console.ReadLine();
            if (userAnswer.ToLower() == "yes" || userAnswer.ToLower() == "y")
            {
              Console.WriteLine($"Student {index} is {Names[index]}. What would you like to know about {Names[index]}? (enter or “hometown” or “favorite food”)");
              validAnswer = true;
            }
            else if (userAnswer.ToLower() == "no" || userAnswer.ToLower() == "n")
            {
              validAnswer = true;
              validInput = true;
            }
          }
        }
        else if (userInput.ToLower() == "favorite food")
        {
          string studentFood = food + " Would you like to know more? (enter “yes” or “no”): ";
          Console.WriteLine(studentFood);
          while (!validAnswer)
          {
            string userAnswer = Console.ReadLine();
            if (userAnswer.ToLower() == "yes" || userAnswer.ToLower() == "y")
            {
              Console.WriteLine($"Student {index} is {Names[index]}. What would you like to know about {Names[index]}? (enter or “hometown” or “favorite food”)");
              validAnswer = true;
            }
            else if (userAnswer.ToLower() == "no" || userAnswer.ToLower() == "n")
            {
              validAnswer = true;
              validInput = true;
            }
          }
        }
        else
        {
          Console.WriteLine("That data does not exist. Please try again.");
        }
      }
      validInput = false;
    }
  }
}

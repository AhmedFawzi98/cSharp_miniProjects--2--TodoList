using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace TodoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> todoList = new List<string>();
            bool isRunning = true;
            do
            {
                Console.WriteLine("---------------TodoList----------------");
                Console.WriteLine("What do you want to do ?");
                Console.WriteLine("[S]ee all todos");
                Console.WriteLine("[A]dd a todo");
                Console.WriteLine("[R]emove a todo");
                Console.WriteLine("[E]xit");

                string userChoice = Console.ReadLine();
                PrintAndExecuteSelection(userChoice.ToLower(), out isRunning, todoList);
            } while (isRunning);

        }

        #region methods
        static void PrintAndExecuteSelection(string userOption, out bool isRunning, List<string> todo)
        {
            isRunning = true;
            switch (userOption)
            {
                case "s":
                    Console.WriteLine($"Selected Option is : See all todos");
                    DisplaytoDo(todo);
                    break;
                case "a":
                    Console.WriteLine($"Selected Option is : Add a todo");
                    AddtoDo(todo);
                    break;
                case "r":
                    Console.WriteLine($"Selected Option is : Remove a todo");
                    RemovetoDo(todo);
                    break;
                case "e":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine($"Invalid Choice");
                    break;
            }
        }
        static void DisplaytoDo(List<string> todo)
        {
            if (todo.Count == 0)
            {
                Console.WriteLine("no todos have been added yet!");
                return;
            }
            for (int i = 0; i < todo.Count; i++)
                Console.WriteLine($"{i + 1}-{todo[i]}");
        }
        static void AddtoDo(List<string> todo)
        {
            string newToDo;
            do
            {
                Console.WriteLine("Enter the todo description: ");
                newToDo = Console.ReadLine();

            } while (!IsValidDescription(todo, newToDo));
            
            todo.Add(newToDo);
            Console.WriteLine("todo is added successfully!");
        }
        static bool IsValidDescription(List<string> todo, string newToDo)
        {
            if (newToDo.Length == 0)
            {
                Console.WriteLine("the description can not be empty\nno to do is added");
                return false;
            }
            else if (todo.Contains(newToDo))
            {
                Console.WriteLine("description exists, description must be unique!");
                return false;
            }
            else
                return true;
        }
        static void RemovetoDo(List<string> todo)
        {
            int index;
            do
            {
                Console.WriteLine("select the index of todo you want to remove");
                DisplaytoDo(todo);

            } while (!IsValidIndex(todo, out index));
            
            Console.WriteLine($"todo: {todo[index - 1]}, is removed successfully!");
            todo.RemoveAt(index - 1);
        }

        static bool IsValidIndex(List<string> todo, out int index)
        {
            bool isIndex = int.TryParse(Console.ReadLine(), out index);

            if (!isIndex || index - 1 < 0 || index - 1 > todo.Count)
                Console.WriteLine("the given index is not valid\n no todo is removed");
            return (isIndex && index - 1 > 0 && index - 1 < todo.Count);
        }
        #endregion

    }
}

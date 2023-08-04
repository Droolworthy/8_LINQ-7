using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ7
{
    internal class Program
    {
        static void Main()
        {
            Database database = new Database();

            database.Work();
        }
    }

    class Database
    {      
        private  List<Soldier> _stormtrooperSoldiers = new List<Soldier>();
        private  List<Soldier> _scoutsSoldiers = new List<Soldier>();

        public Database()
        {
            AddSoldiers();
        }

        public void Work()
        {
            bool isWork = true;

            string commandShowSoldierSurname = "1";
            string commandExit = "2";
            string letter = "Б";

            Console.WriteLine("Показать фамилии солдат 2 отряда - " + commandShowSoldierSurname);
            Console.WriteLine("Выход - " + commandExit);

            while (isWork)
            {
                Console.Write("\nВвод: ");
                string userInput = Console.ReadLine();

                if (userInput == commandShowSoldierSurname)
                {
                    var filteredSoldiers = _stormtrooperSoldiers.Where(soldier => soldier.Surname.StartsWith(letter));

                    _scoutsSoldiers = _scoutsSoldiers.Union(filteredSoldiers).ToList();

                    _stormtrooperSoldiers = _stormtrooperSoldiers.Except(filteredSoldiers).ToList();

                    Console.WriteLine("Первый отряд: ");

                    ShowFilteredSoldiers(_stormtrooperSoldiers);

                    Console.WriteLine("\nВторой отряд: ");

                    ShowFilteredSoldiers(_scoutsSoldiers);
                }
                else if (userInput == commandExit)
                {
                    isWork = false;
                }
                else
                {
                    Console.WriteLine("Ошибка. Попробуйте ещё раз.");
                }
            }
        }

        private void ShowFilteredSoldiers(List<Soldier> filteredSoldiers)
        {
            foreach (var soldier in filteredSoldiers)
            {
                Console.WriteLine("Фамилия - " + soldier.Surname);
            }
        }

        private void AddSoldiers()
        {
            _stormtrooperSoldiers.Add(new Soldier("Бобров"));
            _stormtrooperSoldiers.Add(new Soldier("Басов"));
            _stormtrooperSoldiers.Add(new Soldier("Хохлов"));
            _stormtrooperSoldiers.Add(new Soldier("Галкин"));
            _scoutsSoldiers.Add(new Soldier("Смирнов"));
            _scoutsSoldiers.Add(new Soldier("Петров"));
            _scoutsSoldiers.Add(new Soldier("Сидоров"));
            _scoutsSoldiers.Add(new Soldier("Васильев"));
        }
    }

    class Soldier
    {
        public Soldier(string familyName)
        {
            Surname = familyName;
        }

        public string Surname { get; private set; }
    }
}

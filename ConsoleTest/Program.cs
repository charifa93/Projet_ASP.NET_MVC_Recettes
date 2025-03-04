using BLL.Entities;
using BLL.Services;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*CocktailService service = new CocktailService();
            foreach (Cocktail c in service.Get())
            {
                Console.WriteLine($"{c.Cocktail_Id} : {c.Name}\nCréé le : {c.CreatedAt.ToShortDateString()}\n{c.Description}\n{c.Instructions}");
            }*/

            User u1 = new User("Samuel", "samuel.legrain@bstorm.be");


            User u2 = new User("Michael","michael.person@bstorm.be");

            Console.ReadLine();
            Console.WriteLine($"{u1.Username} : {u1.Email}");
            Console.WriteLine($"{u2.Username} : {u2.Email}");

        }
    }
}
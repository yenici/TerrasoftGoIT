using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_03_1
{
    class Program
    {
        // Создать консольное приложение(Console Application). 
        // Используя условные конструкции, реализовать аутентификацию пользователя.
        // Логин и пароль вводятся с клавиатуры.
        // На ввод пароля дается три попытки.
        // Данные о всех возможных пользователях, их паролях и их ролях хранятся в трех массивах в самой программе.
        // Существуют следующие возможные роли для пользователей:
        //    Admin;
        //    Moderator;
        //    User;
        // В зависимости от роли пользователя выводить следующую информацию:
        //    Admin: имена всех пользователей, их пароли и роли;
        //    Moderator: количество всех пользователей;
        //    User: имена всеx пользователей с ролью User и их общее количество.
        // ВАЖНО!!!
        // Реализовать программу без использования оператора безусловного перехода Goto.

        static void Main(string[] args)
        {
            string[] users = { "root", "admin", "user1", "user2", "user3" };
            string[] passwords = { "root", "admin", "user1", "user2", "user3" };
            string[] roles = { "Admin", "Admin", "Moderator", "User", "User" };

            const byte MAX_ATTEMPTS = 3;
            byte attempt = 0;
            int userId = -1;
            string user, password;
            bool signedIn = false;

            while (!signedIn && attempt++ < MAX_ATTEMPTS)
            {
                Console.Write("localhost login: ");
                user = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();
                if ((userId = Array.IndexOf(users, user)) >= 0)
                    if (password == passwords[userId]) signedIn = true;
                if (!signedIn)
                    Console.WriteLine("\nLogin incorrect");
            }
            if (signedIn)
            {
                Console.WriteLine("Welcome {0} / {1}\n", users[userId], roles[userId]);
                Console.WriteLine("{0}@localhost:~$ ", users[userId]);
                switch (roles[userId])
                {
                    case "Admin":
                        //    Admin: имена всех пользователей, их пароли и роли;
                        Console.WriteLine("Users:");
                        for (int i = 0; i < users.Length; i++)
                        {
                            Console.WriteLine("\t{0}\t{1}\t{2}", users[i], passwords[i], roles[i]);
                        }
                        break;
                    case "Moderator":
                        //    Moderator: количество всех пользователей;
                        Console.WriteLine("Number of users: {0}", users.Length);
                        break;
                    case "User":
                        //    User: имена всеx пользователей с ролью User и их общее количество.
                        Console.WriteLine("Users:");
                        int count = 0;
                        for (int i = 0; i < users.Length; i++)
                        {
                            if (roles[i] == "User")
                            {
                                Console.WriteLine("\t{0}", users[i]);
                                ++count;
                            }
                        }
                        Console.WriteLine("Number of users: {0}", count);
                        break;
                }
            }
        }
    }
}

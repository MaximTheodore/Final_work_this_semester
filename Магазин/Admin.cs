﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Магазин.Post;

namespace Магазин
{
    internal class Admin : CRUD
    {
        public static int selected;

        public static void AdminLobby(string name,int d)
        {
            Console.Clear();
            Console.SetCursorPosition(35, 0);
            Console.WriteLine($"Welcome {name}!");
            Console.SetCursorPosition(60, 0);
            Text(d, 0);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(8, 2);
            Console.WriteLine("ID");
            Console.SetCursorPosition(19, 2);
            Console.WriteLine("Login");
            Console.SetCursorPosition(27, 2);
            Console.WriteLine("Password");
            Console.SetCursorPosition(38, 2);
            Console.WriteLine("Post");
            List<Login_password> u = Ser_deser.Mydeserial<List<Login_password>>("Logins.json");
            Login_password login = new Login_password();

            int i = 3;
            int j = 2;
            foreach (Login_password u2 in u)
            {

                Console.SetCursorPosition(8, i);
                Console.WriteLine(u2.ID);
                Console.SetCursorPosition(19, i);
                Console.WriteLine(u2.Username);
                Console.SetCursorPosition(27, i);
                Console.WriteLine(u2.Password);
                Console.SetCursorPosition(38, i);
                Text(u2.Post, 0);

                i++;
            }
            int t = 2;
            while (t <= 15)
            {
                Console.SetCursorPosition(60, t);
                Console.WriteLine("|");
                t++;
            }
            Console.SetCursorPosition(62, 2);
            Console.WriteLine("F1 - добавить пункт");
            Console.SetCursorPosition(62, 3);
            Console.WriteLine("F2 - поиск по индексу");
            selected = Arrow.Checker(3, u.Count, u, "Logins.json");
            if (selected >= 3)
            {
                Console.Clear();
                Console.SetCursorPosition(35, 0);
                Console.WriteLine($"Welcome {name}!");
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine($"  ID: {u[selected - 3].ID}");
                Console.WriteLine($"  Login: {u[selected - 3].Username}");
                Console.WriteLine($"  Password: {u[selected - 3].Password}");
                Text(u[selected - 3].Post, 1);
                t = 2;
                while (t <= 15)
                {
                    Console.SetCursorPosition(60, t);
                    Console.WriteLine("|");
                    t++;
                }
                Console.SetCursorPosition(62, 2);
                Console.WriteLine("F10 - изменить пункт");
                Console.SetCursorPosition(62, 3);
                Console.WriteLine("Del - удалить пункт");
                Console.SetCursorPosition(62, 4);
                Console.WriteLine("Esc - вернуться в меню");
                int pos = Arrow.Checker(2, 4, u, "Logins.json");
                if (pos == -10)
                {
                    AdminLobby(name,d);
                }
                else if (pos == -11)
                {
                    AdminLobby(name,d);
                }
                else if (pos == -2)
                {
                    int o = 2;
                    while (o <= 6)
                    {
                        Console.SetCursorPosition(62, o);
                        Console.Write("                        ");
                        o++;

                    }
                    Console.SetCursorPosition(62, 2);
                    Console.WriteLine("0-Админ");
                    Console.SetCursorPosition(62, 3);
                    Console.WriteLine("1 - Кассир");
                    Console.SetCursorPosition(62, 4);
                    Console.WriteLine("2 - Кадровик");
                    Console.SetCursorPosition(62, 5);
                    Console.WriteLine("3 - Склад-менеджер");
                    Console.SetCursorPosition(62, 6);
                    Console.WriteLine("4 - Бухгалтер");
                    Console.SetCursorPosition(62, 7);
                    Console.WriteLine("S - сохранить изменения");
                    while (true)
                    {
                        int selected = Arrow.Checker(2, 4, u, "Logins.json");
                        if (selected == 2)
                        {
                            var e = login.ID.ToString();
                            try
                            {
                                u[Admin.selected - 3].ID = Convert.ToInt32(Update(e, "ID: "));
                            }
                            catch
                            {
                                Console.SetCursorPosition(62, 8);
                                Console.WriteLine("Недопустимое значение, попробуйте снова");
                                Console.SetCursorPosition(8, 2);
                                u[Admin.selected - 3].ID = Convert.ToInt32(Update(e, "ID: "));
                            }

                        }
                        else if (selected == 3)
                        {
                            u[Admin.selected - 3].Username = Update(login.Username, "Login: ");
                            name = u[0].Username;
                        }
                        else if (selected == 4)
                        {
                            u[Admin.selected - 3].Password = Update(login.Password, "Password: ");

                        }
                        else if (selected == 5)
                        {
                            var e = login.Post.ToString();
                            u[Admin.selected - 3].Post = Convert.ToInt32(Update(e, "Post: "));

                        }
                        else if (selected == -9)
                        {
                            Ser_deser.MySeri(u, "Logins.json");
                            AdminLobby(name, d);

                        }
                    }
                }
            }
            else if (selected == -4)
            {
                Console.Clear();
                Console.SetCursorPosition(35, 0);
                Console.WriteLine($"Welcome {name}!");
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("  ID: ");
                Console.WriteLine("  Login: ");
                Console.WriteLine("  Password: ");
                Console.WriteLine("  Post: ");
                int treck = 2;
                while (treck <= 15)
                {
                    Console.SetCursorPosition(60, treck);
                    Console.WriteLine("|");
                    treck++;
                }
                Console.SetCursorPosition(62, 2);
                Console.WriteLine("0-Админ");
                Console.SetCursorPosition(62, 3);
                Console.WriteLine("1 - Кассир");
                Console.SetCursorPosition(62, 4);
                Console.WriteLine("2 - Кадровик");
                Console.SetCursorPosition(62, 5);
                Console.WriteLine("3 - Склад-менеджер");
                Console.SetCursorPosition(62, 6);
                Console.WriteLine("4 - Бухгалтер");
                Console.SetCursorPosition(62, 7);
                Console.WriteLine("S - сохранить");
                Console.SetCursorPosition(62, 8);
                Console.WriteLine("Esc - выйти в меню");
                while (true)
                {
                    int new_sel = Arrow.Checker(2, 4, u, "Logins.json");
                    if (new_sel == 2)
                    {
                        var e = login.ID.ToString();
                        try
                        {
                            login.ID = Convert.ToInt32(Update(e, "  ID: "));
                        }
                        catch
                        {

                            Console.SetCursorPosition(62, 9);
                            Console.WriteLine("Недопустимое значение, попробуйте снова");
                            Console.SetCursorPosition(8,2);
                            login.ID = Convert.ToInt32(Update(e, "  ID: "));

                        }

                    }
                    else if (new_sel == 3)
                    {
                        login.Username = Update(login.Username, "  Login: ");

                    }
                    else if (new_sel == 4)
                    {
                        login.Password = Update(login.Password, "  Password: ");

                    }
                    else if (new_sel == 5)
                    {
                        var e = login.Post.ToString();
                        login.Post = Convert.ToInt32(Update(e, "  Post: "));

                    }
                    else if (new_sel == -9)
                    {

                        u.Add(login);
                        Ser_deser.MySeri(u, "Logins.json");
                        Admin.AdminLobby(u[0].Username, d);
                    }
                    else if (new_sel == -10)
                    {
                        AdminLobby(u[0].Username, d);
                    }
                }
            }
            else if (selected == -5)
            {
                Console.Clear();
                Console.SetCursorPosition(35, 0);
                Console.WriteLine($"Welcome {u[0].Username}!");
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("Выберите, по какому пункту вы хотите произвести поиск:");
                Console.WriteLine("  ID");
                Console.WriteLine("  Login");
                Console.WriteLine("  Password");
                Console.WriteLine("  Post");
                int treck = 2;
                while (treck <= 15)
                {
                    Console.SetCursorPosition(60, treck);
                    Console.WriteLine("|");
                    treck++;
                }
                int sel = Arrow.Checker(3, 4, u, "Logins.json");
                if (sel == 3)
                {
                    Console.SetCursorPosition(0, 8);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 9);
                    int id = Convert.ToInt32(Console.ReadLine());
                    int r = 3;
                    for (int ii = 0; ii < u.Count; ii++)
                    {

                        if (u[ii].ID == id)
                        {

                            print();
                            Console.SetCursorPosition(8, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(19, r);
                            Console.WriteLine(u[ii].Username);
                            Console.SetCursorPosition(27, r);
                            Console.WriteLine(u[ii].Password);
                            Console.SetCursorPosition(38, r);
                            Admin.Text(u[ii].Post, 0);
                           
                            int se = Arrow.Checker(3, r, u, "Logins.json");
                            if (se == -10)
                            {
                                AdminLobby(name, d);
                            }
                            r++;
                        }
                    }
                }
                else if (sel == 4)
                {
                    Console.SetCursorPosition(0, 8);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 9);
                    string username = Console.ReadLine();
                    int r = 3;

                    for (int ii = 0; ii < u.Count; ii++)
                    {

                        if (u[ii].Username == username)
                        {


                            print();
                            Console.SetCursorPosition(8, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(19, r);
                            Console.WriteLine(u[ii].Username);
                            Console.SetCursorPosition(27, r);
                            Console.WriteLine(u[ii].Password);
                            Console.SetCursorPosition(38, r);
                            Admin.Text(u[ii].Post, 0);
                            
                            int se = Arrow.Checker(3, r, u, "Logins.json");
                            if (se == -10)
                            {
                                AdminLobby(name, d);
                            }
                            r++;
                        }
                    }
                }


                else if (sel == 5)
                {
                    Console.SetCursorPosition(0, 8);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 9);
                    string password = Console.ReadLine();
                    int r = 3;
                    for (int ii = 0; ii < u.Count; ii++)
                    {

                        if (u[ii].Password == password)
                        {
                            print();

                            Console.SetCursorPosition(8, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(19, r);
                            Console.WriteLine(u[ii].Username);
                            Console.SetCursorPosition(27, r);
                            Console.WriteLine(u[ii].Password);
                            Console.SetCursorPosition(38, r);
                            Admin.Text(u[ii].Post, 0);
                            r++;

                            int se = Arrow.Checker(3, r, u, "Logins.json");
                            if (se == -10)
                            {
                                AdminLobby(name, d);
                            }
                            
                           
                        }
                    }
                }
                else if (sel == 6)
                {
                    Console.SetCursorPosition(0, 8);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 9);
                    int po = Convert.ToInt32(Console.ReadLine());
                    int r = 3;
                    for (int ii = 0; ii < u.Count; ii++)
                    {

                        if (u[ii].Post == po)
                        {

                            print();
                            
                            Console.SetCursorPosition(8, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(19, r);
                            Console.WriteLine(u[ii].Username);
                            Console.SetCursorPosition(27, r);
                            Console.WriteLine(u[ii].Password);
                            Console.SetCursorPosition(38, r);
                            Text(u[ii].Post, 0);
                            r++;

                            int se = Arrow.Checker(3, r, u, "Logins.json");
                            if (se == -10)
                            {
                                AdminLobby(name, d);
                            }
                           
                        }
                       
                    }

                }
                if (sel == -10)
                {
                    AdminLobby(name, d);
                }

            }
            else if (selected == -9)
            {
                AdminLobby(name, d);
            }
            else if (selected == -11)
            {
                AdminLobby(name, d);
            }
            else if (selected == -10) { Program.Main(); }
        } 
        
        private static void print()
        {

            Console.Clear();
            Console.SetCursorPosition(35, 0);
            Console.WriteLine($"Welcome {Program.y}!");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.SetCursorPosition(8, 2);
            Console.WriteLine("ID");
            Console.SetCursorPosition(19, 2);
            Console.WriteLine("Login");
            Console.SetCursorPosition(27, 2);
            Console.WriteLine("Password");
            Console.SetCursorPosition(38, 2);
            Console.WriteLine("Post");
            int tt = 2;
            while (tt <= 15)
            {
                Console.SetCursorPosition(60, tt);
                Console.WriteLine("|");
                tt++;
            }
           


        }
        public static void Text(int txt, int check)
        {
                    string text;
                    if (check == 0)
                    {
                        if (txt == (int)post1) { text = "Administrastor"; Console.WriteLine(text); }
                        else if (txt == (int)post2) { text = "Kassir"; Console.WriteLine(text); }
                        else if (txt == (int)post3) { text = "Kadrovik"; Console.WriteLine(text); }
                        else if (txt == (int)post4) { text = "Sklad-manager"; Console.WriteLine(text); }
                        else if (txt == (int)post5) { text = "buhgalter"; Console.WriteLine(text); }
                    }
                    else if (check == 1)
                    {
                        if (txt == (int)post1)
                        { Console.WriteLine($"  Должность: {txt} - Администратор"); }
                        else if (txt == (int)post2)
                        { Console.WriteLine($"  Должность: {txt} - Кассир"); }
                        else if (txt == (int)post3)
                        {
                            Console.WriteLine($"  Должность: {txt} - Кадровик");
                        }
                        else if (txt == (int)post4)
                        {
                            Console.WriteLine($"  Должность: {txt} - Склад-менеджер");
                        }
                        else if (txt == (int)post5)
                        {
                            Console.WriteLine($"  Должность: {txt} - Бухгалтер");
                        }
                    }

        }

 }           
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Магазин
{
    internal class Accountant:CRUD
    {
        static string o;
        static int aa;
        static double l;
        public static void Buhoe_menu(string g, int rota)
        {
            o = g;
            aa = rota;  
           // List<Buh_uchyot> list = new List<Buh_uchyot>();
            Buh_uchyot buh_ = new Buh_uchyot();
           // list.Add(buh_);
            //Ser_deser.MySeri(list,"Buh.json");
            Console.Clear();
            Console.SetCursorPosition(35, 0);
            Console.WriteLine($" Welcome {g}");
            Console.SetCursorPosition(60, 0);
            Admin.Text(rota, 0);
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(12, 2);
            Console.WriteLine("ID");
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("Название");
            Console.SetCursorPosition(45, 2);
            Console.WriteLine("Сумма");
            Console.SetCursorPosition(65, 2);
            Console.WriteLine("Время записи");
            Console.SetCursorPosition(85, 2);
            Console.WriteLine("Прибавка?");

            List<Buh_uchyot> u = Ser_deser.Mydeserial<List<Buh_uchyot>>("Buh.json");
            var h=u.Count+8;
            l = 0;
            int i = 3;
            foreach (Buh_uchyot u2 in u)
            {
                Console.SetCursorPosition(12, i);
                Console.WriteLine(u2.ID);
                Console.SetCursorPosition(25, i);
                Console.WriteLine(u2.NameOf);
                Console.SetCursorPosition(45, i);
                Console.WriteLine(u2.Zarplata);
                Console.SetCursorPosition(65, i);
                Console.WriteLine(u2.time.ToShortDateString());
                Console.SetCursorPosition(85, i);
                Console.WriteLine(u2.tf);
               
                if (u2.tf == true)
                {
                
                    l = l + u2.Zarplata;
                }
                else
                {
                  
                    l=l - u2.Zarplata;
                }
                
                i++;
            }
            Console.SetCursorPosition(80, h + 1);
            Console.WriteLine($"Итог: {l}");
            int t = 2;
            while (t <= 15)
            {
                Console.SetCursorPosition(100, t);
                Console.WriteLine("|");
                t++;
            }
            Console.SetCursorPosition(102, 2);
            Console.WriteLine("F1 - добавить");
            Console.SetCursorPosition(102, 3);
            Console.WriteLine(" пункт");
            Console.SetCursorPosition(102, 4);
            Console.WriteLine("F2 - поиск");
            Console.SetCursorPosition(102, 5);
            Console.WriteLine("по индексу");
            Admin.selected = Arrow.Checker(3, u.Count, u, "Buh.json");
            if (Admin.selected >= 3)
            {
                Console.Clear();
                Console.SetCursorPosition(35, 0);
                Console.WriteLine($"Welcome {g}!");
                Console.SetCursorPosition(60, 0);
                Admin.Text(rota, 0);
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine($"  ID: {u[Admin.selected - 3].ID}");
                Console.WriteLine($"  Название: {u[Admin.selected - 3].NameOf}");
                Console.WriteLine($"  Сумма: {u[Admin.selected - 3].Zarplata}");
                Console.WriteLine($"  Время записи: {u[Admin.selected - 3].time.ToShortDateString()}");
                Console.WriteLine($"  Прибавка?: {u[Admin.selected - 3].tf}");

                t = 2;
                while (t <= 15)
                {
                    Console.SetCursorPosition(58, t);
                    Console.WriteLine("|");
                    t++;
                }
                Console.SetCursorPosition(60, 2);
                Console.WriteLine("F10 - изменить");
                Console.SetCursorPosition(60, 3);
                Console.WriteLine("пункт");
                Console.SetCursorPosition(60, 4);
                Console.WriteLine("Del - удалить пункт");
                Console.SetCursorPosition(60, 5);
                Console.WriteLine("пункт");
                Console.SetCursorPosition(60, 6);
                Console.WriteLine("Esc - вернуться");
                Console.SetCursorPosition(60, 7);
                Console.WriteLine("в меню");
                int sel = Arrow.Checker(2, 5, u, "Buh.json");
                if (sel == -10)
                {
                    Buhoe_menu(g,rota);
                }
                if (sel == -11)
                {
                    Buhoe_menu(g, rota);
                }
                if (sel == -2)
                {
                    Console.SetCursorPosition(60, 9);
                    Console.WriteLine("S -cохранить");
                    while (true)
                    {
                        int selected = Arrow.Checker(2, 5, u, "Buh.json");
                        if (selected == 2)
                        {
                            try
                            {
                                var e = buh_.ID.ToString();
                                u[Admin.selected - 3].ID = Convert.ToInt32(Update(e, "  ID: "));
                            }
                            catch
                            {
                                Console.SetCursorPosition(60, 11);
                                Console.WriteLine("Недопустимое значение, попробуйте снова");
                                var e = buh_.ID.ToString();
                                u[Admin.selected - 3].ID = Convert.ToInt32(Update(e, "  ID: "));
                            }
                        }
                        else if (selected == 3)
                        {
                            u[Admin.selected - 3].NameOf = Update(buh_.NameOf, "  Название: ");

                        }
                        else if (selected == 4)
                        {
                            var e =buh_.Zarplata.ToString();
                            u[Admin.selected - 3].Zarplata = Convert.ToDouble(Update(e, "  Сумма: "));

                        }
                        else if (selected == 5)
                        {
                            var e = buh_.time.ToString();
                            u[Admin.selected - 3].time = Convert.ToDateTime(Update(e, "   Время записи: "));

                        }
                        else if (selected == 6)
                        {
                            var e = buh_.tf.ToString();
                            u[Admin.selected - 3].tf = Convert.ToBoolean(Update(e, "  Прибавка?: "));
                            if (u[Admin.selected - 3].tf == true)
                            {
                                l = l + u[Admin.selected - 3].Zarplata;
                            }
                            else
                            {
                                l = 0;
                                l = l - u[Admin.selected - 3].Zarplata;
                            }

                        }

                        else if (selected == -9)
                        {
                            Ser_deser.MySeri(u, "Buh.json");
                            Buhoe_menu(g, rota);
                        }
                        else if (selected == -10)
                        {
                            Buhoe_menu(g, rota);
                        }
                        
                    }
                }
            }
            else if (Admin.selected == -4)
            {
                Console.Clear();
                Console.SetCursorPosition(35, 0);
                Console.WriteLine($" Welcome {g}");
                Console.SetCursorPosition(60, 0);
                Admin.Text(rota, 0);
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("  ID: ");
                Console.WriteLine("  Название: ");
                Console.WriteLine("  Сумма: ");
                Console.WriteLine("  Время записи: ");
                Console.WriteLine("  Прибавка?: ");
                int treck = 2;
                while (treck <= 15)
                {
                    Console.SetCursorPosition(70, treck);
                    Console.WriteLine("|");
                    treck++;
                }
                Console.SetCursorPosition(72, 9);
                Console.WriteLine("S - сохранить");
                Console.SetCursorPosition(72, 10);
                Console.WriteLine("Esc - выйти в меню");
                while (true)
                {
                    int selected = Arrow.Checker(2, 5, u, "Buh.json");
                    if (selected == 2)
                    {
                        try
                        {
                            var e = buh_.ID.ToString();
                            buh_.ID = Convert.ToInt32(Update(e, "  ID: "));
                        }
                        catch
                        {
                            Console.SetCursorPosition(72, 11);
                            Console.WriteLine("Недопустимое значение, попробуйте снова");
                            var e = buh_.ID.ToString();
                            Console.SetCursorPosition(8, 2);
                            buh_.ID = Convert.ToInt32(Update(e, "  ID: "));
                        }
                    }
                    else if (selected == 3)
                    {
                        buh_.NameOf = Update(buh_.NameOf, "  Название: ");

                    }
                    else if (selected == 4)
                    {
                        var e = buh_.Zarplata.ToString();
                        buh_.Zarplata = Convert.ToDouble(Update(e, "  Сумма: "));

                    }
                    else if (selected == 5)
                    {
                        var e = buh_.time.ToString();
                        buh_.time = Convert.ToDateTime(Update(e, "  Сумма: "));

                    }
                    else if (selected == 6)
                    {
                        var e = buh_.tf.ToString();
                        buh_.tf = Convert.ToBoolean(Update(e, "  Общее количество: "));
                        if (buh_.tf == true)
                        {
                            l = l + buh_.Zarplata;
                        }
                        else
                        {
                            l = 0;
                            l = l - buh_.Zarplata;

                        }

                    }

                    else if (selected == -9)
                    {
                        u.Add(buh_);
                        Ser_deser.MySeri(u, "Buh.json");
                        Buhoe_menu(g, rota);
                    }
                    else if (selected == -10)
                    {
                        Buhoe_menu(g, rota);
                    }
                }
            }
            else if (Admin.selected == -10)
            {
                l = 0;
                Program.Main();
            }





            else if (Admin.selected == -5)
            {
                Console.Clear();
                Console.SetCursorPosition(35, 0);
                Console.WriteLine($" Welcome {g}");
                Console.SetCursorPosition(60, 0);
                Admin.Text(rota, 0);
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("Выберите, по какому пункту вы хотите произвести поиск:");
                Console.WriteLine("  ID");
                Console.WriteLine("  Название");
                Console.WriteLine("  Сумма");
                Console.WriteLine("  Время записи");
                Console.WriteLine("  Прибавка?");
                int treck = 2;
                while (treck <= 15)
                {
                    Console.SetCursorPosition(60, treck);
                    Console.WriteLine("|");
                    treck++;
                }
                int sel = Arrow.Checker(3, 5, u, "Buh.json");
                if (sel == 3)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    int id = Convert.ToInt32(Console.ReadLine());
                    int r = 3;
                    for (int ii = 0; ii < u.Count; ii++)
                    {
                        if (u[ii].ID == id)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(u[ii].NameOf);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(u[ii].Zarplata);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(u[ii].time.ToShortDateString());
                            Console.SetCursorPosition(85, r);
                            Console.WriteLine(u[ii].tf);
                            r++;
                            int se = Arrow.Checker(3, r, u, "Buh.json");
                            if (se == -10)
                            {
                                Buhoe_menu(g, rota);
                            }
                           
                        }
                    }
                }
                if (sel == 4)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    string id = Console.ReadLine();
                    int r = 3;
                    for (int ii = 0; ii < u.Count; ii++)
                    {
                        if (u[ii].NameOf == id)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(u[ii].NameOf);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(u[ii].Zarplata);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(u[ii].time.ToShortDateString());
                            Console.SetCursorPosition(85, r);
                            Console.WriteLine(u[ii].tf);
                          
                            int se = Arrow.Checker(3, r, u, "Buh.json");
                            if (se == -10)
                            {
                                Buhoe_menu(g, rota);
                            }
                            r++;
                        }
                    }
                }
                if (sel == 5)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    double id = Convert.ToDouble(Console.ReadLine());
                    int r = 3;
                    for (int ii = 0; ii < u.Count; ii++)
                    {
                        if (u[ii].Zarplata == id)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(u[ii].NameOf);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(u[ii].Zarplata);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(u[ii].time.ToShortDateString());
                            Console.SetCursorPosition(85, r);
                            Console.WriteLine(u[ii].tf);
                            r++;
                            int se = Arrow.Checker(3, r, u, "Buh.json");
                            if (se == -10)
                            {
                                Buhoe_menu(g, rota);
                            }

                        }
                       
                    }
                }
                if (sel == 6)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    DateTime id = Convert.ToDateTime(Console.ReadLine());
                    int r = 3;
                    for (int ii = 0; ii < u.Count; ii++)
                    {
                        if (u[ii].time == id)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(u[ii].NameOf);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(u[ii].Zarplata);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(u[ii].time.ToShortDateString());
                            Console.SetCursorPosition(85, r);
                            Console.WriteLine(u[ii].tf);
                          
                            int se = Arrow.Checker(3, r, u, "Buh.json");
                            if (se == -10)
                            {
                                Buhoe_menu(g, rota);
                            }
                            r++;
                        }
                    }
                }
                if (sel == 7)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    bool id = Convert.ToBoolean(Console.ReadLine());
                    int r = 3;
                    for (int ii = 0; ii < u.Count; ii++)
                    {
                        if (u[ii].tf == id)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(u[ii].NameOf);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(u[ii].Zarplata);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(u[ii].time.ToShortDateString());
                            Console.SetCursorPosition(85, r);
                            Console.WriteLine(u[ii].tf);
                           
                            int se = Arrow.Checker(3, r, u, "Buh.json");
                            if (se == -10)
                            {
                                Buhoe_menu(g, rota);
                            }
                            r++;
                        }
                    }
                }
            }
        }
        public static void Printed()
        {
            Console.Clear();
            Console.SetCursorPosition(35, 0);
            Console.WriteLine($" Welcome {o}");
            Console.SetCursorPosition(60, 0);
            Admin.Text(aa, 0);
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(12, 2);
            Console.WriteLine("ID");
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("Название");
            Console.SetCursorPosition(45, 2);
            Console.WriteLine("Сумма");
            Console.SetCursorPosition(65, 2);
            Console.WriteLine("Время записи");
            Console.SetCursorPosition(85, 2);
            Console.WriteLine("Прибавка?");
            int t = 2;
            while (t <= 15)
            {
                Console.SetCursorPosition(102, t);
                Console.WriteLine("|");
                t++;
            }
        }
    }
}

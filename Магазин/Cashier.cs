using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Магазин
{
    internal class Cashier
    {
        static double w;
        static int l;
        public static void Cashier_Menu(string g,int rota, int r=0)
        {
            Console.Clear();
            Console.SetCursorPosition(35, 0);
            Console.WriteLine($" Welcome {g}");
            Console.SetCursorPosition(60, 0);
            Admin.Text(rota, 0);
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(12, 2);
            Console.WriteLine("ID");
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("Название товара");
            Console.SetCursorPosition(45, 2);
            Console.WriteLine("Цена за штуку");
            Console.SetCursorPosition(65, 2);
            Console.WriteLine("Количество");
            int t = 2;
            while (t <= 15)
            {
                Console.SetCursorPosition(95, t);
                Console.WriteLine("|");
                t++;
            }
            List<Tovar> tovars = Ser_deser.Mydeserial<List<Tovar>>("Tovar.json");
            
            Console.SetCursorPosition(97,3);
            Console.WriteLine("S - завершить покупку ");
            Console.SetCursorPosition(97, 4);
            Console.WriteLine("Esc - вернуться в меню");
            
        
            int i = 3;
            foreach (Tovar tovar in tovars)
            {
                Console.SetCursorPosition(12, i);
                Console.WriteLine(tovar.ID);
                Console.SetCursorPosition(25, i);
                Console.WriteLine(tovar.NameOf);
                Console.SetCursorPosition(50, i);
                Console.WriteLine(tovar.priceFor1);
                Console.SetCursorPosition(70, i);
                Console.WriteLine(tovar.p) ;
                i++;
            }
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine($"                                                             Итог: {w}");
            Admin.selected = Arrow.Checker(3, tovars.Count, tovars, "Tovar.json");
            if (Admin.selected >= 3)
            {
                Console.Clear();
                Console.SetCursorPosition(35, 0);
                Console.WriteLine($"Welcome {g}!");
                Console.SetCursorPosition(60, 0);
                Admin.Text(rota, 0);
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine($"  ID: {tovars[Admin.selected - 3].ID}");
                Console.WriteLine($"  Название: {tovars[Admin.selected - 3].NameOf}");
                Console.WriteLine($"  Цена за штуку: {tovars[Admin.selected - 3].priceFor1}");
                Console.WriteLine($"  Количество: {tovars[Admin.selected-3].p}");
                t = 2;
                while (t <= 15)
                {
                    Console.SetCursorPosition(58, t);
                    Console.WriteLine("|");
                    t++;
                }
                Console.SetCursorPosition(60, 2);
                Console.WriteLine("'+' - прибавить");
                Console.SetCursorPosition(60, 3);
                Console.WriteLine("'-'  - убавить ");
                Console.SetCursorPosition(60, 4);
                Console.WriteLine("Esc - вернуться в меню");
                tovars[Admin.selected-3].p = 0;
                l = 0;
                while (true)
                {
                    
                    int sel = Arrow.Checker(2, 4, tovars, "Tovar.json");
                    if (sel == -20)
                    {
                        if (tovars[Admin.selected - 3].p <= tovars[Admin.selected - 3].sklad && tovars[Admin.selected - 3].p >= 0)
                        {

                            tovars[Admin.selected - 3].p = tovars[Admin.selected - 3].p + 1;
                         
                         
                            Console.SetCursorPosition(2, 5);
                            Console.WriteLine($"Количество: {tovars[Admin.selected - 3].p}");
                          
                        }
                    }
                    else if (sel == -21)
                    {
                        if (tovars[Admin.selected-3].p <= tovars[Admin.selected - 3].sklad && tovars[Admin.selected - 3].p >= 0)
                        {
                            tovars[Admin.selected-3].p = tovars[Admin.selected-3].p - 1;
                          
                            Console.SetCursorPosition(2, 5);
                            Console.WriteLine($"Количество: {tovars[Admin.selected - 3].p}");
                    
                        }
                    }
                    else if (sel == -10)
                    {
                        tovars[Admin.selected - 3].sklad -= tovars[Admin.selected - 3].p;
                        tovars[Admin.selected - 3].pokupka= tovars[Admin.selected - 3].p * tovars[Admin.selected - 3].priceFor1;
                        w =w+ tovars[Admin.selected-3].p * tovars[Admin.selected-3].priceFor1;
                        l = l + tovars[Admin.selected - 3].p;
                        tovars[Admin.selected-3].p = l;
                        Ser_deser.MySeri(tovars, "Tovar.json");
                        Cashier_Menu(g, rota, tovars[Admin.selected - 3].p);
                    } 
                }
            }
            if (Admin.selected == -10)
            {
                Cashier_Menu(g, rota);
            }
            else if (Admin.selected == -9) 
            {
               
                List<Buh_uchyot> u = Ser_deser.Mydeserial<List<Buh_uchyot>>("Buh.json");
                foreach (Tovar tovar in tovars)
                {
                    Buh_uchyot buh_Uchyot = new Buh_uchyot();
                    buh_Uchyot.ID = tovar.ID;
                    buh_Uchyot.NameOf = tovar.NameOf;
                    buh_Uchyot.Zarplata = tovar.pokupka ;
                    buh_Uchyot.time=DateTime.Now;
                    buh_Uchyot.tf = true;
                    u.Add(buh_Uchyot);
                    Ser_deser.MySeri(u, "Buh.json");
                }
               
                w = 0;
               
                int k = 3;
                while (k<=4)
                {
                    Console.SetCursorPosition(97, k);
                    Console.WriteLine("                                ");
                    k++;    
                }
                Console.SetCursorPosition(97,3);
                Console.WriteLine("Сохранено!");
                foreach (Tovar tovar in tovars)
                {
                    tovar.p = 0;
                    tovar.pokupka = 0;
                    Ser_deser.MySeri(tovars, "Tovar.json");
                }
              Admin.selected = Arrow.Checker(3, tovars.Count, tovars, "Tovar.json");
                 if (Admin.selected == -10)
                {
                    Program.Main();
                }
               
            }
        }
    }
}

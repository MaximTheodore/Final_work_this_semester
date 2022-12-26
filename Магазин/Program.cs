namespace Магазин
{
    internal class Program:CRUD
    {
       
       public static string y;
        static string yu;

       public static void Main()
        {

            /*  List<Login_password> login_Passwords = new List<Login_password>();
              Login_password login_ = new Login_password();
              login_.ID = 0;
              login_.Username = "admin";
              login_.Password = "admin";
              login_.Post = 0;
              login_Passwords.Add(login_);
              Ser_deser.MySeri(login_Passwords, "Logins.json");*/
            Console.Clear();
            Console.SetCursorPosition(35, 0);
            Console.WriteLine("Welcome to supermarket");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("Login: ");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("Password: ");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("Log in");
            List<Login_password> u = Ser_deser.Mydeserial<List<Login_password>>("Logins.json");
            Login_password omy = new Login_password();
            List<Basa> rtx = Ser_deser.Mydeserial<List<Basa>>("Basa.json");
            while (true)
            {
                int selected = Arrow.Checker(2, 3,u , "");

                if (selected == 2)
                {

                    y = Update(omy.Username, "Login:  ");

                }
                else if (selected == 3)
                {
                    yu = Update(omy.Password, "Password:   ");
                }
               


                else if (selected == 4)
                {

                    var user = u.Find(e => e.Username == y && e.Password == yu);
                    if (user != null)
                    {
                        bool a = true;
                        
                        if (user.Post == 0)
                        {
                            for (int i = 0; i < rtx.Count; i++)
                            {
                                if (rtx[i].Post == user.Post)
                                {
                                    Admin.AdminLobby(rtx[i].Name, rtx[i].Post);
                                    a = false;
                                }
                            }
                            if (a) Admin.AdminLobby(y, user.Post);
                        }
                        else if (user.Post == 1)
                        {
                            a = true;
                            for (int i = 0; i < rtx.Count; i++)
                            {
                                if (rtx[i].Post == user.Post)
                                {
                                    Cashier.Cashier_Menu(rtx[i].Name, rtx[i].Post);
                                    a = false;
                                }
                            }

                            if (a) Cashier.Cashier_Menu(y, 2);
                        }
                        else if (user.Post == 2)
                        {
                            a = true;
                            for (int i = 0; i < rtx.Count; i++)
                            {
                                if (rtx[i].Post == user.Post)
                                {
                                    Manager.Manager_menu(rtx[i].Name, rtx[i].Post);
                                    a = false;
                                }
                            }

                            if(a) Manager.Manager_menu(y, 2);
                        }
                        else if (user.Post == 3)
                        {
                            a = true;
                            for (int i = 0; i < rtx.Count; i++)
                            {
                                if (rtx[i].Post == user.Post)
                                {
                                    warehouse_manager.Sklad_menu(rtx[i].Name, rtx[i].Post);
                                    a = false;
                                }
                            }

                            if (a) warehouse_manager.Sklad_menu(y, user.Post);
                        }
                        else if (user.Post == 4)
                        {
                            a = true;
                            for (int i = 0; i < rtx.Count; i++)
                            {
                                if (rtx[i].Post == user.Post)
                                {
                                    Accountant.Buhoe_menu(rtx[i].Name, rtx[i].Post);
                                    a = false;
                                }
                            }

                            if (a) Accountant.Buhoe_menu(y, user.Post);
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 5);
                        Console.WriteLine("Неправильный логин или пароль, попробуйте снова");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Main();
                    }

                   
                }

            }
            
        }
        
    }
    
}
    
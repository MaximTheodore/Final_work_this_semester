﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Магазин
{
    internal class Login_password
    {
        public int ID;
        public string Password;
        public string Username;
        public int Post;
       
        
    }
    internal class Basa:Login_password
    {
        public string Name; 
        
        public string Surname;
        public string NameOfName;
        public long pasport;
        public string birthday;
        public double Zarplata;
        public string account;
    }
    public class Tovar
    {
        public int ID;
        public string NameOf;
        public double priceFor1;
        public int sklad;
        public int p;
        public double pokupka;    
        
    }
    internal class Buh_uchyot
    {
        public int ID;
        public string NameOf;
        public double Zarplata;
        public DateTime time = DateTime.Now;
        public bool tf;
    }
    
}

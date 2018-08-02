using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPD01.Models
{
    public class GreetDiffLang
    {
        public string Name { get; set; }
        public string[] Hellos { get; set; }
        public GreetDiffLang(string name)
        {
                Name = name;
                Hellos =new string[] {"Mirëdita", "Ahalan", "Parev", "Zdravei", "Nei Ho", "Dobrý den", "Ahoj", "Goddag", "Goede dag, Hallo", "Hello", "Saluton", "Hei", "Bonjour",
                "Guten Tag", "Gia'sou", "Aloha", "Shalom", "Namaste", "Namaste", "Jó napot", "Halló", "Helló", "Góðan daginn", "Halo", "Aksunai", "Qanuipit", "Dia dhuit",
                "Salve", "Ciao", "Kon-nichiwa", "An-nyong Ha-se-yo", "Salvëte", "Ni hao", "Dzien' dobry", "Olá", "Bunã ziua", "Zdravstvuyte", "Hola", "Jambo", "Hujambo", "Hej",
                "Sa-wat-dee", "Merhaba", "Selam", "Vitayu", "Xin chào", "Hylo", "Sut Mae", "Sholem Aleychem", "Sawubona"};
        }
        
        public string GetSize()
        {
            Random rnd = new Random();
            return (rnd.Next(8, 35)+"px").ToString();
        }
        public int GetRGB()
        {
            Random rnd = new Random();
            return rnd.Next(0,256);
        }

    }
}

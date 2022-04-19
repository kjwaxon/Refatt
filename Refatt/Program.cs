using System;

namespace Refatt
{
    class Program
    {
        /*
         * Attributeslar ve reflectionslar genelde beraber kullanılırlar.
         * Run time esnasında class enum method gibi yapılarla ilgili bilgi veren ve kontrol etmemizi sağlayan yapılardır.
         * 
         * Aşağıdaki örneğimizde person ismindeki sınıfımıza tanımladğımız prop. lerin hepsine bir değer girilmesini , oluşturduğumuz attributes sayesinde zorunlu
         * hale getirdik.
         * Control sınıfımızdaki check methodumuzla da bu kontrol işlemini sağladık.
         * Foreach ve iflerle doluluk durumuna bakıp bool bir değer döndürdük...
         * 
         * 
         */
        static void Main(string[] args)
        {
            Person p1 = new Person()
            {
                Name = "Kaan",
                Age = 26
            };

            Console.WriteLine(Control.Check(p1));
            Console.ReadLine();
                
                }
        public class Person
        {
            [zorunlu]
            public string Name;
            [zorunlu]
            public string ID;
            [zorunlu] 
            public int Age;

        }

        public class zorunluAttribute : Attribute
        {       }
        public static class Control
        {
            public static bool Check(Person ins)
            {
                Type type = ins.GetType();
                foreach(var item in type.GetFields())
                {
                    object[] attributes = item.GetCustomAttributes(typeof(zorunluAttribute), true);
                    if (attributes.Length != 0)
                    {
                        object value = item.GetValue(ins);
                        if (value == null)
                        {
                            return false;
                        }
                    }
                }
                return true;     
            }
        }
    
    }
}

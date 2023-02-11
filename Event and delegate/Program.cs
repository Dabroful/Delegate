using System;

namespace Event_and_delegate
{
    public delegate void MyDelegate();                                  //объявление глобального делегата. Не принимет аргументы и не возвращщает значения
    internal class Program
    {
        public delegate int ValueDelegate(int i);                       //объявляем новый делегат, который принимает и возвращает интовые значения.
        public static void Main(string[] args)
        {
            MyDelegate myDelegate = Methed1;                            //объявляю переменну делегата и присваиваю ей метод1.
            myDelegate += Methed4;                                      //добавляю к переменной делегата еще один схожий по сигнатурее метод4.
            myDelegate();                                               //вызываем делеагт и вместе с ним метод1

            MyDelegate myDelegate2 = new MyDelegate(Methed4);           //это другой способ создания делегата
            myDelegate2 += Methed4;                                     //в один делеагт можно добавить метод несколько раз
            myDelegate2.Invoke();                                       //а это способ вызова делегата, если он создается альтернативным способом

            MyDelegate myDelegate3 = myDelegate + myDelegate2;          //создали новую переменную делагата и в нее добавили два других делегата

            var valueDelegate = new ValueDelegate(MethedValue);         //обхявляем переменную делегата, которая принимает в себя интовый метод
            valueDelegate((new Random()).Next(10, 50));                //вызываем этот делегат, а в аргументе передаем рандомное число. Если делеагт не пустой, то нужно передавать в него аргументы
        }

        public static int MethedValue(int i)                            //метод для делегата возвращающий и принимающий интовые значения
        {
            Console.WriteLine(i);
            return i;
        }
        public static void Methed1()                                     //объявляю метод, который соответствует сигнатуре делегата. То есть ничего не принимает и не возвращает
        {
            Console.WriteLine("Methed1");
        }
        public int Methed2()                                             //отличающийся от остальных метод
        {
            Console.WriteLine("Methed2");
            return 0;
        }
        public void Methed3(int i)                                            
        {
            Console.WriteLine("Methed3");
        }
        public static void Methed4()                                            
        {
            Console.WriteLine("Methed4");
        }
        
    }
}
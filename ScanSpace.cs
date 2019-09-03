using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//КОСМИЧЕСКИЙ ОБЬЕКТ, ПЛАНЕТА, ЗВЕЗДА, чЕРНАЯ ДЫРА 

namespace Lab10_11
{
    
    class Space_obj 
    {
        public delegate void MyDeleg( double r);
        public Space_obj() {  }
        public void PhisPar(double r) {  //выводит диаметр и обьем обьекта
            MyDeleg myDel = new MyDeleg(Diam);  //добавляем в список вызова делегата  метод Diam
            myDel += new MyDeleg(Val);  //добавляем в список вызова делегата второй метод Val
            myDel(r);// вызываем оба метода         
        }   
        private int year; //объявление закрытого поля
        public int Year //объявление свойства
        {
            get // аксессор чтения поля
            {
                return year;            
            }
            set // аксессор записи в поле
            {
                if (value < 0)//value неявный параметр сожержит присваиваемое значение свойства
                    throw new MyException("Время должно быть положительно", value); //обработка ошибки


                else year = value;
            }
        }
        virtual public string Name ()
        {

            return "Basic";
        }


        virtual public double GetMass(ref int p, double r)
        {
            double m;
            if (p < 1)
                p = 1;
            if (p > 100) { p = 100; }

            m = ((4 / 3) * 3.14 * Math.Pow(r, 3)) / p;
            return m;
        }


        virtual public int GetTemp(int t)
        {
            if (t < -273)
            {
                return 0;
            }
            if (t > 100000) {
                t = 100000;
                
            }
            return t+273;
        }
        public double Rad(double r)
        {
            if (r < 1) {
                r = 1;
            }
            if (r > 1000) {
                r = 1000;
            }

            return r ;
        }
        //диаметр
        public void Diam (double r) {
            double dm = 2 * r;

            MessageBox.Show("Диаметр обьекта:  "+ dm.ToString()+ "10^3 км");
        }
        //обьем
        public void Val( double r)
        {

            double v = (4/3)*3.14*Math.Pow(r,3);
            MessageBox.Show("Обьем обьекта:  " + v.ToString() + "10^11 км^3");
        }

        ~Space_obj() { }
    }
    ///-----------------
    class Planet  : Space_obj  
    {
        public Planet() { }

        
        
        override public string Name ()   //переопределяем виртуальную функцию названия обьекта
        {
           return "Planet";
        }
        override public int GetTemp(int t)   //реализация интерфейса
        {

            if (t > 1500)
            {
                return 1500;

            }
            else
            {
                if (t < -273)
                    return 0;

                else
                
                    return t+273;
                
            }
        }
        public string DescrPlant() {
            return "Планета — это небесное тело, вращающееся по орбите вокруг звезды или её остатков, достаточно массивное, чтобы стать округлым под действием собственной гравитации, но недостаточно массивное для начала термоядерной реакции";
        }
        ~Planet() { }
    }
    class LifPlant : Planet
    {
        public LifPlant() { }
        public string InfPlL()
        {
            return "Данная планета потенциально может быть пригодна для жизни, обладает климатом схожим с Земным";
        }
        
        override public string Name()
        {
            return "Life Planet";
        }
        ~LifPlant() { }
    }
    class DiePlant : Planet
    {
        public DiePlant() { }
        public string INfPlD() {
            return "Данная планета непригодна для проживания человека, имеют место экстримальные перепады температур";
        }
        override public string Name()
        {
            return "Die Plant";
        }
       ~ DiePlant() { }
    }
    class Star :Space_obj
    {
        public Star() { }

        override  public double GetMass(ref int p, double r)
        {  //реализация интерфейса

            double m;
            if (p < 1)
                p = 1;
            if (p > 500) { p = 500; }

            m = ((4 / 3) * 3.14 * Math.Pow(r, 3)) / p;
            return m;

        }
        override  public int GetTemp(int t)   //реализация интерфейса
        {

            if (t > 30000)
            {
                return 30000; 

            } 
            else
            {
                if (t < 1500)
                    return 1500;

                else {
                    return t;
                };
            }
        }
        override public string Name()
        {
           return  "Star";
        }

        public string DescrStar()
        {

           return "Звезда — массивный газовый шар, излучающий свет и удерживаемый в состоянии равновесия силами собственной гравитации и внутренним давлением, в недрах которого происходят (или происходили ранее) реакции термоядерного синтеза.";
        }
        ~Star() { }
    }
    class Black_hole :Space_obj
    {
        public Black_hole() { }
        override public double GetMass(ref int p, double r)
        {  //реализация интерфейса

            double m;
            if (p < 500)
                p = 500;
            if (p > 1500) { p = 1500; }

            m = ((4 / 3) * 3.14 * Math.Pow(r, 3)) / p;
            return m;

        }

        override public string Name()
        {
            return "Black hole";
        }
    
        public string  DescrHole()
        {
            return "Чёрная дыра — область пространства-времени, гравитационное притяжение которой настолько велико, что покинуть её не могут даже объекты, движущиеся со скоростью света, в том числе кванты самого света.";
        }
        ~Black_hole() { }


    }
    class MyException : InvalidCastException   ///класс исключения
    {
        public int Value { get; }
        public MyException(string message, int val)
            : base(message)
        {
            Value = val;
        }
    }
}

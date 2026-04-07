using System;
using System.Collections.Generic;

namespace Exercise_Ch10_3_2
{
    // 介面定義：契約（需要實作的行為）
    interface IShape
    {
        string Info();
        double Area();
    }

    // 方法直接寫在類別上（沒有介面）
    class RectangleNoInterface
    {
        public double Width { get; }
        public double Height { get; }

        public RectangleNoInterface(double w, double h)
        {
            Width = w;
            Height = h;
        }

        public string Info()
        {
            return $"RectangleNoInterface: {Width} x {Height}";
        }

        public double Area()
        {
            return Width * Height;
        }
    }

    // 使用介面的實作：可以被當作 IShape 來處理
    class RectangleWithInterface : IShape
    {
        public double Width { get; }
        public double Height { get; }

        public RectangleWithInterface(double w, double h)
        {
            Width = w;
            Height = h;
        }

        public string Info()
        {
            return $"RectangleWithInterface: {Width} x {Height}";
        }

        public double Area()
        {
            return Width * Height;
        }
    }

    // 另一個實作，示範多型
    class Circle : IShape
    {
        public double Radius { get; }

        public Circle(double r) => Radius = r;

        public string Info() => $"Circle: r={Radius}";

        public double Area() => Math.PI * Radius * Radius;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 1) 直接使用類別的方法（不透過介面）
            var rNoIf = new RectangleNoInterface(10, 20);
            Console.WriteLine("-- 直接呼叫類別方法（無介面） --");
            Console.WriteLine(rNoIf.Info());
            Console.WriteLine("長方形面積：" + rNoIf.Area());

            Console.WriteLine();

            // 2) 使用介面，享受多型與可替換性
            IShape rIf = new RectangleWithInterface(10, 20);
            Console.WriteLine("-- 透過介面呼叫（IShape） --");
            // 呼叫端只知道 IShape，與具體實作無關
            PrintShapeInfo(rIf);

            // 把不同形狀放進同一個集合（多型）
            var shapes = new List<IShape>
            {
                rIf,
                new Circle(5)
            };

            Console.WriteLine();
            Console.WriteLine("-- IShape 集合，對所有形狀同一處理方式 --");
            foreach (var s in shapes)
            {
                PrintShapeInfo(s);
            }

            Console.WriteLine();
            Console.WriteLine("按任意鍵結束...");
            Console.ReadKey();
        }

        static void PrintShapeInfo(IShape s)
        {
            Console.WriteLine(s.Info());
            Console.WriteLine("面積：" + s.Area());
        }
    }
}

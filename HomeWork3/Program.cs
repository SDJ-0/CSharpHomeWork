using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Example3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the quantity of shapes:");
            string str = Console.ReadLine();
            int quantity;
            try
            {
                quantity = Int32.Parse(str);
            }
            catch (FormatException)
            {
                Console.WriteLine("Input error.");
                Console.ReadKey();
                return;
            }
            Shape_Factory shape_Factory = new Shape_Factory();
            double total_area = 0;
            for(int i = 0; i < quantity; i++)
            {
                Shape shape = shape_Factory.Random_Create();
                if (shape == null)
                {
                    i--;
                    continue;
                }
                total_area += shape.Area;
            }
            Console.WriteLine($"Total area: {total_area}.");
            Console.ReadKey();
        }
    }

    abstract class Shape
    {
        public abstract bool IsLegal();
        public abstract double Area { get; }
    }

    class Rectangle : Shape
    {
        private double length, width;
        public double Length { get => length; set => length = value; }
        public double Width { get => width; set => width = value; }
        public Rectangle(double length,double width)
        {
            this.length = length;
            this.width = width;
        }
        public override bool IsLegal()
        {
            if (length <= 0 || width <= 0)
            {
                return false;
            }
            return true;
        }
        public override double Area
        {
            get
            {
                if (IsLegal())
                {
                    return length * width;
                }
                return -1;
            }
        }
    }

    class Square : Shape
    {
        private double side_length;
        public double Side_length { get => side_length; set => side_length = value; }
        public Square(double side_length)
        {
            this.side_length = side_length;
        }
        public override bool IsLegal()
        {
            if (side_length <= 0)
            {
                return false;
            }
            return true;
        }
        public override double Area
        {
            get
            {
                if (IsLegal())
                {
                    return side_length * side_length;
                }
                return -1;
            }
        }
    }

    class Triangle : Shape
    {
        private double length_1, length_2, length_3;
        public double Length_1 { get => length_1; set => length_1 = value; }
        public double Length_2 { get => length_2; set => length_2 = value; }
        public double Length_3 { get => length_3; set => length_3 = value; }
        public Triangle(double length_1, double length_2, double length_3)
        {
            this.length_1 = length_1;
            this.length_2 = length_2;
            this.length_3 = length_3;
        }
        public override bool IsLegal()
        {
            if (length_1 + length_2 <= length_3 ||
                length_1 + length_3 <= length_2 ||
                length_2 + length_3 <= length_1)
            {
                return false;
            }
                return true;
        }
        public override double Area
        {
            get
            {
                if (IsLegal())
                {
                    double p = (length_1 + length_2 + length_3) / 2;
                    double area = p * (p - length_1) * (p - length_2) * (p - length_3);
                    area = Math.Pow(area, 0.5);
                    return area;
                }
                return -1;
            }
        }
    }

    class Circle : Shape
    {
        double radius;
        public double Radius { get => radius; set => radius = value; }
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override bool IsLegal()
        {
            if (radius <= 0)
            {
                return false;
            }
            return true;
        }
        public override double Area
        {
            get
            {
                if (IsLegal())
                {
                    return Math.PI * radius * radius;
                }
                return -1;
            }
        }
    }

    class Shape_Factory
    {
        public Shape Create(string str)
        {
            Random rd = new Random();
            str = str.ToLower();
            switch(str){
                case "rectangle":
                    return Create_Rectangle();
                case "square":
                    return Create_Square();
                case "triangle":
                    return Create_Triangle();
                case "circle":
                    return Create_Circle();
                default:
                    return null;
            }
        }
        public Shape Random_Create()
        {
            Random rd = new Random();
            int model = rd.Next(4);
            switch (model)
            {
                case 0:
                    return Create_Rectangle();
                case 1:
                    return Create_Square();
                case 2:
                    return Create_Triangle();
                case 3:
                    return Create_Circle();
                default:
                    return null;
            }
        }
        public Shape Create_Rectangle()
        {
            Shape shape;
            Random rd = new Random();
            while (true)
            {
                shape = new Rectangle(rd.Next(100), rd.Next(100));
                if (shape.Area != -1)
                    return shape;
            }
        }
        public Shape Create_Square()
        {
            Shape shape;
            Random rd = new Random();
            while (true)
            {
                shape = new Square(rd.Next(100));
                if (shape.Area != -1)
                    return shape;
            }
        }
        public Shape Create_Triangle()
        {
            Shape shape;
            Random rd = new Random();
            while (true)
            {
                shape = new Triangle(rd.Next(100), rd.Next(100), rd.Next(100));
                if (shape.Area != -1)
                    return shape;
            }
        }
        public Shape Create_Circle()
        {
            Shape shape;
            Random rd = new Random();
            while (true)
            {
                shape = new Circle(rd.Next(100));
                if (shape.Area != -1)
                    return shape;
            }
        }
    }
}

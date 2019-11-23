using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q1
{
    public abstract class My2DPoint
    {
        public double x { get; set; }
        public double y { get; set; }
        public abstract double Distance(My2DPoint target);
    }
    public class ManhattanPoint : My2DPoint
    {
        public override double Distance(My2DPoint b)
        {
            return Math.Abs(this.x - b.x) + Math.Abs(this.y - b.y);
        }
    }
    public class EuclideanPoint : My2DPoint
    {
        public override double Distance(My2DPoint b)
        {
            return Math.Sqrt(Math.Pow((this.x - b.x), 2) + Math.Pow((this.y - b.y), 2));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            My2DPoint target = new ManhattanPoint()
            {
                x = 10,
                y = 10
            };
            My2DPoint manhattan = new ManhattanPoint()
            {
                x = 1,
                y = 1
            };
            My2DPoint euclidean = new EuclideanPoint()
            {
                x = 1,
                y = 1
            };
            Console.WriteLine("Manhattan: " + manhattan.Distance(target));
            Console.WriteLine("Euclidean: " + euclidean.Distance(target));
            Console.ReadKey();
        }
    }
}

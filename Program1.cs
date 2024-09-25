using System;


namespace Task1
{

    public struct Vector 
    {
        private int x,y,z;

        public Vector(int x, int y, int z) 
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector operator+ (Vector v1, Vector v2) 
        {
            Vector v3 = new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
            return v3;
        }

        public static Vector operator* (Vector v, int a)
        {
            v.x = v.x* a;
            v.y = v.y * a;
            v.z = v.z * a;
            return v;
        }

        public static Vector operator *(Vector v1, Vector v2)
        {
            Vector v3 = new Vector(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            return v3;
        }

        public void print() 
        {
            Console.WriteLine($"x={x}, y={y}, z={z}");
        }

        public static bool operator <(Vector v1, Vector v2) 
        {
            return Math.Sqrt(v1.x * v1.x + v1.y * v1.y + v1.z * v1.z) < Math.Sqrt(v2.x * v2.x + v2.y * v2.y + v2.z * v2.z);
        }
        public static bool operator >(Vector v1, Vector v2)
        {
            return Math.Sqrt(v1.x * v1.x + v1.y * v1.y + v1.z * v1.z) > Math.Sqrt(v2.x * v2.x + v2.y * v2.y + v2.z * v2.z); ;
        }

        public static bool operator ==(Vector v1, Vector v2) 
        {
            return Math.Sqrt(v1.x * v1.x + v1.y * v1.y + v1.z * v1.z) == Math.Sqrt(v2.x * v2.x + v2.y * v2.y + v2.z * v2.z);
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return Math.Sqrt(v1.x * v1.x + v1.y * v1.y + v1.z * v1.z) != Math.Sqrt(v2.x * v2.x + v2.y * v2.y + v2.z * v2.z);
        }
    }
    public class Program
    {
        static void Main()
        {
            Vector v1 = new Vector(2, 6, 7);
            Vector v2 = new Vector(-4, 8, 1);
            Vector v3 = v1 + v2;
            v3.print();
            Vector v4 = v1 * 2;
            v4.print();
            if(v1 > v2) 
            {
                v1.print();
            }
        }
    }
}

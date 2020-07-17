using System;
using System.Collections.Generic;
using System.Text;

namespace AutoConsole
{
    struct Vector2
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
            => new Vector2(a.X + b.X, a.Y + b.Y);

        public static Vector2 operator *(Vector2 v, float f)
            => new Vector2(v.X * f, v.Y * f);

        public static Vector2 Zero => new Vector2(0.0f, 0.0f);
    }
    
    class Utils
    {
        public static Vector2 RadianToVector2(float rad)
        {
            return new Vector2(
                MathF.Sin(rad), // x
                -MathF.Cos(rad)); // y
        }

        public static int RadianToDegrees(float rad)
        {
            int degrees = (int)(rad * 180 / MathF.PI) % 360;

            if (degrees < 0)
                degrees += 360;

            return degrees;
        }
    }
}
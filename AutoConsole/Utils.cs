using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace AutoConsole
{
    class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
            => new Vector2(a.X + b.X, a.Y + b.Y);

        public static Vector2 operator *(Vector2 v, float f)
            => new Vector2(v.X * f, v.Y * f);

        public static Vector2 Zero { get { return new Vector2(0.0f, 0.0f); } }
    }

    class Utils
    {
        public static Vector2 RadianToVector2(float rad)
        {
            return new Vector2(
                MathF.Cos(rad), // x
                MathF.Sin(rad)); // y
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

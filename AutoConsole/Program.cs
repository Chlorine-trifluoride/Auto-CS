using System;
using System.Drawing;
using System.Threading.Tasks;

namespace AutoConsole
{
    class Program
    {
        static void PrintOutput(Car car)
        {
            Console.Clear(); // TODO: fix blinking?

            Point p = new Point((int)car.Position.X, (int)car.Position.Y);
            // Set origin to center
            p.X += Console.BufferWidth / 2;
            p.Y += Console.WindowHeight / 2;

            // Edge wrap
            p.X = p.X % Console.BufferWidth;
            p.Y = p.Y % Console.WindowHeight;

            if (p.X < 0)
                p.X += Console.BufferWidth;

            if (p.Y < 0)
                p.Y += Console.WindowHeight;

            Console.SetCursorPosition(p.X, p.Y);
            Console.Write('X');

            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.WriteLine($"Car is on? {car.IsEngineOn} || Velocity: {car.VelocityInKmh} || Rotation: {car.RotationDegrees}");
        }
        
        static void Main(string[] args)
        {
            bool quit = false;

            Car car = new Car();
            Task.Run(async () =>
            {
                try // Catch any issues
                {
                    while (!quit)
                    {
                        car.Update();
                        PrintOutput(car);

                        await Task.Delay(100);
                    }
                } catch (Exception e) { Console.WriteLine(e); }
            });

            while(!quit)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(false);
                ConsoleKey key = keyInfo.Key;

                switch (key)
                {
                    case ConsoleKey.A:
                        car.SteerLeft();
                        break;
                    case ConsoleKey.D:
                        car.SteerRight();
                        break;
                    case ConsoleKey.W:
                        car.Accelerate();
                        break;
                    case ConsoleKey.S:
                        car.Decelerate();
                        break;

                    case ConsoleKey.Z:
                        car.TurnEngineOn();
                        break;
                    case ConsoleKey.X:
                        car.TurnEngineOff();
                        break;

                    case ConsoleKey.Escape:
                        quit = true;
                        break;
                }
            }
        }
    }
}

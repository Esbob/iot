// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading;

namespace Iot.Device.QwiicTwist.Samples
{
    /// <summary>
    /// Sets the color of the Qwiic Twist knob.
    /// </summary>
    internal class SetKnobColor
    {
        public static void Run(QwiicTwist twist)
        {
            Console.WriteLine("Set knob color sample started - press ESC to stop");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("### Red color ###");
            Console.WriteLine("Press 1 to decrease red color value (min is 0)");
            Console.WriteLine("Press 2 to increase red color value (max is 255)");
            Console.WriteLine();
            Console.WriteLine("### Green color ###");
            Console.WriteLine("Press 3 to decrease green color value (min is 0)");
            Console.WriteLine("Press 4 to increase green color value (max is 255)");
            Console.WriteLine();
            Console.WriteLine("### Blue color ###");
            Console.WriteLine("Press 5 to decrease blue color value (min is 0)");
            Console.WriteLine("Press 6 to increase blue color value (max is 255)");
            Console.WriteLine();
            Console.WriteLine("### All three colors ###");
            Console.WriteLine("Press 7 to reset to default color");
            Console.WriteLine("Press 8 to switch off LED");

            byte redValue = 255;
            byte greenValue = 255;
            byte blueValue = 255;

            do
            {
                while (Console.KeyAvailable == false)
                {
                   Thread.Sleep(10);
                }

                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    {
                        redValue = DecreaseValueIfNotMin(redValue);
                        twist.SetRed(redValue);
                        Console.WriteLine($"Red color value set to {redValue}");
                        break;
                    }

                    case ConsoleKey.D2:
                    {
                        redValue = IncreaseValueIfNotMax(redValue);
                        twist.SetRed(redValue);
                        Console.WriteLine($"Red color value set to {redValue}");
                        break;
                    }

                    case ConsoleKey.D3:
                    {
                        greenValue = DecreaseValueIfNotMin(greenValue);
                        twist.SetGreen(greenValue);
                        Console.WriteLine($"Green color value set to {greenValue}");
                        break;
                    }

                    case ConsoleKey.D4:
                    {
                        greenValue = IncreaseValueIfNotMax(greenValue);
                        twist.SetGreen(greenValue);
                        Console.WriteLine($"Green color value set to {greenValue}");
                        break;
                    }

                    case ConsoleKey.D5:
                    {
                        blueValue = DecreaseValueIfNotMin(blueValue);
                        twist.SetBlue(blueValue);
                        Console.WriteLine($"Blue color value set to {blueValue}");
                        break;
                    }

                    case ConsoleKey.D6:
                    {
                        blueValue = IncreaseValueIfNotMax(blueValue);
                        twist.SetBlue(blueValue);
                        Console.WriteLine($"Blue color value set to {blueValue}");
                        break;
                    }

                    case ConsoleKey.D7:
                    {
                        twist.SetColor(255, 255, 255);
                        Console.WriteLine($"Red/green/blue set to 255");
                        break;
                    }

                    case ConsoleKey.D8:
                    {
                        twist.SetColor(0, 0, 0);
                        Console.WriteLine($"Red/green/blue set to 0");
                        break;
                    }
                }

                Thread.Sleep(20); // Don't hammer too hard on the I2c bus
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private static byte DecreaseValueIfNotMin(byte value)
        {
            if (value > 0)
            {
                value--;
            }

            return value;
        }

        private static byte IncreaseValueIfNotMax(byte value)
        {
            if (value < 255)
            {
                value++;
            }

            return value;
        }
    }
}

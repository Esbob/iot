// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading;

namespace Iot.Device.QwiicTwist.Samples
{
    /// <summary>
    /// Checks whether the knob is turned or pressed and then prints its status in the console.
    /// </summary>
    internal class PrintTwistStatus
    {
        public static void Run(QwiicTwist twist)
        {
            Console.WriteLine("Print Twist status sample started - press ESC to stop");

            do
            {
                while (!Console.KeyAvailable)
                {
                    Console.WriteLine($"Indents count: {twist.GetTurnCount()}");

                    // Check if Twist is pressed, and tell us if it is!
                    if (twist.IsPressed())
                    {
                        Console.WriteLine("The knob is pressed!");
                        while (twist.IsPressed())
                        {
                            Thread.Sleep(10); // Wait for user to stop pressing
                        }

                        Console.WriteLine("The knob is not pressed anymore!");
                    }

                    if (twist.IsClicked())
                    {
                        Console.WriteLine("The knob was clicked (pressed down and released)!");
                    }

                    Thread.Sleep(100); // Don't hammer too hard on the I2c bus
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}

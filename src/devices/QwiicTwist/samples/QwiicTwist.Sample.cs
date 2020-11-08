// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Iot.Device.QwiicTwist.Samples
{
    /// <summary>
    /// Samples for QwiicTwist
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point
        /// </summary>
        public static void Main(string[] args)
        {
            DisplayWelcomeMessage();

            if (ShouldScanForI2cDevices())
            {
                FindI2cDevices.Run();
            }

            var deviceBusId = GetDeviceBusId();
            var deviceAddress = GetDeviceAddress();
            var sampleNumber = GetSampleNumber();

            using (var twist = new QwiicTwist(deviceBusId, deviceAddress))
            {
                switch (sampleNumber)
                {
                    case 1:
                        PrintTwistConfiguration.Run(twist);
                        break;
                    case 2:
                        PrintTwistStatus.Run(twist);
                        break;
                    case 3:
                        SetKnobColor.Run(twist);
                        break;
                    // case 3:
                    //    new PrintButtonStatusInterruptBased().Run(twist);
                    //    break;
                    // case 4:
                    //    LightWhenPressed.Run(twist);
                    //    break;
                    // case 5:
                    //    PulseWhenPressed.Run(twist);
                    //    break;
                    // case 6:
                    //    OnOffButtonWithLight.Run(twist);
                    //    break;
                    case 8:
                        ChangeI2cAddress.Run(twist);
                        break;
                    default:
                        Console.WriteLine("No sample chosen - exiting...");
                        break;
                }
            }
        }

        private static int GetDeviceBusId()
        {
            Console.WriteLine("Enter I2C bus ID that the Qwiic Twist is attached to: [Press Enter for default = 1]");
            string deviceBusId = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(deviceBusId))
            {
                deviceBusId = "1";
            }

            Console.WriteLine("Using bus ID " + deviceBusId);
            Console.WriteLine();
            return int.Parse(deviceBusId);
        }

        private static byte GetDeviceAddress()
        {
            Console.WriteLine("Enter Qwiic Twist I2C address as decimal number: [Press Enter for default = 63]");
            string deviceAddress = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(deviceAddress))
            {
                deviceAddress = "63";
            }

            Console.WriteLine("Using address " + deviceAddress);
            Console.WriteLine();
            return byte.Parse(deviceAddress);
        }

        private static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Qwiic Twist samples!");
            Console.WriteLine("------------------------------------");
        }

        private static bool ShouldScanForI2cDevices()
        {
            Console.WriteLine("Do you want to scan for I2C devices before setting I2C bus ID and device address? [Y/N]");
            return Console.ReadLine()?.ToUpperInvariant() == "Y";
        }

        private static int GetSampleNumber()
        {
            Console.WriteLine("Choose a sample by typing the corresponding number:");
            Console.WriteLine();
            Console.WriteLine("1. Print Twist configuration");
            Console.WriteLine("2. Print Twist status");
            Console.WriteLine("3. Set knob color");
            // Console.WriteLine("3. Print button status - interrupt based");
            // Console.WriteLine("4. Light when button pressed");
            // Console.WriteLine("5. Pulse when button pressed");
            // Console.WriteLine("6. ON/OFF button with light when ON");
            Console.WriteLine("8. Change I2C address");

            string sampleNumber = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(sampleNumber))
            {
                sampleNumber = "0";
            }

            return int.Parse(sampleNumber);
        }
    }
}

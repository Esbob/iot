﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Iot.Device.QwiicButton.Samples
{
    /// <summary>
    /// Samples for QwiicButton
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point
        /// </summary>
        public static void Main(string[] args)
        {
            DisplayWelcomeMessage();

            var deviceBusId = GetDeviceBusId();
            var deviceAddress = GetDeviceAddress();
            var sampleNumber = GetSampleNumber();
            var button = new QwiicButton(deviceBusId, deviceAddress);

            switch (sampleNumber)
            {
                case 1:
                    PrintButtonStatus.Run(button);
                    break;
                default:
                    Console.WriteLine("No sample chosen - exiting...");
                    break;
            }
        }

        private static int GetDeviceBusId()
        {
            Console.WriteLine("Enter Qwiic Button I2C bus ID: [Press Enter for default = 1]");
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
            Console.WriteLine("Enter Qwiic Button I2C address: [Press Enter for default = 111]");
            string deviceAddress = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(deviceAddress))
            {
                deviceAddress = "111";
            }

            Console.WriteLine("Using address " + deviceAddress);
            Console.WriteLine();
            return byte.Parse(deviceAddress);
        }

        private static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Qwiic Button samples!");
            Console.WriteLine("------------------------------------");
        }

        private static int GetSampleNumber()
        {
            Console.WriteLine("Choose a sample by typing the corresponding number:");
            Console.WriteLine();
            Console.WriteLine("1. Print button status");

            string sampleNumber = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(sampleNumber))
            {
                sampleNumber = "0";
            }

            return int.Parse(sampleNumber);
        }
    }
}

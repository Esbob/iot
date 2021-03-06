﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Iot.Device.QwiicButton.Samples
{
    /// <summary>
    /// Prints button configuration to the console.
    /// </summary>
    internal class PrintButtonConfiguration
    {
        public static void Run(QwiicButton button)
        {
            Console.WriteLine("Qwiic Button Configuration");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Device ID: {button.GetDeviceId()}");
            Console.WriteLine($"Firmware version: {button.GetFirmwareVersion()}");
            Console.WriteLine($"Debounce time: {button.GetDebounceTime().TotalMilliseconds}ms");
        }
    }
}

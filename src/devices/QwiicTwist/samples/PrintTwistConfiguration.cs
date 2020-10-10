// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Iot.Device.QwiicTwist.Samples
{
    /// <summary>
    /// Prints Twist configuration to the console.
    /// </summary>
    internal class PrintTwistConfiguration
    {
        public static void Run(QwiicTwist twist)
        {
            Console.WriteLine("Qwiic Twist Configuration");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"I2C bus ID: {twist.I2cBusId}");
            Console.WriteLine($"I2C bus address: 0x{twist.I2cAddress:X} (decimal: {twist.I2cAddress})");
            Console.WriteLine($"Device ID: {twist.GetDeviceId()}");
            Console.WriteLine($"Firmware version: {twist.GetFirmwareVersionAsInteger()} ({twist.GetFirmwareVersionAsString()})");
        }
    }
}

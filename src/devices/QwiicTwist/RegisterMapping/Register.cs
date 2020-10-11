//// Licensed to the .NET Foundation under one or more agreements.
//// The .NET Foundation licenses this file to you under the MIT license.
//// See the LICENSE file in the project root for more information.

namespace Iot.Device.QwiicTwist.RegisterMapping
{
    /// <summary>
    /// Register map for the Qwiic Twist.
    /// </summary>
    internal enum Register : byte
    {
        Id = 0x00,
        Status = 0x01, // 2 - button clicked, 1 - button pressed, 0 - encoder moved
        FirmwareMajor = 0x02,
        FirmwareMinor = 0x03,
        TWIST_ENABLE_INTS = 0x04, // 1 - button interrupt, 0 - encoder interrupt
        Count = 0x05,
        TWIST_DIFFERENCE = 0x07,
        TWIST_LAST_ENCODER_EVENT = 0x09, // Millis since last movement of knob
        LastButtonEvent = 0x0B,  // Millis since last press/release
        TWIST_RED = 0x0D,
        TWIST_GREEN = 0x0E,
        TWIST_BLUE = 0x0F,
        TWIST_CONNECT_RED = 0x10, // Amount to change red LED for each encoder tick
        TWIST_CONNECT_GREEN = 0x12,
        TWIST_CONNECT_BLUE = 0x14,
        TWIST_TURN_INT_TIMEOUT = 0x16,
        I2cAddress = 0x18,
        TWIST_LIMIT = 0x19
    }
}

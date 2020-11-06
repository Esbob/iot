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
        Status = 0x01,
        FirmwareMajor = 0x02,
        FirmwareMinor = 0x03,
        InterruptConfig = 0x04,
        Count = 0x05,
        Difference = 0x07,
        LastEncoderEvent = 0x09,
        LastButtonEvent = 0x0B,
        Red = 0x0D,
        Green = 0x0E,
        Blue = 0x0F,
        ConnectRed = 0x10,
        TWIST_CONNECT_GREEN = 0x12,
        TWIST_CONNECT_BLUE = 0x14,
        TurnInterruptTimeout = 0x16,
        I2cAddress = 0x18,
        Limit = 0x19
    }
}

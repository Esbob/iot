// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Device.I2c;
using Iot.Device.Common;
using Iot.Device.QwiicTwist.RegisterMapping;

namespace Iot.Device.QwiicTwist
{
    /// <summary>
    /// The Qwiic Twist is a I2C controlled encoder
    /// TODO
    /// </summary>
    public sealed partial class QwiicTwist : IDisposable
    {
        private const int DefaultAddress = 0x3F; // 7-bit unshifted default I2C address
        private I2cRegisterAccess<Register> _registerAccess;

        /// <summary>
        /// Initializes a new instance of the <see cref="QwiicTwist"/> class.
        /// </summary>
        /// <param name="i2cBusId">I2C bus ID the Twist is connected to.</param>
        /// <param name="i2cAddress">I2C bus address of the Twist (default=0x3F).</param>
        public QwiicTwist(int i2cBusId, byte i2cAddress = DefaultAddress)
        {
            I2cBusId = i2cBusId;
            I2cAddress = i2cAddress;
            var settings = new I2cConnectionSettings(i2cBusId, i2cAddress);
            var device = I2cDevice.Create(settings);
            _registerAccess = new I2cRegisterAccess<Register>(device);
        }

        /// <summary>
        /// I2C bus ID the Twist is connected to.
        /// </summary>
        public int I2cBusId { get; set; }

        /// <summary>
        /// I2C bus address of the Twist.
        /// </summary>
        public byte I2cAddress { get; set; }

        /// <summary>
        /// Returns the 8-bit device ID of the Twist.
        /// </summary>
        public byte GetDeviceId()
        {
            return _registerAccess.ReadSingleRegister(Register.Id);
        }

        /// <summary>
        /// Returns the firmware version of the Twist as a 16-bit integer.
        /// The leftmost (high) byte is the major revision number, and the rightmost (low) byte is
        /// the minor revision number.
        /// </summary>
        public ushort GetFirmwareVersionAsInteger()
        {
            ushort version = (ushort)(_registerAccess.ReadSingleRegister(Register.FirmwareMajor) << 8);
            version |= _registerAccess.ReadSingleRegister(Register.FirmwareMinor);
            return version;
        }

        /// <summary>
        /// Returns the firmware version of the Twist as a [major revision].[minor revision] string.
        /// </summary>
        public string GetFirmwareVersionAsString()
        {
            var major = _registerAccess.ReadSingleRegister(Register.FirmwareMajor);
            var minor = _registerAccess.ReadSingleRegister(Register.FirmwareMinor);
            return major + "." + minor;
        }

        /// <summary>
        /// Configures the Twist to attach to the I2C bus using the specified address.
        /// </summary>
        public void SetI2cAddress(byte address)
        {
            if (address < 0x08 || address > 0x77)
            {
                throw new ArgumentOutOfRangeException(nameof(address), "I2C input address must be between 0x08 and 0x77");
            }

            _registerAccess.WriteSingleRegister(Register.I2cAddress, address);
            I2cAddress = address;
        }

        // TODO
        // Clears the moved, clicked, and pressed bits
        // void TWIST::clearInterrupts()
        // {
        //    writeRegister(TWIST_STATUS, 0); //Clear the moved, clicked, and pressed bits
        // }

        /// <inheritdoc />
        public void Dispose()
        {
            _registerAccess?.Dispose();
            _registerAccess = null;
        }
    }
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Device.I2c;
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
            var settings = new I2cConnectionSettings(i2cBusId, i2cAddress);
            var device = I2cDevice.Create(settings);
            _registerAccess = new I2cRegisterAccess<Register>(device, useLittleEndian: true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QwiicTwist"/> class.
        /// </summary>
        /// <param name="i2cDevice">Qwiic Twist communications channel.</param>
        public QwiicTwist(I2cDevice i2cDevice)
        {
            if (i2cDevice == null)
            {
                throw new ArgumentNullException(nameof(i2cDevice));
            }

            _registerAccess = new I2cRegisterAccess<Register>(i2cDevice, useLittleEndian: true);
        }

        /// <summary>
        /// Returns the 8-bit device ID of the Twist.
        /// </summary>
        public byte GetDeviceId()
        {
            return _registerAccess.ReadRegister<byte>(Register.Id);
        }

        /// <summary>
        /// Returns the firmware version of the Twist.
        /// </summary>
        public Version GetFirmwareVersion()
        {
            var major = _registerAccess.ReadRegister<byte>(Register.FirmwareMajor);
            var minor = _registerAccess.ReadRegister<byte>(Register.FirmwareMinor);
            return new Version(major, minor);
        }

        /// <summary>
        /// Configures the Twist to attach to the I2C bus using the specified address.
        /// Since this operation does not update the configuration of the underlying <see cref="I2cDevice"/>,
        /// the <see cref="QwiicTwist"/> instance is subsequently misconfigured and thus actively disposed.
        /// </summary>
        public void ChangeI2cAddressAndDispose(byte address)
        {
            if (address < 0x08 || address > 0x77)
            {
                throw new ArgumentOutOfRangeException(nameof(address), "I2C input address must be between 0x08 and 0x77");
            }

            _registerAccess.WriteRegister(Register.I2cAddress, address);
            Dispose();
        }

        /// <summary>
        /// Clears the turned, clicked, and pressed down bits, see <see cref="StatusRegisterBitField"/>.
        /// </summary>
        public void ClearStatusFlags()
        {
            _registerAccess.WriteRegister<byte>(Register.Status, 0);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _registerAccess?.Dispose();
            _registerAccess = null;
        }
    }
}

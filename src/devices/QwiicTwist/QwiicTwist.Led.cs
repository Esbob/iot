// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Iot.Device.QwiicTwist.RegisterMapping;

namespace Iot.Device.QwiicTwist
{
    public sealed partial class QwiicTwist
    {
        /// <summary>
        /// Sets the color of the encoder LED.
        /// </summary>
        /// <param name="red">Brightness of the red LED; value between 0 and 255.</param>
        /// <param name="green">Brightness of the green LED; value between 0 and 255.</param>
        /// <param name="blue">Brightness of the blue LED; value between 0 and 255.</param>
        public void SetColor(byte red, byte green, byte blue)
        {
            _registerAccess.WriteRegister(Register.Red, (uint)red << 16 | (uint)green << 8 | blue);
        }

        /// <summary>
        /// Sets the brightness of the red LED.
        /// Value between 0 and 255.
        /// Default is 255.
        /// </summary>
        public void SetRed(byte red)
        {
            _registerAccess.WriteRegister(Register.Red, red);
        }

        /// <summary>
        /// Sets the brightness of the green LED.
        /// Value between 0 and 255.
        /// Default is 255.
        /// </summary>
        public void SetGreen(byte green)
        {
            _registerAccess.WriteRegister(Register.Green, green);
        }

        /// <summary>
        /// Sets the brightness of the blue LED.
        /// Value between 0 and 255.
        /// Default is 255.
        /// </summary>
        public void SetBlue(byte blue)
        {
            _registerAccess.WriteRegister(Register.Blue, blue);
        }

        /// <summary>
        /// Returns the current red value of the LED.
        /// </summary>
        public byte GetRed()
        {
            return _registerAccess.ReadRegister<byte>(Register.Red);
        }

        /// <summary>
        /// Returns the current green value of the LED.
        /// </summary>
        public byte GetGreen()
        {
            return _registerAccess.ReadRegister<byte>(Register.Green);
        }

        /// <summary>
        /// Returns the current blue value of the LED.
        /// </summary>
        public byte GetBlue()
        {
            return _registerAccess.ReadRegister<byte>(Register.Blue);
        }

        /// <summary>
        /// Sets the relation between each color and the turning of the knob.
        /// This will connect the LED so it changes [amount] with each encoder tick.
        /// Negative numbers are allowed: LED gets brighter the more the encoder is turned down.
        /// </summary>
        /// <param name="red">Value between -255 and 255 indicating the amount to change the red LED brightness with each tick movement of the encoder.
        /// Default is 0.
        /// </param>
        /// <param name="green">Value between -255 and 255 indicating the amount to change the green LED brightness with each tick movement of the encoder.
        /// Default is 0.
        /// </param>
        /// <param name="blue">Value between -255 and 255 indicating the amount to change the blue LED brightness with each tick movement of the encoder.
        /// Default is 0.
        /// </param>
        public void ConnectColor(short red, short green, short blue)
        {
            _registerAccess.WriteRegister(
                Register.ConnectRed, (ulong)red >> 8 | (ulong)red & 0xFF | (ulong)green >> 8 | (ulong)green & 0xFF | (ulong)blue >> 8 | (ulong)blue & 0xFF);
        }

        /// <summary>
        /// Sets the amount to change the red LED brightness with each tick movement of the encoder.
        /// Value between -255 and 255.
        /// Default is 0.
        /// </summary>
        public void ConnectRed(short red)
        {
            _registerAccess.WriteRegister(Register.ConnectRed, red);
        }

        /// <summary>
        /// Sets the amount to change the green LED brightness with each tick movement of the encoder.
        /// Value between -255 and 255.
        /// Default is 0.
        /// </summary>
        public void ConnectGreen(short green)
        {
            _registerAccess.WriteRegister(Register.ConnectGreen, green);
        }

        /// <summary>
        /// Sets the amount to change the blue LED brightness with each tick movement of the encoder.
        /// Value between -255 and 255.
        /// Default is 0.
        /// </summary>
        public void ConnectBlue(short blue)
        {
            _registerAccess.WriteRegister(Register.ConnectBlue, blue);
        }

        /// <summary>
        /// Returns the amount to change the red LED brightness with each tick movement of the encoder.
        /// Value between -255 and 255.
        /// Default is 0.
        /// </summary>
        public short GetRedConnect()
        {
            return _registerAccess.ReadRegister<short>(Register.ConnectRed);
        }

        /// <summary>
        /// Returns the amount to change the green LED brightness with each tick movement of the encoder.
        /// Value between -255 and 255.
        /// Default is 0.
        /// </summary>
        public short GetGreenConnect()
        {
            return _registerAccess.ReadRegister<short>(Register.ConnectGreen);
        }

        /// <summary>
        /// Returns the amount to change the blue LED brightness with each tick movement of the encoder.
        /// Value between -255 and 255.
        /// Default is 0.
        /// </summary>
        public short GetBlueConnect()
        {
            return _registerAccess.ReadRegister<short>(Register.ConnectBlue);
        }
    }
}

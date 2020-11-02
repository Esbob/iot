//// Licensed to the .NET Foundation under one or more agreements.
//// The .NET Foundation licenses this file to you under the MIT license.
//// See the LICENSE file in the project root for more information.

using System;

namespace Iot.Device.QwiicTwist.RegisterMapping
{
    internal struct InterruptConfigBitField
    {
        [Flags]
        private enum InterruptConfigBits
        {
            EnableEncoder = 1, // Bit 0
            EnableButton = 2 // Bit 1
        }

        private InterruptConfigBits _interruptConfigValue;

        public InterruptConfigBitField(byte interruptConfigValue)
        {
            _interruptConfigValue = (InterruptConfigBits)interruptConfigValue;
        }

        public byte InterruptConfigValue => (byte)_interruptConfigValue;

        /// <summary>
        /// Set to true to enable an interrupt when the encoder is turned.
        /// Defaults to true.
        /// </summary>
        public bool EnableEncoder
        {
            get { return FlagsHelper.IsSet(_interruptConfigValue, InterruptConfigBits.EnableEncoder); }
            set { FlagsHelper.SetValue(ref _interruptConfigValue, InterruptConfigBits.EnableEncoder, value); }
        }

        /// <summary>
        /// Set to true to enable an interrupt when the button is pressed down. TODO: What about Clicked?
        /// Defaults to true.
        /// </summary>
        public bool EnableButton
        {
            get { return FlagsHelper.IsSet(_interruptConfigValue, InterruptConfigBits.EnableButton); }
            set { FlagsHelper.SetValue(ref _interruptConfigValue, InterruptConfigBits.EnableButton, value); }
        }
    }
}

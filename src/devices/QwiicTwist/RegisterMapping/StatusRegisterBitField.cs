//// Licensed to the .NET Foundation under one or more agreements.
//// The .NET Foundation licenses this file to you under the MIT license.
//// See the LICENSE file in the project root for more information.

using System;

namespace Iot.Device.QwiicTwist.RegisterMapping
{
    internal struct StatusRegisterBitField
    {
        // TODO
        // If doesn't work, from docs:
        // buttonPressed(3),
        // buttonClicked(2),
        // buttonInterrupt(1),
        // encoderInterrupt(0).
        [Flags]
        private enum StatusRegisterBits
        {
            EncoderTurned = 0,
            ButtonPressedDown = 1,
            ButtonClicked = 2
        }

        private StatusRegisterBits _statusRegisterValue;

        public StatusRegisterBitField(byte statusRegisterValue)
        {
            _statusRegisterValue = (StatusRegisterBits)statusRegisterValue;
        }

        public byte StatusRegisterValue => (byte)_statusRegisterValue;

        /// <summary>
        /// Gets set to true if the encoder is turned.
        /// Must be manually set to false to clear the flag.
        /// </summary>
        public bool IsEncoderTurned
        {
            get { return FlagsHelper.IsSet(_statusRegisterValue, StatusRegisterBits.EncoderTurned); }
            set { FlagsHelper.SetValue(ref _statusRegisterValue, StatusRegisterBits.EncoderTurned, value); }
        }

        /// <summary>
        /// Gets set to true if the button is pressed.
        /// Must be manually set to false to clear the flag.
        /// </summary>
        public bool IsButtonPressedDown
        {
            get { return FlagsHelper.IsSet(_statusRegisterValue, StatusRegisterBits.ButtonPressedDown); }
            set { FlagsHelper.SetValue(ref _statusRegisterValue, StatusRegisterBits.ButtonPressedDown, value); }
        }

        /// <summary>
        /// Gets set to true when the button gets clicked.
        /// Must be manually set to false to clear the flag.
        /// </summary>
        public bool IsButtonClicked
        {
            get { return FlagsHelper.IsSet(_statusRegisterValue, StatusRegisterBits.ButtonClicked); }
            set { FlagsHelper.SetValue(ref _statusRegisterValue, StatusRegisterBits.ButtonClicked, value); }
        }
    }
}

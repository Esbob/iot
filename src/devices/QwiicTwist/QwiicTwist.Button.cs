// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Iot.Device.QwiicTwist.RegisterMapping;

namespace Iot.Device.QwiicTwist
{
    public sealed partial class QwiicTwist
    {
        /// <summary>
        /// Returns whether the knob is currently being pressed.
        /// Is subsequently set to false.
        /// </summary>
        public bool IsPressed()
        {
            var status = new StatusRegisterBitField(_registerAccess.ReadRegister<byte>(Register.Status));
            var isButtonPressed = status.IsButtonPressedDown;
            status.IsButtonPressedDown = false;
            _registerAccess.WriteRegister(Register.Status, status.StatusRegisterValue); // We've read this status bit, now clear it
            return isButtonPressed;
        }

        /// <summary>
        /// Returns whether the knob has been clicked.
        /// Is subsequently set to false.
        /// </summary>
        public bool IsClicked()
        {
            var status = new StatusRegisterBitField(_registerAccess.ReadRegister<byte>(Register.Status));
            var isButtonClicked = status.IsButtonClicked;
            status.IsButtonClicked = false;
            _registerAccess.WriteRegister(Register.Status, status.StatusRegisterValue); // We've read this status bit, now clear it
            return isButtonClicked;
        }

        /// <summary>
        /// Returns interval of time since the last button event (press and release).
        /// If called when no event has occurred then returns ??? TODO
        /// </summary>
        /// <param name="clearValue"><see langword="true"/> if the value should subsequently be cleared; <see langword="false"/> otherwise.</param>
        public TimeSpan GetTimeSinceLastPress(bool clearValue = false)
        {
            ushort timeElapsed = _registerAccess.ReadRegister<ushort>(Register.LastButtonEvent);
            if (clearValue)
            {
                _registerAccess.WriteRegister<ushort>(Register.LastButtonEvent, 0);
            }

            return TimeSpan.FromMilliseconds(timeElapsed);
        }
    }
}

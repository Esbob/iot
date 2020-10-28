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
        /// Returns the number of indents the user has turned the knob.
        /// Value between -32,768 and 32,767.
        /// The encoder has 24 indents per rotation.
        /// </summary>
        public short GetTurnCount()
        {
            return _registerAccess.ReadRegister<short>(Register.Count);
        }

        /// <summary>
        /// Sets the number of indents to a given amount.
        /// Value between -32,768 and 32,767.
        /// The encoder has 24 indents per rotation.
        /// </summary>
        public void SetTurnCount(short amount)
        {
            _registerAccess.WriteRegister(Register.Count, amount);
        }

        /// <summary>
        /// Returns the limit of allowed turn counts before wrapping.
        /// Value between 0 and 65,535.
        /// 0 means disabled.
        /// </summary>
        public ushort GetTurnLimit()
        {
            return _registerAccess.ReadRegister<ushort>(Register.Limit);
        }

        /// <summary>
        /// Sets the limit of turn counts the encoder will go to, then wrap to 0.
        /// Value between 0 and 65,535.
        /// Set to 0 to disable. TODO: What happens then?
        /// </summary>
        public void SetTurnLimit(ushort amount)
        {
            _registerAccess.WriteRegister(Register.Limit, amount);
        }

        /// <summary>
        /// Returns whether the knob has been turned.
        /// </summary>
        public bool IsEncoderTurned()
        {
            var status = new StatusRegisterBitField(_registerAccess.ReadRegister<byte>(Register.Status));
            var isEncoderTurned = status.IsEncoderTurned;
            status.IsEncoderTurned = false;
            _registerAccess.WriteRegister(Register.Status, status.StatusRegisterValue); // We've read this status bit, now clear it
            return isEncoderTurned;
        }

        /// <summary>
        /// Returns the number of indents the user has turned the knob since last movement.
        /// Value between -32,768 and 32,767.
        /// The encoder has 24 indents per rotation.
        /// By default, clears the current value.
        /// If called when no event has occurred then returns ??? TODO
        /// </summary>
        /// <param name="clearValue"><see langword="true"/> if the value should subsequently be cleared; <see langword="false"/> otherwise.</param>
        public short GetTurnsSinceLastMovement(bool clearValue = true)
        {
            var difference = _registerAccess.ReadRegister<short>(Register.Difference);
            if (clearValue)
            {
                _registerAccess.WriteRegister<short>(Register.Difference, 0);
            }

            return difference;
        }

        /// <summary>
        /// Returns interval of time since last encoder movement.
        /// By default, clears the current value.
        /// If called when no event has occurred then returns ??? TODO
        /// </summary>
        /// <param name="clearValue"><see langword="true"/> if the value should subsequently be cleared; <see langword="false"/> otherwise.</param>
        public TimeSpan GetTimeSinceLastMovement(bool clearValue = true)
        {
            var timeElapsed = _registerAccess.ReadRegister<ushort>(Register.LastEncoderEvent);
            if (clearValue)
            {
                _registerAccess.WriteRegister<ushort>(Register.LastEncoderEvent, 0);
            }

            return TimeSpan.FromMilliseconds(timeElapsed);
        }

        /// <summary>
        /// Returns interval of time that must elapse between end of knob turning and interrupt firing.
        /// </summary>
        public TimeSpan GetTurnInterruptTimeout()
        {
            var timeout = _registerAccess.ReadRegister<ushort>(Register.TurnInterruptTimeout);
            return TimeSpan.FromMilliseconds(timeout);
        }

        /// <summary>
        /// Sets the number of milliseconds that must elapse between end of knob turning and interrupt firing.
        /// Value between 0 and 65,535.
        /// Set to 0 to disable timeout.
        /// </summary>
        public void SetInterruptTimeout(ushort timeout)
        {
            _registerAccess.WriteRegister(Register.TurnInterruptTimeout, timeout);
        }
    }
}

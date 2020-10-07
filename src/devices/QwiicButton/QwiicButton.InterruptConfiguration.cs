﻿//// Licensed to the .NET Foundation under one or more agreements.
//// The .NET Foundation licenses this file to you under the MIT license.
//// See the LICENSE file in the project root for more information.

namespace Iot.Device.QwiicButton
{
    public partial class QwiicButton
    {
        /// <summary>
        /// When called, the interrupt will be configured to trigger when the button is pressed.
        /// If <see cref="EnableClickedInterrupt"/> has also been called,
        /// then the interrupt will trigger on either a push or a click.
        /// </summary>
        public void EnablePressedInterrupt()
        {
            var interrupt =
                new InterruptConfigBitField(_registerAccess.ReadSingleRegister(Register.InterruptConfig))
                {
                    PressedEnable = true
                };
            _registerAccess.WriteSingleRegister(Register.InterruptConfig, interrupt.InterruptConfigValue);
        }

        /// <summary>
        /// When called, the interrupt will no longer be configured to trigger when the button is pressed.
        /// If <see cref="EnableClickedInterrupt"/> has also been called,
        /// then the interrupt will still trigger on the button click.
        /// </summary>
        public void DisablePressedInterrupt()
        {
            var interrupt =
                new InterruptConfigBitField(_registerAccess.ReadSingleRegister(Register.InterruptConfig))
                {
                    PressedEnable = false
                };
            _registerAccess.WriteSingleRegister(Register.InterruptConfig, interrupt.InterruptConfigValue);
        }

        /// <summary>
        /// When called, the interrupt will be configured to trigger when the button is clicked.
        /// If <see cref="EnablePressedInterrupt"/> has also been called,
        /// then the interrupt will trigger on either a push or a click.
        /// </summary>
        public void EnableClickedInterrupt()
        {
            var interrupt =
                new InterruptConfigBitField(_registerAccess.ReadSingleRegister(Register.InterruptConfig))
                {
                    ClickedEnable = true
                };

            _registerAccess.WriteSingleRegister(Register.InterruptConfig, interrupt.InterruptConfigValue);
        }

        /// <summary>
        /// When called, the interrupt will no longer be configured to trigger when the button is clicked.
        /// If <see cref="EnablePressedInterrupt"/> has also been called,
        /// then the interrupt will still trigger on the button press.
        /// </summary>
        public void DisableClickedInterrupt()
        {
            var interrupt =
                new InterruptConfigBitField(_registerAccess.ReadSingleRegister(Register.InterruptConfig))
                {
                    ClickedEnable = false
                };

            _registerAccess.WriteSingleRegister(Register.InterruptConfig, interrupt.InterruptConfigValue);
        }

        /// <summary>
        /// Resets the interrupt configuration back to defaults.
        /// </summary>
        public void ResetInterruptConfig()
        {
            var interrupt = new InterruptConfigBitField
            {
                PressedEnable = true,
                ClickedEnable = true
            };
            _registerAccess.WriteSingleRegister(Register.InterruptConfig, interrupt.InterruptConfigValue);

            var status = new StatusRegisterBitField
            {
                EventAvailable = false
            };
            _registerAccess.WriteSingleRegister(Register.ButtonStatus, status.StatusRegisterValue);
        }
    }
}

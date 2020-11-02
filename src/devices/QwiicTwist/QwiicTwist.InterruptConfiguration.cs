// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Iot.Device.QwiicTwist.RegisterMapping;

namespace Iot.Device.QwiicTwist
{
    public sealed partial class QwiicTwist
    {
        /// <summary>
        /// When called, the interrupt will be configured to trigger when the encoder is turned.
        /// Interrupt is enabled by default.
        /// </summary>
        public void EnableEncoderInterrupt()
        {
            SetInterrupt(enableEncoder: true, enableButton: null);
        }

        /// <summary>
        /// When called, the interrupt will no longer be configured to trigger when the encoder is turned.
        /// Interrupt is enabled by default.
        /// </summary>
        public void DisableEncoderInterrupt()
        {
            SetInterrupt(enableEncoder: false, enableButton: null);
        }

        /// <summary>
        /// When called, the interrupt will be configured to trigger when the button is pressed down. TODO: What about Clicked?
        /// Interrupt is enabled by default.
        /// </summary>
        public void EnableButtonInterrupt()
        {
            SetInterrupt(enableEncoder: null, enableButton: true);
        }

        /// <summary>
        /// When called, the interrupt will no longer be configured to trigger when the button is pressed down. TODO: What about Clicked?
        /// Interrupt is enabled by default.
        /// </summary>
        public void DisableButtonInterrupt()
        {
            SetInterrupt(enableEncoder: null, enableButton: false);
        }

        private void SetInterrupt(bool? enableEncoder, bool? enableButton)
        {
            var interrupt = new InterruptConfigBitField(_registerAccess.ReadRegister<byte>(Register.InterruptConfig));

            if (enableEncoder != null)
            {
                interrupt.EnableEncoder = enableEncoder.Value;
            }

            if (enableButton != null)
            {
                interrupt.EnableButton = enableButton.Value;
            }

            _registerAccess.WriteRegister(Register.InterruptConfig, interrupt.InterruptConfigValue);
        }
    }
}

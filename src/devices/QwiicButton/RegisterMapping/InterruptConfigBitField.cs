﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Iot.Device.QwiicButton.RegisterMapping
{
    internal struct InterruptConfigBitField
    {
        [Flags]
        private enum InterruptConfigBits
        {
            ClickedEnable = 1,
            PressedEnable = 2
        }

        private InterruptConfigBits _interruptConfigValue;

        public InterruptConfigBitField(byte interruptConfigValue)
        {
            _interruptConfigValue = (InterruptConfigBits)interruptConfigValue;
        }

        public byte InterruptConfigValue => (byte)_interruptConfigValue;

        /// <summary>
        /// Set to true to enable an interrupt when the button is clicked.
        /// Defaults to false.
        /// </summary>
        public bool ClickedEnable
        {
            get { return FlagsHelper.IsSet(_interruptConfigValue, InterruptConfigBits.ClickedEnable); }
            set { FlagsHelper.SetValue(ref _interruptConfigValue, InterruptConfigBits.ClickedEnable, value); }
        }

        /// <summary>
        /// Set to true to enable an interrupt when the button is pressed.
        /// Defaults to false.
        /// </summary>
        public bool PressedEnable
        {
            get { return FlagsHelper.IsSet(_interruptConfigValue, InterruptConfigBits.PressedEnable); }
            set { FlagsHelper.SetValue(ref _interruptConfigValue, InterruptConfigBits.PressedEnable, value); }
        }
    }
}

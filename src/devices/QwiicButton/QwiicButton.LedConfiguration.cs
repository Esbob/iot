﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Iot.Device.QwiicButton.RegisterMapping;

namespace Iot.Device.QwiicButton
{
    public sealed partial class QwiicButton
    {
        /// <summary>
        /// Turns the onboard LED on with the specified brightness.
        /// </summary>
        /// <param name="brightness">LED brightness value between 0 (off) and 255 (max). Defaults to max.</param>
        public void LedOn(byte brightness = 255)
        {
            LedConfig(brightness, 0, 0);
        }

        /// <summary>
        /// Turns the onboard LED off.
        /// </summary>
        public void LedOff()
        {
            LedConfig(0, 0, 0);
        }

        /// <summary>
        /// Configures the onboard LED with the given max brightness, granularity, cycle time, and off time.
        /// Brightness defines how strong the light emanating from the LED should be.
        /// Granularity defines the number of steps it should take to get to the set brightness level.
        /// Cycle time is used for creating pulsating light and defines how long each individual pulse should take.
        /// Off time is used in conjunction with pulsating light and defines the amount of time between each pulse.
        /// </summary>
        /// <param name="brightness">LED brightness value between 0 (off) and 255 (max). Default is 255.</param>
        /// <param name="cycleTime">Total pulse cycle time in ms. Does not include off time. Pulse disabled if 0.</param>
        /// <param name="offTime">Off time between pulses in ms. Default is 500 ms.</param>
        /// <param name="granularity">Amount of steps it takes to get to the set brightness level (1 is fine for most applications).</param>
        public void LedConfig(byte brightness, ushort cycleTime, ushort offTime, byte granularity = 1)
        {
            _registerAccess.WriteRegister(Register.LedBrightness, brightness);
            _registerAccess.WriteRegister(Register.LedPulseGranularity, granularity);
            _registerAccess.WriteRegister(Register.LedPulseCycleTime, cycleTime);
            _registerAccess.WriteRegister(Register.LedPulseOffTime, offTime);
        }
    }
}

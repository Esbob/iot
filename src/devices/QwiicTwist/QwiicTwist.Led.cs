// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Iot.Device.QwiicTwist
{
    /// <summary>
    /// TODO
    /// </summary>
    public sealed partial class QwiicTwist
    {
        /*
        //Sets the color of the encoder LEDs, 0-255
        boolean TWIST::setColor(uint8_t red, uint8_t green, uint8_t blue)
        {
            return (writeRegister24(TWIST_RED, (uint32_t)red << 16 | (uint32_t)green << 8 | blue));
        }

        // Sets the red LED.
        // Value between 0 and 255 representing the brightness of
        // the red LED. Default is 255.
        boolean TWIST::setRed(uint8_t red)
        {
            return (writeRegister(TWIST_RED, red));
        }

        // Sets the green LED.
        // Value between 0 and 255 representing the brightness of
        // the green LED. Default is 255.
        boolean TWIST::setGreen(uint8_t green)
        {
            return (writeRegister(TWIST_GREEN, green));
        }

        // Sets the blue LED.
        // Value between 0 and 255 representing the brightness of
        // the blue LED. Default is 255.
        boolean TWIST::setBlue(uint8_t blue)
        {
            return (writeRegister(TWIST_BLUE, blue));
        }

        //Returns the current red value of the color
        uint8_t TWIST::getRed()
        {
            return (readRegister(TWIST_RED));
        }

        //Returns the current green value of the color
        uint8_t TWIST::getGreen()
        {
            return (readRegister(TWIST_GREEN));
        }

        //Returns the current blue value of the color
        uint8_t TWIST::getBlue()
        {
            return (readRegister(TWIST_BLUE));
        }

        //Sets the relation between each color and the twisting of the knob
        //This will connect the LED so it changes [amount] with each encoder tick
        //Negative numbers are allowed (so LED gets brighter the more you turn the encoder down)
        boolean TWIST::connectColor(int16_t red, int16_t green, int16_t blue)
        {
            _i2cPort->beginTransmission((uint8_t)_deviceAddress);
            _i2cPort->write(TWIST_CONNECT_RED); //Command
            _i2cPort->write(red >> 8);          //MSB
            _i2cPort->write(red & 0xFF);        //LSB
            _i2cPort->write(green >> 8);        //MSB
            _i2cPort->write(green & 0xFF);      //LSB
            _i2cPort->write(blue >> 8);         //MSB
            _i2cPort->write(blue & 0xFF);       //LSB
            if (_i2cPort->endTransmission() != 0)
                return (false); //Sensor did not ACK
            return (true);
        }

        // Value between 255 and -255 indicating the amount to
        // change the red LED brightness with each tick movement
        // of the encoder. Default is 0.
        boolean TWIST::connectRed(int16_t red)
        {
            return (writeRegister16(TWIST_CONNECT_RED, red));
        }

        // Value between 255 and -255 indicating the amount to
        // change the green LED brightness with each tick movement
        // of the encoder. Default is 0.
        boolean TWIST::connectGreen(int16_t green)
        {
            return (writeRegister16(TWIST_CONNECT_GREEN, green));
        }

        // Value between 255 and -255 indicating the amount to
        // change the blue LED brightness with each tick movement
        // of the encoder. Default is 0.
        boolean TWIST::connectBlue(int16_t blue)
        {
            return (writeRegister16(TWIST_CONNECT_BLUE, blue));
        }

        // Value between 255 and -255 indicating the amount to
        // change the red LED brightness with each tick movement
        // of the encoder.
        int16_t TWIST::getRedConnect()
        {
            return (readRegister16(TWIST_CONNECT_RED));
        }

        // Value between 255 and -255 indicating the amount to
        // change the green LED brightness with each tick movement
        // of the encoder.
        int16_t TWIST::getGreenConnect()
        {
            return (readRegister16(TWIST_CONNECT_GREEN));
        }

        // Value between 255 and -255 indicating the amount to
        // change the blue LED brightness with each tick movement
        // of the encoder.
        int16_t TWIST::getBlueConnect()
        {
            return (readRegister16(TWIST_CONNECT_BLUE));
        }
        */
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QwiicTwist
{
    /// <summary>
    /// TODO
    /// </summary>
    public sealed partial class QwiicTwist
    {
        /*
        //Returns the number of indents the user has turned the knob
        int16_t TWIST::getCount()
        {
            return (readRegister16(TWIST_COUNT));
        }

        //Set the number of indents to a given amount
        boolean TWIST::setCount(int16_t amount)
        {
            return (writeRegister16(TWIST_COUNT, amount));
        }

        //Returns the limit of allowed counts before wrapping
        //0 is disabled
        uint16_t TWIST::getLimit()
        {
            return (readRegister16(TWIST_LIMIT));
        }

        //Sets the limit of what the encoder will go to, then wrap to 0. Set to 0 to disable.
        boolean TWIST::setLimit(uint16_t amount)
        {
            return (writeRegister16(TWIST_LIMIT, amount));
        }

        //Returns true if knob has been turned
        boolean TWIST::isMoved()
        {
            byte status = readRegister(TWIST_STATUS);
            boolean moved = status & (1 << statusEncoderMovedBit);

            writeRegister(TWIST_STATUS, status & ~(1 << statusEncoderMovedBit)); //We've read this status bit, now clear it

            return (moved);
        }

        //Returns the number of milliseconds since the last encoder movement
        //By default, clears the current value
        uint16_t TWIST::timeSinceLastMovement(boolean clearValue)
        {
            uint16_t timeElapsed = readRegister16(TWIST_LAST_ENCODER_EVENT);

            //Clear the current value if requested
            if (clearValue == true)
                writeRegister16(TWIST_LAST_ENCODER_EVENT, 0);

            return (timeElapsed);
        }

        //Gets number of milliseconds that must elapse between end of knob turning and interrupt firing
        uint16_t TWIST::getIntTimeout()
        {
            return (readRegister16(TWIST_TURN_INT_TIMEOUT));
        }

        //Sets number of milliseconds that must elapse between end of knob turning and interrupt firing
        boolean TWIST::setIntTimeout(uint16_t timeout)
        {
            return (writeRegister16(TWIST_TURN_INT_TIMEOUT, timeout));
        }

        //Returns the number of ticks since last check
        int16_t TWIST::getDiff(boolean clearValue)
        {
            int16_t difference = readRegister16(TWIST_DIFFERENCE);

            //Clear the current value if requested
            if (clearValue == true)
                writeRegister16(TWIST_DIFFERENCE, 0);

            return (difference);
        }
        */
    }
}

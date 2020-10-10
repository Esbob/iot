using System;
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
        //Returns true if button is currently being pressed.
        boolean TWIST::isPressed()
        {
            byte status = readRegister(TWIST_STATUS);
            boolean pressed = status & (1 << statusButtonPressedBit);

            writeRegister(TWIST_STATUS, status & ~(1 << statusButtonPressedBit)); //We've read this status bit, now clear it

            return (pressed);
        }

        //Returns true if a click event has occurred. Event flag is then reset.
        boolean TWIST::isClicked()
        {
            byte status = readRegister(TWIST_STATUS);
            boolean clicked = status & (1 << statusButtonClickedBit);

            writeRegister(TWIST_STATUS, status & ~(1 << statusButtonClickedBit)); //We've read this status bit, now clear it

            return (clicked);
        }

        //Returns the number of milliseconds since the last button event (press and release)
        uint16_t TWIST::timeSinceLastPress(boolean clearValue)
        {
            uint16_t timeElapsed = readRegister16(TWIST_LAST_BUTTON_EVENT);

            //Clear the current value if requested
            if (clearValue == true)
                writeRegister16(TWIST_LAST_BUTTON_EVENT, 0);

            return (timeElapsed);
        }
        */
    }
}

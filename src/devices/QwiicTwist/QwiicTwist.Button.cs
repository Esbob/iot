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
            var status = new StatusRegisterBitField(_registerAccess.ReadSingleRegister(Register.Status));
            var isButtonPressed = status.IsButtonPressed;
            status.IsButtonPressed = false;
            _registerAccess.WriteSingleRegister(Register.Status, status.StatusRegisterValue); // We've read this status bit, now clear it
            return isButtonPressed;
        }

        /// <summary>
        /// Returns whether the knob has been clicked.
        /// Is subsequently set to false.
        /// </summary>
        public bool IsClicked()
        {
            var status = new StatusRegisterBitField(_registerAccess.ReadSingleRegister(Register.Status));
            var isButtonClicked = status.IsButtonClicked;
            status.IsButtonClicked = false;
            _registerAccess.WriteSingleRegister(Register.Status, status.StatusRegisterValue); // We've read this status bit, now clear it
            return isButtonClicked;
        }

        /// <summary>
        /// Returns the number of milliseconds since the last button event (press and release).
        /// </summary>
        /// <param name="clearValue"><see langword="true"/> if the value should subsequently be cleared; <see langword="false"/> otherwise.</param>
        public ushort TimeSinceLastPress(bool clearValue = false)
        {
            ushort timeElapsed = _registerAccess.ReadDoubleRegister(Register.LastButtonEvent);
            if (clearValue)
            {
                _registerAccess.WriteDoubleRegister(Register.LastButtonEvent, 0);
            }

            return timeElapsed;
        }
    }
}

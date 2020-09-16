﻿//// Licensed to the .NET Foundation under one or more agreements.
//// The .NET Foundation licenses this file to you under the MIT license.
//// See the LICENSE file in the project root for more information.

using System;

namespace Iot.Device.QwiicButton
{
    internal class QueueStatusBitField
    {
        [Flags]
        private enum QueueStatusBits
        {
            PopRequest = 1,
            IsEmpty = 2,
            IsFull = 4,
        }

        public QueueStatusBitField()
        {
        }

        public QueueStatusBitField(byte queueStatusValue)
        {
            QueueStatusValue = queueStatusValue;
        }

        public byte QueueStatusValue { get; set; }

        /// <summary>
        /// Set to true to pop from the queue.
        /// After the value is popped from the queue, this flag is set back to false.
        /// </summary>
        public bool PopRequest
        {
            get { return FlagsHelper.IsSet((QueueStatusBits)QueueStatusValue, QueueStatusBits.PopRequest); }
            set { QueueStatusValue = (byte)FlagsHelper.SetValue((QueueStatusBits)QueueStatusValue, QueueStatusBits.PopRequest, value); }
        }

        /// <summary>
        /// Returns whether the queue is empty.
        /// </summary>
        public bool IsEmpty
        {
            get { return FlagsHelper.IsSet((QueueStatusBits)QueueStatusValue, QueueStatusBits.IsEmpty); }
        }

        /// <summary>
        /// Returns whether the queue is full.
        /// </summary>
        public bool IsFull
        {
            get { return FlagsHelper.IsSet((QueueStatusBits)QueueStatusValue, QueueStatusBits.IsFull); }
        }
    }
}

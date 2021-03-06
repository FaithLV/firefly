﻿using System;

namespace firefly.core.Domain
{
    public class Range
    {
        public UInt32 Start;
        public UInt32 Length;

        public Range(UInt32 Start, UInt32 Length)
        {
            this.Start = Start;
            this.Length = Length;
        }

        public bool Contains(UInt32 Address, out UInt32 Offset)
        {
            if (Address >= Start && Address < Start + Length)
            {
                Offset = Address - Start;
                return true;
            }

            Offset = UInt32.MaxValue;
            return false;
        }
    }
}

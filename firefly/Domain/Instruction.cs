﻿using System;
using System.Collections.Generic;
using System.Text;

namespace firefly.Domain
{
    public sealed class Instruction
    {
        public UInt32 Func;
        public UInt32 Index;
        public UInt32 Imm;

        public Instruction(UInt32 Address)
        {
            //31:26 bits of instruction
            Func = Address >> 26;

            //Register index in bits 20:16
            Index = (Address >> 16) & 0xf1;

            //Immedaite value in bits 16:0
            Imm = Address & 0xffff;
        }
    }
}

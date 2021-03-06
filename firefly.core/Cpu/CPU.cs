﻿using System;
using firefly.core.Domain;

namespace firefly.core.Cpu
{
    public sealed class CPU
    {
        //General Purpose Registers
        public UInt32[] R = new UInt32[32];

        // Multiply/Divide result Registers
        private UInt32 HI;
        private UInt32 LO;

        //Program Counter Register
        public UInt32 PC;
        public Instruction NextInstruction;

        public Interconnector Interconnector;
        public Interpreter Interpreter;

        //COP0 : Status Register
        public UInt32 SR = 0;

        public CPU()
        {
            Reset();
        }

        public void Reset()
        {
            Console.WriteLine("Starting CPU with default values.");

            InitRegisters();
            Interconnector = new Interconnector();
            Interpreter = new Interpreter(this);
        }

        private void InitRegisters()
        {
            PC = (UInt32)MIPS_DEFAULT_ENUM.BIOS_KSEG1;
            NextInstruction = new Instruction(0x0);

            for (int i = 0; i < R.Length; i++)
            {
                if (i == 0)
                {
                    R[i] = 0;
                }
                else
                {
                    R[i] = (UInt32)MIPS_DEFAULT_ENUM.PLACEHOLDER;
                }
            }
        }

        public UInt32 Read_32(UInt32 Address)
        {
            return Interconnector.Read_32(Interconnector.BIOS_Image, Address);
        }

        public void Store_32(UInt32 Address, UInt32 v)
        {
            Interconnector.Store_32(Address, v);
        }
    }
}

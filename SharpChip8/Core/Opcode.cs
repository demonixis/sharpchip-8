using System;

namespace SharpChip8.Core
{
    public class Opcode
    {
        public const int OpcodeCount = 55; // 35 opcodes Chip-8 + 9 Opcodes Super Chip-8 + 11 Opcodes Mega Chip-8

        public ushort Id { get; set; }
        public ushort Mask { get; set; }

        private static Opcode[] _opcodes;
        private static bool _init = false;

        public Opcode(ushort id, ushort mask)
        {
            Id = id;
            Mask = mask;
        }

        /// <summary>
        /// Initialisation des opcodes Chip8
        /// </summary>
        public static Opcode [] GetOpcodeTable()
        {
            if (!_init)
            {
                _opcodes = new Opcode[OpcodeCount];
                
                _opcodes[0] = new Opcode(0x00E0, 0xFFFF);    // 00E0
                _opcodes[1] = new Opcode(0x00EE, 0xFFFF);    // 00EE
                _opcodes[2] = new Opcode(0x0FFF, 0x0F00);    // 0XXX
                _opcodes[3] = new Opcode(0x1000, 0xF000);   // 1NNN
                _opcodes[4] = new Opcode(0x2000, 0xF000);   // 2NNN
                _opcodes[5] = new Opcode(0x3000, 0xF000);   // 3XNN
                _opcodes[6] = new Opcode(0x4000, 0xF000);   // 4XNN
                _opcodes[7] = new Opcode(0x5000, 0xF00F);   // 5XY0
                _opcodes[8] = new Opcode(0x6000, 0xF000);   // 6XNN
                _opcodes[9] = new Opcode(0x7000, 0xF000);   // 7XNN
                _opcodes[10] = new Opcode(0x8000, 0xF00F);  // 8XY0
                _opcodes[11] = new Opcode(0x8001, 0xF00F);  // 8XY1
                _opcodes[12] = new Opcode(0x8002, 0xF00F);  // 8XY2
                _opcodes[13] = new Opcode(0x8003, 0xF00F);  // 8XY3
                _opcodes[14] = new Opcode(0x8004, 0xF00F);  // 8XY4
                _opcodes[15] = new Opcode(0x8005, 0xF00F);  // 8XY5
                _opcodes[16] = new Opcode(0x8006, 0xF00F);  // 8XY6
                _opcodes[17] = new Opcode(0x8007, 0xF00F);  // 8XY7
                _opcodes[18] = new Opcode(0x800E, 0xF00F);  // 8XYE
                _opcodes[19] = new Opcode(0x9000, 0xF00F);  // 9XY0
                _opcodes[20] = new Opcode(0xA000, 0xF000);  // ANNN
                _opcodes[21] = new Opcode(0xB000, 0xF000);  // BNNN
                _opcodes[22] = new Opcode(0xC000, 0xF000);  // CXNN
                _opcodes[23] = new Opcode(0xD000, 0xF000);  // DXYN
                _opcodes[24] = new Opcode(0xE09E, 0xF0FF);  // EX9E
                _opcodes[25] = new Opcode(0xE0A1, 0xF0FF);  // EXA1
                _opcodes[26] = new Opcode(0xF007, 0xF0FF);  // FX07
                _opcodes[27] = new Opcode(0xF00A, 0xF0FF);  // FX0A
                _opcodes[28] = new Opcode(0xF015, 0xF0FF);  // FX15
                _opcodes[29] = new Opcode(0xF018, 0xF0FF);  // FX18
                _opcodes[30] = new Opcode(0xF01E, 0xF0FF);  // FX1E
                _opcodes[31] = new Opcode(0xF029, 0xF0FF);  // FX29
                _opcodes[32] = new Opcode(0xF033, 0xF0FF);  // FX33
                _opcodes[33] = new Opcode(0xF055, 0xF0FF);  // FX55
                _opcodes[34] = new Opcode(0xF065, 0xF0FF);  // FX65
                // Opcode Super Chip-8
                _opcodes[35] = new Opcode(0x00C0, 0xFFFF); // 00CN
                _opcodes[36] = new Opcode(0x00FB, 0xFFFF); // 00FB
                _opcodes[37] = new Opcode(0x00FC, 0xFFFF); // 00FC
                _opcodes[38] = new Opcode(0x00FD, 0xFFFF); // 00FD
                _opcodes[39] = new Opcode(0x00FE, 0xFFFF); // 00FE
                _opcodes[40] = new Opcode(0x00FF, 0xFFFF); // 00FF
				_opcodes[41] = new Opcode(0xF000, 0xF0FF); // FX30
                _opcodes[42] = new Opcode(0xF075, 0xF0FF); // FX75
                _opcodes[43] = new Opcode(0xF085, 0xF0FF); // FX85
                // Opcode Mega Chip-8
				_opcodes[44] = new Opcode(0x0010, 0xFFFF); // 0010
				_opcodes[45] = new Opcode(0x0011, 0xFFFF); // 0011
				_opcodes[46] = new Opcode(0x0100, 0xFFFF); // 01NN
				_opcodes[47] = new Opcode(0x0200, 0xFFFF); // 02NN
				_opcodes[48] = new Opcode(0x0300, 0xFFFF); // 03NN
				_opcodes[49] = new Opcode(0x0400, 0xFFFF); // 04NN
				_opcodes[50] = new Opcode(0x0500, 0xFFFF); // 05NN
				_opcodes[51] = new Opcode(0x06C0, 0xFFFF); // 060N
				_opcodes[52] = new Opcode(0x07C0, 0xFFFF); // 0700
				_opcodes[53] = new Opcode(0x08C0, 0xFFFF); // 080N
				_opcodes[54] = new Opcode(0x00B0, 0xFFFF); // 00BN
                _init = true;
            }
            return _opcodes;
        }
    }
}

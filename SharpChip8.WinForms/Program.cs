using System;
using System.Windows.Forms;
using SharpChip8;

namespace SharpChip8.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Chip8 chip8 = new Chip8();
            Application.Run(new OpenTKRenderer(chip8));
        }
    }
}

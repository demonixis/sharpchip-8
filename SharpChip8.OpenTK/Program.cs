using System;
using System.IO;
using SharpChip8;

namespace SharpChip8.OpenTK
{
	public class Program
	{
        private static string screenSize = "normal";
        private static string speed = "normal";
        private static bool soundEnabled = true;
        private static string romPath = String.Empty;

		[STAThread]
		public static void Main(string [] args)
		{
            int argsCount = args.Length;

            if (argsCount > 0 && File.Exists(args[0]))
            {
                romPath = args[0];

                if (argsCount > 1)
                {
                    for (int i = 1; i < argsCount; i++)
                        PrepareParams(args[i]);
                }

                LaunchEmulator();    
            }
            else
                Console.WriteLine("Usage: SharpChip8.exe romName.ch8");
		}

        private static void LaunchEmulator()
        {
            Chip8 chip8 = new Chip8();
            chip8.Reset();
            chip8.LoadRomFromFile(romPath);
            chip8.Start();

            MainWindow mainWindow = new MainWindow(chip8);
            mainWindow.SoundEnabled = soundEnabled;
            mainWindow.Run();
        }

        private static void PrepareParams(string param)
        {
            string[] temp = param.Split(new char[] { '=' });
            string name = temp[0];
            string value = temp[1];

            switch (name)
            {
                case "file": romPath = value; break;
                case "screen": screenSize = value; break;
                case "speed": speed = value; break;
                case "sound": soundEnabled = bool.Parse(value); break;
                default: break;
            }
        }
	}
}

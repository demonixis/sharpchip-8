using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using SharpChip8;

namespace SharpChip8.WinForms.Debugger
{
    public enum Visualisation
    {
        Decimal, Hexadecimal, Binary
    }

    public partial class DebugWindow : Form
    {
        private Chip8 _chip8;

        public DebugWindow(Chip8 chip8)
        {
            InitializeComponent();
            _chip8 = chip8;

            UpdateInfo();

            chip8.Cpu.CpuRunning += new EventHandler<EventArgs>(Cpu_CpuRunning);

            // Mémoire
            UpdateMemoryView();

            // Désassembleur
            SharpChip8.Core.Disassembler dasm = new SharpChip8.Core.Disassembler(_chip8);
            richTextBoxDasm.Text = dasm.AsmWithLineNumber;
        }

        void Cpu_CpuRunning(object sender, EventArgs e)
        {
            UpdateInfo();
            Thread.Sleep(14);
        }

        private void UpdateInfo()
        {
            Visualisation desiredRepresentation = Visualisation.Hexadecimal;
            UpdateInfo(desiredRepresentation);
        }

        private void UpdateInfo(Visualisation desiredRepresentation)
        {
            string[] regValues = new string[16];
            string[] pValues = new string[2];
            byte[] iValues = _chip8.Cpu.Input.Keys;

            string representation = "0x{0:X}";
            if (desiredRepresentation == Visualisation.Binary)
                representation = "{0:B}";
            else if (desiredRepresentation == Visualisation.Decimal)
                representation = "{0:D}";

            for (int i = 0; i < 16; i++)
            {
                regValues[i] = String.Format(representation, _chip8.Cpu.V[i]);    
            }

            pValues[0] = String.Format(representation, _chip8.Cpu.I);
            pValues[1] = String.Format(representation, _chip8.Cpu.PC);

            // Pointeurs
            textBoxI.Text = pValues[0];
            textBoxPC.Text = pValues[1];

            // Registres
            textBoxV0.Text = regValues[0];
            textBoxV1.Text = regValues[1];
            textBoxV2.Text = regValues[2];
            textBoxV3.Text = regValues[3];
            textBoxV4.Text = regValues[4];
            textBoxV5.Text = regValues[5];
            textBoxV6.Text = regValues[6];
            textBoxV7.Text = regValues[7];
            textBoxV8.Text = regValues[8];
            textBoxV9.Text = regValues[9];
            textBoxV10.Text = regValues[10];
            textBoxV11.Text = regValues[11];
            textBoxV12.Text = regValues[12];
            textBoxV13.Text = regValues[13];
            textBoxV14.Text = regValues[14];
            textBoxV15.Text = regValues[15];

            // Compteur CPU et Son
            textBoxCpuCounter.Text = String.Format(representation, _chip8.Cpu.DelayTimer);
            textBoxSoundCounter.Text = String.Format(representation, _chip8.Cpu.SoundTimer);

            // Pile
            textBoxStackCount.Text = String.Format("{0:D}", _chip8.Cpu.CountStack);
            textBoxStackElement.Text = String.Format(representation, _chip8.Cpu.CurrentStackState);

            // Input
            bt0.BackColor = iValues[0] > 0x0 ? Color.DimGray : Color.Transparent;
            bt1.BackColor = iValues[1] > 0x0 ? Color.DimGray : Color.Transparent;
            bt2.BackColor = iValues[2] > 0x0 ? Color.DimGray : Color.Transparent;
            bt3.BackColor = iValues[3] > 0x0 ? Color.DimGray : Color.Transparent;
            bt4.BackColor = iValues[4] > 0x0 ? Color.DimGray : Color.Transparent;
            bt5.BackColor = iValues[5] > 0x0 ? Color.DimGray : Color.Transparent;
            bt6.BackColor = iValues[6] > 0x0 ? Color.DimGray : Color.Transparent;
            bt7.BackColor = iValues[7] > 0x0 ? Color.DimGray : Color.Transparent;
            bt8.BackColor = iValues[8] > 0x0 ? Color.DimGray : Color.Transparent;
            bt9.BackColor = iValues[9] > 0x0 ? Color.DimGray : Color.Transparent;
            btA.BackColor = iValues[10] > 0x0 ? Color.CadetBlue : Color.LightSkyBlue;
            btB.BackColor = iValues[11] > 0x0 ? Color.CadetBlue : Color.LightSkyBlue;
            btC.BackColor = iValues[12] > 0x0 ? Color.CadetBlue : Color.LightSkyBlue;
            btD.BackColor = iValues[13] > 0x0 ? Color.CadetBlue : Color.LightSkyBlue;
            btE.BackColor = iValues[14] > 0x0 ? Color.CadetBlue : Color.LightSkyBlue;
            btF.BackColor = iValues[15] > 0x0 ? Color.CadetBlue : Color.LightSkyBlue;

            // Opcode
            textBoxOpcode.Text = String.Format(representation, _chip8.Cpu.CurrentOpcode);
            textBoxVX.Text = String.Format(representation, (_chip8.Cpu.CurrentOpcode & 0x0F00) >> 8);
            textBoxVY.Text = String.Format(representation, (_chip8.Cpu.CurrentOpcode & 0x00F0) >> 4);
            textBoxNibble.Text = String.Format(representation, _chip8.Cpu.CurrentOpcode & 0x000F);
            textBoxNNN.Text = String.Format(representation, (((_chip8.Cpu.CurrentOpcode & 0x0F00) >> 8) + ((_chip8.Cpu.CurrentOpcode & 0x00F0) >> 4) + (_chip8.Cpu.CurrentOpcode & 0x000F)));
            textBoxNN.Text = String.Format(representation, (((_chip8.Cpu.CurrentOpcode & 0x00F0) >> 4) + (_chip8.Cpu.CurrentOpcode & 0x000F)));
        }

        public void UpdateMemoryView()
        {
            byte[] m = _chip8.Cpu.Memory;
            string stringMem = "Offset   00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F\n";

            for (int i = 0; i < SharpChip8.Core.Memory.MemorySize; i++)
            {
                if (i % 16 == 0 || i == 0)
                {
                    stringMem += "\n";
                    stringMem += String.Format("{0:X8} ", i);
                    string val = String.Format("{0:X2} ", m[i]);
                    stringMem += val;
                }
                else
                    stringMem += String.Format("{0:X2} ", m[i]);
            }
            this.richTextBoxMemory.Text = stringMem;
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void visualMemory_Click(object sender, EventArgs e)
        {
            UpdateMemoryView();
        }

        private void DebugWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _chip8.Cpu.CpuRunning -= Cpu_CpuRunning;
        }

        private void textBoxCpuOpPSec_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SharpChip8.Core.Cpu.OperationPerSecond = int.Parse(textBoxCpuOpPSec.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vous devez entrer une valeur numérique", "Valeur invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxCpuSpeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SharpChip8.Core.Cpu.WaitTime = int.Parse(textBoxCpuSpeed.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vous devez entrer une valeur numérique", "Valeur invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemDumpToText_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogSave = CreateSaveFileDialog(String.Empty);

            if (dialogSave.ShowDialog() == DialogResult.OK)
            {
                richTextBoxMemory.SaveFile(dialogSave.FileName, RichTextBoxStreamType.PlainText);
            }

            dialogSave = null;
        }

        private void itemDumpToBin_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogSave = CreateSaveFileDialog("Fichier binaire Chip-8 (*.ch8)|*.txt|Tout types (*.*)|*.*");

            if (dialogSave.ShowDialog() == DialogResult.OK)
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(File.Create(dialogSave.FileName)))
                {
                    byte [] memory = _chip8.Cpu.Memory;
                    binaryWriter.Write(memory);
                }
            }

            dialogSave = null;
        }

        private SaveFileDialog CreateSaveFileDialog(string ext)
        {
            SaveFileDialog dialogSave = new SaveFileDialog();
            if (ext == String.Empty)
                dialogSave.Filter = "Fichier texte (*.txt)|*.txt|Tout types (*.*)|*.*";
            else
                dialogSave.Filter = ext;
            dialogSave.AddExtension = true;
            dialogSave.RestoreDirectory = true;
            dialogSave.Title = "Enregistrement du fichier";
            dialogSave.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            

            return dialogSave;
        }

    }
}

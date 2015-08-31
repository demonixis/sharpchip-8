using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using SharpChip8;

namespace SharpChip8.WinForms.Debugger
{
    public partial class DisassemblerWindow : Form
    {
        private Chip8 _chip8;

        private string asmWithLineNumber;
        private string asmWithoutLineNumber;

        public DisassemblerWindow(Chip8 chip8)
        {
            InitializeComponent();

            _chip8 = chip8;

            SharpChip8.Core.Disassembler dasm = new SharpChip8.Core.Disassembler(_chip8);
            asmWithLineNumber = dasm.AsmWithLineNumber;
            asmWithoutLineNumber = dasm.AsmWithoutLineNumber;

            richTextBoxASM.Text = asmWithLineNumber;
        }

        private void ShowAsm(bool withLineNumber)
        {
            if (withLineNumber)
                richTextBoxASM.Text = asmWithLineNumber;
            else
                richTextBoxASM.Text = asmWithoutLineNumber;
        }

        private void itemMenuQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void itemMenuSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogSave = new SaveFileDialog();
            dialogSave.Filter = "Fichier ASM Chip8 (*.chp)|*.chp|Fichier texte (*.txt)|*.txt|Tout types (*.*)|*.*";
            dialogSave.DefaultExt = "txt";
            dialogSave.AddExtension = true;
            dialogSave.RestoreDirectory = true;
            dialogSave.Title = "Enregistrement du fichier";
            dialogSave.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (dialogSave.ShowDialog() == DialogResult.OK)
            {
                richTextBoxASM.SaveFile(dialogSave.FileName, RichTextBoxStreamType.PlainText);   
            }

            dialogSave = null;
        }

        private void itemMenuWithLine_Click(object sender, EventArgs e)
        {
            itemMenuWithLine.Checked = true;
            itemMenuWithoutLine.Checked = false;
            ShowAsm(true);
        }

        private void itemMenuWithoutLine_Click(object sender, EventArgs e)
        {
            itemMenuWithLine.Checked = false;
            itemMenuWithoutLine.Checked = true;
            ShowAsm(false);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using InazumaEleven3ScriptEditor.Tools;
using InazumaEleven3ScriptEditor.Level5;
using InazumaEleven3ScriptEditor.Level5.Function;
using System.Windows.Forms;

namespace InazumaEleven3ScriptEditor
{
    public partial class View : Form
    {
        DataReader FileOpened;

        DataReader FileOpenedText;

        List<string> FileContent = new List<string>();

        public View()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = null;
            openFileDialog1.Filter = "PAC files (*.pac_)|*.pac_";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            openFileDialog2.FileName = null;
            openFileDialog2.Filter = "PAC files (*.pac_)|*.pac_";
            openFileDialog2.RestoreDirectory = true;
            if (openFileDialog2.ShowDialog() != DialogResult.OK) return;

            // Function
            FileOpened = new DataReader(File.ReadAllBytes(openFileDialog1.FileName));
            FileOpenedText = new DataReader(File.ReadAllBytes(openFileDialog2.FileName));
            //long lengthText = 0x32C;
            FileOpenedText.Skip(3);
            FileOpened.Seek(0x08);
            int EOF = FileOpened.ReadUInt16();
            //0x0C
            FileOpened.Seek(0x0C);
            //0x1C
            int line = FileOpened.ReadUInt16();
            //0x20
            FileOpened.Seek(0x20);

            for (long i = 0; i < line; i++)
            {
                int offset = FileOpened.ReadInt16();
                int length = FileOpened.ReadInt16() - 4;

                IFunction function = Function.GetFunction(FileOpened.GetSection((uint)FileOpened.BaseStream.Position, length));
                if (function.usesText)
                {
                    int textLength = FileOpenedText.ReadByte()-1;
                    string hexString = BitConverter.ToString(FileOpenedText.GetSection((uint)FileOpenedText.BaseStream.Position, textLength)).Replace("-", "").Replace("\0", "");
                    FileContent.Add(string.Format("0x{0:x4} ", offset) + function.ToText() + " \"" + Encoding.GetEncoding("shift-jis").GetString(StringToByteArray(hexString)).Replace("-", "").Replace("\0", "") + " \"");
                    FileOpenedText.Skip((uint)textLength);
                    FileOpened.Skip((uint)length);
                }
                else {
                    FileContent.Add(string.Format("0x{0:x4} ", offset) + function.ToText());
                    FileOpened.Skip((uint)length);
                }
            }

            while (FileOpened.BaseStream.Position < EOF) {
                long pos = FileOpened.BaseStream.Position;
                //int offset = FileOpened.ReadInt16();
                short offset;
                byte low;
                byte high;
                while ((low = FileOpened.ReadByte()) == 0) {
                    if (FileOpened.BaseStream.Position == EOF) {
                        break;
                    }
                }
                if (FileOpened.BaseStream.Position == EOF)
                {
                    break;
                }
                high = FileOpened.ReadByte();
                offset = (short)(65535 & ((high << 8) | low));
                //THIS LINE IS TEMPORARY UNTIL I KNOW WHAT TO DO WOTH THOSE 2 BYTES
                FileOpened.Skip(2);
                List<byte> bytes = new List<byte>();
                byte buffer;
                int count = 0;
                while (count < 2 || (pos = FileOpened.BaseStream.Position) % 2 == 1)
                {
                    if ((buffer = FileOpened.ReadByte()) == 0)
                    {
                        count++;
                    }
                    else {
                        count = 0;
                    }
                    bytes.Add(buffer);
                }
                /*while ((buffer = FileOpened.ReadByte()) != 0 || (pos = FileOpened.BaseStream.Position) % 2 == 1) {
                    bytes.Add(buffer);
                }*/
                pos = FileOpened.BaseStream.Position;
                FileContent[offset-1] += " " + Encoding.GetEncoding("shift-jis").GetString(bytes.ToArray()).Replace("-", "").Replace("\0", "");

            }

            string scriptText = "";
            foreach (string textContent in FileContent)
            {
                scriptText += textContent + Environment.NewLine;
            }
            string directorioActual = Directory.GetCurrentDirectory();

            // Imprimimos el directorio actual en la consola
            Console.WriteLine("El directorio actual es: " + directorioActual);
            using (FileStream fileStream2 = File.Create("./output.txt"))
            {
                // Se crea un StreamWriter para escribir el string en el FileStream
                using (StreamWriter writer = new StreamWriter(fileStream2))
                {
                    // Se escribe el string en el archivo
                    writer.Write(scriptText);
                }
            }

            textBox1.Text = directorioActual + Environment.NewLine + scriptText;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}

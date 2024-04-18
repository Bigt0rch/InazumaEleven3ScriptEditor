using System;
using InazumaEleven3ScriptEditor.Tools;

namespace InazumaEleven3ScriptEditor.Level5.Function
{
    public class CharacterRotate : Function
    {
        public override string Name => "CharacterRotate";

        public override string ToText()
        {
            DataReader functionReader = new DataReader(FunctionArray);
            functionReader.Skip(0x04);
            int offset = functionReader.ReadInt16();
            functionReader.Skip(0x02);
            int character = functionReader.ReadInt16();
            functionReader.Skip(0x07);
            int rotate = functionReader.ReadInt16();
            if (rotate == 0x10E0)
            {
                return Name + string.Format(" 0x{0:x4}", offset) + string.Format(" 0x{0:x4}", character) + " UP";
            } else
            {
                return Name + string.Format(" 0x{0:x4}", offset) + string.Format(" 0x{0:x4} ", character) + string.Format("0x{0:x4} ", rotate);
            }
        }

        public CharacterRotate(byte[] LoadedByteArray) : base(LoadedByteArray) { }
    }
}

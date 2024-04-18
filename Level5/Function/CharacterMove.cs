using System;
using InazumaEleven3ScriptEditor.Tools;

namespace InazumaEleven3ScriptEditor.Level5.Function
{
    public class CharacterMove : Function
    {
        public override string Name => "CharacterMove";

        public override string ToText()
        {
            DataReader functionReader = new DataReader(FunctionArray);
            functionReader.Skip(0x04);                 //0x04
            int offset = functionReader.ReadInt16();   //0x06
            functionReader.Skip(0x02);                 //0x08
            int character = functionReader.ReadInt16();//0x0A
            functionReader.Skip(0x06);                 //0x10
            int unknown1 = functionReader.ReadInt16(); //0x12
            int unknown2 = functionReader.ReadInt16(); //0x14
            int unknown3 = functionReader.ReadInt16(); //0x16
            functionReader.Skip(0x02);                 //0x18
            int unknown4 = functionReader.ReadInt16(); //0x20
            int unknown5 = functionReader.ReadInt16(); //0x22
            int unknown6 = functionReader.ReadInt16(); //0x24
            return Name + string.Format(" 0x{0:x4}", offset) + string.Format(" 0x{0:x4}", character)
                + string.Format(" 0x{0:x4}", unknown1) + string.Format(" 0x{0:x4}", unknown2)
                + string.Format(" 0x{0:x4}", unknown3) + string.Format(" 0x{0:x4}", unknown4)
                + string.Format(" 0x{0:x4}", unknown5) + string.Format(" 0x{0:x4}", unknown6);
        }

        public CharacterMove(byte[] LoadedByteArray) : base(LoadedByteArray) {}
    }
}

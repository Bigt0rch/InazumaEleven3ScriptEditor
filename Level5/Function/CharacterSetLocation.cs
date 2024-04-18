using System;
using InazumaEleven3ScriptEditor.Tools;

namespace InazumaEleven3ScriptEditor.Level5.Function
{
    public class CharacterSetLocation : Function
    {
        public override string Name => "CharacterSetLocation";

        public override string ToText()
        {
            DataReader functionReader = new DataReader(FunctionArray);
            Console.WriteLine(BitConverter.ToString(FunctionArray));
            functionReader.Skip(0x04);
            int offset = functionReader.ReadInt16();
            functionReader.Skip(0x02);
            int character = functionReader.ReadInt16();
            return Name + string.Format(" 0x{0:x4}", offset) + string.Format(" 0x{0:x4}", character);
        }

        

        public CharacterSetLocation(byte[] LoadedByteArray) : base(LoadedByteArray) { }
    }
}

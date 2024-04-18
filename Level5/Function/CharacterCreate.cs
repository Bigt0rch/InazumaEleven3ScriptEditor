using InazumaEleven3ScriptEditor.Tools;

namespace InazumaEleven3ScriptEditor.Level5.Function
{
    public class CharacterCreate : Function
    {
        public override string Name => "CharacterCreate";
        public CharacterCreate(byte[] LoadedByteArray) : base(LoadedByteArray) {}

        public override string ToText()
        {
            DataReader functionReader = new DataReader(FunctionArray);
            functionReader.Skip(0x04);
            int offset = functionReader.ReadInt16();           
            functionReader.Skip(0x02);
            int character = functionReader.ReadInt16();
            return Name + string.Format(" 0x{0:x4}", offset) + string.Format(" 0x{0:x4}", character);
        }

    }
}

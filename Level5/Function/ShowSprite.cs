using InazumaEleven3ScriptEditor.Tools;

namespace InazumaEleven3ScriptEditor.Level5.Function
{
    public class ShowSprite : Function
    {
        public override string Name => "ShowSprite";

        public override string ToText()
        {
            DataReader functionReader = new DataReader(FunctionArray);
            functionReader.Skip(0x0C);
            int character = functionReader.ReadInt16();
            functionReader.Skip(0x06);
            int unknown = functionReader.ReadInt16();
            return Name + string.Format(" 0x{0:x4}", character);
        }

        public ShowSprite(byte[] LoadedByteArray) : base(LoadedByteArray) { }
    }
}

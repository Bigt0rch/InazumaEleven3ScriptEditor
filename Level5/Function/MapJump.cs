using InazumaEleven3ScriptEditor.Tools;

namespace InazumaEleven3ScriptEditor.Level5.Function
{
    public class MapJump : Function
    {
        public override string Name => "MapJump";

        public override string ToText()
        {
            return Name;
        }

        public MapJump(byte[] LoadedByteArray) : base(LoadedByteArray) { }
    }
}

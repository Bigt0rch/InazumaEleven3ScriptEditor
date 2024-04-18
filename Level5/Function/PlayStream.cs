using InazumaEleven3ScriptEditor.Tools;

namespace InazumaEleven3ScriptEditor.Level5.Function
{
    public class PlayStream : Function
    {
        public override string Name => "PlayStream";

        public override string ToText()
        {
            return Name;
        }

        public PlayStream(byte[] LoadedByteArray) : base(LoadedByteArray) { }
    }
}

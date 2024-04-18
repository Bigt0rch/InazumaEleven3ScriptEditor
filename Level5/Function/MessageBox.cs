using InazumaEleven3ScriptEditor.Tools;

namespace InazumaEleven3ScriptEditor.Level5.Function
{
    public class MessageBox : Function
    {
        public override string Name => "MessageBox";

        public override string ToText()
        {
            return Name;
        }

        public MessageBox(byte[] LoadedByteArray) : base(LoadedByteArray) { }
    }
}

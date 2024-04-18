using System;
using InazumaEleven3ScriptEditor.Tools;

namespace InazumaEleven3ScriptEditor.Level5.Function
{
    public class Unknown : Function
    {
        public string Name => "Unknown";

        public byte[] FunctionArray { get; set; }

        public string ToText()
        {
            return BitConverter.ToString(FunctionArray).Replace("-", "");
        }

        public byte[] GetByte(string text)
        {
            return new byte[0];
        }

        public Unknown(byte[] LoadedByteArray) : base(LoadedByteArray) { }
    }
}

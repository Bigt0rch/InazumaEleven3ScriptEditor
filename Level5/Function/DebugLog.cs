namespace InazumaEleven3ScriptEditor.Level5.Function

{
    using System;
    using System.Text;
    internal class DebugLog : Function
    {
        public override string Name => "DebugLog ";

        public override string ToText()
        {
            return Name + BitConverter.ToString(FunctionArray).Replace("-", ""); ;
        }

        public DebugLog(byte[] LoadedByteArray) : base(LoadedByteArray) { }
    }
}
namespace InazumaEleven3ScriptEditor.Level5.Function
{
    public interface IFunction
    {
        string Name { get;}
        bool usesText { get; set; }

        byte[] FunctionArray { get; set; }

        string ToText();

        byte[] GetByte(string text);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InazumaEleven3ScriptEditor.Tools;
using InazumaEleven3ScriptEditor.Level5.Function;

namespace InazumaEleven3ScriptEditor.Level5.Function
{
    public class Function : IFunction
    {
        public bool usesText { get; set; }
        public virtual string Name => "Unknown";

        public virtual byte[] FunctionArray { get; set; }

        public static IFunction GetFunction(byte[] _FunctionByteArray)
        {
            DataReader functionReader = new DataReader(_FunctionByteArray);
            IFunction function;
            switch ((uint)functionReader.ReadInt16())
            {
                case 0x3017:
                    function = new PlayStream(_FunctionByteArray);
                    function.usesText = false;
                    return function;
                case 0x3070:
                    function = new DebugLog(_FunctionByteArray);
                    function.usesText = false;
                    return function;
                case 0x301A:
                    function = new ShowSprite(_FunctionByteArray);
                    function.usesText = false;
                    return function;
                case 0x301D:
                    function = new MessageBox(_FunctionByteArray);
                    function.usesText = true;
                    return function;
                case 0x3058:
                    function = new CharacterCreate(_FunctionByteArray);
                    function.usesText = false;
                    return function;
                case 0x305C:
                    function = new CharacterRotate(_FunctionByteArray);
                    function.usesText = false;
                    return function;
                case 0x3066:
                    function = new CharacterMove(_FunctionByteArray);
                    function.usesText = false;
                    return function;
                case 0x4090:
                    function = new MapJump(_FunctionByteArray);
                    function.usesText = false;
                    return function;
                default:
                    function = new Function(_FunctionByteArray);
                    function.usesText = false;
                    return function;
            }
        }

        public Function(byte[] LoadedByteArray)
        {
            FunctionArray = LoadedByteArray;
        }
        public virtual string ToText()
        {
            return BitConverter.ToString(FunctionArray).Replace("-", "");
        }

        public virtual byte[] GetByte(string text)
        {
            return new byte[0];
        }

    }
}

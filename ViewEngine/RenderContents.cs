namespace OpenVMSys_Core.ViewEngine
{
    public class RenderContents
    {
        public readonly string Key;
        public readonly string Value;
        public RenderContents(string key, string value)
        {
            Key = "{{ " + key + " }}";
            Value = value;
        }
        public RenderContents Get()
        {
            return this;
        }
    }
}

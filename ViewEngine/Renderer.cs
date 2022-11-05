namespace OpenVMSys_Core.ViewEngine
{
    public class Renderer
    {
        private static FileStream _fileStream;
        private static StreamReader _reader;

        public static string Render(
            string resourcePath)
        {
            _fileStream = new(resourcePath, FileMode.Open);
            _reader = new StreamReader(_fileStream, System.Text.Encoding.UTF8);
            var renderObj = _reader.ReadToEnd();
            return renderObj;
        }

        public static string Render(
            string resourcePath, 
            RenderContents[] renderContents
            )
        {
            _fileStream = new(resourcePath,FileMode.Open);
            _reader = new StreamReader(_fileStream,System.Text.Encoding.UTF8);
            var renderObj = _reader.ReadToEnd();
            foreach (var renderContent in renderContents)
            {
                renderObj.Replace(renderContent.Get().Key, renderContent.Value);
            }
            return renderObj;
        }
    }
}

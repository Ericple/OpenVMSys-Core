namespace OpenVMSys_Core.Core.Security
{
    public class SecurityKeyService
    {
        public static List<SecurityKeyModel> KeyCollection = new();
        private FileStream? _file;
        private StreamReader? _reader;
        private string keyFilePath = OpenVMSysPluginSystem.Path.Join(new string[]
        {
            "OpenKey"//Appdomain.BaseDirectory/OpenKey
        });
        /*
         * Security以明文保存于keyFilePath中
         * 读取keyFilePath文件并序列化其内容
         */
        public void Get()
        {
            try
            {
                _file = new(keyFilePath, FileMode.Open);
                _reader = new StreamReader(_file, System.Text.Encoding.UTF8);
                var rawData = _reader.ReadToEnd();
                var keys = rawData.Split("\n");
                KeyCollection.Clear();
                foreach (var key in keys)
                {
                    var obj = key.Split("\t");
                    if (obj.Length > 1)
                    {
                        KeyCollection.Add(new SecurityKeyModel(key.Split("\t")[0], int.Parse(key.Split("\t")[1])));
                    }
                }
                //关闭读写流
                _reader.Close();
                _file.Close();
            }
            catch
            {
                File.WriteAllText(keyFilePath, "");
            }
        }
        /*
         * 核验请求的key是否有效
         * 若key存在且要求permission小于key的permission，则通过
         */
        public bool Auth(string key,OpenVMSysConfigurations.SecurityPermission permission)
        {
            Get();
            foreach(var _key in KeyCollection)
            {
                if(_key.Key != null && _key.Key.Equals(key) && permission.CompareTo(_key.Permission) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        
    }
}

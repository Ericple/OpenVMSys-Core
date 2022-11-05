namespace OpenVMSys_Core.Core.Security
{
    public class SecurityKeyModel
    {
        public string? Key;
        public int Permission;
        public SecurityKeyModel(string? key, int permission)
        {
            Key = key;
            Permission = permission;
        }
    }
}

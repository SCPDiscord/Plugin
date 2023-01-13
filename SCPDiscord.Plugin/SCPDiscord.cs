using PluginAPI.Core.Attributes;

namespace SCPDiscord.Plugin
{
    /// <summary>
    /// Main Class
    /// </summary>
    public class SCPDiscord
    {
        public static SCPDiscord Instance;
        
        [PluginEntryPoint("SCPDiscord.Plugin", "0.0.1", "Yes", "SrLicht")]
        void LoadPlugin()
        {
            Instance = this;
            
        }

        [PluginUnload]
        void UnLoadPlugin()
        {
            
        }

        [PluginReload]
        void ReloadPlugin()
        {
            
        }

        private void LoadEvents()
        {
            
        }

        private void UnLoadEvents()
        {
            
        }
    }
}
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Visuals
{
#if UNITY_EDITOR_WIN
    [InitializeOnLoad]
    public class AddDefine
    {
        static AddDefine()
        {
            string symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);

            if (!symbols.Contains("COMMAND"))
            {
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, symbols + ";COMMAND");
            }
        }
    }
#endif
}
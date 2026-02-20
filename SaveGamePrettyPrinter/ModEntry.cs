using StardewModdingAPI;

using HarmonyLib;


namespace SaveGamePrettyPrinter {
    public class ModEntry : Mod {
        public override void Entry(IModHelper helper) {
            var harmony = new Harmony(this.ModManifest.UniqueID);
            // ATTENTION: This enables indent for all XmlWriterSettings objects in the game!
            harmony.Patch(original: AccessTools.Constructor(typeof(System.Xml.XmlWriterSettings)),
                          postfix:  new HarmonyMethod(typeof(ModEntry), nameof(ModEntry.XmlWriterSettingsPostfix)));
        }

        // ReSharper disable once InconsistentNaming
        private static void XmlWriterSettingsPostfix(System.Xml.XmlWriterSettings __instance) {
            __instance.Indent = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ModdingTools.Engine
{
    public class UModelFacade
    {

        public UModelFacade()
        {
           if (!File.Exists(GetUModelEXE()))
            {
                throw new Exception("Please, place the umodel.exe and SDL2.dll into the program root directory and try again!\nYou can download it from https://www.gildor.org/en/projects/umodel");
            }
        }


        public enum ExportType
        {
            SoundNodeWave, Texture2D, StaticMesh, AnimSet, Font
        }

        private string GetUModelEXE()
        {
            return Path.Combine(Program.GetAppRoot(), "umodel.exe");
        }

        private string GetTMPDir()
        {
            return Path.Combine(Program.GetAppRoot(), "ExporterTMP");
        }

        public static string GetExtensionForType(ExportType exportType)
        {
            string extension = null;
            switch (exportType)
            {
                case ExportType.SoundNodeWave:
                    extension = ".ogg";
                    break;
                case ExportType.Texture2D:
                    extension = ".tga";
                    break;
            }
            return extension;
        }

        public bool Run(string args)
        {
            Debug.WriteLine("CmdArgs >> " + args);
            var p = new Process();
            p.StartInfo.FileName = GetUModelEXE();
            p.StartInfo.Arguments = args;
            p.Start();

            p.WaitForExit();

            return p.ExitCode == 0;
        }

        public bool Export(string package, string assetName, ExportType exportType, string destination)
        {
            var tmpDir = GetTMPDir();
            if (Directory.Exists(tmpDir))
            {
                Directory.Delete(tmpDir, true);
            }
            Directory.CreateDirectory(tmpDir);

            // .\umodel.exe -game=ue3 -path="C:\Program Files (x86)\Steam\steamapps\common\HatinTime\HatinTimeGame\EditorCookedPC" -export HatinTime_Music_Metro4 Act_4_Pink_Paw_Station -sounds -out=".\test"
            var res = Run($"-game=ue3 -path=\"{GameFinder.GetEditorCookedPcDir()}\" -3rdparty -export {package} {assetName}{(exportType == ExportType.SoundNodeWave ? " -sounds" : "")} -out=\"{tmpDir}\"");
            if (!res)
            {
                return false;
            }

            var extension = GetExtensionForType(exportType);

            var path = Path.Combine(tmpDir, package, exportType.ToString(), assetName + extension);
            Debug.WriteLine("ExceptedPath: " + path);

            if (File.Exists(path))
            {
                if (File.Exists(destination))
                {
                    File.Delete(destination);
                }
                File.Move(path, destination);
                return true;
            }

            return false;
        }
    }
}

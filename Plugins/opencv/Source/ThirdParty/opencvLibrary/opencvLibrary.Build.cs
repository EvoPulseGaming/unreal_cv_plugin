// Fill out your copyright notice in the Description page of Project Settings.

using System.IO;
using UnrealBuildTool;

public class opencvLibrary : ModuleRules
{
    private string ThirdPartyPath
    {
        get { return Path.GetFullPath(Path.Combine(ModuleDirectory, "../../../../../ThirdParty/")); }
    }

    public opencvLibrary(ReadOnlyTargetRules Target) : base(Target)
	{
		Type = ModuleType.External;

        //LoadOpenCV(Target);

  //      if (Target.Platform == UnrealTargetPlatform.Win64)
		//{
		//	// Add the import library
		//	PublicLibraryPaths.Add(Path.Combine(ModuleDirectory, "x64", "Release"));
		//	PublicAdditionalLibraries.Add("ExampleLibrary.lib");

		//	// Delay-load the DLL, so we can load it from the right place first
		//	PublicDelayLoadDLLs.Add("ExampleLibrary.dll");
		//}
  //      else if (Target.Platform == UnrealTargetPlatform.Mac)
  //      {
  //          PublicDelayLoadDLLs.Add(Path.Combine(ModuleDirectory, "Mac", "Release", "libExampleLibrary.dylib"));
  //      }
	}

    public bool LoadOpenCV(ReadOnlyTargetRules Target)
    {
        // Start OpenCV linking here!
        bool isLibrarySupported = false;

        // Create OpenCV Path 
        string OpenCVPath = Path.Combine(ThirdPartyPath, "opencv");

        // Get Library Path 
        string LibPath = "";
        string DllPath = "";

        //bool bDebug = (Target.Configuration == UnrealTargetConfiguration.Debug && BuildConfiguration.bDebugBuildsActuallyUseDebugCRT);
        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            LibPath = Path.Combine(OpenCVPath, "lib");
            DllPath = Path.Combine(OpenCVPath, "bin");
            isLibrarySupported = true;
        }
        else
        {
            string Err = string.Format("{0} dedicated server is made to depend on {1}. We want to avoid this, please correct module dependencies.", Target.Platform.ToString(), this.ToString()); System.Console.WriteLine(Err);
        }

        if (isLibrarySupported)
        {
            //Add Include path 
            PublicIncludePaths.AddRange(new string[] { Path.Combine(OpenCVPath, "include") });

            // Add Library Path 
            PublicLibraryPaths.Add(LibPath);
            PublicLibraryPaths.Add(DllPath);

            //Add Static Libraries
            PublicAdditionalLibraries.Add("opencv_world411.lib");
            PublicAdditionalLibraries.Add("opencv_img_hash411.lib");

            //Add Dynamic Libraries
            PublicDelayLoadDLLs.Add("opencv_world411.dll");
            PublicDelayLoadDLLs.Add("opencv_img_hash411.dll");
            PublicDelayLoadDLLs.Add("opencv_videoio_ffmpeg411_64.dll");
        }

        // Definitions.Add(string.Format("WITH_OPENCV_BINDING={0}", isLibrarySupported ? 1 : 0));

        return isLibrarySupported;
    }
}

**OPEN MOD MANAGER**

For A Hat In Time

Because it's still work-in-progress you must compile it by you own using Visual Studio (in my case 2017) - I'll prepare a build script for compiling it without Visual Studio later.

Also you still need to have original Mod Manager executable placed in Binaries directory and OMM executable with depend DLL's must be placed in the same directory as the ModManager.exe.

Only tested with Steam release of the game.


---

**IF YOU WANT TO UPLOAD MODS INTO WORKSHOP USING OMM**

You need to go into *[Game directory]\Binaries*, copy all files from build directory *Bin/[Debug|Release]*, rename ***ModManager.exe*** to ***ModManager_original.exe*** and ***ModdingTools.exe*** to ***ModManager.exe***
You probably need to do it after every editor update and/or modding tools integrity check.
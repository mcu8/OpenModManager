Clear-Host

$scriptpath = $MyInvocation.MyCommand.Path
$dir = Split-Path $scriptpath
Write-host "My directory is $dir"

$devenv = "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.com"

$outputDir = Join-Path -Path $dir -Child "Release"
$tmpDir = Join-Path -Path $outputDir -Child ".tmp"

Remove-Item -Path $outputDir\*.* -Force -Recurse
New-Item -Path $tmpDir -ItemType Directory -ErrorAction Ignore
Remove-Item -Path $tmpDir\* -Force -Recurse

$ommFiles = Join-Path -Path $dir -Child "ModdingTools.Cli\bin\Debug"
$ommUpdaterFiles = Join-Path -Path $dir -Child "ModdingTools.Updater\bin\Debug"

Remove-Item -Force $ommFiles\*
Remove-Item -Force $ommUpdaterFiles\*

$csproj = Join-Path -Path $dir -Child "OpenModManager.sln"
& $devenv "$csproj" /build Debug

Write-Host $ommFiles
Copy-Item -Path $ommFiles\* -Recurse -Destination $tmpDir

Write-Host $ommUpdaterFiles
Copy-Item -Path $ommUpdaterFiles\* -Recurse -Destination $tmpDir

Move-Item -Path $tmpDir\ModdingTools.Updater.exe -Destination $tmpDir\ModdingTools.Updater.New.exe
Move-Item -Path $tmpDir\ModdingTools.Updater.pdb -Destination $tmpDir\ModdingTools.Updater.New.pdb

Compress-Archive -Path $tmpDir\* -DestinationPath $outputDir\OpenModManager-bin.zip
Remove-Item -Path $tmpDir -Recurse -Force

$sha256 = Get-FileHash $outputDir\OpenModManager-bin.zip -Algorithm SHA256 | Select-Object -ExpandProperty Hash
[IO.File]::WriteAllText("$outputDir\OpenModManager-bin.zip.sha256", ("$sha256".ToLower() + "  OpenModManager-bin.zip") -join "`n")

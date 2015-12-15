$env:Path += ".\Nuget";

cd .\Blurk

nuget pack -build -Properties Configuration=Release

nuget push *.nupkg

Move-Item .\*.nupkg .\..\Nuget

cd ..

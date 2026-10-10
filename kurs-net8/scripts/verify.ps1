$ErrorActionPreference = "Stop"

$courseRoot = Split-Path -Parent $PSScriptRoot
Set-Location $courseRoot

# Pozwala uruchomić kurs także na komputerze, na którym profil użytkownika
# jest tylko do odczytu.
$env:DOTNET_CLI_HOME = Join-Path $courseRoot ".dotnet-cli-home"
New-Item -ItemType Directory -Force -Path $env:DOTNET_CLI_HOME | Out-Null

dotnet restore WzorceProjektoweKurs.sln
dotnet build WzorceProjektoweKurs.sln --no-restore --nologo -m:1
dotnet test WzorceProjektoweKurs.sln --no-build --no-restore --nologo -m:1

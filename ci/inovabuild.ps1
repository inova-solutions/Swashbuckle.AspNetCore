# Version suffix - use preview suffix for CI builds that are not tagged (i.e. unofficial)
$VersionSuffix = ""
if ($env:APPVEYOR -eq "True" -and $env:APPVEYOR_REPO_TAG -eq "false") {
    $VersionSuffix = "preview-" + $env:APPVEYOR_BUILD_NUMBER.PadLeft(4, '0')
}

# Target folder for build artifacts (e.g. nugets)
$ArtifactsPath = "$(pwd)" + "\artifacts"

$Solution = "Inova.Swashbuckle.AspNetCore.sln"

function dotnet-build {
    if ($VersionSuffix.Length -gt 0) {
        dotnet build $Solution -c Release --version-suffix $VersionSuffix
    }
    else {
        dotnet build $Solution -c Release
    }
}

function dotnet-pack {
    if ($VersionSuffix.Length -gt 0) {
        dotnet pack $Solution -c Release --no-build -o $ArtifactsPath --version-suffix $VersionSuffix
    }
    else {
        dotnet pack $Solution -c Release --no-build -o $ArtifactsPath
    }
}

@( "dotnet-build", "dotnet-pack" ) | ForEach-Object {
    echo ""
    echo "***** $_ *****"
    echo ""

    # Invoke function and exit on error
    &$_
    if ($LastExitCode -ne 0) { Exit $LastExitCode }
}

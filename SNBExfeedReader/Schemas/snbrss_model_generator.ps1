# Paths  
$BaseSourcesPath = "";
$XsdCommandPath = "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\xsd.exe";

# Functions
function Get-Current-Location() {
    return Split-Path $script:MyInvocation.MyCommand.Path;
}

function Get-Model-Location() {
    $Current = $script:MyInvocation.MyCommand.Path;
    return (get-item $Current).parent.parent.FullName;
}

# Main
$CurrentDir = Get-Current-Location
$ModelsDir =  (get-item $CurrentDir).parent.FullName 
$ModelsDir = Join-Path -Path $ModelsDir -ChildPath "Models"

Write-Host -BackgroundColor red -ForegroundColor white -Object 'Generating SNB Rss Models from XSD Schemas... '
& "xsd.exe"  "/c"  "snbrss.xsd" "snbrss.xsd" "snbrss_app1.xsd" "snbrss_app2.xsd" "snbrss_app3.xsd" "snbrss_app4.xsd" "snbrss_app5.xsd"

Write-Host "Removing old models..."
Remove-Item -Path "SNBRssModels.cs"
Start-Sleep -Seconds 1
Write-Host "Old models removed!"

Write-Host "Updating models..."
Rename-Item -Path "snbrss_snbrss_app1_snbrss_app2_snbrss_app3_snbrss_app4_snbrss_app5.cs" "SNBRssModels.cs"
Start-Sleep -Seconds 1
Write-Host "Models updated!"

Write-Host "Closing..."
Start-Sleep -Seconds 2



# Prompt the user for the target string and replacement string
$targetString = "Genesis.Models"
$replacementString = Read-Host "Enter the new package name"

# Define the root directory as the current running directory
$rootDirectory = Get-Location

# Function to replace in file contents
function Replace-InFileContent {
    param (
        [string]$filePath
    )
    (Get-Content $filePath) -replace $targetString, $replacementString | Set-Content $filePath
}

# Rename files and folders
Get-ChildItem -Recurse -Path $rootDirectory | ForEach-Object {
    $item = $_

    # Rename folder or file if it contains the target string
    if ($item.Name -like "*$targetString*") {
        $newName = $item.Name -replace $targetString, $replacementString
        Rename-Item -Path $item.FullName -NewName $newName
    }

    # If it's a file, replace the content inside
    if ($item.PSIsContainer -eq $false) {
        Replace-InFileContent -filePath $item.FullName
    }
}

Write-Host "Replacement complete!"

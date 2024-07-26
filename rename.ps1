﻿param($p)

# set output encoding
$OutputEncoding = [Text.UTF8Encoding]::UTF8

# company name placeholder 
$oldCompanyName="AbpCompanyName"
# your company name
$newCompanyName=""

# project name placeholder
$oldProjectName="AbpZero"
# your project name
$newProjectName="$p"

# file type
$fileType="FileInfo"

# directory type
$dirType="DirectoryInfo"

# copy 
Write-Host 'Start copy folders...'
if($newCompanyName -eq ""){
$newRoot=$newProjectName
}else{
$newRoot=$newCompanyName+"."+$newProjectName
}
write-host "The New Project: $newRoot"

mkdir $newRoot
Copy-Item -Recurse .\src\ .\$newRoot\
Copy-Item -Recurse .\test\ .\$newRoot\
Copy-Item -Recurse .\etc\ .\$newRoot\
Copy-Item AbpZero.sln .\$newRoot\
Copy-Item .gitignore .\$newRoot\
Copy-Item README.md .\$newRoot\
Copy-Item add-migration.ps1 .\$newRoot\
Copy-Item aremove-migration.ps1 .\$newRoot\
Copy-Item Dockerfile .\$newRoot\
Copy-Item .gitlab-ci.yml .\$newRoot\
Copy-Item azure-pipelines.yml .\$newRoot\
Copy-Item .gitignore .\$newRoot\
Copy-Item .gitattributes .\$newRoot\
Copy-Item .dockerignore .\$newRoot\

# folders to deal with
$srcFolder = (Get-Item -Path "./$newRoot/" -Verbose).FullName

function Rename {
	param (
		$TargetFolder,
		$PlaceHolderCompanyName,
		$PlaceHolderProjectName,
		$NewCompanyName,
		$NewProjectName
	)
	# file extensions to deal with
	$include=@("*.cs","*.cshtml","*.asax","*.ps1","*.ts","*.csproj","*.sln","*.xaml","*.json","*.js","*.xml","*.config","Dockerfile", "*.yml")

	$elapsed = [System.Diagnostics.Stopwatch]::StartNew()

	Write-Host "[$TargetFolder]Start rename folder..."
	# rename folder
	Ls $TargetFolder -Recurse | Where { $_.GetType().Name -eq $dirType -and ($_.Name.Contains($PlaceHolderCompanyName) -or $_.Name.Contains($PlaceHolderProjectName)) } | ForEach-Object{
		Write-Host 'directory ' $_.FullName
		$newDirectoryName=$_.Name.Replace($PlaceHolderCompanyName,$NewCompanyName).Replace($PlaceHolderProjectName,$NewProjectName)
		Rename-Item $_.FullName $newDirectoryName
	}
	Write-Host "[$TargetFolder]End rename folder."
	Write-Host '-------------------------------------------------------------'


	# replace file content and rename file name
	Write-Host "[$TargetFolder]Start replace file content and rename file name..."
	Ls $TargetFolder -Include $include -Recurse | Where { $_.GetType().Name -eq $fileType} | ForEach-Object{
		$fileText = Get-Content $_ -Raw -Encoding UTF8
		if($fileText.Length -gt 0 -and ($fileText.contains($PlaceHolderCompanyName) -or $fileText.contains($PlaceHolderProjectName))){
			$fileText.Replace($PlaceHolderCompanyName,$NewCompanyName).Replace($PlaceHolderProjectName,$NewProjectName) | Set-Content $_ -Encoding UTF8
			Write-Host 'file(change text) ' $_.FullName
		}
		If($_.Name.contains($PlaceHolderCompanyName) -or $_.Name.contains($PlaceHolderProjectName)){
			$newFileName=$_.Name.Replace($PlaceHolderCompanyName,$NewCompanyName).Replace($PlaceHolderProjectName,$NewProjectName)
			Rename-Item $_.FullName $newFileName
			Write-Host 'file(change name) ' $_.FullName
		}
	}
	Write-Host "[$TargetFolder]End replace file content and rename file name."
	Write-Host '-------------------------------------------------------------'

	$elapsed.stop()
	write-host "[$TargetFolder]Total Time Cost: $($elapsed.Elapsed.ToString())"
}

Rename -TargetFolder $srcFolder -PlaceHolderCompanyName $oldCompanyName -PlaceHolderProjectName $oldProjectName -NewCompanyName $newCompanyName -NewProjectName $newProjectName
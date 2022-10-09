@echo off
set "name=ClassCollectionCooper"
:: set name to parent name
for %%a in ("%~dp0\.") do set "name=%%~nxa"
echo %name%

if exist "%cd%\%name%.zip" (
	del "%cd%\%name%.zip"
)

"C:\Program Files\7-Zip\7z.exe" a "%cd%\%name%.zip" "%cd%\%name%\*"
ren "%cd%\%name%.zip" "%name%.deli"
"C:\Program Files\7-Zip\7z.exe" a "%cd%\%name%.zip" "%cd%\%name%.deli" "%cd%\manifest.json" "icon.png" "README.md" "Plugin.dll"
del "%cd%\%name%.deli"
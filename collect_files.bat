::@echo off
:: #### Collects all tech tree files and puts them into one directory for easier releasing ####

:: Constants
set DEST_DIR=collected_files
set DATA_DIR=DATA
set EDITOR_DIR=Editor
set VIEW_DIR=NewTechTree
set VIEW_INJECT_DIR=Inject
set VIEW_INSTALL_DIR=Install
set EDITOR_RELEASE_PATH=..\AoETechTreeTool\AoETechTreeTool\bin\Release
set INSTALLER_RELEASE_PATH=AoETechTreeInstaller\bin\x86\Release
set VIEW_RELEASE_PATH=..\AoETechTree\Release

:: Delete and recreate destination directory
if exist %DEST_DIR%\nul rd /s /q %DEST_DIR%
mkdir %DEST_DIR%

:: Create sub directories
cd %DEST_DIR%
mkdir %DATA_DIR%
mkdir %EDITOR_DIR%
mkdir %VIEW_DIR%

:: Fill data directory
cd %DATA_DIR%
copy ..\..\%VIEW_RELEASE_PATH%\empires2_x1_p1.dat .
cd ..

:: Fill editor directory
cd %EDITOR_DIR%
copy ..\..\%EDITOR_RELEASE_PATH%\age2_x1.ntt .
copy ..\..\%EDITOR_RELEASE_PATH%\AoETechTreeTool.exe .
copy ..\..\%EDITOR_RELEASE_PATH%\GenieLibrary.dll .
copy ..\..\%EDITOR_RELEASE_PATH%\IORAMHelper.dll .
copy ..\..\%EDITOR_RELEASE_PATH%\LICENSE .
copy ..\..\%EDITOR_RELEASE_PATH%\README.md .
cd ..

:: Go to view dir
cd %VIEW_DIR%
mkdir %VIEW_INSTALL_DIR%
mkdir %VIEW_INJECT_DIR%

:: Fill inject dir
cd %VIEW_INJECT_DIR%
copy ..\..\..\%VIEW_RELEASE_PATH%\AoETechTree.exe .
copy ..\..\..\%VIEW_RELEASE_PATH%\LICENSE .
copy ..\..\..\%VIEW_RELEASE_PATH%\README.md .
copy ..\..\..\%VIEW_RELEASE_PATH%\TechTree.dll .
cd ..

:: Fill install dir
cd %VIEW_INSTALL_DIR%
copy ..\..\..\%INSTALLER_RELEASE_PATH%\AoETechTreeInstaller.exe .
copy ..\..\..\%INSTALLER_RELEASE_PATH%\IORAMHelper.dll .
copy ..\..\..\%VIEW_RELEASE_PATH%\LICENSE .
copy ..\..\..\%VIEW_RELEASE_PATH%\README.md .
copy ..\..\..\%VIEW_RELEASE_PATH%\TechTree.dll .
cd ..

:: Leave view dir
cd ..

:: Leave destination dir
cd ..
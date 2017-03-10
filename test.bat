@echo off

set interactive=1
echo %cmdcmdline% | find /i "%~0" >nul
if not errorlevel 1 set interactive=0

rem now I can use %interactive% anywhere

IF NOT EXIST "%~dp0packages\NUnit.ConsoleRunner.3.6.1\" (ECHO Error: Cannot find NUnit Console Runner. Build the project to restore the packages && PAUSE && EXIT /B 1)
%~dp0packages\NUnit.ConsoleRunner.3.6.1\tools\nunit3-console.exe %~dp0test\KitchenSink.Tests\bin\Debug\KitchenSink.Tests.dll --noheader --params Browsers=Chrome,Firefox

if _%1_==__ (
    if _%interactive%_==_0_ pause
)

IF ERRORLEVEL 1 EXIT /B 1
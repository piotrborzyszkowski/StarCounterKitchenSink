@echo off

set interactive=1
echo %cmdcmdline% | find /i "%~0" >nul
if not errorlevel 1 set interactive=0

rem If we are in interactive mode (batch file not started from the command line), pause at the exit

IF NOT EXIST "%~dp0packages\NUnit.ConsoleRunner.3.6.1\" (ECHO Error: Cannot find NUnit Console Runner. Build the project to restore the packages && PAUSE && EXIT /B 1)
%~dp0packages\NUnit.ConsoleRunner.3.6.1\tools\nunit3-console.exe %~dp0test\KitchenSink.Tests\bin\Debug\KitchenSink.Tests.dll --noheader --params Browsers=Chrome

if %interactive%==0 pause

IF ERRORLEVEL 1 EXIT /B 1
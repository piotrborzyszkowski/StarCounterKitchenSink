@echo off

IF NOT EXIST "%~dp0packages\NUnit.ConsoleRunner.3.6.0\" (ECHO Error: Cannot find NUnit Console Runner. Build the project to restore the packages && PAUSE && EXIT /B 1)
%~dp0packages\NUnit.ConsoleRunner.3.6.0\tools\nunit3-console.exe %~dp0test\KitchenSink.Tests\bin\Debug\KitchenSink.Tests.dll --noheader --params Browsers=Chrome,Firefox
pause
IF ERRORLEVEL 1 EXIT /B 1
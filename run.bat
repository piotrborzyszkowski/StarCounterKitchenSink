@echo off

:: If we are not running on build server, stop the db to stop the running apps
IF NOT "%TEAMCITY_VERSION%"=="True" (
    staradmin stop db default
)

star.exe --resourcedir="%~dp0src\KitchenSink\wwwroot" "%~dp0bin\Debug\KitchenSink.exe"
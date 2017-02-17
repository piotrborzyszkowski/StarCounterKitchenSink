$KitchenSinkWwwPath = "..\src\KitchenSink\wwwroot"
$KitchenSinkExePath = "..\bin\Debug\KitchenSink.exe"

#start KitchenSink app
Function startKitchenSink($wwwPath, $exePath)
{
	$process = Start-Process star.exe -ArgumentList "--d=kitchensink --resourcedir=$wwwPath $exePath" -PassThru -NoNewWindow
	return $process.Id
}

try 
{
	$id = startKitchenSink -wwwPath $KitchenSinkWwwPath -exePath $KitchenSinkExePath 
	wait-process -id $id
	exit(0) 
} 
Catch 
{
	exit(1)
}
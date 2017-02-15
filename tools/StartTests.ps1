$KitchenSinkTestsPath = "..\test\KitchenSink.Tests\bin\Debug\KitchenSink.Tests.dll"


#run KitchenSink tests
Function runTests($testPath)
{
	$process = Start-Process -FilePath "..\packages\NUnit.ConsoleRunner.3.6.0\tools\nunit3-console.exe" -ArgumentList "$testPath --noheader " -PassThru -NoNewWindow -Wait
	return $process.ExitCode
}

try 
{
	$testExitCode = runTests -testPath $KitchenSinkTestsPath
	if($testExitCode -ge 0)
	{
		exit(0) 
	}
	else 
	{ 
		exit(1) 
	}
} 
Catch 
{
	exit(1)
}
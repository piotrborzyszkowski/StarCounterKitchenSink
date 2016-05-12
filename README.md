# KitchenSink

Shows how to model different UI patterns in JSON:

- String
   - Text
   - Password
   - Textarea
   - Markdown
   - Html
   - Datepicker
   - Url
   - Redirect

- Number
   - Integer
   - Decimal
   - Button
   - Map

- Boolean
   - Checkbox
   - Button

- Array
   - Radio
   - Dropdown
   - Radiolist
   - Multiselect
   - Table
   - Chart

## Video

Intended for 13 October 2015 webinar: http://starcounter.io/video-expressing-your-ui-in-json-plain-data-binding-advanced-data-binding/

## Screenshot

![](https://raw.githubusercontent.com/StarcounterSamples/KitchenSink/master/screenshot.png)

## Excercises

### 1. Change binding feedback event

From:

```cs
<input type="text" value="{{model.Name$::change}}" placeholder="Name">
```

To:

```cs
<input type="text" value="{{model.Name$::input}}" placeholder="Name">
```

## Testing

### Adding tests for your project?

Go to Tools → NuGet Packet Manager → Packet Manager Console.

In the console, choose your test project from the "Default project" dropdown:

Add packages:

```
Install-Package Selenium.WebDriver
Install-Package Selenium.Support
Install-Package NUnit -Version 2.6.4
Install-Package NUnitTestAdapter
Install-Package NUnit.Runners -Version 2.6.4
```

More info: http://training-course-material.com/training/Selenium_WebDriver_in_C-Sharp

### Prepare your environment

Before running the steps, you need to:

- Download and install Visual Studio 2015 to run the tests
- Download and install Java, required by Selenium Standalone Server
- Download [Selenium Standalone Server](http://docs.seleniumhq.org/download/)
	- It controls browsers to perform the tests. 
	- It is just a single file (`selenium-server-standalone-2.52.0.jar`). 
	- Put this file wherever you like.
- Download additional [drivers](http://docs.seleniumhq.org/download/) (those are all single files) and put them in the same directory as server
- Firefox drivers are built-in to Selenium Standalone Server; no need to download these

### Run the test (from Visual Studio)

1. Start Selenium Remote Driver: `java -jar selenium-server-standalone-2.52.0.jar`
2. Open `KitchenSink.sln` in Visual Studio and enable Test Explorer (Test > Window > Test Explorer)
3. Start the KitchenSink app
4. Press "Run all" in Test Explorer
   - If you get an error about some packages not installed, right click on the project in Solution Explorer. Choose "Manage NuGet Packages" and click on "Restore".
5. Don't touch your keyboard or mouse while the tests are being executed :)

### Run the test (from command line)

1. Start Selenium Remote Driver: `java -jar selenium-server-standalone-2.52.0.jar`
2. Go to the solution folder and run `nuget restore` to make sure you have the test dependencies (listed in `test\KitchenSink.Tests\packages.config`)
 - if you don't have `nuget.exe`, get it from [here](http://docs.nuget.org/Consume/Command-Line-Reference)
3. Build the solution ('msbuild KitchenSink.sln')
4. Start the KitchenSink app (`run.bat`)
5. Start the KitchenSink.Test runner (`test.bat`)
6. Don't touch your keyboard or mouse while the tests are being executed :)

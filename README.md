# KitchenSink

Shows how to model different UI patterns in JSON:

- String
   - Text
   - Password
   - Textarea
   - Url
   - Markdown
   - Html

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
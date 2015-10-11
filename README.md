# KitchenSink
Shows how to model UI in JSON

Intended for 13 October 2015 webinar: http://starcounter.io/starcounter-events/13-10-2015-webinar-expressing-your-ui-in-json/

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
# TimePicker
A touch friendly time picker for WPF inspired by a simple clock.

![Example](/screenshot.png)

# Installation
This library is available as a NuGet package (https://www.nuget.org/packages/RoyT.TimePicker/). You can install the latest stable version by issuing the following command in the Package Manager Console
```
Install-Package RoyT.TimePicker
```

You can then use the TimePicker in your XAML files like this:
```xaml
<!-- Namespace declaration -->
xmlns:tp="clr-namespace:RoyT.TimePicker;assembly=RoyT.TimePicker"

<!-- Time is a property of the custom type Time in our data context -->
<tp:TimePicker Time="{Binding Time, Mode=TwoWay}" />
```
For more information see the blog post at http://roy-t.nl

# Release 0.3
## Added Features
- NuGet Package support

# Release 0.2
## Added Features
- AM / PM support

## Fixed Issues
- The hour indicator was longer than the minute indicator

# Missing Features
- Highlight for indicator that is being dragged

## Known Issues
- None so far

# Release 0.1
## Implemented Features
- Adjust the time by dragging the hour and minute indicator
- Styling options:
  - Brush for the hour indicator
  - Thickness of the hour indicator
  - Brush for the minute indicator
  - Thickness of the minute indicator
  - Separate brushes for the hour and minute ticks
  - Separate thickness for the hour and minute ticks
  - Background brush
  - Border brush and border thickness

## Missing Features
- AM/PM selection
- Highlight for indicator that is being dragged

## Known Issues
- None so far

# The MIT License (MIT)
Copyright (c) 2016, Roy Triesscheijn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
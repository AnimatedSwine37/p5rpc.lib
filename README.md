# p5rpc.lib
A [Reloaded-II](https://reloaded-project.github.io/Reloaded-II/) library that gives mods easy acces to some of Persona 5 Royal (Steam)'s native functions.

Currently this includes the ability to call flowscript functions and get their return values and the ability to read some basic information about the current sequence such as the sequence type and the current event (sequence stuff is still very WIP). In the future as I need to use other native functions I'll add them to this library (and of course it's open to contributions from the community).

## Using In Your Mods
Firstly, you'll need to add the [p5rpc.lib.interfaces nuget package](https://www.nuget.org/packages/p5rpc.lib.interfaces) to your project. Then add `p5rpc.lib` as a dependency in your `ModConfig.json`.

Finally, you'll need to access `IP5RLib` by adding the following to your Mod.cs
``` C#
var p5rLibController = _modLoader.GetController<IP5RLib>();
if (p5rLibController == null || !p5rLibController.TryGetTarget(out var p5rLib))
{
    // Tell the user that you couldn't access inputhook so stuff won't work
}
```

Once you have an instance of IP5RLib you can access the different "components" of it. Currently there is the `FlowCaller` component and the `Sequencer` component.

### Calling Flow Functions
You can use the `FlowCaller` field of IP5RLib to call flowscript functions. Every flowscript flowscript function has been mapped to a C# function for ease of use, for example if you wanted to get the current field you could do the following:

``` C#
int fieldMajor = _p5rLib.FlowCaller.FLD_GET_MAJOR();
int fieldMinor = _p5rLib.FlowCaller.FLD_GET_MINOR();
_logger.WriteLine($"The current field is {fieldMajor}_{fieldMinor}");
```

This assumes that you've saved your reference to IP5RLib in a `_p5rLib` variable. If you're only interested in using the FlowCaller component (or another one) it may be a good idea to put that in a separate variable to save yourself a bit of typing such as `IFlowCaller _flowCaller = _p5rLib.FlowCaller;`

For more examples check out the [test mod](p5rpc.lib.tester/Mod.cs).

#### Caveats
FlowCaller won't necessarily work with every available function. For example any functions that are displaying messages or selections such as `MSG` won't work as there is no associated bf with the calls to the functions (I may make a workaround for this in the future though). 

There may be other functions that don't work as I've only tested the handful that I actually need (there are 2163 functions, no chance I'm testing them all :D). If you find one that doesn't work that you need to use (other than ones using messages) make an issue and I can look into it.

### Getting Sequence Information
You can use the `Sequencer` field of IP5RLib to access some information about the current sequence. There are three things you can access currently, an event that will be invoked whenever the sequence changes, one that will be invoked when an event starts, and a function that gets the current sequence info. For example, to track when an event started you could do the following:

``` C#
_p5rLib.Sequencer.EventStarted += EventStarted;
  
private void EventStarted(EventInfo eventInfo)
{
  _logger.WriteLine($"You are now in event {eventInfo}"); // Could also use eventInfo.Major and eventInfo.Minor
}
```

For more examples check out the [test mod](p5rpc.lib.tester/Mod.cs).

#### Caveats
The only reliable way to get the current event is by subscribing to the `EventStarted` event as it is only briefly stored in the sequence info so using `GetSequenceInfo` will not be able to reliably tell you information about the current event.

Also, the `SequenceType`s are not neccessarily accurate. In particular `BATTLE` seems to be used almost everywhere, not just in battle, and `FIELD` and `FILED_VIEWR` are never used as far as I've seen. The event, calendar and title screen ones do seem to be accurate.
Later on I'll probably try and find a way to accurately track those that are always showing as BATTLE.

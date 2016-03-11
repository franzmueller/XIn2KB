# XIn2KB
With XIn2KB you can easily translate your XInput Controller (for example the XBOX 360 Controller) into keystrokes. This is useful, because some applications don't support controllers at all or only support DirectInput controllers which comes with some downsides. With DirectInput you can't use the triggers both at once, with XInput you can.

#Download
Please download the latest version from <a href="https://github.com/franzmueller/XIn2KB/releases">the release page.</a>

##Setup
XIn2KB is programmed to run out-of-the-box, all you have to do is create your rules. This is in fact harder than it should be at the moment, but this might change in the future if enough people actually use this program.

###Rule creation
Each ruleset is saved in it's own XML file. By default XIn2KB will try to load the rules from settings.xml, which you should edit.
To add rules you should read the instructions given in the file carefully. You may add as many rules per controller as you want, you can even create two rules with the same input, but different outputs.

###Different rulesets
You can create as many different rulesets as you want. Simply copy your settings.xml, rename and edit it. You can then proceed and start XIn2KB via the command line like this:

>XIn2KB.exe example.xml


###Rule limitations
As this is a fairly new project, rule creation is limited by the following factors:

- You can not use inline XML

- You can not use a rule with more than one in- or output.

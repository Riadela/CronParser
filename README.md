# Cron Expression Parser
 
This is a C# project, containing a Cron Expression Parser, which supports the standard cron format with five fields, `Minutes, Hour, Day of Month, Month and Day of Week`, and as well as some of the operators `, - * /` .

This is runnable on Windows, Linux and macOS.

## How to run it on macOS

First of all, we need to build our project and in order to do so, we will download Visual Studio from here https://visualstudio.microsoft.com/vs/mac/, install it (will take care and install .Net as well), open up our solution and build it.

Once that is done, we can navigate to the bin folder through command line (i.e. `../CronParser/CronParser/CronParser/bin/Debug`) and run our .exe file as follows:

`
mono CronParser.exe */15 0 1,15 \* 1-5 /usr/bin/find
`

As you can notice, we had to escape the * symbol using the backslash, otherwise .NET thinks we want to know which files are in the folder. 
So please, when passing in the argument, if you're passing only `*` as a single argument, pass it as `\*` . 
All the other symbols are fine and work as expected (no need to escape for example `*/15`)

The above examble produces the following output

```
minute          0 15 30 45
hour            0         
day of month    1 15      
month           1 2 3 4 5 6 7 8 9 10 11 12
day of week     1 2 3 4 5 
command         /usr/bin/find
```

## Unit testing

Unfortunately, the console project is targeting .Net 4.7.2 framework, but on macOS we can only create create UnitTest projects targeting .Net Core, so our project is not testable on Linux based OS at the moment.

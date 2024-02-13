# JP55.CmdParser

this will either become my biggest project ever or literally be forgotten in a week who knows

basically it's a backend for console application to handle commands and arguments

it's absolutely unfinished and not even close to being actually usable in any way, i'm just putting it on github so i can have *some* version control as i completely change the way it works because it's shit

## Usage
basically you have commands that do stuff and the command manager that will actually parse argv. except rn it just finds the command by name and doesn't give a shit about anything else you throw at it

then each command's ArgPrepHelper function will actually parse the argv with the arguments into actual typed parameters for the command handler function to use

so you just call commandmanager.execute with the command and the argv (except the argv here doesn't have the command name) and that handles the argprephelper and all that shit yea actually this system blows

## Contributing
if anyone actually cares about contributing to this, just send a pull request or something idk

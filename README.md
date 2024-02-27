# JP55.CmdParser

this will either become my biggest project ever or literally be forgotten in a week who knows

basically it's a backend for console application to handle commands and arguments

it's actually somewhat usable now

## Usage
basically you have commands that do stuff and the command manager that will actually parse argv. that's it, you literally just throw your argv at it and it will do its magic

then each command's ArgPrepHelper function will actually parse the argv into actual typed parameters for the command handler function to use

so you just call commandmanager.parseAndExecute with your argv and it will find the command, handle most error cases, call the ArgPrepHelper, and then execute the command

## Contributing
if anyone actually cares about contributing to this, just send a pull request or something idk

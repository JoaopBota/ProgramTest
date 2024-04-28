# Process Monitor

A simple C# console application to monitor a specified process and terminate it if it exceeds a maximum lifetime.

## Usage

The program accepts three command-line arguments:

1. **Process Name**: Name of the process to monitor.
2. **Max Lifetime**: Maximum allowed lifetime of the process in minutes.
3. **Monitoring Frequency**: Frequency at which to check the process lifetime in minutes.

Example usage:

Program.exe notepad 5 1


## Functionality

- The program checks if the specified process is running.
- If the process is running, it starts monitoring it.
- The monitoring task runs asynchronously and checks the lifetime of the process.
- If the process exceeds the maximum lifetime, it is terminated.
- The user can quit the program by pressing 'Q'.

## Command-Line Arguments

1. **Process Name**: Name of the process to monitor.
2. **Max Lifetime**: Maximum allowed lifetime of the process in minutes.
3. **Monitoring Frequency**: Frequency at which to check the process lifetime in minutes.

## Exiting the Program

You can exit the program by pressing the 'Q' key at any time.


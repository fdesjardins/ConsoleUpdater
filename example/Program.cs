using System;
using System.Collections.Generic;
using System.Timers;
using ConsoleUpdater;

public class Program
{
  public static Timer timer;
  public static int timesWritten = 0;
  public static List<String> frames;
  
  public static void Main()
  {
    frames = new List<String>(){@"
  \o/
   |
  / \
", @"
   o
  /|\
  / \
"};
    
    timer = new Timer(500);
    timer.Elapsed += UpdateConsole;
    timer.AutoReset = true;
    timer.Enabled = true;
    
    Console.WriteLine("Press any key to exit...");
    Console.ReadLine();
    ConsoleUpdate.Clear();
    ConsoleUpdate.Done();
  }
  
  private static void UpdateConsole(Object source, ElapsedEventArgs e)
  {
    var frame = frames[timesWritten % frames.Count];
    ConsoleUpdate.Render(frame);
    timesWritten += 1;
  }
}
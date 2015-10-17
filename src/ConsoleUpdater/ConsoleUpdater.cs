using System;

namespace ConsoleUpdater
{
	public class ConsoleUpdate
	{
		public static int prevLineCount = 0;
		
		public static void Render(string message)
		{
			Console.CursorVisible = false;
			var bufferOut = message + '\n';
			EraseLines(prevLineCount);
			Console.Write(bufferOut);
			prevLineCount = bufferOut.Split('\n').Length;
		}
		
		public static void Clear()
		{
			EraseLines(prevLineCount);
			prevLineCount = 0;
		}
		
		public static void Done()
		{
			prevLineCount = 0;
			Console.CursorVisible = true;
		}
		
		private static void EraseLines(int count)
		{
			int cursorTop = Console.CursorTop;
			
			for (int i = 0; i < count; i++)
			{
				Console.SetCursorPosition(0, cursorTop - i);
				EraseLine();
			}
		}
		
		private static void EraseLine()
		{
			int cursorTop = Console.CursorTop;
			Console.SetCursorPosition(0, cursorTop);
			Console.Write(new string(' ', Console.WindowWidth)); 
			Console.SetCursorPosition(0, cursorTop);
		}
	}
}
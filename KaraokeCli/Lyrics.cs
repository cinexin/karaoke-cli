using System;
using System.IO;
using System.Security;

namespace KaraokeCli
{
	public class Lyrics
	{
		private string[] lines;

		private void WriteLine(string line)
		{
			var results = line.Split(':');
			this.WriteLine(results[0], int.Parse(results[1]));

		}

		private void WriteLine(string line, int time)
		{
			var speed = time / line.Length;
			foreach (var letter in line.ToCharArray())
			{
				Console.Write(letter);
				System.Threading.Thread.Sleep(speed);
			}
			Console.WriteLine("");

		}

		public void ShowLyrics()
		{
			Console.WriteLine("============================================");
			foreach (var line in lines)
			{
				this.WriteLine(line);
			}
			Console.WriteLine("============================================");
		}

		public Boolean InitLyricsFromFile(string fileName)
		{
			try
			{
				this.lines = File.ReadAllLines(fileName);
			}
			catch (Exception ex ) when (
				ex is ArgumentException ||
				ex is ArgumentNullException ||
				ex is PathTooLongException ||
				ex is DirectoryNotFoundException ||
				ex is IOException ||
				ex is UnauthorizedAccessException ||
				ex is FileNotFoundException ||
				ex is SecurityException
			)
			{
				return false;
			}
			return true;
		}

		public Lyrics()
		{
		}
	}
}

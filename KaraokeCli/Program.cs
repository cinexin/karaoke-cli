using System;


namespace KaraokeCli
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			const string fileSuffix = ".txt";
			var songs = new string[] { "allthistime","endoftheworld","itsasmallworld"};
			while (true)
			{
				Console.WriteLine("Welcome to Karaoke Command-Line!");
				Console.WriteLine("Choose the song you'd like to sing...");
				Console.WriteLine("1 for All This Time");
				Console.WriteLine("2 for End Of The World");
				Console.WriteLine("3 for It's a Small World");
				Console.Write("Your choice (type 'Q' to quit app): ");

				var response = Console.ReadLine();

				if ( response.ToLower().StartsWith("q")  )
				{
					break;
					//Console.ReadLine();
				}

				var chosenSong = 0;
				if (!int.TryParse(response, out chosenSong))
				{
					Console.WriteLine("Ooops! Wrong choice! Try again...");
					continue;	
				}

				chosenSong--;
				var fileName = songs[chosenSong] + fileSuffix;
				Lyrics lyrics = new Lyrics();
				if (!lyrics.InitLyricsFromFile(fileName))
				{
					Console.WriteLine("Ooops...there was an error trying to open the lyrics. Try another option. Sorry :-(");
					continue;
				}

				lyrics.ShowLyrics();
			}
		}
	}
}

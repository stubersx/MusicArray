using System.ComponentModel.DataAnnotations;

namespace FunWithMusic
{
    internal class Program
    {
        enum Genre
        {
            Classical,
            Pop,
            HipHop,
            Rock,
            Jazz
        }

        struct Music
        {
            private string Title;
            private string Artist;
            private string Album;
            private string Length;
            private Genre? Genre;

            public void SetTitle(string title)
            {
                Title = title;
            }

            public void SetArtist(string artist)
            {
                Artist = artist;
            }

            public void SetAlbum(string album)
            {
                Album = album;
            }

            public void SetLength(string length)
            {
                Length = length;
            }

            public void SetGenre(Genre genre)
            {
                Genre = genre;
            }

            public string Display()
            {
                return "Title: " + Title +
                    "\nArtist: " + Artist +
                    "\nAlbum: " + Album +
                    "\nLength: " + Length +
                    "\nGenre: " + Genre;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("How many songs would you like to enter?");
            int size = int.Parse(Console.ReadLine());
            Music[] musics = new Music[size];
            try
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine("What is the title of the song?");
                    musics[i].SetTitle(Console.ReadLine());
                    Console.WriteLine("Who is the artist?");
                    musics[i].SetArtist(Console.ReadLine());
                    Console.WriteLine("What album is it on?");
                    musics[i].SetAlbum(Console.ReadLine());
                    Console.WriteLine("What is the length of the song?");
                    musics[i].SetLength(Console.ReadLine());
                    Console.WriteLine("What is the genre?");
                    Console.WriteLine("C - Classical\nP - Pop\nH - Hip Hop\nR - Rock\nJ - Jazz");
                    Genre? genre;
                    char g = char.Parse(Console.ReadLine());
                    switch (g)
                    {
                        case 'C':
                        case 'c':
                            genre = Genre.Classical;
                            break;
                        case 'P':
                        case 'p':
                            genre = Genre.Pop;
                            break;
                        case 'H':
                        case 'h':
                            genre = Genre.HipHop;
                            break;
                        case 'R':
                        case 'r':
                            genre = Genre.Rock;
                            break;
                        case 'J':
                        case 'j':
                            genre = Genre.Jazz;
                            break;
                        default:
                            genre = null;
                            break;
                    }
                    musics[i].SetGenre(genre.GetValueOrDefault());
                }
            }
            catch(ArgumentException e)
            { 
                Console.WriteLine(e.Message);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                for(int i = 0; i < size; i++)
                {
                    Console.WriteLine($"{musics[i].Display()}");
                }
            }
        }
    }
}

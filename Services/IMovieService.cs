using System.Collections.Generic;
using MovieApi.Models;
namespace MovieApi.Services
{
    public interface IMovieSerivce
    {
        public IEnumerable<Movie> GetMovies();
        public Movie GetMovieByName(string name);
        public Movie GetMovieByYear(int year);
        public void CreateMovie(Movie movie);
        public void UpdateMovie(string name,Movie m);
        public void DeleteMovie(string name);
        
    }
}
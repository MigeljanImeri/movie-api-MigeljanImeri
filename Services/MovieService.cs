using System.Collections.Generic;
using MovieApi.Models;
using MovieApi.Respository;
namespace MovieApi.Services
{
    public class MovieService : IMovieSerivce
    {
        private IMovieRepository _repo;
        public MovieService(IMovieRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Movie> GetMovies() 
        {
            IEnumerable<Movie> myList = _repo.GetAll();

            return myList;
        }
        public Movie GetMovieByName(string name)
        {
            return _repo.GetMovieByName(name);

        }
        public Movie GetMovieByYear(int year)
        {
            IEnumerable<Movie> myList = _repo.GetAll();
            foreach(Movie m in myList)
            {
                if (m.Year == year) return m;
            }
            return null;

        }
        public void CreateMovie(Movie movie)
        {
            _repo.InsertMovie(movie);
        }
        public void UpdateMovie(string name,Movie m)
        {
            _repo.UpdateMovie(name,m);
        }
            
        public void DeleteMovie(string name)
        {
            _repo.DeleteMovie(name);
        }    

    }
}
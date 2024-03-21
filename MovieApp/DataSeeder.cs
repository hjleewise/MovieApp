using MovieApp.Data;
using System.Runtime.CompilerServices;

namespace MovieApp
{
    public static class DataSeeder
    {
        public static void Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<MovieContext>();
            context.Database.EnsureCreated();
            AddMovies(context);
        }

        private static void AddMovies(MovieContext context)
        {
            var movie = context.Movies.FirstOrDefault();
            if (movie != null) return;

            context.Movies.Add(new Movie 
            { 
                Title = "쇼생크탈출",
                Year = 1994,
                Summary = "쇼생크탈출 영화 줄거리",
                Actors = new List<Actor>
                {
                    new Actor { Fullname = "모건 프리먼"},
                    new Actor { Fullname = "팀 로빈스"}
                }
            });

            context.Movies.Add(new Movie
            {
                Title = "갓파더",
                Year = 1972,
                Summary = "갓파더 영화 줄거리",
                Actors = new List<Actor>
                {
                    new Actor { Fullname = "말론 브랜도"},
                    new Actor { Fullname = "알 파치노"}
                }
            });

            context.Movies.Add(new Movie
            {
                Title = "다크나이트",
                Year = 2008,
                Summary = "다크나이트 영화 줄거리",
                Actors = new List<Actor>
                {
                    new Actor { Fullname = "히스 레저"},
                    new Actor { Fullname = "크리스찬 베일"}
                }
            });

            context.SaveChanges();

        }
    }
}

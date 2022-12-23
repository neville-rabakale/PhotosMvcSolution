using PhotosMvc.Views.Home;
using System;

namespace PhotosMvc.Models
{
    public class DataService
    {
        public DataService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
        List<Photo> Photos = new List<Photo>
        {                      
            new Photo {Id = 1, Title = "Cute Cat", Url="https://tinyurl.com/4p98bj3p"},
            new Photo {Id = 2, Title = "Angry Dog", Url="https://tinyurl.com/mr22nmpu" },
            new Photo {Id = 3, Title = "Happy Hamser", Url="https://tinyurl.com/4p98bj3p"},
        };
        private readonly IHttpClientFactory clientFactory;

        public IndexVM[] GetAllPhotos()
        {
            return Photos.Select(o => new IndexVM
            {
                Titel = o.Title,
                ImageUrl= o.Url,
            })
            .ToArray();

        }

        public async Task<IndexVM[]> GetPhotosAsync()
        {
            var url = "https://localhost:7249/api/photos";
            // Kräver att en instans av IHttpClientFactory injicerats i servicens konstruktor
            // och att följande anropas i program: builder.Services.AddHttpClient();
            HttpClient httpClient = clientFactory.CreateClient();
            // Anropar Web-API:t och deserialiserarinnehållet till en array av foton
            Photo[] photos = await httpClient.GetFromJsonAsync<Photo[]>(url);
            return photos
            .Select(o => new IndexVM
            {
                Titel = o.Title,
                ImageUrl = o.Url,
            })
            .ToArray();
        }
        public Photo[] GetAll()
        {
            return Photos
            .ToArray();

        }
        public Photo GetById(int id)
        {
            return Photos.Where(o => o.Id == id)
                .Single();
        }

    }
}

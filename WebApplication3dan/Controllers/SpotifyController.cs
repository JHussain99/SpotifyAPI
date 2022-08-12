    using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;
using System.Linq;

namespace WebApplication3dan.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotifyController : ControllerBase
    {

        private readonly ILogger<SpotifyController> _logger;

        public SpotifyController(ILogger<SpotifyController> logger)
        {
            _logger = logger;
        }
      
       
        [HttpGet(Name = "SpotifyWebPlayer")]
        public async Task<CurrentlyPlayingTrack> Get()
        {
            var spotify = new SpotifyClient("BQCf4arAEjNe6TyLh2VekkSk5MDt6khiJbYkkJA072TD8rBz5HfQ-UqgzncoIAYTGFB4VHljOy2se75BEyuqk2-ML6BNXM1gRn0Uk0K7jm2xld95hRI2OBNzi32kdfKPzyaoW4r8psmfpHz0LUb-YvcuKH7ZGIk6yLC7KA7r1ixH5xSHjoxJlUzIu52TTLZEvpoNHIdRtXE");
            // BQC24Q6ncRrjmkQx1HhARRI1CZtCBITtS_iDI-7p38wlQ8NDm36YvMXoyxQd0PF9vLWFug5GRb3EfiJ1r9dbkcoibJs5THe2TfQwHnaDd0k9rFoMrbcMKPbXuMt2061pcK2D9NQUBP7802O47He5ulkNl6WuiaF7838pY34OP45qD8xSc5LMjBI0DtKhkuishGHvrYy-AT4

            var request = new PlayerCurrentlyPlayingRequest(PlayerCurrentlyPlayingRequest.AdditionalTypes.Track);

            
            var track = await spotify.Player.GetCurrentlyPlaying(request);
            // Tracks.Get("0tEjjVdIQM2i3z3Cmlt0er");

            var item = track.Item as FullTrack;




            var data = new CurrentlyPlayingTrack
            { 
                
                Artist = string.Join(",", item.Artists.Select(x => x.Name)),
                Title = item.Name,
                AlbumImageUrl = item.Album.Images[0].Url,
                TrackUrl = item.ExternalUrls.FirstOrDefault(x => x.Key == "spotify").Value,
                IsPlaying = track.IsPlaying,

                
             
            
            };
           


            return data;



        }
    }
}
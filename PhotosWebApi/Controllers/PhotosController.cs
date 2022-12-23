using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotosMvc.Models;
using PhotosMvc.Views.Home;

namespace PhotosWebApi.Controllers
{
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly DataService service;

        public PhotosController(DataService service)
        {
            this.service = service;
        }

        //[HttpGet("api/photos/{id}")]
        //public Photo GetPhoto(int id)
        //{
        //    Photo photo = service.GetById(id);
        //    return photo;
        //}

        [HttpGet("/api/photos/{id}")]
        public ActionResult<Photo> GetPhotoAction(int id)
        {
            var photo = service.GetById(id);
            if (photo == null)
                return NotFound();
            return photo;
        }

        [HttpGet("/api/photos/")]
        public ActionResult<Photo[]> GetAllPhotoAction()
        {
            var photo = service.GetAll();
            if (photo == null)
                return NotFound();
            return photo;
        }


    }
}

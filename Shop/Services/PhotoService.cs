using Shop.Data;
using Shop.Data.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class PhotoService
    {
        private readonly ApplicationDbContext _db;

        public PhotoService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Photo GetPhoto(int photoId)
        {
            return _db.Photos.FirstOrDefault(u => u.PhotoId == photoId);
        }

        public List<Photo> GetPhotos(int productId)
        {
            List<Photo> photos = _db.Photos.ToList();
            List<Photo> result = new List<Photo>();
            foreach (var item in photos)
            {
                if (item.ProductId == productId)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        //Intentional no save to DB - this service should be only called from Product Service
        public bool DeletePhoto(Photo photo)
        {
            if (_db.Photos.Contains(photo))
            {
                _db.Photos.Remove(photo);
            }
            else
            {
                return false;
            }
            return true;
        }

        //Intentional no save to DB - this service should be only called from Product Service
        public bool CreatePhoto(Photo photo)
        {
            try
            {
                _db.Photos.Add(photo);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}

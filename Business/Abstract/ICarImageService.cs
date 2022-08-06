using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService 
    {
        IResult Add(CarImage carImage, IFormFile formFile);
        IResult Delete(int imageId);
        IResult Update(int imageId, IFormFile file);
        IDataResult<List<CarImage>> GetImages();
        IDataResult<CarImage> GetImage(int imageId);
        IDataResult<List<CarImage>> GetCarImagesById(int carId);
    }

}

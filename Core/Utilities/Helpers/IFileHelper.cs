using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        string Add(string root, IFormFile file);
        void Delete(string fielPath);
        string Update(string root, IFormFile file, string fielPath);

        //string Get(string fielPath);


    }
}

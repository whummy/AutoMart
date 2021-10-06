
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace AutoMart.Controllers
{
    [Route("api/v1/images")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        public  static IWebHostEnvironment _webHostEnvironment;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public FileUploadController(IWebHostEnvironment webHostEnvironment, IRepositoryManager repository, IMapper mapper)
        {
            _webHostEnvironment = webHostEnvironment;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// This endpoint create a file for a particular item (car, profile pcitures and all other objects that requires an image)
        /// The fileItemId is the Id of the item that owns this images e.g a car's Id.
        /// </summary>
        /// <param name="fileItemId"></param>
        /// <param name="objectFile"></param>
        /// <returns></returns>
        [HttpPost("{fileItemId}")]
        public string Post([FromRoute] Guid fileItemId, [FromForm] CreateFileUploadDto objectFile)
        {
            try
            {
                if (objectFile.files.Length > 0)
                {
                    string rootpath = _webHostEnvironment.WebRootPath;
                    string folderPath = Path.Combine(rootpath, "\\uploads\\");

                    if(!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    var uniqueValue = DateTime.UtcNow.ToString("yyyy/MM/dd/hh/mm/fffffff");
                    var relativeFilePath = Path.Combine("\\uploads\\", objectFile.files.FileName + uniqueValue);
                    var filePath = Path.Combine(rootpath, relativeFilePath);

                    using (FileStream filestream = System.IO.File.Create(filePath))
                    {
                        objectFile.files.CopyTo(filestream);
                        filestream.Flush();
                        return "Uploaded.";
                    }

                    // add a new record for fileUpload
                   

                }
                else
                {
                    return "Not Uploaded";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
       
    }
}

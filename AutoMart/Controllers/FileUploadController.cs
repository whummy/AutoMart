
using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
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
        private readonly RepositoryContext dbcontext;

        public FileUploadController(IWebHostEnvironment webHostEnvironment, IRepositoryManager repository, IMapper mapper, RepositoryContext db)
        {
            _webHostEnvironment = webHostEnvironment;
            _repository = repository;
            _mapper = mapper;
            dbcontext = db;
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
                    string folderPath = Path.Combine(rootpath, "uploads");

                    if(!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    var uniqueValue = DateTime.UtcNow.ToString("yyyy-MM-dd-hh-mm-fffffff");
                    var relativeFilePath = Path.Combine("uploads\\", uniqueValue + objectFile.files.FileName);
                    var filePath = Path.Combine(rootpath, relativeFilePath);

                    using (FileStream filestream = System.IO.File.Create(filePath))
                    {
                        objectFile.files.CopyTo(filestream);
                        filestream.Flush();                       
                    }

                    // add a new record for fileUpload
                    
                    FileUpload fileupload = new FileUpload();
                    fileupload.Imagepath = relativeFilePath;
                    fileupload.InsertedOn = DateTime.Now;
                    fileupload.FileItemId = fileItemId;
                    dbcontext.FileUploads.Add(fileupload);
                    dbcontext.SaveChanges();
                    return "Save Successfully.";
                                       
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

using Microsoft.AspNetCore.Http;
using System;

namespace Entities.DataTransferObjects
{
    public class CreateFileUploadDto
    {
        public IFormFile files { get; set; }
    } 
    
    public class FileUploadDto
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }

        public Guid FileItemId { get; set; }
    }
}

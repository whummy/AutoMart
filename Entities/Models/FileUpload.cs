using Microsoft.AspNetCore.Http;
using System;

namespace Entities.Models
{
    public class FileUpload
    {
        public Guid Id { get; set; }
        public string Imagepath { get; set; }
        public DateTime InsertedOn { get; set; }
        public Guid FileItemId { get; set; }
    }
}

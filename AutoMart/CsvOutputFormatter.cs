using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoMart
{
    public class CsvOutputFormatter:TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        protected override bool CanWriteType(Type type)
        {
            if (typeof(BrandDto).IsAssignableFrom(type) ||
                typeof(IEnumerable<BrandDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();
            if (context.Object is IEnumerable<BrandDto>)
            {
                foreach (var brand in (IEnumerable<BrandDto>)context.Object)
                {
                    FormatCsv(buffer, brand);
                }
            }
            else
            {
                FormatCsv(buffer, (BrandDto)context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }
        private static void FormatCsv(StringBuilder buffer, BrandDto brand)
        {
            buffer.AppendLine($"{brand.Id},\"{brand.Name},\"");
        }
    }


}


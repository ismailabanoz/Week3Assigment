using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Week3.Service.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        [JsonIgnore]
        public int Status { get; set; }
    }
}

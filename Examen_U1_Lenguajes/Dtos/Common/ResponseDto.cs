using Newtonsoft.Json;

namespace Examen_U1_Lenguajes.Dtos.Common
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public bool Status { get; set; }
    }
}

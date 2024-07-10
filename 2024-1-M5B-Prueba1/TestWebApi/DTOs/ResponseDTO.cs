using Logic.Models;

namespace WebApi.DTOs
{
    public class ResponseDTO
    {
        public bool Success { get; set; }
        public string Responce { get; set; }
        public ResponseDTO()
        {
            Success = true;
            Responce = "paracetamol"
        }
    }
}
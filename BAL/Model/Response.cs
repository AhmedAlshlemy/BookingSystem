using BAL.Enum;

namespace BAL.Model
{
    public class Response
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
        public dynamic Errors { get; set; }
        public dynamic Data { get; set; }
    }
}

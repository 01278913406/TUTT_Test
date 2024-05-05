namespace TUTT_API.Models
{
    public interface IResult
    {
        bool Status { get; set; }

        string Message { get; set; }

        int? Code { get; set; }
    }
    public class Result : IResult
    {
        public bool Status { get; set; } = true;


        public string Message { get; set; }

        public int? Code { get; set; }

        public object Data { get; set; }

        public int? TotalRecord { get; set; }

        public static Result Error(string message = "")
        {
            return new Result
            {
                Message = message,
                Status = false
            };
        }

        public static Result Success(object data, int totalRecord = 0, string message = "")
        {
            return new Result
            {
                Data = data,
                TotalRecord = totalRecord,
                Message = message
            };
        }
    }
}

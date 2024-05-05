namespace TUTT_API.Models
{
    public class ServiceHttpResult
    {
        public bool isSuccess { get; set; }
        public string result { get; set; }
        public string error { get; set; }
        public int code { get; set; }

        public ServiceHttpResult()
        {

        }
        public ServiceHttpResult(int code, string data)
        {
            this.code = code;
            this.isSuccess = false;
            if (code >= 200 && code < 300)
            {
                this.isSuccess = true;
                this.result = data;
            }
            else
            {
                this.error = data;
            }

        }
    }
}

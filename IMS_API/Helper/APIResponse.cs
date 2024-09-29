namespace IMS_API.Helper
{
    public class APIResponse
    {
        public int ResponseCode { get; set; }
        public bool Status { get; set; }
        public string Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}

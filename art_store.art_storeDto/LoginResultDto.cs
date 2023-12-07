namespace art_store.art_storeDto
{
    public class LoginResultDto
    {
        public bool IsSuccessful { get; set; }
        public string Error { get; set; }
        public string AccessToken { get; set; }
    }
}

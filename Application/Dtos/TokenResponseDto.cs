namespace Application.Dto
{
    public class TokenResponseDto
    {
        public string AccessToken { get; set; }
        public DateTime ExpiresIn { get; set; }

        public TokenResponseDto(string accessToken, DateTime expiresIn)
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
        }
    }
}

namespace CryptoPunks.MoreTech.CryptoClient
{
    public static class CryptoHttpClient
    {
        public static string VersionApi { get; set; } = "/v1/";

        public static HttpClient Client { get; set; } = new()
        {
            BaseAddress = new("https://hackathon.lsp.team/hk" + VersionApi)
        };
    }
}

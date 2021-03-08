namespace Auth.Domain.Validation
{
    public class UnauthorizedException : System.Exception
    {
        public UnauthorizedException() : base("Unauthorized")
        {
        }
    }
}

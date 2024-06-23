namespace AroundTheWorld.Application.Interfaces
{
    public interface IJwtService
    {
        public string CreateJWTToken(Guid userId);
    }
}

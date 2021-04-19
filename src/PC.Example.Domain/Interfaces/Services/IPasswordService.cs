namespace PC.Example.Domain.Interfaces.Services
{
    public interface IPasswordService
    {
        bool Validate(string password);
    }
}
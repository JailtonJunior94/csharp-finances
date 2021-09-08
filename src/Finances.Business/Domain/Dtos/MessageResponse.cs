namespace Finances.Business.Domain.Dtos
{
    public class MessageResponse
    {
        public MessageResponse(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}

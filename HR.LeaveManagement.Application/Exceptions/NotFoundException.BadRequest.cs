namespace HR.LeaveManagement.Application.Exceptions;

public partial class NotFoundException
{
    public class BadRequest : Exception
    {
        public BadRequest(string messege): base(messege)
        {
            
        }
    }
}




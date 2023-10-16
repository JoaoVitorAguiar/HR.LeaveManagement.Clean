using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string messege) : base(messege)
    {
        ValidationErros = new List<string>();
    }

    public BadRequestException(string messege, ValidationResult validationResult) : base(messege)
    {
        ValidationErros = new List<string>();
        foreach(var error in validationResult.Errors)
        {
            ValidationErros.Add(error.ErrorMessage);
        }
    }

    public List<string> ValidationErros { get; set; }
}




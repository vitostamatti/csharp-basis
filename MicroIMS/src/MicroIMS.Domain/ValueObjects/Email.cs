using MicroIMS.Domain.Common;
using MicroIMS.Domain.Errors;
using MicroIMS.Domain.Primitives;

namespace MicroIMS.Domain.ValueObjects;

public sealed class Email : ValueObject
{
    public string Value { get; }
    private Email(string value)
    {
        Value = value;
    }
    public static Result<Email> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return Result.Failure<Email>(DomainErrors.Email.Invalid);
        }
        if (email.Split('@').Length != 2)
        {
            return Result.Failure<Email>(DomainErrors.Email.Invalid);
        }
        return new Email(email);
    }
    public override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
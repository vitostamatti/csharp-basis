using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MicroIMS.Domain.Common;

public class Error : IEquatable<Error>
{
    public string Code { get; }
    public string Message { get; }
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error Some = new(string.Empty, string.Empty);
    public bool Equals(Error? other)
    {
        if (other is null)
        {
            return false;
        }
        return Code == other.Code && Message == other.Message;
    }
    public override bool Equals(object? obj)
    {
        return obj is Error error && Equals(error);
    }
    public override string ToString()
    {
        return Code;
    }
    public static implicit operator string(Error error) => error.Code;
    public static bool operator ==(Error? a, Error? b)
    {
        if (a is null && b is null)
        {
            return true;
        }
        if (a is null || b is null)
        {
            return false;
        }
        return a.Equals(b);
    }
    public static bool operator !=(Error? a, Error? b)
    {
        return !(a == b);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Code, Message);
    }
}
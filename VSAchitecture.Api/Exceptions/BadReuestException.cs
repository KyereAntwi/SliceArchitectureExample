using System;
namespace VSAchitecture.Api.Exceptions;

public class BadReuestException : Exception
{
	public BadReuestException(string message) : base(message)
	{
	}
}


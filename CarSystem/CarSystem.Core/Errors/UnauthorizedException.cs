using System.Runtime.Serialization;

namespace TaskManager.Core.Errors;

public class UnauthorizedException : BaseException
{
    public UnauthorizedException() { }
    public UnauthorizedException(String message) : base(message) { }
    public UnauthorizedException(String message, Exception inner) : base(message, inner) { }
    public UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context) { } 

    //public ImageFileUnexpectedException() { }
    //public ImageFileUnexpectedException(String message) : base(message) { }
    //public ImageFileUnexpectedException(String message, Exception inner) : base(message, inner) { }
    //protected ImageFileUnexpectedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

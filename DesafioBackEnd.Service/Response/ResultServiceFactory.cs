using System.Net;

namespace DesafioBackEnd.Service.Response;

public static class ResultServiceFactory
{
    public static ResultService Ok(string message)
    {
        return new ResultService(
            message,
            (int)HttpStatusCode.OK,
            success: true
        );
    }

    public static ResultService Created(string message)
    {
        return new ResultService(
            message,
            (int)HttpStatusCode.Created,
            success: true
        );
    }

    public static ResultService NoContent()
    {
        return new ResultService(null, (int)HttpStatusCode.NoContent, true);
    }

    public static ResultService NoContent(string message)
    {
        return new ResultService(message, (int)HttpStatusCode.NoContent, true);
    }

    public static ResultService BadRequest(string message)
    {
        return new ResultService(
            message,
            (int)HttpStatusCode.BadRequest,
            errors: new List<string>()
        );
    }

    public static ResultService BadRequest(ICollection<string> errors, string message)
    {
        return new ResultService(
            message,
            (int)HttpStatusCode.BadRequest,
            errors: errors
        );
    }

    public static ResultService NotFound(string message)
    {
        return new ResultService(message, (int)HttpStatusCode.NotFound);
    }

    public static ResultService Forbidden(string message)
    {
        return new ResultService(message, (int)HttpStatusCode.Forbidden);
    }
    
    public static ResultService Unauthorized(string message)
    {
        return new ResultService(message, (int)HttpStatusCode.Unauthorized);
    }


    public static ResultService InternalServerError(string message)
    {
        return new ResultService(message, (int)HttpStatusCode.InternalServerError);
    }
}

/// <summary>
/// Factory for the results service with result data generic - ResponseFactory
/// </summary>
/// <typeparam name="T">type result</typeparam>
public static class ResultServiceFactory<TResult> where TResult : class
{
    public static ResultService<TResult> Ok(TResult data, string message = null)
    {
        return new ResultService<TResult>(
            statusCode: (int)HttpStatusCode.OK,
            success: true,
            data: data,
            message: message
        );
    }


    public static ResultService<TResult> Created(TResult data, string message)
    {
        return new ResultService<TResult>(
            statusCode: (int)HttpStatusCode.Created,
            success: true,
            data: data,
            message: message
        );
    }

    public static ResultService<TResult> NoContent(TResult data, string message = null)
    {
        return new ResultService<TResult>
        (
            statusCode: (int)HttpStatusCode.NoContent,
            success: true,
            data: data,
            message: message
        );
    }


}
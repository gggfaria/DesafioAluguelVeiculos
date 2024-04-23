using System.Text.Json.Serialization;
using DesafioBackEnd.Domain.Entities;

namespace DesafioBackEnd.Service.Response;

public class ResultService
{
    #region Ctor

    public ResultService(string message, int statusCode, bool success = false,
        ICollection<InvalidDataResult> errors = null)
    {
        Message = message;
        StatusCode = statusCode;
        Success = success;
        HasFailed = !success;
        Errors = errors;
    }

    #endregion

    #region Props

    [JsonPropertyName("message")] 
    public string Message { get; protected set; }

    [JsonPropertyName("statusCode")] 
    public int StatusCode { get; protected set; }

    [JsonPropertyName("success")] 
    public bool Success { get; protected set; }

    [JsonPropertyName("failure")] 
    public bool HasFailed { get; protected set; }

    [JsonPropertyName("errors")] 
    public ICollection<InvalidDataResult> Errors { get; protected set; }

    #endregion
}

public class ResultService<TDataReturn> : ResultService where TDataReturn : class
{
    public ResultService(TDataReturn data, string message, int statusCode, bool success = false, ICollection<InvalidDataResult> errors = null) 
        : base(message, statusCode, success, errors)
    {
        Data = data;
    }

    [JsonPropertyName("data")] public TDataReturn Data { get; private set; }

}


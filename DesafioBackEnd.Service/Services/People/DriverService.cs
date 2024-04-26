using AutoMapper;
using DesafioBackEnd.Domain.Entities;
using DesafioBackEnd.Domain.Entities.People;
using DesafioBackEnd.Domain.Repositories;
using DesafioBackEnd.Service.DTOs.People;
using DesafioBackEnd.Service.Interfaces.People;
using DesafioBackEnd.Service.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DesafioBackEnd.Service.Services.People;

public class DriverService : AuthService, IDriverService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<DriverService> _logger;

    public DriverService(IUnitOfWork unitOfWork, IMapper mapper, InjectionStrings tokenInjection,
        IHttpContextAccessor httpContextAccessor, ILogger<DriverService> logger)
        : base(tokenInjection, unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }


    public async Task<ResultService> CreateDriver(CreateDriverDto dto)
    {
        var driver = _mapper.Map<Driver>(dto);
        if (!driver.IsValid())
            return ResultServiceFactory.BadRequest(driver.GetInvalidData(), "Invalid data");

        if (await _unitOfWork.Driver.EntityExists(p => p.UserName == driver.UserName))
            return ResultServiceFactory.BadRequest("Username already in use");

        await _unitOfWork.Driver.AddAsync(driver);
        var result = await _unitOfWork.CommitAsync();

        if (!result)
        {
            _logger.LogError("Error commit update driver. Object driver {@driver}", driver);
            return ResultServiceFactory.InternalServerError("Created has failed");
        }

        var returnViewDriverDto = _mapper.Map<ViewDriverDto>(driver);
        returnViewDriverDto.TokenJwt = await CreateToken(driver);

        return ResultServiceFactory<ViewDriverDto>.Created(returnViewDriverDto);
    }

    public async Task<ResultService> UploadImage(IFormFile cnhImage)
    {
        var userId = GetUserIdByTokenAuth();
        var driver = await _unitOfWork.Driver.GetAsync(userId);

        if (driver is null)
            return ResultServiceFactory.Unauthorized("No driver found");

        DeleteFile(driver);
        
        driver.SetImageInfo(GetPathFileNameImage(driver), cnhImage.ContentType, cnhImage.Length);

        if (!driver.IsValid())
            return ResultServiceFactory.BadRequest(driver.GetInvalidData(), "Invalid data");

        var taskSaveFile = SaveFile(driver, cnhImage);
        
        _unitOfWork.Driver.Update(driver);
        var result = await _unitOfWork.CommitAsync();

        if (!result)
        {
            _logger.LogError("Error commit update driver. Object driver {@driver}", driver);
            return ResultServiceFactory.InternalServerError("Update has failed");
        }
        
        await taskSaveFile;
        
        return ResultServiceFactory.NoContent();
    }

    private Guid GetUserIdByTokenAuth()
    {
        var user = _httpContextAccessor.HttpContext!.User;
        var userId = user.FindFirst("Id")!.Value;
        return new Guid(userId);
    }

    private static async Task SaveFile(Driver driver, IFormFile cnhImg)
    {
        await using (var stream = new FileStream(driver.CnhImage, FileMode.Create))
        {
            await cnhImg.CopyToAsync(stream);
        }
    }

    private static void DeleteFile(Driver driver)
    {
        if (string.IsNullOrEmpty(driver.CnhImage))
            return;
        
        if (File.Exists(driver.CnhImage))
        {
            File.Delete(driver.CnhImage);
        }
    }

    private static string GetPathFileNameImage(Driver driver)
    {
        var filePath = "FileCnh";
        DateTimeOffset now = DateTimeOffset.Now;
        long unixTimestamp = now.ToUnixTimeSeconds();
        
        var newPathFileName = Path.Combine(filePath, $"{driver.Id}-{unixTimestamp}");
        return newPathFileName;
        
    }
}
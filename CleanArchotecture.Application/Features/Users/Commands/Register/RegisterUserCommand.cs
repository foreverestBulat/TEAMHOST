using AutoMapper;
using MediatR;


//using Microsoft.AspNetCore.Cryptography.KeyDerivation;
//using System.Security.Cryptography;
////using System.Web.Helpers;

//using WebTeamHost.Domain.Entities;
////using System.Numerics;
using WebTeamHost.Application.Interfaces.Repositories;
//using WebTeamHost.Shared;
using WebTeamHost.Application.Common.Mappings;
using WebTeamHost.Shared.Interfaces;
using Microsoft.AspNetCore.Identity;
using WebTeamHost.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace WebTeamHost.Application.Features.Users.Commands.Register;

public class RegisterUserCommand : IRequest<IResult<int>>, IMapFrom<IdentityUser>
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public static bool Send(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        //var user = new IdentityUser
        //{
        //    UserName = command.Email,
        //    Email = command.Email
        //};
        //var result = await userManager.CreateAsync(user, model.Password);
        return false;
    }
}

//public class RegistUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<int>>
//{

//}

//public class PostRegisterCommand : PostRegisterRequest, IRequest<PostRegisterResponse>
//{
//    /// <summary>
//    /// Конструктор
//    /// </summary>
//    /// <param name="request">Запрос</param>
//    public PostRegisterCommand(PostRegisterRequest request)
//        : base(request)
//    {
//    }
//}

//public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<int>>
//{
//    //public async Task<bool> Execute(ApplicationUserManager userManager)
//    //{
//    //    var user = new ApplicationUser { UserName = Username, Email = Username };
//    //    var result = await userManager.CreateAsync(user, Password);

//    //    if (result.Succeeded)
//    //    {
//    //        // пользователь успешно создан
//    //        return true;
//    //    }

//    //    // обработка ошибок при создании пользователя
//    //    return false;
//    //}

//    private readonly IUnitOfWork _unitOfWork;
//    private readonly IMapper _mapper;
//    //private readonly UserManager<IdentityUser> _userManager;
//    //private readonly SignInManager<IdentityUser> _signInManager;

//    //UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager
//    public RegisterUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
//    {
//        _unitOfWork = unitOfWork;
//        _mapper = mapper;
//        //_userManager = userManager;
//        //_signInManager = signInManager;
//    }

//    public async Task<Result<int>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
//    {
//        //byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
//        //PasswordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
//        //    password: command.Password!,
//        //    salt: salt,
//        //    prf: KeyDerivationPrf.HMACSHA256,
//        //    iterationCount: 100000,
//        //    numBytesRequested: 256 / 8
//        //))

//        return await Result<int>.SuccessAsync(0, "Player Created.");
//        //return new Result<int>();

//        //IdentityUser user = new User
//        //{
//        //    Email = command.Email,
//        //    UserName = command.Username,
//        //    EmailConfirmed = false,
//        //    PhoneNumberConfirmed = false,
//        //    TwoFactorEnabled = false,
//        //    LockoutEnabled = false,
//        //    AccessFailedCount = 0,
//        //};

//        //var result = await _userManager.CreateAsync(user, command.Password);

//        //foreach (var error in result.Errors)
//        //{
//        //    Console.WriteLine(error.Description);
//        //}
//        //Console.WriteLine("HANDLE");
//        //Console.WriteLine(command.Email);
//        //Console.WriteLine(command.Username);
//        //Console.WriteLine(command.Password);
//        //if (result.Succeeded)
//        //{
//        //    Console.WriteLine("REGISTER TRUE");
//        //    return new Result<int> { Succeeded = true };  
//        //}
//        //Console.WriteLine("REGISTER FALSE");
//        //return new Result<int> { Succeeded = false };
//        //return await _userManager.CreateAsync(user, command.Password);
//        //return await Result<int>.SuccessAsync(user.Id, "Player Created.");
//        //var user = new User
//        //{
//        //    UserName = request.Username,
//        //    Email = request.Email,
//        //    UserInfo = new UserInfo
//        //    {
//        //        FirstName = "Тимерхан",
//        //        LastName = "Мухутдинов",
//        //        Patronimic = "Аглямович",
//        //        Country = new Country
//        //        {
//        //            Name = "Неизвестно"
//        //        },
//        //    }
//        //};

//        //var result = await _userManager
//        //    .CreateAsync(user, request.Password);

//        //if (!result.Succeeded)
//        //    return new PostRegisterResponse
//        //    {
//        //        IsSucceed = false,
//        //        Errors = result.Errors
//        //            .Select(x => x.Description)
//        //            .ToList(),
//        //    };

//        //await _signInManager.SignInAsync(user, false);

//        //return new PostRegisterResponse
//        //{
//        //    IsSucceed = true,
//        //    Errors = null,
//        //};
//        //if (command is null)
//        //    throw new ArgumentNullException(nameof(command));
//        //if (string.IsNullOrEmpty(command.Username))
//        //    throw new ApplicationException("Username обязателен");

//        //if (string.IsNullOrEmpty(command.Password))
//        //    throw new ApplicationException("Password обязателен");

//        //if (string.IsNullOrWhiteSpace(command.RepeatPassword))
//        //    throw new ApplicationException("RepeatPassword обязателен");

//        //byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
//        //Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");
//        //var user = new User()
//        //{
//        //    UserName = command.Username,
//        //    PasswordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
//        //        password: command.Password!,
//        //        salt: salt,
//        //        prf: KeyDerivationPrf.HMACSHA256,
//        //        iterationCount: 100000,
//        //        numBytesRequested: 256 / 8
//        //    ))
//        //};
//        //await _unitOfWork.Repository<User>().AddAsync(user);
//        //user.AddDomainEvent(new UserRegisteredEvent(user));

//        //await _unitOfWork.Save(cancellationToken);

//        //return await Result<int>.SuccessAsync(user.Id, "Player Created.");
//    }
//}


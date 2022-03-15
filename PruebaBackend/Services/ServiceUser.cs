using Microsoft.Extensions.Configuration;
using PruebaBackend.Helper;
using PruebaBackend.Helper.Interfaces;
using PruebaBackend.Mapper.Interface;
using PruebaBackend.Models.Dtos;
using PruebaBackend.Models.Response;
using PruebaBackend.Repositories.Interfaces;
using PruebaBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaBackend.Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityMapper _mapper;
        private readonly IJwtHelper _jwtHelper;
        public ServiceUser(IUnitOfWork unitOfWork, IJwtHelper jwtHelper, IEntityMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
        }
        public async Task<Result> Insert(UserDtoForRegister dto)

        {
            var errorList = new List<string>();
            var user = _mapper.UserDtoForRegisterToUser(dto);

            try
            {
                // verifico que no exista Email en sistema
                var existUserEmail = await _unitOfWork.UserRepository.FindByConditionAsync(x => x.Email == user.Email);
                var existUserName = await _unitOfWork.UserRepository.FindByConditionAsync(x => x.UserName == user.UserName);

                if (existUserEmail != null && existUserEmail.Count > 0)
                    return Result.FailureResult("Email ingresado ya posee usuario en sistema.");
                if( existUserName != null && existUserName.Count > 0)
                    return Result.FailureResult("Nombre de Usuario está en uso. Por favor ingrese otro.");

                user.Password = EncryptHelper.GetSHA256(user.Password);

                await this._unitOfWork.UserRepository.Create(user);
                await this._unitOfWork.SaveChangesAsync();

                var userDisplay = _mapper.UserToUserDtoDisplay(user);
                userDisplay.Token = _jwtHelper.GenerateJwtToken(user);

                var result = Result<UserDtoDisplay>.SuccessResult(userDisplay);
                result.ErrorList = errorList; // adjunto lista de posibles errores a la respuesta


                return result;
            }
            catch (Exception e)
            {
                errorList.Add(e.Message);
                return Result.ErrorResult(errorList);
            }
        }
        public async Task<Result> LoginAsync(UserLoginDto userLoginDto)
        {
            try
            {
                var result = await this._unitOfWork.UserRepository.FindByConditionAsync(x => x.Email == userLoginDto.Email);

                if (result.Count > 0)
                {
                    var currentUser = result.FirstOrDefault();
                    if (currentUser != null)
                    {
                        var resultPassword = EncryptHelper.Verify(userLoginDto.Password, currentUser.Password);
                        if (resultPassword)
                        {
                            var userDisplay = _mapper.UserToUserDtoDisplay(currentUser);
                            userDisplay.Token = _jwtHelper.GenerateJwtToken(currentUser);

                            return Result<UserDtoDisplay>.SuccessResult(userDisplay);
                        }
                    }
                }

                return Result.FailureResult("No se pudo iniciar sesion, Email o Contrasena invalidos");
            }
            catch (Exception e)
            {
                return Result.ErrorResult(new List<string> { e.Message });
            }
        }
    }
}

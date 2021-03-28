using ReadingIsGood.Domain.Models;
using ReadingIsGood.Domain.Repositories;
using ReadingIsGood.Domain.ResponseModels;
using ReadingIsGood.Domain.Services;
using System;

namespace ReadingIsGood.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public UserResponse AddUser(User user)
        {
            try
            {
                userRepository.AddUser(user);
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse(ex.Message);
            }
        }

        public void SaveToken(int userId, string token)
        {
            try
            {
                userRepository.SaveToken(userId, token);
            }
            catch (Exception ex)
            {
                //Logging
            }
        }
        public UserResponse FindEmailAndPassword(string mail, string password)
        {
            try
            {
                User user = userRepository.FindByEmailandPassword(mail, password);

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse(ex.Message);
            }
        }

        public UserResponse FindById(int userId)
        {
            try
            {
                User user = userRepository.FindById(userId);

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse(ex.Message);
            }
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper) 
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public List<UserViewModel> Get()
        {
            List<UserViewModel> _usersViewModel = new List<UserViewModel>();

            IEnumerable<User> _users = this.userRepository.GetAll();

            _usersViewModel = mapper.Map<List<UserViewModel>>(_users);

            //foreach (var item in _users)
            //    _usersViewModel.Add(_usersViewModel.Add(new UserViewModel { Id = item.Id, Email = item.Email, Name = item.Name }););


            return _usersViewModel;
        }

        public bool Post(UserViewModel userViewModel)
        {
            //User _user = new User
            //{
            //    Id = System.Guid.NewGuid(),
            //    Email = userViewModel.Email,
            //    Name = userViewModel.Name
            //};

            User _user = mapper.Map<User>(userViewModel);

            this.userRepository.Create(_user);

            return true;
        }

        public UserViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("User id is not valid");

            User _user = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted);

            if (_user == null)
                throw new System.Exception("User not found");

            return mapper.Map<UserViewModel>(_user);
        }

        public bool Put(UserViewModel userViewModel)
        {
            User _user = this.userRepository.Find(x => x.Id == userViewModel.Id && !x.IsDeleted);
            
            if (_user == null)
                throw new System.Exception("User not found");

            _user = mapper.Map<User>(userViewModel);

            this.userRepository.Update(_user);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("User id is not valid");

            User _user = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted);

            if (_user == null)
                throw new System.Exception("User not found");
                        
            return this.userRepository.Delete(_user);
        }
    }
}

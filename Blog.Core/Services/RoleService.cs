using AutoMapper;
using Blog.Core.Domain.RepositoryInterfaces;
using Blog.Core.IServices;
using Blog.Core.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{

    
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddRole(string roleName)
        {
            return await _roleRepository.AddRole(roleName);
        }

        public async Task<bool> AddUserToRole(string userId, string roleName)
        {
            return await _roleRepository.AddUserToRole(userId, roleName);
        }

        public async Task<bool> DeleteRole(string roleName)
        {
            return await _roleRepository.DeleteRole(roleName);
        }

        public List<GetAllRolesDto> GetAllRoles()
        {
            var result = _roleRepository.GetAllRoles();

            // map from domain to dto
            var mappedResult = _mapper.Map<List<GetAllRolesDto>>(result);

            return mappedResult;
        }

        public async Task<bool> UpdateRole(string roleName, string updateName)
        {
            return await _roleRepository.UpdateRole(roleName, updateName);
        }
    }
}

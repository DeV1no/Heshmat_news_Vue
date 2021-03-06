using System.Collections.Generic;
using dadachMovie.DTOs.Role;
using dadachMovie.Services.Contracts;
using HeshmastNews.DTOs.Role;
using HeshmastNews.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HeshmastNews.Controllers
{
    [ApiController]
    [Route("api/Role")]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public List<RoleDTO> GetAllRoles()
        {
            return _roleService.GetAllRoles();
        }

        [HttpGet("{roleId:int}")]
        public RoleDTO GetRoleById(int roleId)
        {
            return _roleService.GetRole(roleId);
        }

        [HttpPost]
        public int AddRole([FromBody] RoleCreateDTO model)
        {
            return _roleService.AddRole(model);
        }

        [HttpPut]
        public int UpdateRole([FromBody] RoleUpdateDTO model)
        {
            return _roleService.UpdateRole(model);
        }

        [HttpDelete("{roleId:int}")]
        public bool RemoveRole(int roleId)
        {
            return _roleService.RemoveRole(roleId);
        }

        [HttpGet("permissions")]
        public List<PermissionViewModelDTO> GetPermissionsList()
        {
            return _roleService.GetPermissionList();
        }

        [HttpGet("parentPermissions")]
        public List<PermissionViewModelDTO> GetParentPermissionsList()
        {
            return _roleService.GetParentPermissionList();
        }

        [HttpGet("subPermissions")]
        public List<PermissionViewModelDTO> GetSubPermissionsList()
        {
            return _roleService.GetSubPermissionList();
        }

        [HttpPut("addPermissionToRole")]
        public bool AddPermissionToRole(AddPermissionToRoleDTO model)
        {
            return _roleService.AddPermissionToRole(model);
        }

        [HttpGet("save/{roleId:int}")]
        public RoleSaveDTO GetRoleSave(int roleId)
        {
            return _roleService.GetRoleSave(roleId);
        }
    }
}
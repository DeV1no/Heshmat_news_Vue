using System.Collections.Generic;
using HeshmastNews.DTOs.Role;

namespace dadachMovie.Services.Contracts
{
    public interface IRoleService
    {
        List<RoleDTO> GetAllRoles();
        RoleDTO GetRole(int roleID);
        int AddRole(RoleDTO model);
        int UpdateRole(RoleDTO model);
        bool RemoveRole(int RoleId);
        List<PermissionViewModelDTO> GetPermissionList();
        List<PermissionViewModelDTO> GetParentPermissionList();
        List<PermissionViewModelDTO> GetSubPermissionList();
       
    }
}
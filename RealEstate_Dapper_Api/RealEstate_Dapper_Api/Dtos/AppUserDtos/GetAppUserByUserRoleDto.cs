namespace RealEstate_Dapper_Api.Dtos.AppUserDtos
{
    public class GetAppUserByUserRoleDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int UserRole { get; set; }
        public string RoleName { get; set; }
    }
}

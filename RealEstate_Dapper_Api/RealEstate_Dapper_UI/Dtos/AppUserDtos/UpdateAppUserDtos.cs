﻿namespace RealEstate_Dapper_UI.Dtos.AppUserDtos
{
    public class UpdateAppUserDtos
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int UserRole { get; set; }
        public string PhoneNumber { get; set; }

    }
}

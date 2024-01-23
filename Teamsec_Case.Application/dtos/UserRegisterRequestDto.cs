﻿using System.ComponentModel.DataAnnotations;

namespace Teamsec_Case.Application.dtos
{
    public class UserRegisterRequestDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        public string Email { get; set; }
    }
}

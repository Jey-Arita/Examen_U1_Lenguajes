﻿namespace Examen_U1_Lenguajes.Dtos.Auth
{
    public class LoginResponseDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpiration { get; set; }
    }
}


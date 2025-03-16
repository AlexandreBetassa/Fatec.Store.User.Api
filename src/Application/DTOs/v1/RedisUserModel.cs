﻿namespace Autenticacao.Jwt.Application.DTOs.v1
{
    public class RedisUserModel
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public RedisUserModel(string token, string name, string email, string role)
        {
            Token = token;
            Name = name;
            Email = email;
            Role = role;
        }
    }
}

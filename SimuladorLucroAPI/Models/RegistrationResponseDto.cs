﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimuladorLucroAPI.Models
{
    public class RegistrationResponseDto
    {
        public bool IsSuccesfulRegistration { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}

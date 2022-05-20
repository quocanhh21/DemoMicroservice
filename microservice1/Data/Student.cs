﻿using System.ComponentModel.DataAnnotations;

namespace microservice1.Data
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int IdClass { get; set; }
    }
}

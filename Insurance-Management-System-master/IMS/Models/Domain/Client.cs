﻿namespace IMS.Models.Domain
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        // Navigation property for associated Insurances
        public ICollection<Insurance> Insurances { get; set; }
    }
}

﻿namespace Domain.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Operation> Operations { get; set; }
    }
}
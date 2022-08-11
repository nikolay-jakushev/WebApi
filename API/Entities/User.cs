using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class User
    {
        public Guid ID { get; set; }
        public int CountSignIn { get; set; }
    }
}
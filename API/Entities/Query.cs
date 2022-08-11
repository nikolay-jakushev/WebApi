using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Query
    {
        public Guid QueryID { get; set; }
        public Guid UserID { get; set; }
        public double Percent  { get; set; }
        public int CountSignIn  { get; set; }
    }
}
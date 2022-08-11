using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class ReportInfo
    {
        public Guid Query { get; set; }
        public int Percent { get; set; }
        public User Result { get; set; }
    }
}
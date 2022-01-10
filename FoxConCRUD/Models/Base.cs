using System;

namespace FoxConCRUD.Models
{
    public class Base
    {
        public int id { get; set; }
        public string active { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? modifield_at { get; set; }
    }
}
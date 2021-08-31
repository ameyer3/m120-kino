using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m120.projekt.kino.Model
{
    public class Category
    {
        public Category() { }
        public Category(int id, string description)
        {
            CategoryId = id;
            Description = description;
        }
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}

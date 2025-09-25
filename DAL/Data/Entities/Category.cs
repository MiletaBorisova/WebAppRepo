using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Entities
{
    public class Category
    {
        public string? Name { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; } = null!;

    }
}

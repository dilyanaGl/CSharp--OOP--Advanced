using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration
{
    public class User
    {
        private string name;
        private HashSet<Category> categories;

        public User(string name)
        {
            this.name = name;
            this.categories = new HashSet<Category>();
        }

        public void AddCategory(Category category)
        {
            this.categories.Add(category);
        }

        public void RemoveCategory()
        {
            if (this.categories.Count == 0)
            {
                throw new InvalidOperationException("List empty");
            }
            var category = this.categories.Last();
            this.categories.Remove(category);
        }
    }
}

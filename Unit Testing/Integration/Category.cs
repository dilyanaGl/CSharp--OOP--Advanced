using System;
using System.Collections.Generic;
using System.Linq;

namespace Integration
{
    public class Category
    {
        private string name;
        private HashSet<User> users;
        private HashSet<Category> subCategories;
        private Category parentCategory;

        public Category(string name)
        {
            this.name = name;
            this.users = new HashSet<User>();
            this.subCategories = new HashSet<Category>();
            this.parentCategory = null;
        }

        public void AddCategory(Category category)
        {
            category.parentCategory = this;
            this.subCategories.Add(category);
        }

        public void RemoveCategory()
        {
            if (this.subCategories.Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }
            var category = this.subCategories.Last();
            if (!this.subCategories.Contains(category))
            {
                throw new InvalidOperationException("No such categories can be found");
            }
            if (category.users.Any())
            {
               this.users.UnionWith(category.users);
            }
            
            if (category.subCategories.Any())
            {
                foreach (var subCategory in category.subCategories)
                {
                    subCategory.parentCategory = this;
                    this.subCategories.Add(subCategory);
                }
            }

            this.subCategories.Remove(category);
        }

        public void AssignUser(User user)
        {
            this.users.Add(user);
            user.AddCategory(this);
        }
    }
}
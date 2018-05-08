using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forum.App.Contracts;
using Forum.App.Contracts.ViewModels;
using Forum.Data;
using Forum.DataModels;

namespace Forum.App.Services
{
    public class PostService : IPostService
    {
        private ForumData forumData;
        private IUserService userService;

        public PostService(ForumData forumData, IUserService userService)
        {
            this.forumData = forumData;
            this.userService = userService;
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            IEnumerable<ICategoryInfoViewModel> categories =
                this.forumData.Categories.Select(p => new CategoryInfoViewModel(p.Id, p.Name, p.Posts.Count));

            return categories;
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            var postInfo = this.forumData.Posts.Where(p => p.Id == categoryId)
                .Select(p => new PostInfoViewModel(p.Id, p.Title, p.Replies.Count));

            return postInfo;
        }

        public string GetCategoryName(int categoryId)
        {
            string categoryName = this.forumData.Categories.Find(c => c.Id == categoryId)?.Name;
            if (categoryName == null)
            {
                throw new ArgumentException($"Category with id {categoryId} not found!");
            }

            return categoryName;
        }

        public IEnumerable<IPostInfoViewModel> GetPostViewModels(int categoryId)
        {
            var post = this.forumData.Posts.Where(p => p.CategoryId == categoryId)
                .Select(p => new PostInfoViewModel(p.Id, p.Title, p.Replies.Count));

            if (post == null)
            {
                throw new ArgumentException($"Category {categoryId} not found");
            }


            return post;
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            var post = this.forumData.Posts.FirstOrDefault(p => p.Id == postId);
            if (post == null)
            {
                throw new ArgumentException("Invalid post");
            }

            var userId = this.userService.GetUserName(post.AuthorId);

            IPostViewModel info = new PostViewModel(post.Title, userId, post.Content, this.GetPostReplies(postId));

            return info;

        }

        private IEnumerable<IReplyViewModel> GetPostReplies(int postId)
        {
            IEnumerable<IReplyViewModel> replies = this.forumData.Replies
                .Where(p => p.PostId == postId)
                .Select(r => new ReplyViewModel(this.userService.GetUserName(r.AuthorId), r.Content));

            return replies;
        }

        public int AddPost(int userId, string postTitle, string postCategory, string postContent)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(postCategory);
            bool emptyTitle = string.IsNullOrWhiteSpace(postTitle);
            bool emptyContent = string.IsNullOrWhiteSpace(postContent);

            if (emptyCategory || emptyContent || emptyTitle)
            {
                throw new ArgumentException("All fields must be filled");
            }

            int postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;

            User autor = this.userService.GetUserById(userId);
            var category = this.EnsureCategory(postCategory);
            int categoryId = category.Id;
            Post post = new Post(postId, postTitle, postContent, categoryId, userId, new List<int>());



            forumData.Posts.Add(post);
            autor.Posts.Add(post.Id);
            category.Posts.Add(post.Id);
            forumData.SaveChanges();

            return post.Id;


        }

        private Category EnsureCategory(string postCategory)
        {

            var category = this.forumData.Categories.FirstOrDefault(p => p.Name == postCategory);
            if (category == null)
            {
                int categoryId = this.forumData.Categories.LastOrDefault()?.Id + 1 ?? 1;
                category = new Category(categoryId, postCategory, new List<int>());
                this.forumData.Categories.Add(category);
            }

            return category;

        }

        public void AddReplyToPost(int postId, string replyContent, int userId)
        {
           var post = this.forumData.Posts.Find(p => p.Id == postId);
            
           var author = this.userService.GetUserById(userId);

            int replyId = this.forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;
            var reply = new Reply(replyId, replyContent, userId, postId);

            this.forumData.Replies.Add(reply);
            post.Replies.Add(replyId);
            this.forumData.SaveChanges();



        }

     
    }
}


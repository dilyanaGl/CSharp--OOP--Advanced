using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.Contracts.ViewModels
{
   public class PostViewModel : ContentViewModel, IPostViewModel
    {

        public PostViewModel(string title, string author, string content, IEnumerable<IReplyViewModel> reply) : base(content)
        {
            this.Title = title;
            this.Author = author;
            this.Content = content;
            this.Replies = reply.ToArray();

        }



        public string Title { get; }
        public string Author { get; }
        public string Content { get; }
        public IReplyViewModel[] Replies { get; }

    }
}

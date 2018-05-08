using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.Contracts.ViewModels
{
    public class ReplyViewModel : ContentViewModel, IReplyViewModel
    {
        public ReplyViewModel(/*string title,*/ string author, string content/*, IEnumerable<IReplyViewModel> replies*/) : base(content)
        {
            //this.Title = title;
            this.Author = author;
            //this.replies = replies.ToArray();
        }

        public string Author { get; }

        public string Title { get; set; }

        public IReplyViewModel[] replies { get; set; }
    }
}

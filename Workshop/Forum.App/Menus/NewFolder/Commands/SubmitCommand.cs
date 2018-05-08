using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.Menus.NewFolder.Commands
{
    public class SubmitCommand : ICommand
    {
        ISession session;
        private IPostService postService;

        public SubmitCommand(ISession session, IPostService postService)
        {
            this.session = session;
            this.postService = postService;
        }

        public IMenu Execute(params string[] args)
        {
            string replyText = args[0];

            if (string.IsNullOrWhiteSpace(replyText))
            {
                throw new ArgumentException("Text is empty");
            }

            int id = int.Parse(args[1]);
            int authorId = this.session.UserId;

            this.postService.AddReplyToPost(id, replyText, authorId);

            return this.session.Back();



        }
    }
}




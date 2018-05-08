﻿using System;

namespace Forum.App.Menus
{
	using Models;
    using Contracts;

    public class LogInMenu : Menu
    {
		private const string errorMessage = "Invalid username or password!";

		private bool error;

		private ILabelFactory labelFactory;
        private ICommandFactory commandFactory;
        private IForumReader forumReader;
        private IUserService userService;
        private ISession session;


        public LogInMenu(ILabelFactory labelFactory, ICommandFactory commandFactory, IUserService userService, ISession session, IForumReader forumReader)
        {
            this.labelFactory = labelFactory;
            this.commandFactory = commandFactory;
            this.userService = userService;
            this.session = session;
            this.forumReader = forumReader;

            this.Open();
        }

        //TODO: Inject Dependencies

        private string UsernameInput => this.Buttons[0].Text.TrimStart();

		private string PasswordInput => this.Buttons[1].Text.TrimStart();

		protected override void InitializeStaticLabels(Position consoleCenter)
        {
            string[] labelContents = new string[] { errorMessage, "Name:", "Password:" };

            Position[] labelPositions = new Position[]
            {
				new Position(consoleCenter.Left - errorMessage.Length / 2, consoleCenter.Top - 13),   // Error: 
                new Position(consoleCenter.Left - 16, consoleCenter.Top - 10),   // Name:
                new Position(consoleCenter.Left - 16, consoleCenter.Top - 8),    // Password:
            };

            this.Labels = new ILabel[labelContents.Length];

            this.Labels[0] = new Label(labelContents[0], labelPositions[0], !this.error);

            for (int i = 1; i < this.Labels.Length; i++)
            {
                this.Labels[i] = new Label(labelContents[i], labelPositions[i]);
            }
        }

		protected override void InitializeButtons(Position consoleCenter)
        {
            string[] buttonContents = new string[]
            {
                " ", " ", "Log In", "Back"
            };

            Position[] buttonPositions = new Position[]
            {
                new Position(consoleCenter.Left - 10, consoleCenter.Top - 10), // Name
                new Position(consoleCenter.Left - 6, consoleCenter.Top - 8),   // Password
                new Position(consoleCenter.Left + 16, consoleCenter.Top),      // Log In
                new Position(consoleCenter.Left + 16, consoleCenter.Top + 1)   // Back
            };

            this.Buttons = new IButton[buttonContents.Length];

            for (int i = 0; i < this.Buttons.Length; i++)
            {
				string buttonContent = buttonContents[i];
				bool isField = string.IsNullOrWhiteSpace(buttonContent);
				this.Buttons[i] = this.labelFactory.CreateButton(buttonContent, buttonPositions[i], false, isField);
            }
        }

		public override IMenu ExecuteCommand()
		{
		    if (this.CurrentOption.IsField)
		    {
		        string fieldInput =
		            " " + this.forumReader.ReadLine(this.CurrentOption.Position.Left + 1, this.CurrentOption.Position.Top);

		        this.Buttons[this.currentIndex] = this.labelFactory.CreateButton(fieldInput, this.CurrentOption.Position,
		           false, true);

		        return this;
		    }

            try
            {
                string commandName = string.Join("", this.CurrentOption.Text.Split());
                ICommand command = this.commandFactory.CreateCommand(commandName);
                IMenu view = command.Execute(this.UsernameInput, this.PasswordInput);
                return view;
            }
            catch (Exception e)
            {
                this.error = true;
                 //this.errorMessage = e.Message;
                this.Open();
                return this;
            }
        }
	}
}

using IdeaHub.Models;
using IdeaHub.Presenters.Base;
using IdeaHub.View.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaHub.Forms
{
    public partial class CreateSuggestionForm : Form, ICreateSuggestionView
    {
        public event EventHandler CreateSuggestionAttempted;

        public CreateSuggestionForm(IServiceProvider serviceProvider, Guid productId)
        {
            InitializeComponent();

            var createSuggestionPresenter = new CreateSuggestionPresenter(this, serviceProvider, productId);

            btnSubmit.Click += (s, e) => CreateSuggestionAttempted?.Invoke(this, EventArgs.Empty);
        }
        public string SuggestionTitle => txtTitle.Text;
        public string SuggestionDescription => txtDescription.Text;

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void CloseView()
        {
            this.Close();
        }
    }
}

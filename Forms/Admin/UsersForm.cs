﻿using IdeaHub.DTOs.User;
using IdeaHub.Presenters.Admin;
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

namespace IdeaHub.Forms.Admin
{
    public partial class UsersForm : Form, IUsersView
    {
        private readonly IServiceProvider _serviceProvider;

        public event EventHandler LoadUsers;
        public event EventHandler LogoutClicked;
        public event EventHandler NewUserClicked;
        public event EventHandler EditUserClicked;

        public UsersForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            var usersPresenter = new UsersPresenter(this, _serviceProvider);

            this.btnEditUser.Click += (sender, e) => EditUserClicked?.Invoke(this, EventArgs.Empty);
            this.btnNewUser.Click += (sender, e) => NewUserClicked?.Invoke(this, EventArgs.Empty);
            this.Load += (sender, e) => LoadUsers?.Invoke(this, EventArgs.Empty);
            this.btnLogout.Click += (sender, e) => LogoutClicked?.Invoke(this, EventArgs.Empty);
            this.dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;
        }


        public List<UserViewDto> UsersDataSource 
        {
            get 
            {
                return dgvUsers.DataSource as List<UserViewDto>;
            }
            set 
            {
                dgvUsers.DataSource = value;
                if (value != null && value.Any())
                {
                    ConfigureGridViewColumns();
                }
            }

        }

        public string SelectedUserName 
        {
            set => txtSelectedUser.Text = value;
        }

        private void ConfigureGridViewColumns()
        {
            if (dgvUsers.Columns.Count == 0) return;
            dgvUsers.ReadOnly = true;

            dgvUsers.Columns["Id"].DisplayIndex = 0;
            dgvUsers.Columns["FullName"].DisplayIndex = 1;
            dgvUsers.Columns["Username"].DisplayIndex = 2;
            dgvUsers.Columns["Email"].DisplayIndex = 3;
            dgvUsers.Columns["Role"].DisplayIndex = 4;
            dgvUsers.Columns["CreatedDate"].DisplayIndex = 5;
            dgvUsers.Columns["IsActive"].DisplayIndex = 6;

            dgvUsers.Columns["FullName"].HeaderText = "Full Name";
            dgvUsers.Columns["CreatedDate"].HeaderText = "Created Date";
            dgvUsers.Columns["IsActive"].HeaderText = "Active";


            dgvUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void ShowCreateUserForm()
        {
            var createUserForm = new CreateUserForm(_serviceProvider);
            createUserForm.ShowDialog();
        }
        public void ShowUpdateUserForm(Guid userId)
        {
            var updateUserForm = new UpdateUserForm(_serviceProvider, userId);
            updateUserForm.UserUpdated += (s, e) => LoadUsers?.Invoke(this, EventArgs.Empty);
            updateUserForm.ShowDialog();
        }


        private void DgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                var user = dgvUsers.SelectedRows[0].DataBoundItem as UserViewDto;
                if (user != null)
                {
                    SelectedUserName = user.Username;
                }
            }
        }

        public Guid GetSelectedUserId()
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                var selectedRow = dgvUsers.SelectedRows[0];
                var user = selectedRow.DataBoundItem as UserViewDto;
                if (user != null)
                {
                    return user.Id;
                }
            }
            return Guid.Empty;
        }
        public void CloseView()
        {
            this.Close();
        }
    }
}

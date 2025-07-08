using IdeaHub.DTOs.Product;
using IdeaHub.DTOs.Suggestion;
using IdeaHub.DTOs.User;
using IdeaHub.Enums;
using IdeaHub.Presenters.Base;
using IdeaHub.View.Interfaces;
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
    public partial class SuggestionsForm : Form, ISuggestionsView
    {
        private readonly IServiceProvider _serviceProvider;

        public DateTime? FilterStartDate => dtpStartDate.Checked ? (DateTime?)dtpStartDate.Value : null;
        public DateTime? FilterEndDate => dtpEndDate.Checked ? (DateTime?)dtpEndDate.Value : null;
        public Guid? FilterByUserId => (Guid?)cmbUserFilter.SelectedValue == Guid.Empty ? null : (Guid?)cmbUserFilter.SelectedValue;
        public Guid? FilterByProductId => (Guid?)cmbProductFilter.SelectedValue == Guid.Empty ? null : (Guid?)cmbProductFilter.SelectedValue;
        public SuggestionStatus? FilterByStatus => cmbStatusFilter.SelectedItem as SuggestionStatus?;

        public event EventHandler LoadSuggestions;
        public event EventHandler ChangeSuggestionStatusAttempted;
        public event EventHandler SuggestionSelected;
        public event EventHandler LogoutClicked;
        public event EventHandler FilterClicked;
        public event EventHandler ClearFilterClicked;
        public event EventHandler LoggedOut;


        public SuggestionsForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;

            var suggestionsPresenter = new SuggestionsPresenter(this, _serviceProvider);
            suggestionsPresenter.LoggedOut += (s, e) => LoggedOut?.Invoke(this, EventArgs.Empty);

            this.DoubleBuffered = true;
            this.Load += MainForm_Load;
            this.dgvSuggestions.SelectionChanged += DgvSuggestions_SelectionChanged;
            this.btnUpdateStatus.Click += BtnUpdateStatus_Click;
            this.dgvSuggestions.CellClick += DgvSuggestions_CellClick;
            this.btnLogout.Click += (s, e) => LogoutClicked?.Invoke(this, EventArgs.Empty);

            btnFilter.Click += (s, e) => FilterClicked?.Invoke(this, EventArgs.Empty);
            btnClear.Click += (s, e) => ClearFilterClicked?.Invoke(this, EventArgs.Empty);

            InitializeComboBoxes();
        }
        private void InitializeComboBoxes()
        {
            var statuses = new List<object> { "All Statuses" };
            statuses.AddRange(Enum.GetValues(typeof(SuggestionStatus)).Cast<object>());
            cmbStatusFilter.DataSource = statuses;


            cmbStatus.DataSource = Enum.GetValues(typeof(SuggestionStatus))
                                    .Cast<SuggestionStatus>()
                                    .ToList();
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public List<SuggestionViewDto> SuggestionsDataSource
        {
            get
            {
                return dgvSuggestions.DataSource as List<SuggestionViewDto>;
            }
            set
            {
                dgvSuggestions.DataSource = value;
                if (value != null && value.Any())
                {
                    ConfigureGridViewColumns();
                }
            }
        }
        public string LoggedInUserMessage
        {   
            get
            {
                if (lblMainMessage != null)
                {
                    return lblMainMessage.Text;
                }
                return string.Empty;
            }
            set
            {
                if (lblMainMessage != null)
                {
                    lblMainMessage.Text = value;
                    lblMainMessage.ForeColor = Color.Black;
                    lblMainMessage.Visible = true;
                }
            }
        }

        private void ConfigureGridViewColumns()
        {
            if (dgvSuggestions.Columns.Count == 0) return;
            dgvSuggestions.ReadOnly = true;

            dgvSuggestions.Columns["UserId"].Visible = false;

            dgvSuggestions.Columns["SubmittedBy"].HeaderText = "User";
            dgvSuggestions.Columns["ProductName"].HeaderText = "Product Name";
            dgvSuggestions.Columns["SubmittedDate"].HeaderText = "Submitted Date";
            dgvSuggestions.Columns["LastUpdatedDate"].HeaderText = "Last Updated";

            dgvSuggestions.Columns["Id"].DisplayIndex = 0;
            dgvSuggestions.Columns["SubmittedBy"].DisplayIndex = 1;
            dgvSuggestions.Columns["ProductName"].DisplayIndex = 2;
            dgvSuggestions.Columns["Title"].DisplayIndex = 3;
            dgvSuggestions.Columns["Description"].DisplayIndex = 4;
            dgvSuggestions.Columns["Status"].DisplayIndex = 5;
            dgvSuggestions.Columns["SubmittedDate"].DisplayIndex = 6;
            dgvSuggestions.Columns["LastUpdatedDate"].DisplayIndex = 7;

            var titleColumn = dgvSuggestions.Columns["Title"];
            titleColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvSuggestions.Columns["Title"].MinimumWidth = 150;

            var descriptionColumn = dgvSuggestions.Columns["Description"];
            descriptionColumn.FillWeight = 200;
            dgvSuggestions.Columns["Description"].MinimumWidth = 200;


            dgvSuggestions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvSuggestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        public Guid SelectedSuggestionId
        {
            get
            {
                if (dgvSuggestions.SelectedRows.Count > 0)
                {
                    var selectedDto = dgvSuggestions.SelectedRows[0].DataBoundItem as SuggestionViewDto;
                    return selectedDto?.Id ?? Guid.Empty;
                }
                return Guid.Empty;
            }
        }

        public SuggestionStatus SelectedSuggestionCurrentStatus
        {
            get
            {
                if (dgvSuggestions.SelectedRows.Count > 0)
                {
                    var selectedDto = dgvSuggestions.SelectedRows[0].DataBoundItem as SuggestionViewDto;
                    return selectedDto?.Status ?? default(SuggestionStatus);
                }
                return default(SuggestionStatus);
            }
        }

        public SuggestionStatus NewStatusToApply
        {
            get
            {
                if (cmbStatus.SelectedItem is SuggestionStatus selectedStatus)
                {
                    return selectedStatus;
                }
                return default;
            }
        }

        public List<UserViewDto> UserFilterDataSource 
        {
            set
            {
                var placeholder = new List<UserViewDto> { new UserViewDto { Id = Guid.Empty, Username = "All Users" } };
                cmbUserFilter.DataSource = placeholder.Concat(value).ToList();
                cmbUserFilter.DisplayMember = "Username";
                cmbUserFilter.ValueMember = "Id";
            }
        }
        public List<ProductViewDto> ProductFilterDataSource 
        {
            set
            {
                var placeholder = new List<ProductViewDto> { new ProductViewDto { Id = Guid.Empty, Name = "All Products" } };
                cmbProductFilter.DataSource = placeholder.Concat(value).ToList();
                cmbProductFilter.DisplayMember = "Name";
                cmbProductFilter.ValueMember = "Id";
            }
        }

        public void SetStatusChangeControlsEnabled(bool enabled)
        {
            cmbStatus.Enabled = enabled;
            btnUpdateStatus.Enabled = enabled;
        }
        public void SetStatusChangeControlsVisibility(bool visible)
        {
            cmbStatus.Visible = visible;
            btnUpdateStatus.Visible = visible;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void RefreshSuggestions()
        {
            LoadSuggestions?.Invoke(this, EventArgs.Empty);
        }

        public void CloseView()
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSuggestions?.Invoke(this, EventArgs.Empty);
        }

        private void DgvSuggestions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSuggestions.SelectedRows.Count > 0)
            {
                var selectedDto = dgvSuggestions.SelectedRows[0].DataBoundItem as SuggestionViewDto;
                if (selectedDto != null)
                {
                    cmbStatus.SelectedItem = selectedDto.Status;
                }
            }
            SuggestionSelected?.Invoke(this, EventArgs.Empty);
        }

        private void BtnUpdateStatus_Click(object sender, EventArgs e)
        {
            ChangeSuggestionStatusAttempted?.Invoke(this, EventArgs.Empty);
        }
        private void DgvSuggestions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvSuggestions.Columns[e.ColumnIndex].Name == "Description")
            {
                var suggestion = dgvSuggestions.Rows[e.RowIndex].DataBoundItem as SuggestionViewDto;
                if (suggestion != null)
                {
                    MessageBox.Show(suggestion.Description, "Full Description");
                }
            }
        }

        public void ClearFilters()
        {
            dtpStartDate.Checked = false;
            dtpEndDate.Checked = false;
            cmbUserFilter.SelectedIndex = 0;
            cmbProductFilter.SelectedIndex = 0;
            cmbStatusFilter.SelectedIndex = 0;
        }

        public void SetFilterControlsVisibility(bool visible)
        {
            var filterControls = new Control[]
            {
                lblFilterByDate, dtpStartDate, lblFromDate, dtpEndDate, lblToDate,
                lblFilterByUser, cmbUserFilter,
                lblFilterByProduct, cmbProductFilter,
                lblFilterByStatus, cmbStatusFilter,
                btnFilter, btnClear
            };

            foreach (var control in filterControls)
            {
                control.Visible = visible;
            }
        }
    }
}

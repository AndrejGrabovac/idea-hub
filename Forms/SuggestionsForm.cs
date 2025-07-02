using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IdeaHub.DTOs.Suggestion;
using IdeaHub.Enums;
using IdeaHub.View.Interfaces;

namespace IdeaHub.Forms
{
    public partial class SuggestionsForm : Form, IMainView
    {
        private bool _isFirstLoad = true;

        public event EventHandler LoadSuggestions;
        public event EventHandler ChangeSuggestionStatusAttempted;
        public event EventHandler SuggestionSelected;
        public event EventHandler LogoutClicked;

        public Form MainFormInstance => throw new NotImplementedException();


        public SuggestionsForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Load += MainForm_Load;
            this.dgvSuggestions.SelectionChanged += DgvSuggestions_SelectionChanged;
            this.btnUpdateStatus.Click += BtnUpdateStatus_Click;
            this.dgvSuggestions.CellClick += DgvSuggestions_CellClick;
            this.btnLogout.Click += (sender, e) => LogoutClicked?.Invoke(this, EventArgs.Empty);


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

            var descriptionColumn = dgvSuggestions.Columns["Description"];
            descriptionColumn.Width = 300;

            dgvSuggestions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            ResizeFormToGrid();
        }

        private void ResizeFormToGrid()
        {
            if (!_isFirstLoad) return;

            int totalWidth = dgvSuggestions.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            totalWidth += dgvSuggestions.RowHeadersWidth;
            totalWidth += 3;

            this.ClientSize = new Size(totalWidth, this.ClientSize.Height);

            _isFirstLoad = false;
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

                throw new InvalidOperationException("No valid status selected in ComboBox.");
            }
        }

        public void SetStatusChangeControlsEnabled(bool enabled)
        {
            cmbStatus.Enabled = enabled;
            btnUpdateStatus.Enabled = enabled;
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
    }
}

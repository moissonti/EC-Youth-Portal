using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microcharts;
using SkiaSharp;


namespace EC_Youth_Portal.ViewModel
{
    public class MyApplicationsPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ApplicationItem> _allApplications;
        private ObservableCollection<ApplicationItem> _filteredApplications;
        private string _applicationsListTitle = "My Applications";
        private Chart _applicationChart;
        private bool _isDrawerOpen;
        private double _drawerTranslationX = 400;

        // Drawer properties
        public bool IsDrawerOpen
        {
            get => _isDrawerOpen;
            set
            {
                _isDrawerOpen = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsOverlayVisible));
            }
        }

        public bool IsOverlayVisible => _isDrawerOpen;

        public double DrawerTranslationX
        {
            get => _drawerTranslationX;
            set
            {
                _drawerTranslationX = value;
                OnPropertyChanged();
            }
        }

        // Summary Stats
        public string TotalApplications => _allApplications?.Count.ToString() ?? "0";
        public string SuccessRate => CalculateSuccessRate();

        public int RepliedCount => _allApplications?.Count(a => a.Status == "Replied") ?? 0;
        public int PendingCount => _allApplications?.Count(a => a.Status == "Pending") ?? 0;
        public int ApprovedCount => _allApplications?.Count(a => a.Status == "Approved") ?? 0;
        public int RejectedCount => _allApplications?.Count(a => a.Status == "Rejected") ?? 0;

        public string RepliedPercent => CalculatePercentage(RepliedCount);
        public string PendingPercent => CalculatePercentage(PendingCount);
        public string ApprovedPercent => CalculatePercentage(ApprovedCount);
        public string RejectedPercent => CalculatePercentage(RejectedCount);

        // Insights
        public string Insight1 => $"• You have {PendingCount} applications awaiting response";
        public string Insight2 => ApprovedCount > 0
            ? $"• Your approval rate is {SuccessRate} - Keep it up!"
            : "• Keep applying to increase your chances";
        public string Insight3 => PendingCount > 0
            ? "• Follow up on pending applications"
            : "• All applications have been reviewed";

        public ObservableCollection<ApplicationItem> FilteredApplications
        {
            get => _filteredApplications;
            set
            {
                _filteredApplications = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ApplicationItem> AllApplications => _allApplications;

        public string ApplicationsListTitle
        {
            get => _applicationsListTitle;
            set
            {
                _applicationsListTitle = value;
                OnPropertyChanged();
            }
        }

        public Chart ApplicationChart
        {
            get => _applicationChart;
            set
            {
                _applicationChart = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public ICommand FilterByStatusCommand { get; }
        public ICommand ViewApplicationDetailCommand { get; }
        public ICommand FilterCommand { get; }
        public ICommand OpenDrawerCommand { get; }
        public ICommand CloseDrawerCommand { get; }

        public MyApplicationsPageViewModel()
        {
            FilterByStatusCommand = new Command<string>(OnFilterByStatus);
            ViewApplicationDetailCommand = new Command<ApplicationItem>(OnViewApplicationDetail);
            FilterCommand = new Command(OnFilter);
            OpenDrawerCommand = new Command(OnOpenDrawer);
            CloseDrawerCommand = new Command(OnCloseDrawer);

            LoadMockData();
            CreateChart();
        }

        private void LoadMockData()
        {
            _allApplications = new ObservableCollection<ApplicationItem>
            {
                new ApplicationItem
                {
                    OpportunityTitle = "Software Developer Intern",
                    Company = "Tech Solutions Ltd",
                    Status = "Approved",
                    AppliedDate = "2d ago"
                },
                new ApplicationItem
                {
                    OpportunityTitle = "Marketing Assistant",
                    Company = "Creative Agency",
                    Status = "Replied",
                    AppliedDate = "5d ago"
                },
                new ApplicationItem
                {
                    OpportunityTitle = "Data Analyst Position",
                    Company = "Finance Corp",
                    Status = "Rejected",
                    AppliedDate = "1w ago"
                },
                new ApplicationItem
                {
                    OpportunityTitle = "Junior Web Developer",
                    Company = "StartUp Inc",
                    Status = "Pending",
                    AppliedDate = "1w ago"
                },
                new ApplicationItem
                {
                    OpportunityTitle = "Engineering Bursary 2026",
                    Company = "National Bursary Fund",
                    Status = "Approved",
                    AppliedDate = "2w ago"
                },
                new ApplicationItem
                {
                    OpportunityTitle = "Graphic Designer",
                    Company = "Design Studio",
                    Status = "Replied",
                    AppliedDate = "3w ago"
                },
                new ApplicationItem
                {
                    OpportunityTitle = "Customer Service Rep",
                    Company = "Retail Solutions",
                    Status = "Pending",
                    AppliedDate = "3w ago"
                },
                new ApplicationItem
                {
                    OpportunityTitle = "IT Support Technician",
                    Company = "Tech Innovations",
                    Status = "Approved",
                    AppliedDate = "1m ago"
                },
                new ApplicationItem
                {
                    OpportunityTitle = "Business Analyst Intern",
                    Company = "Consulting Firm",
                    Status = "Pending",
                    AppliedDate = "1m ago"
                },
                new ApplicationItem
                {
                    OpportunityTitle = "Content Writer",
                    Company = "Media House",
                    Status = "Replied",
                    AppliedDate = "1m ago"
                }
            };

            FilteredApplications = new ObservableCollection<ApplicationItem>(_allApplications);
        }

        private void CreateChart()
        {
            var entries = new[]
            {
                new ChartEntry(ApprovedCount)
                {
                    Label = "Approved",
                    ValueLabel = ApprovedCount.ToString(),
                    Color = SKColor.Parse("#4CAF50")
                },
                new ChartEntry(RepliedCount)
                {
                    Label = "Replied",
                    ValueLabel = RepliedCount.ToString(),
                    Color = SKColor.Parse("#2196F3")
                },
                new ChartEntry(PendingCount)
                {
                    Label = "Pending",
                    ValueLabel = PendingCount.ToString(),
                    Color = SKColor.Parse("#FFA500")
                },
                new ChartEntry(RejectedCount)
                {
                    Label = "Rejected",
                    ValueLabel = RejectedCount.ToString(),
                    Color = SKColor.Parse("#F44336")
                }
            };

            ApplicationChart = new DonutChart
            {
                Entries = entries,
                LabelTextSize = 32,
                LabelMode = LabelMode.None,
                GraphPosition = GraphPosition.Center,
                BackgroundColor = SKColors.Transparent
            };
        }

        private void OnOpenDrawer()
        {
            // Reset to all applications when opening drawer
            FilteredApplications = new ObservableCollection<ApplicationItem>(_allApplications);
            ApplicationsListTitle = "All Applications";
            IsDrawerOpen = true;
        }

        private void OnCloseDrawer()
        {
            IsDrawerOpen = false;
        }

        private void OnFilterByStatus(string status)
        {
            if (status == null) return;

            var filtered = _allApplications.Where(a => a.Status == status).ToList();
            FilteredApplications = new ObservableCollection<ApplicationItem>(filtered);
            ApplicationsListTitle = $"{status} Applications";
        }

        private async void OnViewApplicationDetail(ApplicationItem application)
        {
            if (application == null) return;

            await Application.Current.MainPage.DisplayAlert(
                application.OpportunityTitle,
                $"Company: {application.Company}\nStatus: {application.Status}\nApplied: {application.AppliedDate}",
                "OK");

            // TODO: Navigate to detailed application view
        }

        private async void OnFilter()
        {
            var action = await Application.Current.MainPage.DisplayActionSheet(
                "Filter Applications",
                "Cancel",
                null,
                "All Applications",
                "Approved Only",
                "Replied Only",
                "Pending Only",
                "Rejected Only");

            switch (action)
            {
                case "All Applications":
                    FilteredApplications = new ObservableCollection<ApplicationItem>(_allApplications);
                    ApplicationsListTitle = "All Applications";
                    break;
                case "Approved Only":
                    OnFilterByStatus("Approved");
                    break;
                case "Replied Only":
                    OnFilterByStatus("Replied");
                    break;
                case "Pending Only":
                    OnFilterByStatus("Pending");
                    break;
                case "Rejected Only":
                    OnFilterByStatus("Rejected");
                    break;
            }
        }

        private string CalculateSuccessRate()
        {
            if (_allApplications == null || _allApplications.Count == 0) return "0%";

            var successCount = ApprovedCount;
            var rate = (double)successCount / _allApplications.Count * 100;
            return $"{rate:F0}%";
        }

        private string CalculatePercentage(int count)
        {
            if (_allApplications == null || _allApplications.Count == 0) return "0% of total";

            var percentage = (double)count / _allApplications.Count * 100;
            return $"{percentage:F1}% of total";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Application Item Model
    public class ApplicationItem
    {
        public string OpportunityTitle { get; set; }
        public string Company { get; set; }
        public string Status { get; set; }
        public string AppliedDate { get; set; }

        public string StatusAndCompany => $"{Status} • {Company}";

        public string StatusIcon => Status switch
        {
            "Approved" => "✓",
            "Replied" => "💬",
            "Pending" => "⏳",
            "Rejected" => "✕",
            _ => "?"
        };

        public Color StatusColor => Status switch
        {
            "Approved" => Color.FromArgb("#4CAF50"),
            "Replied" => Color.FromArgb("#2196F3"),
            "Pending" => Color.FromArgb("#FFA500"),
            "Rejected" => Color.FromArgb("#F44336"),
            _ => Color.FromArgb("#999999")
        };
    }
}
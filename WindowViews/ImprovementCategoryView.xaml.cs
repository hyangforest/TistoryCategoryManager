using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TistoryCategoryManager.WindowViews
{
    /// <summary>
    /// ImprovementCategoryView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ImprovementCategoryView : UserControl, IUtilities
    {
        private int ID = 0;
        private int SELECTED_SORTORDER = 0;

        /// <summary>
        /// DB
        /// </summary>
        private readonly AppDbContext _context = new AppDbContext();
        private CollectionViewSource? collectionViewSource { get; set; }
        public ICollectionView? collection
        {
            get
            {

                if (collectionViewSource != null)
                {
                    return collectionViewSource.View;
                }
                else
                {
                    return null;
                }
            }
        }
        public ImprovementCategoryView()
        {
            InitializeComponent();
        }

        #region Interface
        /// <summary>
        /// 초기화
        /// </summary>
        public void ResetControl()
        {
            ID = 0;
            this.txtENGCategoryName.Text = string.Empty;
            this.txtKORCategoryName.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtSortOrder.Text = this.GetMaxSortOrder();
            this.chkUsageStatus.IsChecked = true;
            this.chkOpenStatus.IsChecked = false;
        }

        /// <summary>
        /// 저장
        /// </summary>
        public void Save()
        {
            if (_context != null)
            {
                ImprovementCategory improvementCategory = new ImprovementCategory
                {
                    ENGCategoryName = this.txtENGCategoryName.Text,
                    KORCategoryName = this.txtKORCategoryName.Text,
                    Description = this.txtDescription.Text,
                    SortOrder = Convert.ToInt32(this.txtSortOrder.Text),
                    UsageStatus = (bool)this.chkUsageStatus.IsChecked ? "Y" : "N",
                    OpenStatus = (bool)this.chkOpenStatus.IsChecked ? "Y" : "N",
                    RegistrationDate = DateTime.Now,
                    ModificationDate = null,
                };

                _context.ImprovementCategories.Add(improvementCategory);
                _context.SaveChanges();

                MessageBox.Show("저장되었습니다.", "기본정보");
            }
        }

        /// <summary>
        /// 수정
        /// </summary>
        public void Update()
        {
            if (_context != null)
            {
                var improvementCategoryToUpdate = _context.ImprovementCategories.FirstOrDefault(h => h.Id == ID);

                if (improvementCategoryToUpdate != null)
                {
                    improvementCategoryToUpdate.ENGCategoryName = this.txtENGCategoryName.Text;
                    improvementCategoryToUpdate.KORCategoryName = this.txtKORCategoryName.Text;
                    improvementCategoryToUpdate.Description = this.txtDescription.Text;
                    improvementCategoryToUpdate.SortOrder = Convert.ToInt32(this.txtSortOrder.Text);
                    improvementCategoryToUpdate.UsageStatus = (bool)this.chkUsageStatus.IsChecked ? "Y" : "N";
                    improvementCategoryToUpdate.OpenStatus = (bool)this.chkOpenStatus.IsChecked ? "Y" : "N";
                    improvementCategoryToUpdate.ModificationDate = DateTime.Now;

                    _context.SaveChanges();

                    MessageBox.Show("수정되었습니다.", "기본정보");
                }
            }
        }

        /// <summary>
        /// 삭제
        /// </summary>
        public void Delete()
        {
            if (_context != null)
            {
                var improvementCategoryToDelete = _context.ImprovementCategories.FirstOrDefault(h => h.Id == ID);

                if (improvementCategoryToDelete != null)
                {
                    Manipulate.DeleteWithParametersAndUpdateSortOrder(_context, improvementCategoryToDelete);

                    MessageBox.Show("삭제되었습니다.", "기본정보");
                }
            }
        }

        /// <summary>
        /// 유효성
        /// </summary>
        /// <param name="isValid"></param>
        public void CheckControl(out bool isValid)
        {
            int check = 0;

            if (string.IsNullOrWhiteSpace(this.txtENGCategoryName.Text))
            {
                check++;
                MessageBox.Show("카테고리명을 입력하세요.", "기본정보");
                this.txtENGCategoryName.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtSortOrder.Text))
            {
                check++;
                MessageBox.Show("정렬순서를 입력하세요.", "기본정보");
                this.txtSortOrder.Focus();
            }

            isValid = check == 0;
        }

        /// <summary>
        /// 사용자 컨트롤 다시 로드
        /// </summary>
        public void ReloadControl()
        {
            DependencyObject parent = VisualTreeHelper.GetParent(this);

            while (!(parent is MainWindow))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            if (parent is MainWindow mainWindow)
            {
                mainWindow.ContentPresenter.Content = new ImprovementCategoryView();
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 정렬순서 (DB 최대값 + 1) 초기화
        /// </summary>
        /// <returns></returns>
        private string GetMaxSortOrder()
        {
            string maxSortOrder = string.Empty;

            if (_context != null)
            {
                maxSortOrder = (_context.ImprovementCategories.OrderByDescending(e => e.SortOrder).Select(e => e.SortOrder).FirstOrDefault() + 1).ToString();
            }

            return maxSortOrder;
        }

        /// <summary>
        /// 정렬순서 중복 확인
        /// 선택한 값과 입력한 값과 동일한 것은 중복 체크 안함
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        private bool HasDuplicateSortOrder(int sortOrder)
        {
            bool hasDuplicateSortOrder = false;

            if (SELECTED_SORTORDER != sortOrder)
            {
                if (_context != null)
                {
                    hasDuplicateSortOrder = _context.ImprovementCategories.Where(h => h.SortOrder == sortOrder).ToList().Count > 0;
                }
            }

            return hasDuplicateSortOrder;
        }

        private int SaveChangeSortOrder()
        {
            int loadCount = 0;
            MessageBoxResult result;

            if (ID == 0)
            {
                result = MessageBox.Show(Utilities.GetOKCancelSaveStatusMessage(Utilities.SaveStatus.SAVE, " 이미 동일한 정렬 순서가 있습니다. 이 순서로"), "기본정보", MessageBoxButton.OKCancel);
            }
            else
            {
                result = MessageBox.Show(Utilities.GetOKCancelSaveStatusMessage(Utilities.SaveStatus.UPDATE, " 이미 동일한 정렬 순서가 있습니다. 이 순서로"), "기본정보", MessageBoxButton.OKCancel);
            }


            if (result == MessageBoxResult.OK)
            {

                if (_context != null)
                {
                    ImprovementCategory improvementCategory = new ImprovementCategory
                    {
                        Id = ID,
                        ENGCategoryName = this.txtENGCategoryName.Text,
                        KORCategoryName = this.txtKORCategoryName.Text,
                        Description = this.txtDescription.Text,
                        SortOrder = Convert.ToInt32(this.txtSortOrder.Text),
                        UsageStatus = (bool)this.chkUsageStatus.IsChecked ? "Y" : "N",
                        OpenStatus = (bool)this.chkOpenStatus.IsChecked ? "Y" : "N",
                        RegistrationDate = DateTime.Now,
                        ModificationDate = null,
                    };

                    Manipulate.InsertWithParametersAndUpdateSortOrder(_context, improvementCategory);

                    loadCount++;
                }
            }

            return loadCount;
        }
        #endregion

        #region Event
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (_context != null)
            {
                collectionViewSource = new CollectionViewSource();
                collectionViewSource.Source = Find.FindStoredProcedureFromSql(_context);
                listView.ItemsSource = collection;

                // 정렬 순서 최대값 + 1
                this.txtSortOrder.Text = this.GetMaxSortOrder();
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                spImprovementCategory improvement = (spImprovementCategory)listView.SelectedItem;

                ID = improvement.Id;
                SELECTED_SORTORDER = improvement.SortOrder;

                this.txtENGCategoryName.Text = improvement.ENGCategoryName; 
                this.txtKORCategoryName.Text = improvement.KORCategoryName;
                this.txtDescription.Text = improvement.Description;
                this.txtSortOrder.Text = improvement.SortOrder.ToString();
                this.chkUsageStatus.IsChecked = improvement.UsageStatus == "Y";
                this.chkOpenStatus.IsChecked = improvement.OpenStatus == "Y";
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(Utilities.GetOKCancelSaveStatusMessage(Utilities.SaveStatus.RESET), "기본정보", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                this.ResetControl();
            }
            else
            {
                this.txtENGCategoryName.Focus();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;

            if (ID == 0)
            {
                result = MessageBox.Show(Utilities.GetOKCancelSaveStatusMessage(Utilities.SaveStatus.SAVE), "기본정보", MessageBoxButton.OKCancel);
            }
            else
            {
                result = MessageBox.Show(Utilities.GetOKCancelSaveStatusMessage(Utilities.SaveStatus.UPDATE), "기본정보", MessageBoxButton.OKCancel);
            }

            if (result == MessageBoxResult.OK)
            {
                bool isValid;
                int loadCount = 0;
                this.CheckControl(out isValid);

                if (isValid)
                {
                    // 정렬순서 중복 저장/수정
                    if (this.HasDuplicateSortOrder(Convert.ToInt32(this.txtSortOrder.Text)))
                    {
                        loadCount = this.SaveChangeSortOrder();
                    }
                    else
                    {
                        // 저장
                        if (ID == 0)
                        {
                            this.Save();
                            loadCount++;

                        }
                        else // 수정
                        {
                            this.Update();
                            loadCount++;
                        }
                    }

                    if (loadCount > 0)
                    {
                        this.ReloadControl();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(Utilities.GetOKCancelSaveStatusMessage(Utilities.SaveStatus.DELETE), "기본정보", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                this.Delete();
                this.ReloadControl();
            }
        }

        /// <summary>
        /// 텍스트 박스 컨트롤 숫자만 입력받기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberOnlyTextBox(object sender, KeyEventArgs e)
        {
            if (!((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Back || e.Key == Key.Delete))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// HabitCategoryView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HabitCategoryView : UserControl, IUtilities
    {
        private int ID = 0;

        /// <summary>
        /// DB
        /// </summary>
        private readonly AppDbContext _context = new AppDbContext();
        private CollectionViewSource? collectionViewSource { get; set; }
        public ICollectionView? collection
        {
            get {

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

        public HabitCategoryView()
        {
            InitializeComponent();
        }

        #region Method
        /// <summary>
        /// 초기화
        /// </summary>
        public void ResetControl()
        {
            ID = 0;
            this.txtKORCategoryName.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtSortOrder.Text = string.Empty;
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
                HabitCategory habitCategory = new HabitCategory {
                    KORCategoryName = this.txtKORCategoryName.Text,
                    Description = this.txtDescription.Text,
                    SortOrder = Convert.ToInt32(this.txtSortOrder.Text),
                    UsageStatus = (bool)this.chkUsageStatus.IsChecked ? "Y" : "N",
                    OpenStatus = (bool)this.chkOpenStatus.IsChecked ? "Y" : "N",
                    RegistrationDate = DateTime.Now,
                    ModificationDate = null,
                };

                _context.HabitCategories.Add(habitCategory);
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
                var habitCategoryToUpdate = _context.HabitCategories.FirstOrDefault(h => h.Id == ID);

                if (habitCategoryToUpdate != null)
                {
                    habitCategoryToUpdate.KORCategoryName = this.txtKORCategoryName.Text;
                    habitCategoryToUpdate.Description = this.txtDescription.Text;
                    habitCategoryToUpdate.SortOrder = Convert.ToInt32(this.txtSortOrder.Text);
                    habitCategoryToUpdate.UsageStatus = (bool)this.chkUsageStatus.IsChecked ? "Y" : "N";
                    habitCategoryToUpdate.OpenStatus = (bool)this.chkOpenStatus.IsChecked ? "Y" : "N";
                    habitCategoryToUpdate.ModificationDate = DateTime.Now;

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
                var habitCategoryToDelete = _context.HabitCategories.FirstOrDefault(h => h.Id == ID);

                if (habitCategoryToDelete != null)
                {
                    _context.HabitCategories.Remove(habitCategoryToDelete);
                    _context.SaveChanges();

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

            if (string.IsNullOrWhiteSpace(this.txtKORCategoryName.Text))
            {
                check++;
                MessageBox.Show("카테고리명을 입력하세요.", "기본정보");
                this.txtKORCategoryName.Focus();
            } 
            else if (string.IsNullOrEmpty(this.txtSortOrder.Text))
            {
                check++;
                MessageBox.Show("정렬순서를 입력하세요.", "기본정보");
                this.txtSortOrder.Focus();
            }

            isValid = check == 0;
        }
        #endregion

        #region Event
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (_context != null)
            {
                collectionViewSource = new CollectionViewSource();
                collectionViewSource.Source = Find.FindStoredProcedureNameFromSql(_context, "sp_Get_HabitCategories");
                collection?.Refresh();
                listView.ItemsSource = null;
                listView.Items.Clear();
                listView.ItemsSource = collection;
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                spHabitCategory habit = (spHabitCategory)listView.SelectedItem;

                ID = habit.Id;
                this.txtKORCategoryName.Text = habit.KORCategoryName;
                this.txtDescription.Text = habit.Description;
                this.txtSortOrder.Text = habit.SortOrder.ToString();
                this.chkUsageStatus.IsChecked = habit.UsageStatus == "Y";
                this.chkOpenStatus.IsChecked = habit.OpenStatus == "Y";
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
                this.txtKORCategoryName.Focus();
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
                this.CheckControl(out isValid);

                if (isValid)
                {
                    if (ID == 0)
                    {
                        this.Save();
                    }
                    else
                    {
                        this.Update();
                    }

                    this.ResetControl();
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(Utilities.GetOKCancelSaveStatusMessage(Utilities.SaveStatus.DELETE), "기본정보", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                this.Delete();
            }
        }

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

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using TistoryCategoryManager.WindowViews;

namespace TistoryCategoryManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 화면
        /// </summary>
        private readonly HabitCategoryView _habitCategoryView;
        private readonly RecordCategoryView _recordCategoryView;

        public MainWindow()
        {
            InitializeComponent();

            

            // 화면
            _habitCategoryView = new HabitCategoryView();
            _recordCategoryView = new RecordCategoryView();

            ContentPresenter.Content = _habitCategoryView;
        }

        private void btnRecord_Click(object sender, RoutedEventArgs e)
        {
            ContentPresenter.Content = _recordCategoryView; 
        }

        private void btnHabit_Click(object sender, RoutedEventArgs e)
        {
            ContentPresenter.Content = _habitCategoryView; 
        }

        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    // clean up database connections
        //    _context.Dispose();
        //    base.OnClosing(e);
        //}

        /// <summary>
        /// 푸터 프로그램 문의 이메일 클릭 시 주소 복사하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink hyperlink = (Hyperlink)sender;

            System.Windows.Clipboard.SetText(hyperlink.Inlines.OfType<Run>().FirstOrDefault()?.Text);

            System.Windows.MessageBox.Show("이메일 주소가 복사되었습니다.", "알림");
        }
    }
}

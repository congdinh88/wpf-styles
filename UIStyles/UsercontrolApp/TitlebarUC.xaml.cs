using System;
using System.Collections.Generic;
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

namespace UIStyles.UsercontrolApp
{
    /// <summary>
    /// Interaction logic for TitlebarUC.xaml
    /// </summary>
    public partial class TitlebarUC : UserControl
    {
        public TitlebarUC()
        {
            InitializeComponent();
            this.MouseDown += CustomTitleBar_MouseDown;
        }

        private void CustomTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if (e.ClickCount == 2)
            {
                MaximizeRestoreButton_Click(null, null);
            }
            if (window != null && e.ChangedButton == MouseButton.Left && !IsMouseOverControlButton(e))
            {
                window.DragMove();
            }

        }

        private bool IsMouseOverControlButton(MouseButtonEventArgs e)
        {
            // Kiểm tra xem chuột có đang trên các nút điều khiển không
            return MinimizeButton.IsMouseOver || MaximizeRestoreButton.IsMouseOver || CloseButton.IsMouseOver;
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        private void MaximizeRestoreButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if (window != null)
            {
                if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                    MaximizeRestoreButton.Content = "\uE922";
                }
                else
                {
                    window.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                    window.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
                    window.WindowState = WindowState.Maximized;
                    MaximizeRestoreButton.Content = "\uE923";
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if (window != null)
            {
                window.Close();
            }
        }


        //private void InitHeader()
        //{
        //    var border = Find<Border>("borderHeader");
        //    var restoreIfMove = false;

        //    border.MouseLeftButtonDown += (s, e) =>
        //    {
        //        if (e.ClickCount == 2)
        //        {
        //            if ((ResizeMode == ResizeMode.CanResize) ||
        //                (ResizeMode == ResizeMode.CanResizeWithGrip))
        //            {
        //                SwitchState();
        //            }
        //        }
        //        else
        //        {
        //            if (WindowState == WindowState.Maximized)
        //            {
        //                restoreIfMove = true;
        //            }

        //            DragMove();
        //        }
        //    };
        //    border.MouseLeftButtonUp += (s, e) =>
        //    {
        //        restoreIfMove = false;
        //    };
        //    border.MouseMove += (s, e) =>
        //    {
        //        if (restoreIfMove)
        //        {
        //            restoreIfMove = false;
        //            var mouseX = e.GetPosition(this).X;
        //            var width = RestoreBounds.Width;
        //            var x = mouseX - width / 2;

        //            if (x < 0)
        //            {
        //                x = 0;
        //            }
        //            else
        //            if (x + width > screenSize.X)
        //            {
        //                x = screenSize.X - width;
        //            }

        //            WindowState = WindowState.Normal;
        //            Left = x;
        //            Top = 0;
        //            DragMove();
        //        }
        //    };
        //}
        //private void SwitchState()
        //{
        //    switch (WindowState)
        //    {
        //        case WindowState.Normal:
        //            {
        //                WindowState = WindowState.Maximized;
        //                break;
        //            }
        //        case WindowState.Maximized:
        //            {
        //                WindowState = WindowState.Normal;
        //                break;
        //            }
        //    }
        //}

    }
}

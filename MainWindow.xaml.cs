using Microsoft.Win32;
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

namespace WorkingWithFiles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string pathTFile = "";
        public MainWindow()
        {
            InitializeComponent();

         //   BClose.Click += BClose_Click;
         //   BLoadTFile.Click += BLoadTFile_Click;
         //   BSaveTextFile.Click += BSaveTextFile_Click;
                
        }

        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BLoadTFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog odialog = new OpenFileDialog();
            odialog.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            odialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            odialog.FilterIndex = 1;
            if (odialog.ShowDialog() == true)
            {
                pathTFile = odialog.FileName;
                LPathFile.Content = pathTFile;
                try
                {
                    string fileText = System.IO.File.ReadAllText(pathTFile);
                    LOpenSaveFile.Content = "Файл открыт";
                    TextFile.Text = fileText;
                }
                catch (Exception ex)
                {
                    LOpenSaveFile.Content = "Файл не может быть открыт";
                }
            }
        }

        private void BSaveTextFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sdialog = new SaveFileDialog();
            sdialog.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            sdialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            sdialog.FilterIndex = 1;
            if (sdialog.ShowDialog() == true)
            {
                pathTFile = sdialog.FileName;
                LPathFile.Content = pathTFile;
                try
                {
                    System.IO.File.WriteAllText(pathTFile, TextFile.Text);
                    LOpenSaveFile.Content = "Файл сохранен";
                }
                catch (Exception ex)
                {
                    LOpenSaveFile.Content = "Файл не может быть сохранен";
                }
            }
        }
    }
}

using Lab_4_1_var_15_30Lib1Lib;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Lab_4_1_var_15_30;

public partial class MainWindow : Window
{
    private Artist<string> artist = new Artist<string>();
    public MainWindow()
    {
        InitializeComponent();
        artist.Artworks = new List<Artwork>() { new Artwork("", 0) };

        InitGrid();
    }

    private void InitGrid()
    {
        DataGridA.ItemsSource = artist.Artworks;
        DataGridA.CanUserAddRows = false;
    }

    private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFileDialog dlg = new();
        dlg.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
        dlg.DefaultExt = ".xml";
        dlg.Filter = "Файли XML (*.xml)|*.xml|Усі файли (*.*)|*.*";
        if (dlg.ShowDialog() == true)
        {
            try
            {
                artist.ReadFromXml(dlg.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("Error reading from file");
            }
            InitGrid();
        }
    }

    private void MenuItemSave_Click(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.SaveFileDialog dlg = new();
        dlg.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
        dlg.DefaultExt = ".xml";
        dlg.Filter = "Файли XML (*.xml)|*.xml|Усі файли (*.*)|*.*";
        if (dlg.ShowDialog() == true)
        {
            try
            {
                artist.WriteToXml(dlg.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("Error writing to file");
            }
        }
    }

    private void ButtonSortByNameAlph_Click(object sender, RoutedEventArgs e)
    {
        artist.SortByNameAlphabetically();
        InitGrid();
    }

    private void ButtonSortByYear_Click(object sender, RoutedEventArgs e)
    {
        artist.SortByYear();
        InitGrid();
    }

    private void ButtonSearchByNameOfArtwork_Click(object sender, RoutedEventArgs e)
    {
        if (TextBoxSearchName.Text == "")
            return;

        string name = TextBoxSearchName.Text;
        var data = artist.GetArtworksWithName(name);

        string result = "";
        foreach (var item in data)
        {
            result += item + "\n";
        }
        MessageBox.Show(result, "Searh result:");
    }

    private void ButtonSearchByYear_Click(object sender, RoutedEventArgs e)
    {
        if (TextBoxSearchPopulationFrom.Text == "" || TextBoxSearchPopulationTo.Text == "")
            return;

        int from = int.Parse(TextBoxSearchPopulationFrom.Text);
        int to = int.Parse(TextBoxSearchPopulationTo.Text);

        var data = artist.GetArtworksWithYear(from, to);

        string result = "";
        foreach (var item in data)
        {
            result += item + "\n";
        }
        MessageBox.Show(result, "Searh result:");
    }

    private void MenuItemAdd_Click(object sender, RoutedEventArgs e)
    {
        DataGridA.CommitEdit();
        artist += new Artwork("", 0);

        InitGrid();
    }

    private void MenuItemRemove_Click(object sender, RoutedEventArgs e)
    {
        int index = DataGridA.SelectedIndex;

        DataGridA.CommitEdit();

        artist.Artworks.RemoveAt(index);

        if (artist.Artworks.Count == 0)
        {
            artist = new Artist<string>();
            artist += new Artwork("", 0);

            InitGrid();
        }

        DataGridA.ItemsSource = null;

        InitGrid();
    }
}
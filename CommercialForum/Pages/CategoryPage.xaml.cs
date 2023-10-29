using CommercialForum.AppData;
using CommercialForum.Models;
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

namespace CommercialForum.Pages
{
    /// <summary>
    /// Логика взаимодействия для CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        private List<Basic_Category> taked_categoryList = new List<Basic_Category>();
        private List<Basic_Category> all_categoryList = new List<Basic_Category>();

        private int ProductId = 0;
        public CategoryPage(int productId)
        {
            InitializeComponent();

            ProductId = productId;
            BasicCategoryLoader();
            BasicComponentsController();
        }

        private void BasicComponentsController()
        {
            var all_rowCategories = App.Connection.Category.ToList();
            foreach (var row_category in all_rowCategories)
            {
                if (taked_categoryList.Find(u=> u.IdCategory == row_category.Id_Category) == null)
                {
                    Basic_Category basic_Category = new Basic_Category()
                    {
                        IdCategory = row_category.Id_Category,
                        Name = row_category.Name,
                    };
                    all_categoryList.Add(basic_Category);
                }
            }

            ListsUpdate();
        }

        private void BasicCategoryLoader()
        {
            var all_rowCategories = App.Connection.Category_Relationship.Where(u=> u.Id_Product == ProductId).ToList();
            foreach (var rowCategory in all_rowCategories)
            {
                var search_category = App.Connection.Category.Find(rowCategory.Id_Category);
                Basic_Category basic_Category = new Basic_Category()
                {
                    IdCategory = search_category.Id_Category,
                    Name = search_category.Name
                };

                taked_categoryList.Add(basic_Category);
            }
        }

        private void ToTakedBut_Click(object sender, RoutedEventArgs e)
        {
            if (all_categoriesList.SelectedItem != null)
            {
                var relocating_category = all_categoriesList.SelectedItem as Basic_Category;
                all_categoryList.Remove(relocating_category);

                taked_categoryList.Add(relocating_category);
            }

            ListsUpdate();
        }

        private void FromTakedBut_Click(object sender, RoutedEventArgs e)
        {
            if (taked_categoriesList.SelectedItem != null)
            {
                var relocating_category = taked_categoriesList.SelectedItem as Basic_Category;
                taked_categoryList.Remove(relocating_category);

                all_categoryList.Add(relocating_category);
            }

            ListsUpdate();
        }

        private void ListsUpdate()
        {
            all_categoriesList.ItemsSource = null;
            taked_categoriesList.ItemsSource = null;
            all_categoriesList.ItemsSource = all_categoryList;
            taked_categoriesList.ItemsSource = taked_categoryList;
        }

        private void SaveBut_Click(object sender, RoutedEventArgs e)
        {
            App.CategoryTransit.Clear();

            if (App.isCategoriesTransit)
            {
                foreach (var category in taked_categoryList)
                {
                    App.CategoryTransit.Add(category);
                }

                MessageBox.Show("Категории добавлены в фильтр!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var all_rowCategoryRelations = App.Connection.Category_Relationship.Where(u=> u.Id_Product == ProductId).ToList();
                foreach (var category in taked_categoryList)
                {
                    var search_missingCategory = all_rowCategoryRelations.Find(u => u.Id_Category == category.IdCategory);
                    if (search_missingCategory == null)
                    {
                        Category_Relationship new_relation = new Category_Relationship
                        {
                            Id_Category = category.IdCategory,
                            Id_Product = ProductId
                        };

                        App.Connection.Category_Relationship.Add(new_relation);
                    }
                }

                all_rowCategoryRelations = App.Connection.Category_Relationship.Where(u => u.Id_Product == ProductId).ToList();
                foreach (var row_category in all_rowCategoryRelations)
                {
                    var search_missingCategory = taked_categoryList.Find(u => u.IdCategory == row_category.Id_Category);
                    if (search_missingCategory == null)
                    {
                        App.Connection.Category_Relationship.Remove(row_category);
                    }
                }

                MessageBox.Show("Категории успешно сохранены!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                App.Connection.SaveChanges();
                App.Current.MainWindow.Activate();
            }
        }

        public CategoryPage()
        {
            InitializeComponent();
            TransitLoader();
            BasicComponentsController();
        }

        private void TransitLoader()
        {
            foreach (var category in App.CategoryTransit)
            {
                taked_categoryList.Add(category);
            }
        } 
    }
}

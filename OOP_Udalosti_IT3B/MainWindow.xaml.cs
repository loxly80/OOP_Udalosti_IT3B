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

namespace OOP_Udalosti_IT3B
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    List<Entity> entities = new List<Entity>();

    public MainWindow()
    {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      GenerateEntities();
      DrawEntities();
    }

    private void DrawEntities()
    {
      Canvas1.Children.Clear();
      foreach (var entity in entities)
      {
        var rectangle = new Rectangle();
        rectangle.Width = entity.Size;
        rectangle.Height = entity.Size;
        rectangle.Fill = entity.Color;
        rectangle.Stroke = Brushes.Black;
        rectangle.StrokeThickness = 3;
        Canvas.SetLeft(rectangle, entity.Location.X);
        Canvas.SetTop(rectangle, entity.Location.Y);
        Canvas1.Children.Add(rectangle);
      }
    }

    private void GenerateEntities()
    {
      entities.Clear();
      Random random = new Random();
      for (int i = 0; i < 10; i++)
      {
        var entity = new Entity();
        entity.Size = random.NextDouble() * 50 + 20;
        var x = random.NextDouble() * (Canvas1.ActualWidth - entity.Size);
        var y = random.NextDouble() * (Canvas1.ActualHeight - entity.Size);
        entity.Location = new Point(x, y);
        entities.Add(entity);
        entity.ColorChanged += Entity_ColorChanged;
      }
    }

    private void Entity_ColorChanged()
    {
      DrawEntities();
    }

    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    {
      GenerateEntities();
      DrawEntities();
    }
  }
}

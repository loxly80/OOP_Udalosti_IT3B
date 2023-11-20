using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace OOP_Udalosti_IT3B
{
  public class Entity
  {
    private int selectedColor;

    public Point Location { get; set; }
    public double Size { get; set; }
    public Brush Color { get => Colors[selectedColor]; }
    public List<Brush> Colors { get; set; }

    public Entity()
    {
      Random random = new Random();
      Location = new Point();
      Size = 50;
      Colors = new List<Brush>() {
       Brushes.White,
       Brushes.Red,
       Brushes.Green,
       Brushes.Blue,
       Brushes.Yellow,
       Brushes.Cyan,
       Brushes.Magenta,
      };
      selectedColor = random.Next(0, Colors.Count);
    }
  }
}

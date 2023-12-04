using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace OOP_Udalosti_IT3B
{
  public class Entity
  {
    private int selectedColor;
    private DispatcherTimer timer;
    private Random random = new Random();

    public Point Location { get; set; }
    public double Size { get; set; }
    public Brush Color { get => Colors[selectedColor]; }
    public List<Brush> Colors { get; set; }

    public event Action? ColorChanged;

    public Entity()
    {
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
      timer = new DispatcherTimer();
      timer.Interval = new TimeSpan(0, 0, random.Next(2,8));
      timer.Tick += Timer_Tick;
      timer.Start();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
      selectedColor = random.Next(0, Colors.Count);
      ColorChanged?.Invoke();
      timer.Interval = new TimeSpan(0, 0, random.Next(2, 8));
    }
  }
}

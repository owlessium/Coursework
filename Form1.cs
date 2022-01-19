using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class FreezSpelButton : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;

        GravityPoint selectedGraviton = null;

        public static Random rand = new Random();

        Enemy enemy;

        int points = 0;

        double freezTimer = 0.0;

        bool isMousePressed = false;

        public enum Direction
        {
            Вверх,
            Вниз,
            Влево,
            Вправо
        }

        public FreezSpelButton()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            emitter = new Emitter
            {
                Direction = 0,
                spreading = 10,
                speedMin = 10,
                speedMax = 10,
                colorFrom = Color.DarkViolet,
                colorTo = Color.FromArgb(0, Color.Maroon),
                particlesPerTick = 10,
                x = picDisplay.Width / 2,
                y = picDisplay.Height / 2,
            };

            emitters.Add(emitter);

            /*emitter = new TopEmitter
            {
                width = picDisplay.Width,
                gravitationY = 0.25f
            };*/

            directionBox.DataSource = Enum.GetValues(typeof(Direction));
            changeDirection();

            initEnemy();
            addGraviton();
        }

        private void addPoints()
        {
            points += enemy.reward;
        }

        private void initEnemy()
        {
            enemy = new Enemy();
            enemy.OnDead += addPoints;
            enemy.OnDead += respawnEnemy;

            respawnEnemy();
        }

        private void respawnEnemy()
        {
            Tuple<int, int> pos = getRespawnPos();

            enemy.x = pos.Item1;
            enemy.y = pos.Item2;
            enemy.life = 250;
            enemy.reward = 10 + rand.Next(15);
        }

        private Tuple<int,int> getRespawnPos()
        {
            int x = 0;
            int y = 0;

            if (rand.Next(2) == 0)
            {
                y = rand.Next(picDisplay.Height);
            }
            else
            {
                x = rand.Next(picDisplay.Width);
            }

            return Tuple.Create(x, y);
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            Points.Text = $"Количество очков {points}";

            emitter.UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);

                emitter.Render(g);
                emitter.checkHitEnemy(g, enemy);
                enemy.Draw(g);

                if (enemy.Overlaps(emitter, g))
                {
                    emitter.health -= 10;
                    
                    if (emitter.health <= 0)
                    {
                        timer1.Enabled = false;
                        
                        MessageBox.Show("ПОРАЖЕНИЕ!");
                    }
                    
                    respawnEnemy();
                }
            }

            enemy.MoveTo(emitter);

            if (freezTimer > 0.40) 
                freezTimer -= (double)timer1.Interval / 1000;
            else 
                freezTimer = 0.0;

            FreezTimer.Text = $"{Math.Round(freezTimer, 1)}";

            

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMousePressed)
            {
                selectedGraviton.x = e.X;
                selectedGraviton.y = e.Y;
            }
        }

        private void changeDirection()
        {
            switch (directionBox.SelectedItem)
            {
                case Direction.Вверх:
                    emitter.Direction = 90;
                    break;
                case Direction.Вниз:
                    emitter.Direction = 270;
                    break;
                case Direction.Влево:
                    emitter.Direction = 180;
                    break;
                case Direction.Вправо:
                    emitter.Direction = 0;
                    break;
            }
        }

        private void addGravitonButton_Click(object sender, EventArgs e)
        {
            addGraviton();
        }

        private void addGraviton()
        {
            var point = new GravityPoint
            {
                x = picDisplay.Width / 2,
                y = picDisplay.Height / 2,
                color = Color.Yellow
            };

            selectGraviton(point);

            emitter.impactPoints.Add(point);
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            if (selectedGraviton != null)
                selectedGraviton.power = tbGraviton.Value;
        }

        private void picDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var point in emitter.impactPoints)
            {
                var graviton = point as GravityPoint;
                if (clickOnGraviton(e.X, e.Y, graviton))
                {
                    selectGraviton(graviton);
                    isMousePressed = true;
                    return;
                }
            }
        }

        private void selectGraviton(GravityPoint graviton)
        {
            if (selectedGraviton != null)
                selectedGraviton.color = Color.Yellow;

            selectedGraviton = graviton;
            selectedGraviton.color = Color.White;
        }

        private bool clickOnGraviton(float mouseX, float mouseY, GravityPoint graviton) 
        {
            return Math.Pow(mouseX - graviton.x, 2) +
                   Math.Pow(mouseY - graviton.y, 2) <= Math.Pow(graviton.power / 2, 2);
        }

        private void picDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            isMousePressed = false;
        }

        private void delGravitonButton_Click(object sender, EventArgs e)
        {
            if (selectedGraviton != null)
            {
                emitter.impactPoints.Remove(selectedGraviton);
                selectedGraviton = null;
            }
        }

        private void directionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeDirection();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    directionBox.SelectedIndex = 0;
                    break;
                case Keys.S:
                    directionBox.SelectedIndex = 1;
                    break;
                case Keys.A:
                    directionBox.SelectedIndex = 2;
                    break;
                case Keys.D:
                    directionBox.SelectedIndex = 3;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            freezEnemy();
        }

        private void freezEnemy()
        {
            freezTimer = 5;
            if (freezTimer != 0.0)
            {
                enemy.isFreez = true;
            }
            
        }

        private void FreezTimer_Click(object sender, EventArgs e)
        {

        }
    }
}

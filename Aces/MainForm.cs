using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Aces
{
/*
Future Features
	2. Realistic flying conditions
		a. Visibility
		b. Cold or heat effects on aircraft or gun behavior
		c. Clouds
		d. Ground features like mountains
		e. Rain, snow, fog
		f. Airspace
		g. Fuel
	3. Trainer mode to allow user to learn what the maneuvers actually do
		a. Straight and level
		b. Flying in a pattern (square, circle, loops, figure 8, etc.)
	4. Better enemy AI
		a. Move list in table
		b. Different levels like trainer, beginner, advanced, ace
		c. Learning algorithms
		d. Other "AI" theory?
		e. Must be able to effectively tail and shoot down a docile aircraft
		f. Must be hard to shake when tailing an active aircraft
		g. Must be able to evade when being tailed
	5. Advanced gameplay features
		a. inertia/speed
		b. stall and loss of control
		c. altitude
		d. roll to hit
		e. damage to areas of aircraft and reduced maneuverability
		f. ammo
		g. gun jams
		h. what else is documented?
	6. Better user interface ideas
		a. Status bar organization better
		c. Arrows overlay on screen
		d. Different icons that better represent maneuvers
		e. Areas of screen that can represent maneuver (so that you don't need "buttons")
		f. Better "toast"
		g. Sound effects
		h. Better screen layout
Phone/mobile port
	1. Reduce size of bitmaps (needs to be automated)
	2. Touchscreen gestures
	3. Appropriate use of toast
Complete revamp
	1. Sprites and animation
	2. Real-time interaction
	3. How to avoid looking like a "broken" flight simulator?
*/
    public partial class MainForm : Form
    {
        private static Random rand = new Random();

        private static int[] startPages = 
        {    
            110, 111, 112, 113, 114, 115, 117, 121, 123, 124, 127, 129, 130, 132, 133, 135, 136, 138, 139, 
            141, 152, 144, 147, 148, 149, 150, 153, 154, 155, 156, 
            159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 
            178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 
            202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222
        };
        int page;
        Player player = new Human();
        Player enemy = null; // new EnemyPilot();
        string playerManeuver;
        string enemyManeuver;
        string lastPlayerManeuver;
        Book germans;
        Book allies;

        public MainForm()
        {
            InitializeComponent();
            germans = Book.loadGermans();
            allies = Book.loadAllies();
            enemy = new EnemyPilot(germans);
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doNewGame();
        }
        private void doNewGame()
        {
            playerManeuver = Maneuvers.Straight;
            enemyManeuver = Maneuvers.Straight;
            int index = rand.Next(0, startPages.Length);
            page = startPages[index];
            player.HitPoints = 8;
            enemy.HitPoints = 8;
            lastPlayerManeuver = playerManeuver;
            updateDisplay();
        }
        private bool isDifficult(string maneuver)
        {
            if (maneuver == null || maneuver == "") return false;
            return Maneuvers.All[maneuver].Difficult;
        }
        private bool canDoManeuvers(Player actor, string last, string next)
        {
            // Damage mechanic.  Just for fun.  If you're at half health your aircraft is damaged and cannot do difficult maneuvers.
            if (isDifficult(next) && actor.HitPoints <= 4) return false;

            if (!isDifficult(last)) return true;
            if (!isDifficult(next)) return true;
            if (last == next) return true;
            return false;
        }
        private void updateDisplay()
        {
            string resource = string.Format("allies_{0}", page);
            this.CockpitView.Image = (Bitmap)global::Aces.Properties.Resources.ResourceManager.GetObject(resource);

            int attack = allies.LookupInt("Attack", page);
            int damage = allies.LookupInt("Damage", page);
            enemy.HitPoints -= attack;
            player.HitPoints -= enemy.GetDamage(damage);
            string health = "Player: " + player.HitPoints + " Enemy: " + enemy.HitPoints;
            enemyManeuver = getEnemyManeuver(page, null);
            if (allies.LookupBool("Tail", page))
            {
                this.gameStatusLabel.Text = health + " Enemy is going " + getDirection(enemyManeuver);
            }
            else
            {
                this.gameStatusLabel.Text = health;
            }
            foreach (ToolStripItem item in this.toolStrip1.Items)
            {
                item.Enabled = canDoManeuvers(player, playerManeuver, item.Text);
            }
            if (player.HitPoints <= 0 && enemy.HitPoints <= 0)
            {
                MessageBox.Show("You have both been shot down.");
                doNewGame();
            }
            else if (player.HitPoints <= 0)
            {
                MessageBox.Show("You have been shot down.");
                doNewGame();
            }
            else if (enemy.HitPoints <= 0)
            {
                MessageBox.Show("You have won!");
                doNewGame();
            }
            if (page == 223)
            {
                MessageBox.Show("Enemy is out of range.");
                doNewGame();
            }
        }
        private void doExit()
        {
            this.Close();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doExit();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            doNewGame();
        }
        private void doPlayerMove(string maneuver)
        {
            playerManeuver = maneuver;
            if (germans.LookupBool("Tail", page))
            {
                enemyManeuver = getEnemyManeuver(page, playerManeuver); // If enemy has Tail then he can re-think his move here
            }
            page = getNextPage(page, playerManeuver, enemyManeuver);
            updateDisplay();
        }
        private string getEnemyManeuver(int page, string playerManeuver)
        {
            return enemy.getNextManeuver(page, playerManeuver);
        }
        private int getNextPage(int page, string player, string enemy)
        {
            int mid = germans.LookupPage(enemy, page);
            int result = allies.LookupPage(player, mid);
            if (result == 223)
            {
                mid = allies.LookupPage(player, page);
                result = germans.LookupPage(enemy, mid);
            }
            return result;
        }
        private string getDirection(string maneuver)
        {
            Maneuvers.Details details = Maneuvers.All[maneuver];
            return details.Direction;
        }

        private void toolStripButton_Click(object sender, EventArgs e)
        {
            doPlayerMove(((ToolStripItem)sender).Text);

        }

        private void trainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.enemy = new Trainer(null);
            doNewGame();
        }

        private void trainerpatternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.enemy = new Trainer(new string[] { Maneuvers.Straight, Maneuvers.Cruise_then_right, Maneuvers.Right_then_cruise, Maneuvers.Straight, Maneuvers.Cruise_then_left, Maneuvers.Left_then_cruise });
            doNewGame();
        }

        private void pilotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.enemy = new EnemyPilot(germans);
            doNewGame();
        }

        private void aceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.enemy = new EnemyAce();
            doNewGame();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = doKeyEvent(e.KeyCode.ToString(), e.Shift, e.Control);
        }

        private static Dictionary<string, string> keyMapping = new Dictionary<string, string>
        {
            { "Ctrl+Q", Maneuvers.Cruise_then_left },
            // { "Ctrl+W", "" },
            { "Ctrl+E", Maneuvers.Cruise_then_right },
            { "Ctrl+A", Maneuvers.Stall_left },
            { "Ctrl+S", Maneuvers.Stall },
            { "Ctrl+D", Maneuvers.Stall_right },
            { "Ctrl+Z", Maneuvers.Wing_left },
            { "Ctrl+X", Maneuvers.Immlemann },
            { "Ctrl+C", Maneuvers.Wing_right },

            { "Ctrl+Shift+A", Maneuvers.Weave_left_right },
            { "Ctrl+Shift+D", Maneuvers.Weave_right_left },

            { "Q", Maneuvers.Left_then_cruise },
            { "W", Maneuvers.Straight },
            { "E", Maneuvers.Right_then_cruise },
            { "A", Maneuvers.Slip_left },
            { "S", Maneuvers.Stall },
            { "D", Maneuvers.Slip_right },
            { "Z", Maneuvers.Turn_left },
            { "X", Maneuvers.Rotary_turn },
            { "C", Maneuvers.Turn_right },

            { "Shift+Q", Maneuvers.Fast_then_left },
            { "Shift+W", Maneuvers.Fast },
            { "Shift+E", Maneuvers.Fast_then_right },
            { "Shift+A", Maneuvers.Barrel_roll_left },
            { "Shift+S", Maneuvers.Stall },
            { "Shift+D", Maneuvers.Barrel_roll_right },
            { "Shift+Z", Maneuvers.Left_then_fast },
            // { "Shift+X", "" },
            { "Shift+C", Maneuvers.Right_then_fast },
        };
        private bool doKeyEvent(String ch, bool isShift, bool isCtrl)
        {
            String key = ch.ToUpper();
            if (isShift) key = "Shift+" + key;
            if (isCtrl) key = "Ctrl+" + key;
            if (keyMapping.ContainsKey(key))
            {
                doPlayerMove(keyMapping[key]);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void turnTopageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputPageDialogBox dialog = new InputPageDialogBox();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int pageNumber;
                if (Int32.TryParse(dialog.PageNumber, out pageNumber))
                {
                    if (pageNumber > 0 && pageNumber < 223)
                    {
                        page = pageNumber;
                        updateDisplay();
                    }
                }
            }
        }
    }
}

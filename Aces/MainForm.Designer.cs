namespace Aces
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnTopageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enemyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainerpatternToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pilotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CockpitView = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.gameStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonStallLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTurnLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonWeaveLeftRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStall = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStallRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTurnRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRotaryTurn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonWeaveRightLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCruiseThenLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLeftThenCruise = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonWingLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStraight = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonImmleman = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSlipLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSlipRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCruiseThenRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRightThenCruise = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonWingRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLeftThenFast = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFastThenLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFast = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBarrelRollLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBarrelRollRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFastThenRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRightThenFast = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CockpitView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.enemyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(552, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.turnTopageToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newGameToolStripMenuItem.Text = "&New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // turnTopageToolStripMenuItem
            // 
            this.turnTopageToolStripMenuItem.Name = "turnTopageToolStripMenuItem";
            this.turnTopageToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.turnTopageToolStripMenuItem.Text = "Turn to &page...";
            this.turnTopageToolStripMenuItem.Click += new System.EventHandler(this.turnTopageToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // enemyToolStripMenuItem
            // 
            this.enemyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trainerToolStripMenuItem,
            this.trainerpatternToolStripMenuItem,
            this.pilotToolStripMenuItem,
            this.aceToolStripMenuItem});
            this.enemyToolStripMenuItem.Name = "enemyToolStripMenuItem";
            this.enemyToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.enemyToolStripMenuItem.Text = "&Enemy";
            // 
            // trainerToolStripMenuItem
            // 
            this.trainerToolStripMenuItem.Name = "trainerToolStripMenuItem";
            this.trainerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.trainerToolStripMenuItem.Text = "Trainer (&Straight)";
            this.trainerToolStripMenuItem.Click += new System.EventHandler(this.trainerToolStripMenuItem_Click);
            // 
            // trainerpatternToolStripMenuItem
            // 
            this.trainerpatternToolStripMenuItem.Name = "trainerpatternToolStripMenuItem";
            this.trainerpatternToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.trainerpatternToolStripMenuItem.Text = "Trainer (&Pattern)";
            this.trainerpatternToolStripMenuItem.Click += new System.EventHandler(this.trainerpatternToolStripMenuItem_Click);
            // 
            // pilotToolStripMenuItem
            // 
            this.pilotToolStripMenuItem.Name = "pilotToolStripMenuItem";
            this.pilotToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.pilotToolStripMenuItem.Text = "P&ilot";
            this.pilotToolStripMenuItem.Click += new System.EventHandler(this.pilotToolStripMenuItem_Click);
            // 
            // aceToolStripMenuItem
            // 
            this.aceToolStripMenuItem.Name = "aceToolStripMenuItem";
            this.aceToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.aceToolStripMenuItem.Text = "&Ace";
            this.aceToolStripMenuItem.Click += new System.EventHandler(this.aceToolStripMenuItem_Click);
            // 
            // CockpitView
            // 
            this.CockpitView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CockpitView.Image = global::Aces.Properties.Resources.allies_223;
            this.CockpitView.Location = new System.Drawing.Point(0, 24);
            this.CockpitView.Margin = new System.Windows.Forms.Padding(2);
            this.CockpitView.Name = "CockpitView";
            this.CockpitView.Size = new System.Drawing.Size(552, 340);
            this.CockpitView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CockpitView.TabIndex = 1;
            this.CockpitView.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 393);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(552, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // gameStatusLabel
            // 
            this.gameStatusLabel.Name = "gameStatusLabel";
            this.gameStatusLabel.Size = new System.Drawing.Size(70, 17);
            this.gameStatusLabel.Text = "GameStatus";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStallLeft,
            this.toolStripButtonTurnLeft,
            this.toolStripButtonWeaveLeftRight,
            this.toolStripButtonStall,
            this.toolStripButtonStallRight,
            this.toolStripButtonTurnRight,
            this.toolStripButtonRotaryTurn,
            this.toolStripButtonWeaveRightLeft,
            this.toolStripSeparator1,
            this.toolStripButtonCruiseThenLeft,
            this.toolStripButtonLeftThenCruise,
            this.toolStripButtonWingLeft,
            this.toolStripButtonStraight,
            this.toolStripButtonImmleman,
            this.toolStripButtonSlipLeft,
            this.toolStripButtonSlipRight,
            this.toolStripButtonCruiseThenRight,
            this.toolStripButtonRightThenCruise,
            this.toolStripButtonWingRight,
            this.toolStripSeparator2,
            this.toolStripButtonLeftThenFast,
            this.toolStripButtonFastThenLeft,
            this.toolStripButtonFast,
            this.toolStripButtonBarrelRollLeft,
            this.toolStripButtonBarrelRollRight,
            this.toolStripButtonFastThenRight,
            this.toolStripButtonRightThenFast});
            this.toolStrip1.Location = new System.Drawing.Point(0, 366);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(552, 27);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonStallLeft
            // 
            this.toolStripButtonStallLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStallLeft.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStallLeft.Image")));
            this.toolStripButtonStallLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStallLeft.Name = "toolStripButtonStallLeft";
            this.toolStripButtonStallLeft.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonStallLeft.Text = "Stall left";
            this.toolStripButtonStallLeft.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonTurnLeft
            // 
            this.toolStripButtonTurnLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTurnLeft.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTurnLeft.Image")));
            this.toolStripButtonTurnLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTurnLeft.Name = "toolStripButtonTurnLeft";
            this.toolStripButtonTurnLeft.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonTurnLeft.Text = "Turn left";
            this.toolStripButtonTurnLeft.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonWeaveLeftRight
            // 
            this.toolStripButtonWeaveLeftRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonWeaveLeftRight.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonWeaveLeftRight.Image")));
            this.toolStripButtonWeaveLeftRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWeaveLeftRight.Name = "toolStripButtonWeaveLeftRight";
            this.toolStripButtonWeaveLeftRight.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonWeaveLeftRight.Text = "Weave left-right";
            this.toolStripButtonWeaveLeftRight.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonStall
            // 
            this.toolStripButtonStall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStall.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStall.Image")));
            this.toolStripButtonStall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStall.Name = "toolStripButtonStall";
            this.toolStripButtonStall.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonStall.Text = "Stall";
            this.toolStripButtonStall.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonStallRight
            // 
            this.toolStripButtonStallRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStallRight.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStallRight.Image")));
            this.toolStripButtonStallRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStallRight.Name = "toolStripButtonStallRight";
            this.toolStripButtonStallRight.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonStallRight.Text = "Stall right";
            this.toolStripButtonStallRight.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonTurnRight
            // 
            this.toolStripButtonTurnRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTurnRight.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTurnRight.Image")));
            this.toolStripButtonTurnRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTurnRight.Name = "toolStripButtonTurnRight";
            this.toolStripButtonTurnRight.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonTurnRight.Text = "Turn right";
            this.toolStripButtonTurnRight.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonRotaryTurn
            // 
            this.toolStripButtonRotaryTurn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRotaryTurn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRotaryTurn.Image")));
            this.toolStripButtonRotaryTurn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRotaryTurn.Name = "toolStripButtonRotaryTurn";
            this.toolStripButtonRotaryTurn.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonRotaryTurn.Text = "Rotary turn";
            this.toolStripButtonRotaryTurn.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonWeaveRightLeft
            // 
            this.toolStripButtonWeaveRightLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonWeaveRightLeft.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonWeaveRightLeft.Image")));
            this.toolStripButtonWeaveRightLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWeaveRightLeft.Name = "toolStripButtonWeaveRightLeft";
            this.toolStripButtonWeaveRightLeft.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonWeaveRightLeft.Text = "Weave right-left";
            this.toolStripButtonWeaveRightLeft.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonCruiseThenLeft
            // 
            this.toolStripButtonCruiseThenLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCruiseThenLeft.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCruiseThenLeft.Image")));
            this.toolStripButtonCruiseThenLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCruiseThenLeft.Name = "toolStripButtonCruiseThenLeft";
            this.toolStripButtonCruiseThenLeft.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonCruiseThenLeft.Text = "Cruise then left";
            this.toolStripButtonCruiseThenLeft.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonLeftThenCruise
            // 
            this.toolStripButtonLeftThenCruise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLeftThenCruise.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLeftThenCruise.Image")));
            this.toolStripButtonLeftThenCruise.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLeftThenCruise.Name = "toolStripButtonLeftThenCruise";
            this.toolStripButtonLeftThenCruise.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonLeftThenCruise.Text = "Left then cruise";
            this.toolStripButtonLeftThenCruise.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonWingLeft
            // 
            this.toolStripButtonWingLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonWingLeft.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonWingLeft.Image")));
            this.toolStripButtonWingLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWingLeft.Name = "toolStripButtonWingLeft";
            this.toolStripButtonWingLeft.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonWingLeft.Text = "Wing left";
            this.toolStripButtonWingLeft.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonStraight
            // 
            this.toolStripButtonStraight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStraight.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStraight.Image")));
            this.toolStripButtonStraight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStraight.Name = "toolStripButtonStraight";
            this.toolStripButtonStraight.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonStraight.Text = "Straight";
            this.toolStripButtonStraight.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonImmleman
            // 
            this.toolStripButtonImmleman.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonImmleman.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonImmleman.Image")));
            this.toolStripButtonImmleman.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonImmleman.Name = "toolStripButtonImmleman";
            this.toolStripButtonImmleman.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonImmleman.Text = "Immleman";
            this.toolStripButtonImmleman.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonSlipLeft
            // 
            this.toolStripButtonSlipLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSlipLeft.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSlipLeft.Image")));
            this.toolStripButtonSlipLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSlipLeft.Name = "toolStripButtonSlipLeft";
            this.toolStripButtonSlipLeft.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonSlipLeft.Text = "Slip left";
            this.toolStripButtonSlipLeft.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonSlipRight
            // 
            this.toolStripButtonSlipRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSlipRight.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSlipRight.Image")));
            this.toolStripButtonSlipRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSlipRight.Name = "toolStripButtonSlipRight";
            this.toolStripButtonSlipRight.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonSlipRight.Text = "Slip right";
            this.toolStripButtonSlipRight.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonCruiseThenRight
            // 
            this.toolStripButtonCruiseThenRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCruiseThenRight.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCruiseThenRight.Image")));
            this.toolStripButtonCruiseThenRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCruiseThenRight.Name = "toolStripButtonCruiseThenRight";
            this.toolStripButtonCruiseThenRight.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonCruiseThenRight.Text = "Cruise then right";
            this.toolStripButtonCruiseThenRight.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonRightThenCruise
            // 
            this.toolStripButtonRightThenCruise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRightThenCruise.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRightThenCruise.Image")));
            this.toolStripButtonRightThenCruise.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRightThenCruise.Name = "toolStripButtonRightThenCruise";
            this.toolStripButtonRightThenCruise.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonRightThenCruise.Text = "Right then cruise";
            this.toolStripButtonRightThenCruise.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonWingRight
            // 
            this.toolStripButtonWingRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonWingRight.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonWingRight.Image")));
            this.toolStripButtonWingRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWingRight.Name = "toolStripButtonWingRight";
            this.toolStripButtonWingRight.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonWingRight.Text = "Wing right";
            this.toolStripButtonWingRight.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonLeftThenFast
            // 
            this.toolStripButtonLeftThenFast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLeftThenFast.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLeftThenFast.Image")));
            this.toolStripButtonLeftThenFast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLeftThenFast.Name = "toolStripButtonLeftThenFast";
            this.toolStripButtonLeftThenFast.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonLeftThenFast.Text = "Left then fast";
            this.toolStripButtonLeftThenFast.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonFastThenLeft
            // 
            this.toolStripButtonFastThenLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFastThenLeft.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFastThenLeft.Image")));
            this.toolStripButtonFastThenLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFastThenLeft.Name = "toolStripButtonFastThenLeft";
            this.toolStripButtonFastThenLeft.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonFastThenLeft.Text = "Fast then left";
            this.toolStripButtonFastThenLeft.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonFast
            // 
            this.toolStripButtonFast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFast.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFast.Image")));
            this.toolStripButtonFast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFast.Name = "toolStripButtonFast";
            this.toolStripButtonFast.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonFast.Text = "Fast";
            this.toolStripButtonFast.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonBarrelRollLeft
            // 
            this.toolStripButtonBarrelRollLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBarrelRollLeft.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBarrelRollLeft.Image")));
            this.toolStripButtonBarrelRollLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBarrelRollLeft.Name = "toolStripButtonBarrelRollLeft";
            this.toolStripButtonBarrelRollLeft.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonBarrelRollLeft.Text = "Barrel roll left";
            this.toolStripButtonBarrelRollLeft.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonBarrelRollRight
            // 
            this.toolStripButtonBarrelRollRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBarrelRollRight.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBarrelRollRight.Image")));
            this.toolStripButtonBarrelRollRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBarrelRollRight.Name = "toolStripButtonBarrelRollRight";
            this.toolStripButtonBarrelRollRight.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonBarrelRollRight.Text = "Barrel roll right";
            this.toolStripButtonBarrelRollRight.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonFastThenRight
            // 
            this.toolStripButtonFastThenRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFastThenRight.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFastThenRight.Image")));
            this.toolStripButtonFastThenRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFastThenRight.Name = "toolStripButtonFastThenRight";
            this.toolStripButtonFastThenRight.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonFastThenRight.Text = "Fast then right";
            this.toolStripButtonFastThenRight.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButtonRightThenFast
            // 
            this.toolStripButtonRightThenFast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRightThenFast.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRightThenFast.Image")));
            this.toolStripButtonRightThenFast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRightThenFast.Name = "toolStripButtonRightThenFast";
            this.toolStripButtonRightThenFast.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonRightThenFast.Text = "Right then fast";
            this.toolStripButtonRightThenFast.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 415);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.CockpitView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Ace of Aces WWI";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CockpitView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox CockpitView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel gameStatusLabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonStallLeft;
        private System.Windows.Forms.ToolStripButton toolStripButtonTurnLeft;
        private System.Windows.Forms.ToolStripButton toolStripButtonWeaveLeftRight;
        private System.Windows.Forms.ToolStripButton toolStripButtonStall;
        private System.Windows.Forms.ToolStripButton toolStripButtonStallRight;
        private System.Windows.Forms.ToolStripButton toolStripButtonTurnRight;
        private System.Windows.Forms.ToolStripButton toolStripButtonRotaryTurn;
        private System.Windows.Forms.ToolStripButton toolStripButtonWeaveRightLeft;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonWingLeft;
        private System.Windows.Forms.ToolStripButton toolStripButtonLeftThenCruise;
        private System.Windows.Forms.ToolStripButton toolStripButtonCruiseThenLeft;
        private System.Windows.Forms.ToolStripButton toolStripButtonSlipLeft;
        private System.Windows.Forms.ToolStripButton toolStripButtonStraight;
        private System.Windows.Forms.ToolStripButton toolStripButtonImmleman;
        private System.Windows.Forms.ToolStripButton toolStripButtonSlipRight;
        private System.Windows.Forms.ToolStripButton toolStripButtonCruiseThenRight;
        private System.Windows.Forms.ToolStripButton toolStripButtonRightThenCruise;
        private System.Windows.Forms.ToolStripButton toolStripButtonWingRight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonLeftThenFast;
        private System.Windows.Forms.ToolStripButton toolStripButtonFastThenLeft;
        private System.Windows.Forms.ToolStripButton toolStripButtonBarrelRollLeft;
        private System.Windows.Forms.ToolStripButton toolStripButtonFast;
        private System.Windows.Forms.ToolStripButton toolStripButtonBarrelRollRight;
        private System.Windows.Forms.ToolStripButton toolStripButtonFastThenRight;
        private System.Windows.Forms.ToolStripButton toolStripButtonRightThenFast;
        private System.Windows.Forms.ToolStripMenuItem enemyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pilotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainerpatternToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnTopageToolStripMenuItem;
    }
}


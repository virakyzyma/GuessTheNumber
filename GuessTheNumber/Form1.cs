
namespace GuessTheNumber
{
    public partial class Form1 : Form
    {
        private int secretNumber;
        private int attemptsLeft;
        private Label statusLabel;
        private TextBox guessTextBox;
        public Form1()
        {
            InitializeComponent();
            InitializeControls();
            StartNewGame();
        }
        private void InitializeControls()
        {
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem newGameMenuItem = new ToolStripMenuItem("New game");
            ToolStripMenuItem rulesMenuItem = new ToolStripMenuItem("Rules");
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit");

            menuStrip.Items.AddRange(new ToolStripMenuItem[] { newGameMenuItem, rulesMenuItem, exitMenuItem });
            newGameMenuItem.Click += (sender, e) => StartNewGame();
            rulesMenuItem.Click += (sender, e) => MessageBox.Show("The computer guesses a number, the player makes a guess, the computer gives a hint until the number is guessed");
            exitMenuItem.Click += (sender, e) => Close();

            this.Controls.Add(menuStrip);
            statusLabel = new Label()
            {
                Text = "Attempts left: 5",
                AutoSize = true,
                Location = new Point(10, 40)
            };
            guessTextBox = new TextBox() {
                Location = new Point(statusLabel.Left, statusLabel.Bottom + 10),
            };
            Button checkButton = new Button()
            {
                Text = "Check",
                Location = new Point(guessTextBox.Right + 10, guessTextBox.Top)
            };
            checkButton.Click += CheckButton_Click;
            this.Controls.Add(statusLabel);
            this.Controls.Add(guessTextBox);
            this.Controls.Add(checkButton);
        }
        private void CheckButton_Click(object? sender, EventArgs e)
        {
           int number = int.Parse(guessTextBox.Text);
            CheckGuess(number);
            guessTextBox.Clear();
            guessTextBox.Focus();
        }
        private void StartNewGame()
        {
            Random random = new Random();
            secretNumber = random.Next(1, 101);
            attemptsLeft = 5;
            UpdateStatusLabel();
        }
        private void UpdateStatusLabel()
        {
            statusLabel.Text = $"Attempts left: {attemptsLeft}";
        }
        private void CheckGuess(int guess)
        {
            attemptsLeft--;
            UpdateStatusLabel();
            if (guess == secretNumber)
            {
                MessageBox.Show("You win");
                StartNewGame();
            }
            else if (attemptsLeft == 0)
            {
                MessageBox.Show("You lose");
                StartNewGame();
            }
            else if(guess < secretNumber)
            {
                MessageBox.Show("The number higher");
                StartNewGame();
            }
            else
            {
                MessageBox.Show("The number lower");
                StartNewGame();
            }
        }
    }
}

using System;
using System.Windows.Forms;
using Tic_Tac_Toe.Game.Backend;
using Tic_Tac_Toe.UI.GameField;
using Tic_Tac_Toe.Menu;
using Tic_Tac_Toe.Menu.Play;

namespace Tic_Tac_Toe
{
    public partial class MainWindow : Form
    {
        private Tic_Tac_Toe.Game.Backend.Game _game = new Tic_Tac_Toe.Game.Backend.Game();
        private PlayerMoveHandler _playerHandler;
        private Bot _bot;
        private GameField _gameField;
        private MenuUserControl _menuUserControl = new MenuUserControl();
        private PlayUserControl _playUserControl = new PlayUserControl();

        private string _previousUserControlName = null;
        private string _currentUserControlName = null;

        public MainWindow()
        {
            InitializeComponent();
            _menuUserControl.Dock = DockStyle.Fill;
            _playUserControl.Dock = DockStyle.Fill;

            _playUserControl.ReturnClicked += ShowPreviousUserControl;
            _menuUserControl.PlayClicked += () => SwitchScreen(_playUserControl);
            _playUserControl.ConfirmClicked += OnGameStart;

            panel1.Controls.Add(_menuUserControl);
        }

        // ����� ������ ����. ���� ������ ����� � ����� (gameMode == 1),
        // ��������� ������ Bot, ����� ���� ���� �������-�������.
        private void OnGameStart(int gameMode, int difficulty)
        {
            // ��� ������ � ����� ������ ���� 5x5, ����� 3x3.
            int size = gameMode == 0 ? 3 : 5;
            GameSettings settings = new GameSettings(size, difficulty);
            _game.StartGame(settings);

            // ������� ���������� ����� ������
            _playerHandler = new PlayerMoveHandler(_game);

            // ������������� �� ������� ���������� ���� (UI ����������� ���������������)
            _game.GameUpdated += (field) =>
            {
                _gameField?.UpdateField(field);
            };

            // ���� ������ ����� "������� ������ ����", ������� ����
            if (gameMode == 1)
            {
                _bot = new Bot(BotDifficulty.Hard);
                // ���� �����, ����� ��� ����� ������, ������������� �������� ������ � 'O'
                _game.SetStartingPlayer('O');
            }
            else
            {
                _bot = null;
            }

            // ������� � ����������� ������������ ������� ����
            _gameField = new GameField(size)
            {
                Dock = DockStyle.Fill
            };
            _gameField.CellClicked += OnCellClicked;
            SwitchScreen(_gameField);
            _gameField.UpdateField(_game.GetField());

            // ���� ��� ����� ������, ��������� ��� ���
            if (_bot != null && _game.CurrentPlayer == 'O')
            {
                MakeBotMove();
            }
        }

        // ��������� ����� �� ������ UI. ���������� ���������� ����� ������.
        private void OnCellClicked(object sender, CellClickEventArgs e)
        {
            // ������������ ��� ������, ���� ������ ��� ������� ('X')
            if (_game.CurrentPlayer == 'X')
            {
                if (_playerHandler.ProcessPlayerMove(e.Coordinates.X, e.Coordinates.Y))
                {
                    // ���� ���� ���� � ����� � ������ ������� ���� ('O'), ��������� ��� ���
                    if (_bot != null && _game.CurrentPlayer == 'O')
                    {
                        MakeBotMove();
                    }
                }
            }
        }

        // ����� ��� ���������� ���� �����.
        // ��� �������� ���������� ������ ���� � Game.SetMove ��������� ����.
        private void MakeBotMove()
        {
            var move = _bot.GetMove(_game.GetField(), 'O', 'X');
            _game.MakeMove(move.row, move.col);
        }

        private void ShowPreviousUserControl()
        {
            if (!string.IsNullOrEmpty(_previousUserControlName))
            {
                SwitchScreenByName(_previousUserControlName);
            }
        }

        private void SwitchScreen(UserControl newControl)
        {
            _previousUserControlName = _currentUserControlName;
            _currentUserControlName = newControl.GetType().Name;
            panel1.Controls.Clear();
            panel1.Controls.Add(newControl);
        }

        private void SwitchScreenByName(string userControlName)
        {
            switch (userControlName)
            {
                case nameof(MenuUserControl):
                    SwitchScreen(_menuUserControl);
                    break;
                case nameof(PlayUserControl):
                    SwitchScreen(_playUserControl);
                    break;
                case nameof(GameField):
                    if (_gameField != null)
                        SwitchScreen(_gameField);
                    break;
            }
        }

        public string PreviousUserControlName => _previousUserControlName;
        public string CurrentUserControlName => _currentUserControlName;

        private void Form1_Load(object sender, EventArgs e)
        {
            SwitchScreen(_menuUserControl);
        }
    }
}

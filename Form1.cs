using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace CatchButton
{
    public partial class Form1 : Form
    {
        // 재사용 난수 생성기
        private readonly Random rd = new Random();

        // 점수 및 게임 설정
        private int score = 0;
        private int missCount = 0;
        private const int ScoreHit = 100;
        private const int ScoreMiss = 10;
        private const int MaxMisses = 20;
        private const double ShrinkFactor = 0.9;
        private readonly Size MinButtonSize = new Size(40, 20);

        // 초기 상태 저장(다시시작에 사용)
        private Size initialButtonSize;
        private Point initialButtonLocation;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 초기값 저장
            initialButtonSize = runbutton.Size;
            initialButtonLocation = runbutton.Location;

            UpdateTitle();
        }

        // 클릭(성공) 처리: 점수 추가, 버튼 축소, 효과음 및 메시지 표시
        private void runbutton_Click(object sender, EventArgs e)
        {
            HandleCatch();
        }

        private void HandleCatch()
        {
            if (!runbutton.Enabled) return;

            // 잡았을 때 효과음
            SystemSounds.Asterisk.Play();

            // 점수 증가
            score += ScoreHit;

            // 버튼 크기 축소
            ShrinkButton();

            // 타이틀 갱신
            UpdateTitle();

            // 성공 메세지
            MessageBox.Show("축하합니다~!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 마우스가 버튼에 들어갈 때(도망갈 때): 점수 감소, 버튼 이동, 효과음
        private void runbutton_MouseEnter(object sender, EventArgs e)
        {
            if (!runbutton.Enabled) return;

            // 도망갈 때 효과음
            SystemSounds.Hand.Play();

            // 점수 감소 및 놓친 횟수 증가
            score -= ScoreMiss;
            missCount++;

            // 가용 영역 계산(버튼이 폼 테두리를 넘지 않게)
            int maxX = Math.Max(0, this.ClientSize.Width - runbutton.Width);
            int maxY = Math.Max(0, this.ClientSize.Height - runbutton.Height);

            int nextX = (maxX == 0) ? 0 : rd.Next(0, maxX);
            int nextY = (maxY == 0) ? 0 : rd.Next(0, maxY);

            runbutton.Location = new Point(nextX, nextY);

            UpdateTitle();

            // 게임 오버 체크
            if (missCount >= MaxMisses)
            {
                OnGameOver();
            }
        }

        // 게임 오버 처리: 메시지박스(다시시작 버튼 포함) 및 게임 비활성화
        private void OnGameOver()
        {
            // 게임오버 효과음
            SystemSounds.Exclamation.Play();

            var result = MessageBox.Show(
                "Game Over?",
                "Game Over~",
                MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Stop);

            if (result == DialogResult.Retry)
            {
                ResetGame();
            }
            else
            {
                DisableGamePlay();
            }
        }

        // 게임 관련 컨트롤 비활성화 (플레이 불가 상태)
        private void DisableGamePlay()
        {
            runbutton.Enabled = false;
            // 필요하면 다른 게임 관련 컨트롤도 비활성화
            // 단, '다시시작' 버튼은 사용자가 재시작하도록 활성화 상태로 둠
        }

        // 게임 정보 초기화 및 재시작
        private void ResetGame()
        {
            score = 0;
            missCount = 0;

            runbutton.Size = initialButtonSize;
            runbutton.Location = initialButtonLocation;
            runbutton.Enabled = true;

            UpdateTitle();
        }

        // '다시시작' 버튼을 폼에 두었고 클릭 시 이 핸들러가 실행됩니다.
        private void restartButton_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        // 버튼을 10% 축소, 최소 크기 보장 및 폼 영역 밖으로 벗어나지 않도록 보정
        private void ShrinkButton()
        {
            int newWidth = Math.Max(MinButtonSize.Width, (int)(runbutton.Width * ShrinkFactor));
            int newHeight = Math.Max(MinButtonSize.Height, (int)(runbutton.Height * ShrinkFactor));

            runbutton.Size = new Size(newWidth, newHeight);

            // 축소 후 폼 영역 내로 위치 보정
            int maxLeft = Math.Max(0, this.ClientSize.Width - runbutton.Width);
            int maxTop = Math.Max(0, this.ClientSize.Height - runbutton.Height);

            int left = Math.Min(runbutton.Left, maxLeft);
            int top = Math.Min(runbutton.Top, maxTop);

            runbutton.Location = new Point(Math.Max(0, left), Math.Max(0, top));
        }

        // 폼 타이틀에 점수, 놓친 횟수 및 버튼 좌표를 표시
        private void UpdateTitle()
        {
            this.Text = $"점수: {score}    놓친횟수: {missCount}/{MaxMisses}    버튼위치: ({runbutton.Location.X}, {runbutton.Location.Y})";
        }
    }
}

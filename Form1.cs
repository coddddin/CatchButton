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
        private const int ScoreHit = 100;
        private const int ScoreMiss = 10;
        private const double ShrinkFactor = 0.9;
        private readonly Size MinButtonSize = new Size(40, 20);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateTitle();
        }

        // 클릭(성공) 처리: 점수 추가, 버튼 축소, 효과음 및 메시지 표시
        private void runbutton_Click(object sender, EventArgs e)
        {
            HandleCatch();
        }

        private void HandleCatch()
        {
            // 잡았을 때 효과음
            SystemSounds.Asterisk.Play();

            // 점수 증가
            score += ScoreHit;

            // 버튼 크기 축소
            ShrinkButton();

            // 타이틀 갱신
            UpdateTitle();

            // 메시지 박스
            MessageBox.Show("축하합니다~!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 마우스가 버튼에 들어갈 때(도망갈 때): 점수 감소, 버튼 이동, 효과음
        private void runbutton_MouseEnter(object sender, EventArgs e)
        {
            // 도망갈 때 효과음
            SystemSounds.Hand.Play();

            // 점수 감소
            score -= ScoreMiss;

            // 가용 영역 계산(버튼이 폼 테두리를 넘지 않게)
            int maxX = Math.Max(0, this.ClientSize.Width - runbutton.Width);
            int maxY = Math.Max(0, this.ClientSize.Height - runbutton.Height);

            int nextX = (maxX == 0) ? 0 : rd.Next(0, maxX);
            int nextY = (maxY == 0) ? 0 : rd.Next(0, maxY);

            runbutton.Location = new Point(nextX, nextY);

            UpdateTitle();
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

        // 폼 타이틀에 점수(및 버튼 좌표)를 표시
        private void UpdateTitle()
        {
            this.Text = $"점수: {score}    버튼위치: ({runbutton.Location.X}, {runbutton.Location.Y})";
        }
    }
}

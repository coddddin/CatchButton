using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace CatchButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void runbutton_Click(object sender, EventArgs e)
        {
            // 잡았을 때 효과음 재생
            SystemSounds.Asterisk.Play();

            // 메시지박스 표시
            MessageBox.Show("축하합니다~!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void runbutton_MouseEnter(object sender, EventArgs e)
        {
            // 도망갈때 효과음 재생
            SystemSounds.Hand.Play();
            // 1. 난수 생성기 준비
            Random rd = new Random();

            // 2. 가용 영역 계산 (버튼이 폼 테두리에 걸리지 않게 보호)
            // 버튼 사이즈 만큼 여유를 둔 최대 좌표 계산
            int maxX = this.ClientSize.Width - 200;
            int maxY = this.ClientSize.Height - 50;

            // 3. 랜덤좌표추출(0 ~ 최대가용치사이)
            int nextX = rd.Next(0, maxX);
            int nextY = rd.Next(0, maxY);

            // 4. 위치할당: 존재하는 컨트롤인 'button1'의 위치 변경
            runbutton.Location = new Point(nextX, nextY);

            // 5. 시각적피드백(폼제목표시줄에좌표출력)
            this.Text = $"버튼위치: ({nextX}, {nextY})";
        }

        // 버튼 mousedown 시 효과음 재생과 메시지박스 표시
        private void runbutton_MouseDown(object sender, MouseEventArgs e)
        {
            // 잡았을 때 효과음 재생
            SystemSounds.Asterisk.Play();

            // 메시지박스 표시
            MessageBox.Show("축하합니다~!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

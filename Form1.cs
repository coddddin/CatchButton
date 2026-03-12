using System;
using System.Drawing;
using System.Windows.Forms;

namespace CatchButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
     
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            // 1. 난수 생성기 준비
            Random rd = new Random();
            
            // 2. 가용 영역 계산 (버튼이 폼 테두리에 걸리지 않게 보호)
            // ClientSize는 타이틀바와 테두리를 제외한 실제 흰도화지영역임
            int maxX = this.ClientSize.Width - 200;
            int maxY = this.ClientSize.Height - 50;
            
            // 3. 랜덤좌표추출(0 ~ 최대가용치사이)
            int nextX = rd.Next(0, maxX);
            int nextY = rd.Next(0, maxY);
            
            // 4. 위치할당: 존재하는 컨트롤인 'button1'의 위치 변경
            button1.Location = new Point(nextX, nextY);
            
            // 5. 시각적피드백(폼제목표시줄에좌표출력)
            this.Text = $"버튼위치: ({nextX}, {nextY})";
        }
    }
}

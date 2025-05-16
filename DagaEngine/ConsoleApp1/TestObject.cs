using DagaEngine;
using System.Diagnostics;
using System.Numerics;

namespace ConsoleApp1
{
    public class TestObject : DagaGameObject
    {
        private char[] _mouthShapes = ['ㅡ', 'ㅇ', 'ㅁ', '0'];

        private string _testString = "나는 그냥 테스트용 문장을 읽을 뿐이야.";
        private string _displayString = string.Empty;
        private int _displayIndex = 0;
        private float _displayTime = 0f;

        public float Speed { get; set; } = 2.0f;

        public override async Task InitializeAsync()
        {
        }

        public override async Task StartAsync()
        {
            Position = new Vector3(1, 0, 0);
        }

        public override async Task UpdateAsync()
        {
            if (_displayIndex < _testString.Length)
            {
                _displayTime += Speed * 10f * DagaTime.DeltaTime;
                if (_displayTime > 1f)
                {
                    _displayString += _testString[_displayIndex++];
                    _displayTime = 0f;
                    Debug.WriteLine($"{_displayString}\n\n\n\n\n\n\n\n\n");
                }
            }

        }
    }
}

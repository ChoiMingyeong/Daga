
namespace DagaEngine
{
    public abstract class DagaComponent : DagaObject
    {
        public bool Disable { get; set; } = false;

        private bool _isStop = false;

        public override Task StartAsync()
        {
            _isStop = false;

            if (Disable)
            {
                return Task.CompletedTask;
            }

            return base.StartAsync();
        }

        public override Task UpdateAsync()
        {
            if (Disable)
            {
                return Task.CompletedTask;
            }

            return _isStop ? Task.CompletedTask : base.UpdateAsync();
        }

        public void Stop()
        {
            _isStop = true;
        }
    }
}

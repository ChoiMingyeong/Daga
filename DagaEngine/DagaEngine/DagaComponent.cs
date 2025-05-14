
namespace DagaEngine
{
    public abstract class DagaComponent : DagaObject
    {
        private bool _isStop = false;

        public override Task StartAsync()
        {
            _isStop = false;
            return base.StartAsync();
        }

        public override Task UpdateAsync()
        {
            return _isStop ? Task.CompletedTask : base.UpdateAsync();
        }

        public void Stop()
        {
            _isStop = true;
        }
    }
}

namespace DagaDev
{

    public class IDBBindingData<T> where T : new()
    {
        private bool _dbLoad = false;
        private bool _isCommitted = false;
        protected bool _openTransaction = false;

        protected T? _transactionValue;
        protected T? _value = default;

        public T? Value
        {
            get
            {
                if (false == _dbLoad)
                {
                    _value = GetDBValue();
                    _dbLoad = true;
                }

                return _openTransaction ? _transactionValue : _value;
            }

            set
            {
                if (false == SetValue(value))
                {
                    throw new InvalidOperationException("DB set failed");
                }
                _value = value;
            }
        }

        protected virtual T? GetDBValue()
        {
            // todo : DB 테이블을 지정하고 값을 가져오는 작업
            // ...
            _value = new T();
            return _value;
        }

        protected virtual bool SetValue(T? value, bool openTransaction = false)
        {
            if (openTransaction)
            {
                _isCommitted = false;
                _openTransaction = true;
                _transactionValue = value;
            }
            else
            {
                _value = value;
                // todo : DB 테이블에 업데이트하는 작업
                return true;
            }

            return true;
        }

        public void Commit()
        {
            if (_isCommitted)
            {
                throw new InvalidOperationException("Already committed");
            }
            // todo : 트랜잭션 반영

        }
    }


}

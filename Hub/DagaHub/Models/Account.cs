using DagaHub.Identifiers;

namespace DagaHub.Models
{
    public class Account
    {
        /// <summary>
        /// DB에서 생성되는 AccountID
        /// </summary>
        public required AccountID ID { get; init; }

        /// <summary>
        /// 이 Account가 가입한 커뮤 리스트
        /// </summary>
        public List<Commu> CommnuList { get; set; } = [];
    }
}

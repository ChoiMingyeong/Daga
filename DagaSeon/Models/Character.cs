using DagaSeon.Identifiers;

namespace DagaSeon.Models
{
    public class Character
    {
        /// <summary>
        /// Account가 가진 CharacterID
        /// </summary>
        public required CharacterID ID { get; init; }

        /// <summary>
        /// 속해있는 커뮤 ID
        /// </summary>
        public CommuID CommuID { get; set; } = 0;

        /// <summary>
        /// 해당 캐릭터의 소스 위치
        /// </summary>
        public ulong SourceID { get; set; }
    }
}

namespace DagaCommuAPIServer.Model
{
    public class DagaCommunity(ulong communityID, byte dbIndex)
    {
        public readonly ulong CommunityID = communityID;

        private readonly byte DBIndex = dbIndex;
    }
}

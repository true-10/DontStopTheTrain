using UnityEngine;

namespace DontStopTheTrain
{
    [CreateAssetMenu(fileName = "PlayerItemStaticData", menuName = "DST/Items/PlayerItemStaticData")]
    public class PlayerItemStaticData : ItemStaticDataBase, IPlayerItemStaticData
    {
        public override ItemType Type => ItemType.Player;

        public PlayerItemType PlayerItemType => _playerItemType;

        [SerializeField, Min(0)]
        private PlayerItemType _playerItemType = PlayerItemType.Credits;
    }

    public interface IPlayerItemStaticData : IItemStaticData
    {
        PlayerItemType PlayerItemType { get; }
    }

    public enum PlayerItemType
    {
        Credits = 0,
        Expo = 1,
        Score = 2,
    }
}

using DontStopTheTrain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using True10.Interfaces;
using UniRx;
using Zenject;

namespace DontStopTheTrain
{
    /*
     * низкая мораль - уменьшает кол-во очков действия
     * 
     */

    public class BuffsController: IGameLifeCycle
    {
        [Inject]
        private PlayerBuffsManager _buffsManager;


        public void Initialize()
        {
        }

        public void Dispose()
        {
        }

        public int GetValue(PerkType perkType)
        {
            var buffs = _buffsManager.Items
                .Where(perk => perk.StaticData.Type == perkType)
                .ToList();

            if (buffs.Count == 0)
            {
                return 0;
            }

            return buffs.Sum(buff => buff.Value);
        }
    }
}

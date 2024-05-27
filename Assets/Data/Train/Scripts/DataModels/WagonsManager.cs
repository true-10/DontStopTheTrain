using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using True10.Managers;
using UnityEngine;

namespace DontStopTheTrain
{
    public class WagonsManager : DataManager<IWagon>
    {
        public Action<IWagon> OnFocus { get; set; }
        public IWagon SelectedWagon { get; private set; }
        public override void Initialize()
        {

        }

        public override void Dispose()
        {
            Clear();
        }

        public Locomotive GetLocomotive()
        {
            return Items.Where(wagon => wagon is Locomotive).FirstOrDefault() as Locomotive;
        }

        public void SetSelectedWagon(IWagon wagon)
        {
            SelectedWagon = wagon;
        }

        public override bool TryToAdd(IWagon item)
        {
            if (base.TryToAdd(item))
            {
                item.OnFocus += OnWagonFocus;
                return true;
            }
            return false;
        }

        public override bool TryToRemove(IWagon item)
        {
            if (base.TryToRemove(item))
            {
                item.OnFocus -= OnWagonFocus;
                return true;
            }
            return false;
        }

        private void OnWagonFocus(IWagon wagon)
        {
            Debug.Log("OnWagonFocus");
            OnFocus?.Invoke(wagon);
        }
    }

    public class WagonSystemsManager : DataManager<IWagonSystem>
    {
        public Action<IWagonSystem> OnFocus { get; set; }

        public override void Initialize()
        {

        }

        public override void Dispose()
        {
            Clear();
        }

        public override bool TryToAdd(IWagonSystem item)
        {
            if (base.TryToAdd(item))
            {
                item.OnFocus += OnSystemFocus;
                return true;
            }
            return false;
        }

        public override bool TryToRemove(IWagonSystem item)
        {
            if (base.TryToRemove(item))
            {
                item.OnFocus -= OnSystemFocus;
                return true;
            }
            return false;
        }

        private void OnSystemFocus(IWagonSystem system)
        {
            Debug.Log("OnSystemFocus");
            OnFocus?.Invoke(system);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradePartData", menuName = "DST/partsData/UpgradeData")]
public class TrainPartData : ScriptableObject
{
    //тип вагона (пассажирский, грузовой, локомотив, мастерская(?) ) на который можно поставить?
    [SerializeField] public int _price          {get; private set;}//
    [SerializeField] public string _name        {get; private set;}//
    [SerializeField] public string _description {get; private set;}//
    [SerializeField] public Sprite _icon        {get; private set;}//thumbnail


    [SerializeField] public float _deterioration { get; private set; }//износ 



}

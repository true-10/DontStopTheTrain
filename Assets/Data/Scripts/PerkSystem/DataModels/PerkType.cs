namespace DontStopTheTrain
{
    public enum PerkType
    {
        None = 0,
        ActionMan = 1, //добавляем очки опыта
        Experience = 2, //множитель опыта
        Credits = 3, //множитель денег
        Score = 4, //множитель очков

        Seller = 5,//торговец - снижаем цены на покупки
        ReducePriceActionPoint = 6,
        ReducePriceResource = 7, //все ресурсы
        ReducePriceCredit = 8,//только кредиты


        //ремонтник - снижаем цену за ремонт
        RepairMan = 10,
        RepairService = 11, //хозяюшка - - износ оборудования замедляется//BusinessExecutive //хозяйственник


        //BoostBuf = 10, //ускорение - баф
    }
}

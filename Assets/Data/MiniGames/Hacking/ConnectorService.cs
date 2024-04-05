namespace DontStopTheTrain.MiniGames
{
    public class ConnectorService
    {
        public static bool IsConnected(HackingElement elementA, HackingElement elementB)
        {
            //тут есть баг
            //если елементА с имеет левый и правый коннекторы
            //а элементБ верхний и правый,
            //то вернет тру, хотя они не соединены
            if (elementA.ConnectorA == GetOpposite(elementB.ConnectorA) ||
                 elementA.ConnectorA == GetOpposite(elementB.ConnectorB) || 
                 elementA.ConnectorB == GetOpposite(elementB.ConnectorA) ||
                 elementA.ConnectorB == GetOpposite(elementB.ConnectorB))
            {
                return true;
            }
            return false;
        }

        public static ConnectorPosition GetOpposite(ConnectorPosition connector)
        {
            switch (connector)
            {
                case ConnectorPosition.Right:
                    return ConnectorPosition.Left;
                case ConnectorPosition.Bottom:
                    return ConnectorPosition.Top;
                case ConnectorPosition.Left:
                    return ConnectorPosition.Right;
                case ConnectorPosition.Top:
                    return ConnectorPosition.Bottom;
            }
            return connector;
        }
    }
}

using System;

namespace DontStopTheTrain.MiniGames
{
    public class HackingElement
    {
        public Action<HackingElement> OnRotate { get; set; }
        public ConnectorPosition ConnectorA => _connectorA;
        public ConnectorPosition ConnectorB => _connectorB;

        public HackingElement(ConnectorPosition connectorA, ConnectorPosition connectorB)
        {
            _connectorA = connectorA;
            _connectorB = connectorB;
        }

        private ConnectorPosition _connectorA;
        private ConnectorPosition _connectorB;

        public void Rotate()
        {
            _connectorA = RotateConnector(_connectorA);
            _connectorB = RotateConnector(_connectorB);
            OnRotate?.Invoke(this);
        }

        //clockwise
        private ConnectorPosition RotateConnector(ConnectorPosition connector)
        {
            switch (connector)
            {
                case ConnectorPosition.Right:
                    return ConnectorPosition.Bottom;
                case ConnectorPosition.Bottom:
                    return ConnectorPosition.Left;
                case ConnectorPosition.Left:
                    return ConnectorPosition.Top;
                case ConnectorPosition.Top:
                    return ConnectorPosition.Right;
            }
            return connector;
        }
    }
}

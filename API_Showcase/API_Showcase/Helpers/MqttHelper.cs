using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using MQTTnet.Client;

namespace API_Showcase.Helpers;

public static class MqttHelper
{
    public static MqttClientOptions GetClientOptions()
    {
        string broker = "";
        int port = 8883;
        string clientId = Guid.NewGuid().ToString();
        string username = "";
        string password = "";

        // Create MQTT client options
        var options = new MqttClientOptionsBuilder()
            .WithTcpServer(broker, port)
            .WithCredentials(username, password)
            .WithClientId(clientId)
            .WithCleanSession()
            .WithTlsOptions(
                builder =>
                {
                    var certificate = X509CertificateLoader.LoadCertificateFromFile("./emqxsl-ca.crt");
                    builder.WithCertificateValidationHandler(_ => true);
                    builder.WithSslProtocols(SslProtocols.Tls12);
                    builder.WithClientCertificates(new[] { certificate });
                }
            )
            .Build();

        return options;
    }
}
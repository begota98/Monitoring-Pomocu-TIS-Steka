using API_Showcase.Helpers;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;

namespace API_Showcase.Services;

public class EmqxService
{
    private readonly IMqttClient _mqttClient;
    public EmqxService()
    {
        var factory = new MqttFactory();
        this._mqttClient = factory.CreateMqttClient();
        this.Connect();
    }

    private void Connect()
    {
        if (this._mqttClient.IsConnected) return;
        
        var connectResult = this._mqttClient.ConnectAsync(MqttHelper.GetClientOptions()).Result;

        if (connectResult.ResultCode == MqttClientConnectResultCode.Success)
        {
            Console.WriteLine("Connected to MQTT broker successfully.");
        }
        else
        {
            throw new Exception("Could not connect to MQTT broker.");
        }
    }

    public Task PublishMessageAsync(byte[] payload, string topic)
    {
        var message = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(payload)
            .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
            .WithRetainFlag()
            .Build();

        return this._mqttClient.PublishAsync(message);
    }

    public Task DisconnectAsync()
    {
        return this._mqttClient.DisconnectAsync();
    }
 
}
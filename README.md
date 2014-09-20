Testing that an asynchronous event was raised can sometimes be tricky, and once you’ve actually figured out *how* to test that an asynchronous event was raised, the solution is usually monotonous.


Enter **EventMonitor**. EventMonitor is a small library that allows for more expressive and succinct syntax when writing tests against systems who raises asynchronous events.



```C#
[Fact]
public void ServerChannel_ChannelEstablished_RaisesEvent()
{
    // Setup
    ServerChannel channel = new ServerChannel();
    channel.Start(50);

    // Exercise
    Action exercise = () =>
    {
        Socket client = SocketFactory.CreateTcpSocket();
        client.Connect(port: 50);
    };

    // Verify
    EventMonitor.AssertRaised(exercise, handler => channel.ChannelEstablished += handler);
}
```


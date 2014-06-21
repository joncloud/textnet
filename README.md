textnet
=======
Simple text messaging API

Sample
------
Add the following using directive: `using TextNet;`

Sending a message:

    string phone = "1234567890";
    string message = "Hello World!";
    string carrier = Carriers.US.Att;
    var text = new TextMessage(phone, message, carrier);
    await text.SendAsync();

# ANUPayments

 this is a warpaer for UPayment payment api , package will handel most of the hard work 


# Installing / Getting Started

- Install the package from nuguet 

### configure app in startup.cs

- defining your api configration
```
   var configuration = new ApiConfiguration()
            {
                Company = "Test",
                Mode = Mode.Staging,
                Password = "test",
                UserName = "test",
                ApiSecretKeyStaging = "jtest123",
                MerchantId = "1201",
                XHeaderAuthorization = "hWFfEkzkYE1X691J4qmcuZHAoet7Ds7ADhL",
                ApiSecretKeyLive = "jtest123"
            };
           

```
- if you want to use the charge apis add the following to your startup.cs
```
 services.AddTransient<IPaymentRequest, PaymentRequest>((func) => new PaymentRequest(configuration));
```

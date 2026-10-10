# NSwag

1. Uruchom `Examples/04-Kiota/WeatherAPI`.
2. Sprawdź dokument OpenAPI pod adresem `/swagger/v1/swagger.json`.
3. Uruchom NSwag z plikiem `nswag.json`.
4. Nie edytuj ręcznie katalogu `Generated`.
5. Napisz testy klienta z podstawionym `HttpMessageHandler`.

Konfiguracja jest przykładem dydaktycznym. W produkcji adres kontraktu powinien
być wersjonowany i kontrolowany w CI.

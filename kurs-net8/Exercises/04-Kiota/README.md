# 4. Kiota — klient C# generowany z kontraktu OpenAPI

## Wprowadzenie

Klient HTTP napisany ręcznie szybko zaczyna zawierać powtarzalne adresy,
serializację, obsługę błędów i typy DTO. Kiota generuje warstwę komunikacji z
kontraktu OpenAPI. Nie rozwiązuje problemu złego kontraktu — tylko konsekwentnie
go powiela — dlatego zaczynamy od API i jego dokumentu.

## Materiały

- serwer: `Examples/04-Kiota/WeatherAPI`;
- klient: `Examples/04-Kiota/WeatherKiota`;
- ćwiczenia: `Exercises/04-Kiota/README.md`;
- kontrakt: `/swagger/v1/swagger.json` po uruchomieniu serwera.

## Cele

Student potrafi:

- odróżnić kontrakt od kodu wygenerowanego;
- wygenerować klienta C# na podstawie OpenAPI;
- skonfigurować `HttpClient` i base URL;
- obsłużyć błąd HTTP, anulowanie i zmianę kontraktu;
- nie edytować ręcznie wygenerowanych plików;
- przetestować kod aplikacji bez prawdziwej sieci.

## Przygotowanie

Uruchom serwer:

```powershell
dotnet run --project Examples/04-Kiota/WeatherAPI
```

Sprawdź dokument pod adresem pokazanym przez ASP.NET Core, np.
`https://localhost:7191/swagger/v1/swagger.json`. Jeżeli certyfikat deweloperski
nie jest zaufany, użyj lokalnej konfiguracji HTTPS albo adresu HTTP.

Zainstaluj Kiotę zgodnie z instrukcją narzędzia i sprawdź:

```powershell
kiota --help
```

Wygeneruj klienta do osobnego katalogu, np. `Generated`, korzystając z dokumentu
OpenAPI. Składnia może zależeć od wersji CLI, dlatego parametry sprawdź przez
`kiota generate --help`; istotne są język C#, dokument wejściowy, namespace i
katalog wyjściowy.

## Co jest generowane, a co piszemy sami?

| Element | Właściciel | Reguła |
|---|---|---|
| modele ścieżek i requestów | Kiota | nie edytuj ręcznie |
| transport HTTP | Kiota/runtime | aktualizuj razem z generatorem |
| konfiguracja base URL | aplikacja | trzymaj w options/config |
| retry, logowanie, polityka błędów | aplikacja | nie ukrywaj w DTO |
| mapowanie do modelu domenowego | aplikacja | nie mieszaj z kodem generated |

## Laboratorium

### Etap A — kontrakt

1. Otwórz Swagger UI i dokument JSON.
2. Wypisz operacje, parametry, odpowiedzi sukcesu i błędu.
3. Wskaż, których informacji klient nie powinien zgadywać.

### Etap B — generowanie

1. Wygeneruj klienta do katalogu oznaczonego jako generated.
2. Dodaj klienta do projektu albo do osobnej biblioteki.
3. Nie zmieniaj plików wygenerowanych.
4. Uruchom klienta z `WeatherKiota`.
5. Zapisz wersję kontraktu i polecenie generowania.

### Etap C — odporność

Dodaj kod aplikacyjny, który:

- przekazuje `CancellationToken`;
- rozróżnia 404, 429 i 5xx;
- nie loguje sekretów i pełnych nagłówków autoryzacji;
- nie ponawia automatycznie operacji, która nie jest idempotentna;
- mapuje odpowiedź klienta na prosty model używany przez resztę aplikacji.

### Etap D — test

Zastąp `HttpMessageHandler` fake'iem. Przygotuj odpowiedzi 200, 404 i 500.
Test ma sprawdzać zachowanie kodu aplikacji, a nie serializację wygenerowanego
pliku.

## Kryteria ukończenia

- klient generuje się powtarzalnie;
- kod wygenerowany i ręczny są rozdzielone;
- istnieje test bez sieci;
- obsłużono co najmniej dwa błędy HTTP;
- opisano, co się stanie po zmianie kontraktu.

## Rozszerzenie

Zmień kontrakt serwera w sposób kompatybilny i niekompatybilny. Wygeneruj
klienta ponownie, porównaj diff i opisz, która zmiana wymaga wersjonowania API.

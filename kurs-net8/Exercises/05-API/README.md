# 5. NSwag i dobre praktyki API

## Wprowadzenie

API jest umową między niezależnymi kodami. Nazwa endpointu i kod HTTP nie są
detalem implementacji: są częścią kontraktu, który konsumują klienci, testy i
narzędzia generujące kod.

Przykład znajduje się w `Examples/05-API/ApiBestPractices`, a konfiguracja
NSwag w `Examples/05-API/nswag.json`.

## Cele

Student potrafi:

- zaprojektować spójne zasoby i odpowiedzi;
- używać `200`, `201`, `204`, `400`, `404`, `409`, `422` i `500` zgodnie z
  semantyką operacji;
- walidować dane i zwracać `ProblemDetails`;
- rozdzielić model wejściowy, domenowy i wyjściowy;
- wygenerować klienta NSwag;
- uwzględnić anulowanie, idempotencję, wersjonowanie i bezpieczeństwo;
- przetestować kontrakt API bez ręcznego klikania w Swagger UI.

## Przykład bazowy

W projekcie istnieją:

```text
POST /api/orders       -> 201 Created albo 400 ValidationProblem
GET  /api/orders/{id}  -> 200 OK albo 404 NotFound
```

`CreateOrderRequest` nie jest tym samym co `OrderResponse`. Dzięki temu klient
nie może przypadkowo ustawiać `Id` albo `Status`.

## Tabela decyzji HTTP

| Sytuacja | Odpowiedź | Dlaczego |
|---|---|---|
| utworzenie zamówienia | 201 + Location | klient zna nowy zasób |
| poprawny odczyt | 200 | wynik jest w body |
| brak zasobu | 404 | identyfikator nie wskazuje zasobu |
| niepoprawny request | 400/422 | klient może poprawić dane |
| konflikt stanu | 409 | żądanie jest syntaktycznie poprawne |
| błąd serwera | 500 + ProblemDetails | nie ujawniaj stack trace klientowi |

## Laboratorium krok po kroku

### Etap A — kontrakt

1. Uruchom `ApiBestPractices`.
2. Sprawdź OpenAPI/Swagger.
3. Wyślij poprawny POST i zachowaj odpowiedź.
4. Wyślij pustego klienta i ujemne `Total`.
5. Sprawdź, czy błąd zawiera pole i czy nie zawiera danych wrażliwych.

### Etap B — rozbudowa zasobu

Dodaj:

- `DELETE /api/orders/{id}` z `204` albo `404`;
- `PUT` lub `PATCH` z jawnie opisanym znaczeniem;
- filtrowanie i limitowanie listy;
- `CancellationToken` w operacjach asynchronicznych;
- korelację żądania w logach.

### Etap C — odporność i bezpieczeństwo

Sprawdź:

- limit rozmiaru body;
- walidację długości tekstu i zakresów liczbowych;
- brak ujawniania wyjątków i connection stringów;
- bezpieczne logowanie danych klienta;
- rozróżnienie uwierzytelnienia i autoryzacji;
- politykę CORS tylko dla znanych originów;
- idempotencję ponawianych żądań.

### Etap D — NSwag

1. Uruchom serwer z kontraktem.
2. Otwórz `nswag.json` i wyjaśnij każdą sekcję.
3. Wygeneruj `WeatherApiClient.cs` do katalogu `Generated`.
4. Nie edytuj wygenerowanego pliku.
5. Napisz mały adapter aplikacyjny, który korzysta z klienta.
6. Dodaj test adaptera z podstawionym handlerem HTTP.

## Definition of Done

- każdy endpoint ma opisany sukces i błędy;
- walidacja jest wykonywana przed logiką domenową;
- błąd ma jednolity kształt;
- klient wygenerowany z NSwag działa po odtworzeniu projektu;
- przynajmniej trzy scenariusze są pokryte testem HTTP;
- decyzje dotyczące bezpieczeństwa są zapisane w README ćwiczenia.

## Rozszerzenie

Dodaj wersję `/api/v2`, zachowując kompatybilność z v1. Przygotuj tabelę zmian
breaking/non-breaking i wygeneruj oba klienty.

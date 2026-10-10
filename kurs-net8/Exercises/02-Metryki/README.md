# 2. Metryki — jak znaleźć hotspot, a nie wystawić ocenę kodowi

## Wprowadzenie

Metryka nie mówi, że kod jest dobry albo zły. Mówi, gdzie warto zadać pytanie.
W tym module pracujemy na `Examples/02-Metryki/SupermarketReceipt`, ponieważ
ma on reguły rabatowe, kilka odpowiedzialności, rozgałęzienia i testy.

## Cele

Student potrafi:

- wyjaśnić LOC, cyclomatic complexity, coupling, cohesion i coverage;
- sformułować hipotezę przed uruchomieniem narzędzia;
- połączyć wynik metryki z konkretnym fragmentem kodu;
- odróżnić hotspot techniczny od uzasadnionej złożoności domenowej;
- przygotować raport przed/po zmianie;
- wskazać ograniczenia coverage i automatycznych code smells.

## Przygotowanie

```powershell
dotnet test Examples/02-Metryki/SupermarketReceipt.Tests/SupermarketReceipt.Test.csproj
dotnet build Examples/02-Metryki/SupermarketReceipt/SupermarketReceipt.csproj
```

W Visual Studio można użyć `Analyze > Calculate Code Metrics`. W Riderze lub
ReSharperze użyj inspekcji projektu i diagramu zależności. Coverage uruchom
tylko po tym, jak testy bazowe są zielone. Wyniki wpisuj do
`Exercises/02-Metryki/RAPORT.md`.

## Co mierzymy?

| Metryka | Pytanie | Ryzyko błędnej interpretacji |
|---|---|---|
| LOC | ile kodu trzeba przeczytać? | krótki kod może być nieczytelny |
| złożoność cyklomatyczna | ile ścieżek trzeba rozważyć? | rozgałęzienie może być domenowo konieczne |
| coupling | ile elementów zna klasa? | nie każde zależności są złe |
| cohesion | czy elementy klasy należą do jednej całości? | metryka nie zna granic domeny |
| coverage | ile kodu wykonują testy? | wykonanie linii nie sprawdza asercji |
| code smells | jakie wzorce ryzyka wykryto? | narzędzie nie rozumie intencji |

## Przykład: `ShoppingCart.HandleOffers`

Przeczytaj metodę przed pomiarem. Zaznacz iterację po produktach, powtarzane
wyszukiwanie w słowniku, wybór typu oferty, obliczanie rabatu, tworzenie
`Discount` i formatowanie ceny. To jest więcej niż jedna odpowiedzialność.

Nie oznacza to jednak, że należy natychmiast rozbić metodę na dziesięć klas.
Najpierw zmierz, napisz hipotezę i wybierz jedną zmianę, która zmniejsza ryzyko.

## Laboratorium krok po kroku

### Etap 1 — hipoteza

Przed użyciem narzędzia odpowiedz:

1. Która klasa będzie hotspotem?
2. Który fragment jest najtrudniejszy do przetestowania?
3. Jakie ryzyko biznesowe niesie zmiana rabatów?

### Etap 2 — pomiar bazowy

1. Uruchom testy.
2. Zmierz projekt w konfiguracji `Debug`.
3. Zanotuj wartości dla `ShoppingCart`, `Teller`, `Receipt`.
4. Uruchom analizę code smells.
5. Zapisz narzędzie, wersję i konfigurację — bez tego wynik jest trudny do
   porównania.

### Etap 3 — triangulacja

Nie wybieraj klasy wyłącznie po jednej liczbie. Połącz trzy sygnały:

```text
wysoka złożoność + częste zmiany + trudne testy = silny kandydat do refaktoryzacji
```

Jeśli klasa ma wysoką złożoność, ale jest stabilna, dobrze przetestowana i
reprezentuje jedną regułę domenową, może pozostać bez zmian.

### Etap 4 — jedna refaktoryzacja

Wybierz jedną z opcji:

- wydziel kalkulator rabatu;
- zastąp powtarzane wyszukiwanie `TryGetValue`;
- nazwij regułę rabatową;
- rozdziel obliczenie od zapisania `Discount`.

Nie zmieniaj jednocześnie algorytmu i struktury danych. Po zmianie uruchom
testy, ponów pomiar i opisz, czy poprawa była rzeczywista.

### Etap 5 — raport

Wypełnij `Exercises/02-Metryki/RAPORT.md`. Raport bez interpretacji wyników i
bez opisu ograniczeń nie jest zaliczeniem.

## Kryteria ukończenia

- jest hipoteza sprzed pomiaru;
- są wyniki co najmniej trzech metryk;
- wskazany hotspot ma uzasadnienie w kodzie;
- refaktoryzacja ma testy przed i po;
- raport wyjaśnia, dlaczego coverage nie jest miarą jakości samą w sobie.

## Rozszerzenia

- porównaj `Debug` i `Release`;
- dodaj mutation testing i sprawdź, czy testy wykrywają zmienioną regułę rabatu;
- zbuduj diagram zależności i omów kierunek sprzężeń;
- ustal próg ostrzeżenia, ale nie ustawiaj wszystkich ostrzeżeń jako błędów
  bez analizy kosztu migracji.

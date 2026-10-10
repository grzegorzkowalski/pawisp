# Szablon raportu z analizy metryk

## 1. Zakres pomiaru

- projekt i commit:
- narzędzie oraz wersja:
- konfiguracja builda (`Debug`/`Release`):
- analizowane klasy:

## 2. Hipoteza przed pomiarem

Zanim uruchomisz narzędzie, wskaż klasę, która prawdopodobnie ma największy
koszt utrzymania. Uzasadnij to liczbą odpowiedzialności, rozgałęzieniami,
sprzężeniem i trudnością testowania.

## 3. Wyniki

| Element | LOC | cyclomatic complexity | coupling | coverage | interpretacja |
|---|---:|---:|---:|---:|---|
| `ShoppingCart` | | | | | |
| `Teller` | | | | | |
| `Receipt` | | | | | |

## 4. Decyzja

Opisz jeden hotspot, który warto zmienić teraz, oraz jeden wynik, którego nie
wolno traktować jako automatycznego nakazu refaktoryzacji.

## 5. Weryfikacja

- testy przed zmianą:
- wykonana zmiana:
- testy po zmianie:
- wpływ na zachowanie:
- nowe ostrzeżenia lub usunięte ostrzeżenia:

## 6. Ograniczenia

Metryka jest sygnałem do rozmowy. Sama długość metody, liczba klas ani coverage
nie mówi, czy kod spełnia wymagania biznesowe. Zapisz, jakie informacje zostały
poza pomiarem.

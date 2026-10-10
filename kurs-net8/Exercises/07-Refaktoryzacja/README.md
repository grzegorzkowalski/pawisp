# 7. Wprowadzenie do bezpiecznej refaktoryzacji

## Wprowadzenie

Refaktoryzacja zmienia strukturę kodu bez zmiany obserwowalnego zachowania.
Najważniejszym narzędziem nie jest skrót IDE, lecz mały krok, test ochronny i
czytelny diff. Projekt `Exercises/07-Refaktoryzacja` jest celowo prosty, aby
student mógł przećwiczyć cały cykl.

## Cykl pracy

```text
zachowanie -> test ochronny -> jedna zmiana -> test -> diff -> następna zmiana
```

Nie zaczynaj od projektowania końcowej architektury. Najpierw zabezpiecz to, co
kod robi dzisiaj, także jeśli obecne zachowanie jest niedoskonałe.

## Laboratorium: `OrderProcessor`

Kod startowy w `Starter/OrderProcessor.cs` łączy obliczenie dostawy, wysyłanie
powiadomień i przejście statusu. Test sprawdza podstawową ścieżkę.

### Etap A — charakterystyka

1. Uruchom test z `Exercises/07-Refaktoryzacja/Tests`.
2. Dopisz test dla `Express`.
3. Dopisz test dla nieznanego typu zamówienia.
4. Dopisz test dla pustego lub ujemnego `amount` i zdecyduj, czy takie dane są
   dozwolone.
5. Zapisz aktualne zachowanie, zanim je zmienisz.

### Etap B — małe kroki

Wykonuj kolejno:

1. nadaj nazwę regule kosztu dostawy;
2. wydziel przejście statusu;
3. wydziel port powiadomień;
4. zastąp stringi typami lub stałymi, jeśli zakres domeny jest zamknięty;
5. wprowadź zależności przez konstruktor;
6. dopiero wtedy rozważ Strategy lub State.

Po każdym kroku uruchom testy. Jeżeli test nie daje sygnału, dopisz go przed
kolejną zmianą.

## Testy ochronne i testy projektowe

Test ochronny mówi „wynik nadal jest taki sam”. Test projektowy może później
sprawdzać, że osobno da się przetestować `ShippingCostCalculator`. Nie mieszaj
tych celów w jednym teście.

## Kryteria ukończenia

- istnieją testy dla każdej obsługiwanej ścieżki;
- każda zmiana jest mała i możliwa do cofnięcia;
- `OrderProcessor` nie odpowiada za transport powiadomień;
- kod wynikowy ma mniej ukrytych decyzji;
- student pokazuje diff i opisuje kompromis.

## Druga ścieżka — kata Gilded Rose

Pełny starter znajduje się w `Exercises/07-Refaktoryzacja/GildedRose`, a testy w
`GildedRose.Tests`. Pracuj zgodnie z tym samym cyklem:

1. uruchom istniejące testy charakterystyki;
2. dodaj brakujące przypadki brzegowe;
3. zastosuj guard clauses;
4. wydziel reguły dla zwykłych przedmiotów, Aged Brie i backstage passes;
5. napraw regułę Conjured i zmień test charakterystyki na test wymagania;
6. dopiero po stabilizacji rozważ strategie `IItemStrategy`;
7. po każdej zmianie uruchom testy i porównaj output.

## Pytania kontrolne

1. Czy refaktoryzacja może poprawić projekt i jednocześnie zachować bug?
2. Kiedy test charakterystyki jest lepszy od ręcznego przepisywania oczekiwań?
3. Jak rozpoznać, że wprowadzenie wzorca nastąpiło za wcześnie?

# 6. Testowanie — testy, które chronią zachowanie

## Wprowadzenie

Test nie jest tylko wywołaniem metody z asercją. Dobry test opisuje zachowanie,
ma czytelny układ Arrange–Act–Assert i daje szybki, wiarygodny sygnał po zmianie.
Moduł korzysta z `AssertClass`, `ObjectMother`, `TestDataBuilder` i
`Specification` w `Examples/06-Testowanie`.

## Cele

- rozróżnić test jednostkowy, integracyjny i kontraktowy;
- pisać testy nazwane zachowaniem;
- dobierać dane bez nadmiernego szumu;
- użyć Object Mother i Buildera bez tworzenia globalnej fabryki wszystkiego;
- rozpoznać kruchą asercję i test implementacji;
- testować błędy, granice i niepoprawne dane.

## Przykłady wzorców danych

### Object Mother

`ReservationMother` daje gotowe scenariusze, np. rezerwację anulowaną lub
gotową do zameldowania. Używaj go, gdy scenariusz ma nazwę biznesową i jest
stabilnym punktem wielu testów.

### Test Data Builder

`UserBuilder` pozwala zmienić jedną cechę bez powtarzania wszystkich wartości:

```csharp
var inactiveUser = new UserBuilder()
    .WithEmail("inactive@example.com")
    .Inactive()
    .Build();
```

Builder nie powinien ukrywać istotnych danych testu. Jeżeli email jest ważny,
zostaw go jawnie w teście.

### Assert Class

`AccountAssert` centralizuje kilka asercji dotyczących jednego obiektu. To ma
sens, kiedy te same reguły pojawiają się w wielu testach. Nie twórz asercji,
która maskuje, co naprawdę jest sprawdzane.

### Specification

`Specification` pokazuje składanie warunków `And`, `Or`, `Not`. Traktuj go jako
narzędzie do nazwanych reguł, nie jako obowiązkową abstrakcję dla każdego `if`.

## Laboratorium

### Etap A — test bazowy

1. Uruchom wszystkie testy.
2. Przeczytaj `ReservationServiceTests` i wskaż dane, które są istotne.
3. Wprowadź celową zmianę w regule zameldowania i zobacz, który test ją wykrywa.
4. Cofnij zmianę.

### Etap B — przypadki brzegowe

Dopisz testy dla:

- pustego imienia;
- rezerwacji anulowanej;
- daty zameldowania dzisiaj, wczoraj i jutro;
- nieopłaconej rezerwacji, jeśli reguła tego wymaga;
- użytkownika nieaktywnego;
- złożonej specyfikacji `expensive.And(inStock)`.

### Etap C — jakość testu

Dla dwóch testów przygotuj trzy wersje nazwy i wybierz najlepszą. Następnie
usuń jedną asercję, która sprawdza implementację zamiast zachowania, i opisz
dlaczego test nadal ma sens albo dlaczego nie.

### Etap D — testy negatywne

Dodaj asercje na wyjątki i komunikaty tylko wtedy, gdy komunikat jest częścią
umowy. Nie sprawdzaj pełnego stack trace ani kolejności logowania, jeśli klient
nie zależy od tych szczegółów.

## Kryteria ukończenia

- testy są niezależne i powtarzalne;
- każdy nowy test ma jedną główną przyczynę niepowodzenia;
- dane testowe nie ukrywają warunku badanego w teście;
- są scenariusze sukcesu, granicy i błędu;
- student umie uzasadnić użycie albo brak użycia Buildera.

## Rozszerzenie

Dodaj test integracyjny z pamięciowym repozytorium oraz test kontraktowy dla
endpointu API. Porównaj koszt i wartość obu testów.

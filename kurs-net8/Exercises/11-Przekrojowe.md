# 11. Tematy przekrojowe — jakość utrzymywana po zajęciach

Ten moduł łączy wszystkie wcześniejsze tematy w praktykę zespołową.

## Przepływ pracy

1. wymaganie i kryteria akceptacji;
2. mała zmiana na branchu;
3. test ochronny;
4. analiza metryk i code smells;
5. build oraz testy w CI;
6. review drugiej osoby;
7. decyzja: przyjąć, poprawić albo odrzucić zmianę.

## Code review

Recenzja ma odpowiadać na pytania o zachowanie, bezpieczeństwo, testowalność,
kontrakt API i koszt utrzymania. Komentarz „nie podoba mi się” zastąp dowodem:
testem, metryką, wymaganiem albo regułą zespołu.

## Quality gates

Minimum dla kursu:

- `dotnet build` bez błędów;
- wszystkie testy zielone;
- brak sekretów w repozytorium;
- wygenerowany kod oddzielony od ręcznego;
- diff ma opis i nie zawiera niepowiązanego formatowania.

Skrypt `scripts/verify.ps1` automatyzuje restore, build i test głównej solucji.

## Bezpieczeństwo

W API i klientach sprawdź walidację wejścia, logowanie, dane wrażliwe,
uprawnienia, limity i obsługę błędów. W DI sprawdź lifetime i współdzielony stan.
W AI sprawdź, czy prompt lub kod nie ujawnia sekretów.

## Projekt zaliczeniowy

Wybierz jedną małą aplikację i pokaż pełny cykl:

- kontrakt API lub interfejs aplikacji;
- minimum dwie zależności wstrzykiwane przez konstruktor;
- testy jednostkowe i co najmniej jeden test integracyjny;
- raport metryk przed/po;
- minimum dwa naprawione smells;
- jeden wzorzec uzasadniony problemem;
- opis użycia AI albo świadomej decyzji o jego nieużyciu;
- review i instrukcję uruchomienia.

# Ćwiczenie 11 — warsztat przekrojowy i jakość dostarczania

## Cel

To ćwiczenie łączy cały kurs w jeden cykl pracy zespołowej: wymaganie,
implementację, test, pomiar, refaktoryzację, review i decyzję o wdrożeniu.
Nie chodzi o stworzenie dużej aplikacji. Chodzi o pokazanie, że dobre praktyki
działają razem i ograniczają ryzyko zmiany.

## Zadanie

Wybierz mały fragment aplikacji, np. rejestrację zamówienia, kalkulację dostawy
albo prosty endpoint. Opisz wymaganie w 5–8 zdaniach i dodaj kryteria akceptacji.
Następnie:

1. zaprojektuj kontrakt wejścia i wyjścia;
2. wstrzyknij minimum dwie zależności przez konstruktor;
3. napisz testy jednostkowe oraz minimum jeden test integracyjny lub HTTP;
4. zmierz jeden hotspot przed zmianą;
5. wskaż minimum dwa code smells i napraw je małymi krokami;
6. zastosuj jeden wzorzec tylko wtedy, gdy problem uzasadnia jego koszt;
7. uruchom build, testy i analizator;
8. wykonaj code review diffu przez inną osobę;
9. zapisz decyzję: przyjąć, poprawić albo odrzucić zmianę.

## Minimalny pakiet oddawany

- instrukcja uruchomienia;
- kryteria akceptacji i przykładowe dane;
- testy z nazwami opisującymi zachowanie;
- raport metryk przed/po;
- tabela smells: dowód, koszt, poprawka;
- uzasadnienie wzorca i prostszej alternatywy;
- diff po review oraz lista uwag przyjętych i odrzuconych;
- informacja, czy użyto AI, oraz zapis kontroli wygenerowanego kodu.

## Quality gates

- `dotnet build` bez błędów;
- wszystkie testy zielone;
- brak sekretów i danych wrażliwych w repozytorium;
- walidacja wejścia i przewidywalne błędy API;
- wygenerowany kod oddzielony od ręcznie pisanego;
- brak niepowiązanego formatowania w diffie.

## Pytania do obrony

1. Które wymaganie zabezpiecza każdy test?
2. Co konkretnie pokazała metryka i czego nie potrafiła pokazać?
3. Który smell można było zostawić i dlaczego?
4. Jaki koszt wprowadził wybrany wzorzec?
5. Jak zmiana zachowa się przy błędzie, ponowieniu żądania i anulowaniu?

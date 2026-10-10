# Wzorce projektowe aplikacji — kurs .NET 8

To jest nowa, uporządkowana wersja kursu. Materiał jest ułożony według
procesu pracy nad kodem:

1. dobre praktyki;
2. metryki;
3. dependency injection;
4. Kiota;
5. NSwag i dobre praktyki API;
6. testowanie;
7. wprowadzenie do refaktoryzacji;
8. code smells;
9. wzorce projektowe;
10. AI-assisted development;
11. bezpieczeństwo, code review, CI i utrzymanie jakości.

## Struktura paczki studenckiej

```text
Exercises/  jedyna ścieżka pracy: instrukcja + kroki + kryteria + pliki startowe
Examples/   działające przykłady używane w instrukcjach ćwiczeń
Tests/      testy ochronne i testy pomocnicze
Extras/     dodatkowe wzorce dla chętnych
```

Rozwiązania, plan prowadzącego, klucze odpowiedzi i materiały oceniania są poza
tym katalogiem, w `kurs-net8-prowadzacy`. Dzięki temu paczka może zostać
udostępniona studentom bez przypadkowego ujawnienia odpowiedzi.

## Solucje

- `WzorceProjektoweKurs.sln` — rdzeń kursu;
- `MaterialyDodatkowe.sln` — opcjonalne wzorce dla chętnych.

## Wymagania

- .NET SDK 8;
- Visual Studio, Rider albo VS Code;
- Docker opcjonalnie do ćwiczeń API;
- dostęp do lokalnego repozytorium, bez wymaganych kluczy do zewnętrznych API.

## Sposób pracy

Student zaczyna od [`Exercises/README.md`](Exercises/README.md), wybiera kolejny
moduł i wykonuje wszystkie kroki w jego `README.md`. Przykłady z `Examples` są
otwierane dokładnie w miejscach wskazanych w instrukcji, a `Extras` nie są
wymagane do zaliczenia. Rozwiązanie referencyjne udostępnia prowadzący dopiero
po zakończeniu pracy.

# 10. AI-assisted development — narzędzie z kontrolą jakości

## Wprowadzenie

AI może przyspieszyć eksplorację, ale nie jest źródłem prawdy o wymaganiach,
bezpieczeństwie ani jakości. W tym module student uczy się prowadzić AI przez
testy i ograniczenia, a potem samodzielnie oceniać wynik.

## Cele

- napisać prompt zawierający kontekst, ograniczenia i kryteria akceptacji;
- poprosić AI o diagnozę przed propozycją kodu;
- zweryfikować wygenerowane rozwiązanie testami i diffem;
- rozpoznać halucynowane API, nadmiarowe wzorce i ryzyko bezpieczeństwa;
- zachować ślad decyzji: prompt, wynik, odrzucone propozycje, finalny kod.

## Zasada pięciu kroków

```text
zrozum wymaganie -> poproś o hipotezy -> napisz test -> wygeneruj mały diff
-> uruchom narzędzia i wykonaj review
```

## Ćwiczenie 1 — diagnoza code smells

Użyj startera z modułu 08. Prompt powinien zawierać:

```text
Przeanalizuj ten kod. Nie zmieniaj go. Wypisz smells, dowody w kodzie,
ryzyko biznesowe, proponowany test ochronny i trzy możliwe refaktoryzacje.
Nie proponuj wzorca bez wskazania prostszej alternatywy.
```

Porównaj odpowiedź AI z własną diagnozą. Odrzuć wskazania, których nie da się
potwierdzić fragmentem kodu.

## Ćwiczenie 2 — testy

Poproś o testy dla `OrderProcessor`. Sprawdź:

- czy testy obejmują granice i błędy;
- czy nie sprawdzają implementacji zamiast zachowania;
- czy nie używają prawdziwej sieci, czasu ani losowości;
- czy nazwy opisują regułę.

## Ćwiczenie 3 — refaktoryzacja

Pozwól AI zaproponować jeden mały diff. Przed akceptacją odpowiedz:

1. Czy zachowanie jest zabezpieczone testem?
2. Czy diff zmienia publiczny kontrakt?
3. Czy dodaje zależność lub sekret?
4. Czy można wyjaśnić każdą nową klasę?
5. Czy analizator i testy potwierdzają poprawę?

## Ćwiczenie 4 — AI i wzorzec

Poproś AI o dwie wersje rozwiązania: prostą oraz opartą na Strategy. Porównaj
koszt obu i wybierz rozwiązanie na podstawie liczby wariantów, częstotliwości
zmian i testowalności, nie na podstawie nazwy wzorca.

## Bezpieczeństwo pracy

Nie wklejaj do zewnętrznego narzędzia kluczy, haseł, danych osobowych ani
prywatnego kodu bez zgody. Każdy kod AI przechodzi lokalnie przez build, testy,
analizator i review. AI nie może być jedynym recenzentem własnego kodu.

## Kryteria ukończenia

- student oddaje prompt, odpowiedź i finalny diff;
- wskazuje minimum trzy błędy lub ryzyka w propozycji AI;
- wszystkie przyjęte zmiany mają test albo uzasadnienie braku testu;
- potrafi odrzucić efektownie wyglądające, lecz nadmiarowe rozwiązanie.

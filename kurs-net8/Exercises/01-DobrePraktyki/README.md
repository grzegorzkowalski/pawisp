# 1. Dobre praktyki — czytelność, odpowiedzialności i decyzje projektowe

## Po co ten moduł?

Na początku kursu nie uczymy się jeszcze wzorców. Najpierw uczymy się rozpoznać
problem w kodzie i nazwać koszt, który ten problem powoduje. Wzorzec jest jedną
z możliwych odpowiedzi, ale często najlepszą poprawą jest prostsza nazwa,
krótsza metoda, właściwy typ danych albo usunięcie niepotrzebnej abstrakcji.

Materiał bazuje na `Examples/01-DobrePraktyki/GoodAndBadStandards`. Katalog
zawiera celowo nierówny przykład: część kodu jest poprawna, a część ma służyć
do dyskusji i analizy ostrzeżeń kompilatora.

## Cele uczenia się

Po zajęciach student potrafi:

- odróżnić błąd formatowania od problemu projektowego;
- nazwać naruszenie SRP, OCP, DIP, DRY, KISS, YAGNI lub prawa Demeter;
- poprawić kod bez zmiany zachowania;
- uzasadnić, kiedy nie warto wprowadzać dodatkowej abstrakcji;
- używać nullable reference types, enkapsulacji i małych typów zamiast komentarzy;
- przeprowadzić review oparte na dowodach, a nie na preferencjach stylistycznych.

## Przygotowanie

W katalogu `kurs-net8` uruchom:

```powershell
dotnet build WzorceProjektoweKurs.sln -m:1
dotnet run --project Examples/01-DobrePraktyki/GoodPractices.Examples
```

Przed zmianami zapisz ostrzeżenia z projektu oraz wykonaj `git diff`, aby każda
zmiana była później możliwa do przejrzenia.

## Przykład do wspólnej analizy

W `BadCode.cs` znajdź następujące problemy:

```csharp
public int _value;
public string txtName;

public void DoSomething()
{
    for (var i = 0; i < 1000; i++)
    {
        var productCode = $"PRC000{i}";
        var value = GetDataValue();
    }
}
```

Nie wystarczy powiedzieć „to jest brzydkie”. Opisz skutek:

| Obserwacja | Koszt | Mała poprawa |
|---|---|---|
| publiczne pola | każdy kod może złamać stan obiektu | prywatne pola i właściwości |
| `txtName` | nazwa nie mówi o znaczeniu | `name` lub nazwa domenowa |
| nieużywany `productCode` | szum i fałszywa intencja | usunięcie albo użycie w logice |
| `100 / DateTime.Now.Second` | błąd zależny od czasu | jawna reguła i test |
| metoda robi wiele rzeczy | trudne testowanie | wydzielenie odpowiedzialności |

Porównaj to z `GoodCode.cs`: nazwa metody i parametrów jest lepsza, ale nawet
tam analizator może znaleźć elementy wymagające rozmowy. „Good” nie oznacza
„niepodlegający review”.

## Laboratorium: popraw kod bez wzorców

### Etap A — diagnoza

1. Otwórz `BadCode.cs` i `GoodCode.cs`.
2. W tabeli zapisz minimum 12 obserwacji.
3. Przy każdej obserwacji dodaj naruszoną zasadę, skutek i najmniejszą możliwą
   zmianę.
4. Oddziel problemy pewne od preferencji, np. „wolę var” nie jest defektem.

### Etap B — bezpieczne poprawki

Wykonuj zmiany pojedynczo i po każdej zmianie buduj projekt:

1. popraw nazwy pól, parametrów i metod;
2. usuń martwy kod i nieużywane importy;
3. schowaj stan obiektu za właściwością lub metodą;
4. rozdziel klasę danych od operacji na pliku;
5. zastąp magiczne liczby nazwanymi stałymi;
6. napraw obsługę wartości null;
7. popraw implementację `IDisposable`, jeżeli obiekt rzeczywiście posiada zasób;
8. nie wprowadzaj interfejsu tylko po to, aby zwiększyć liczbę plików.

### Etap C — review

Przygotuj diff i przeprowadź review w parach. Recenzent odpowiada na pytania:

- czy zachowanie publiczne pozostało takie samo?
- czy nowa nazwa opisuje regułę biznesową?
- czy klasa ma jedną spójną odpowiedzialność?
- czy poprawa zmniejszyła sprzężenie, czy tylko przeniosła kod?
- czy test lub przykład wykonania potwierdza decyzję?

## Kryteria ukończenia

- raport zawiera minimum 12 diagnoz;
- co najmniej 8 zmian jest małych i niezależnych;
- kod buduje się bez błędów;
- student potrafi obronić dwie decyzje, w których nie zastosował wzorca;
- diff nie zawiera niepowiązanej zmiany formatowania całego repozytorium.

## Pytania kontrolne

1. Czy każda duża klasa łamie SRP?
2. Kiedy DRY szkodzi, bo łączy dwa przypadki, które dopiero wyglądają podobnie?
3. Dlaczego publiczne pola utrudniają późniejszą zmianę reprezentacji danych?
4. Czym różni się „kod działa” od „kod ma czytelną intencję”?
5. Jak udowodnisz, że refaktoryzacja nie zmieniła zachowania?

## Rozszerzenie

Dodaj analizator stylu do projektu, ustaw jedną regułę jako błąd w CI i opisz,
dlaczego pozostałych ostrzeżeń nie naprawiasz jeszcze. To przygotowuje grunt pod
moduł metryk i późniejsze quality gates.

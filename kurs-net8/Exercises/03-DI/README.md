# 3. Dependency Injection — od ręcznego composition root do kontenera .NET

## Wprowadzenie

Dependency Injection nie oznacza „użyj kontenera”. Oznacza, że obiekt otrzymuje
rzeczy, których potrzebuje, zamiast samodzielnie je tworzyć. Dzięki temu kod ma
jawne zależności, łatwiej go testować, a wybór implementacji znajduje się w
jednym miejscu — composition root.

Materiał obejmuje dwa warianty:

- ręczne wstrzykiwanie w `ManualCompositionRoot.cs`;
- automatyczną rejestrację w `Program.cs` przez `ServiceCollection`.

## Cele

Po module student potrafi:

- rozpoznać ukryte `new` jako zależność utrudniającą testowanie;
- zastosować constructor injection bez service locatora;
- zbudować obiekty ręcznie w composition root;
- użyć `Microsoft.Extensions.DependencyInjection`;
- dobrać lifetime: transient, scoped, singleton;
- wyjaśnić, dlaczego singleton z mutowalnym stanem może być błędem;
- napisać test z fake lub stubem bez uruchamiania kontenera.

## Kod wyjściowy

Interfejs i klasy znajdują się w `Examples/03-DI/DiExamples/Program.cs`:

```csharp
public interface ILogger
{
    void Log(string message);
}

public sealed class Worker(ILogger logger)
{
    public void DoWork() => logger.Log("Worker completed work.");
}
```

`Worker` nie tworzy loggera. Zależność jest widoczna w konstruktorze i może być
podstawiona w teście.

## Wariant 1 — ręczne wstrzykiwanie

Uruchom `ManualCompositionRoot.Run()` w `ManualCompositionRoot.cs`:

```csharp
var logger = new InMemoryLogger();
var worker = new Worker(logger);
worker.DoWork();
```

To jest pełnoprawny DI. Kontener nie jest warunkiem stosowania wzorca. Ręczna
wersja jest przejrzysta dla małej aplikacji, ale przy wielu zależnościach może
stać się powtarzalna.

## Wariant 2 — kontener .NET

W `Program.cs` znajduje się composition root:

```csharp
var services = new ServiceCollection();
services.AddSingleton<ILogger, InMemoryLogger>();
services.AddTransient<Worker>();

using var provider = services.BuildServiceProvider();
var worker = provider.GetRequiredService<Worker>();
```

Kontener zna mapowania, ale `Worker` nadal zna tylko `ILogger`. Nie przenoś
`IServiceProvider` do klasy biznesowej. Wywołanie `GetRequiredService` poza
composition root byłoby service locatorem.

## Laboratorium

### Etap A — antyprzykład

Dodaj tymczasowo klasę:

```csharp
public sealed class BadWorker
{
    public void DoWork()
    {
        var logger = new InMemoryLogger();
        logger.Log("Worker completed work.");
    }
}
```

Odpowiedz, dlaczego nie da się łatwo sprawdzić, czy logowanie zadziałało, bez
przechwytywania wyjścia lub zmiany kodu klasy.

### Etap B — ręczny composition root

1. Zostaw `Worker` zależny od `ILogger`.
2. Utwórz `ConsoleLogger` i `InMemoryLogger` jako dwie implementacje.
3. Zbuduj wariant produkcyjny ręcznie.
4. Zbuduj wariant testowy z `InMemoryLogger`.
5. Nie dodawaj `if (test)` do klasy `Worker`.

### Etap C — kontener

1. Zarejestruj `ConsoleLogger` jako `ILogger`.
2. Dodaj `Worker` jako transient.
3. Sprawdź, że dwa pobrania `Worker` zwracają różne obiekty.
4. Zmień logger na singleton i sprawdź, co dzieje się z jego stanem.
5. Dodaj drugą zależność, np. `IClock`, a następnie przetestuj ją fake'iem.

### Etap D — test

W `Tests/03-DI/DiExamples.Tests/WorkerTests.cs` dopisz test komunikatu, test
liczby wywołań oraz test potwierdzający, że `Worker` nie tworzy loggera sam.
Testuj klasę bez kontenera. Kontener testuj osobnym, małym testem rejestracji,
jeżeli chcesz sprawdzić composition root.

## Lifetime — ćwiczenie decyzyjne

| Zależność | Propozycja | Pytanie kontrolne |
|---|---|---|
| logger bez stanu użytkownika | singleton | czy jest bezpieczny w wielu wątkach? |
| handler żądania HTTP | scoped | czy stan ma żyć tylko podczas żądania? |
| lekki formatter | transient | czy utworzenie obiektu jest tanie? |
| cache mutowalny | do uzasadnienia | kto kontroluje synchronizację? |

## Kryteria ukończenia

- istnieją działające warianty ręczny i kontenerowy;
- `Worker` nie tworzy loggera;
- testy używają fake'a, nie prawdziwego pliku ani konsoli;
- student potrafi wskazać composition root;
- potrafi wyjaśnić, dlaczego service locator utrudnia analizę zależności.

## Pytania kontrolne

1. Czy interfejs zawsze poprawia projekt?
2. Kiedy ręczne DI jest lepsze od kontenera?
3. Co złego może wyniknąć z singletona z listą komunikatów?
4. Czy test kontenera zastępuje test klasy biznesowej?
5. Jak rozpoznać, że klasa ma zbyt wiele zależności?

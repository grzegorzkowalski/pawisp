# 8. Code smells — laboratorium diagnozy i naprawy

To nie jest jedno ćwiczenie z dwiema klasami. To laboratorium składa się z
czterech poziomów i 24 zadań. Pracujemy na kodzie z `GoodAndBadStandards`,
`SupermarketReceipt`, starterze tego modułu, Gilded Rose i przykładach wzorców.
Każdy smell najpierw opisujemy dowodem, potem zabezpieczamy testem, a dopiero
na końcu naprawiamy. Nie usuwaj zapachu przez zmianę zachowania bez decyzji.

## Zasady laboratorium

Do każdego zadania oddaj tabelę: fragment, smell, koszt, test ochronny, najmniejsza
zmiana, ryzyko i decyzja „naprawić teraz / odłożyć / odrzucić”. Wzorzec nie jest
automatycznym lekarstwem. Jeśli proponujesz Strategy, Builder albo Facade,
musisz pokazać prostszą alternatywę.

## Poziom 1 — rozpoznawanie i dowody

### Zadanie 1 — katalog zapachów w dobrym i złym kodzie

Przeczytaj `Examples/01-DobrePraktyki/GoodAndBadStandards/BadCode.cs` oraz
`GoodCode.cs`. Znajdź minimum 15 obserwacji. Uwzględnij publiczne pola,
nieznaczące nazwy, martwy kod, magiczne liczby, zależność od czasu, klasy
wewnętrzne, błędny typ danych, puste implementacje i organizację namespace.
Oddziel błąd od preferencji stylistycznej.

### Zadanie 2 — mapa kosztu

Każdą obserwację z zadania 1 przypisz do kosztu: zmiana wymagań, testowanie,
debugowanie, onboarding, bezpieczeństwo albo wydajność. Wskaż trzy smells,
które można świadomie zostawić, jeśli kod jest stabilny i dobrze zabezpieczony.

### Zadanie 3 — mechaniczny czy projektowy?

Podziel 20 fragmentów na: formatowanie, błąd kompilacji, bug, smell projektu,
problem domenowy. Uzasadnij, dlaczego `var`, długość pliku i liczba klas nie są
same w sobie dowodem złego projektu.

### Zadanie 4 — analiza narzędzi

Uruchom analizator IDE/ReSharper/Rider na `BadCode.cs`, `ShoppingCart` i
`GildedRose`. Porównaj ostrzeżenia z własną diagnozą. Zapisz minimum pięć
fałszywych alarmów lub problemów, których narzędzie nie rozpoznało.

## Poziom 2 — pojedyncze smells i małe poprawki

Kod startowy znajduje się w `Starter/Smells.cs` i `Starter/SmellCases.cs`.
Przed każdą zmianą dopisz test charakterystyki. Po każdej zmianie uruchom testy.

### Zadanie 5 — Long Parameter List i Primitive Obsession

`ProductManager.RegisterProduct` przyjmuje nazwę, kategorię, cenę i ilość.
Wprowadź nazwany `ProductInfo` albo obiekt parametrów. Zachowaj dokładny format
wyjściowy. Porównaj ten ruch z samym dodaniem komentarza.

### Zadanie 6 — Duplicate Code

`Logger.Error` i `Logger.Warning` powtarzają formatowanie. Wydziel regułę tak,
aby poziom logowania nadal był jawny. Nie twórz bezimiennego `StringUtils`.

### Zadanie 7 — Long Method

W `SmellCases.OrderProcessor` znajdź metodę, która waliduje, nalicza rabat,
zmienia status i tworzy komunikat. Wydziel metody według decyzji biznesowych,
nie według liczby linii. Testy muszą pokryć zamówienie puste, rabat i błąd.

### Zadanie 8 — magic numbers i stringi statusów

Zastąp `0`, `50`, `100` oraz statusy tekstowe nazwanymi regułami lub enumem.
Uzasadnij, czy enum poprawia model, czy tylko maskuje niejasność.

### Zadanie 9 — null i wyjątek jako sterowanie

W `SmellCases.CustomerDirectory` napraw zwracanie `null` w kilku miejscach.
Wybierz jawny wynik, wyjątek albo pustą kolekcję zależnie od kontraktu. Dodaj
test dla braku klienta i niepoprawnego identyfikatora.

### Zadanie 10 — martwy kod i komentarz jako dezodorant

Usuń nieużywaną metodę, zakomentowany blok i komentarz opisujący nieczytelny
warunek. Zastąp komentarz nazwą metody lub poprawą struktury. W raporcie zapisz,
jak upewniłeś się, że kod jest martwy.

### Zadanie 11 — Data Class / anemiczna domena

W `SmellCases.StockItem` przenieś regułę zmiany ilości do obiektu domenowego.
Zabroń zejścia poniżej zera. Nie przenoś do klasy wszystkich operacji systemu.

### Zadanie 12 — Feature Envy

Znajdź metodę, która odczytuje pięć pól `Customer` i podejmuje decyzję poza nim.
Przenieś zachowanie do właściwego obiektu albo wyjaśnij, dlaczego koordynator
powinien je zachować.

### Zadanie 13 — Switch Explosion

W `SmellCases.NotificationSender` rozbuduj switch o trzeci kanał, a następnie
porównaj mapę funkcji, prosty switch i Strategy. Wybierz rozwiązanie na podstawie
częstotliwości zmian, nie nazwy wzorca.

### Zadanie 14 — Speculative Generality

Usuń nieużywany interfejs, fabrykę z jedną implementacją i generyczny parametr,
który nie ma drugiego wariantu. Zapisz, kiedy taka abstrakcja zaczęłaby mieć sens.

### Zadanie 15 — Shotgun Surgery

Dodaj pole `Currency` do `Price`. Zobacz, w ilu miejscach trzeba zmienić kod.
Zaprojektuj jeden punkt odpowiedzialności, ale nie buduj pełnego frameworka.

### Zadanie 16 — God Class

W `SmellCases.LegacyOrderApplication` rozdziel wejście, reguły zamówienia,
repozytorium i powiadomienia. Wydziel maksymalnie cztery odpowiedzialności.
Porównaj z `wpa/OrderWorkshop` i wskaż, czego nie należy przenosić bez testów.

## Poziom 3 — smells w istniejących przykładach

### Zadanie 17 — SupermarketReceipt

W `Examples/02-Metryki/SupermarketReceipt` wskaż odpowiedzialności
`ShoppingCart.HandleOffers`. Wydziel jedną regułę rabatową, zachowując testy i
porównaj metryki przed/po.

### Zadanie 18 — Gilded Rose

W `Exercises/07-Refaktoryzacja/GildedRose` wykonaj characterization tests,
guard clauses, Extract Method i dopiero potem rozważ Strategy. Napraw `Conjured`
bez zmiany reguł Aged Brie, Sulfuras i Backstage passes.

### Zadanie 19 — dobre praktyki IDisposable

Porównaj `Worker` i `UnitOfWork` w przykładzie dobrego kodu. Wskaż, które
elementy implementacji `IDisposable` są potrzebne dla zarządzanych zasobów,
a które są szablonowym szumem. Nie dodawaj finalizera bez zasobu natywnego.

### Zadanie 20 — test smells

Przeanalizuj `ObjectMother`, `TestDataBuilder`, `AssertClass` i `Specification`.
Znajdź nadmierne dane, test zależny od kolejności, zbyt szeroką asercję i
duplikację setupu. Napraw minimum dwa test smells.

### Zadanie 21 — API smells

W `Examples/05-API/ApiBestPractices` znajdź brak walidacji, niejednolite błędy,
przeciek szczegółów i niejawny kontrakt statusu. Dodaj testy HTTP przed zmianą.

### Zadanie 22 — Singleton i globalny stan

Przeanalizuj `Extras/WzorceProjektowe/Singleton-sample` oraz `SingletonVault`.
Pokaż test, który psuje się przez współdzielony stan. Zastąp singleton kompozycją
albo uzasadnij jego ograniczony zakres.

## Poziom 4 — refaktoryzacja PR

### Zadanie 23 — naprawa sekwencyjna

Wybierz minimum cztery smells z różnych grup. Utwórz cztery małe commity:
testy ochronne, poprawa nazewnictwa/kształtu, zmiana odpowiedzialności, końcowe
uproszczenie. Każdy commit musi się budować.

### Zadanie 24 — review i regresja

Przygotuj diff przed/po. Druga osoba ma wskazać trzy ryzyka. Dodaj test regresyjny
na największe ryzyko i odpowiedz, który smell świadomie pozostawiasz.

## Kod krok po kroku — ścieżka ratunkowa

Jeśli utkniesz, kopiuj kod z bieżącej sekcji etapami. Po każdym kroku uruchom
testy i dopiero potem przejdź dalej. Zadania 1–4 są raportowe, więc dostają
gotowy szablon artefaktu zamiast sztucznej implementacji.

### Zadania 1–4 — szablon diagnozy

```csharp
public sealed record SmellObservation(
    string Location, string Smell, string Evidence, string Risk,
    string SuggestedChange, bool FixNow);

var report = new List<SmellObservation>
{
    new("OrderProcessor.Process", "Long Parameter List",
        "5 parametrów opisuje jeden przypadek użycia", "błędna kolejność argumentów",
        "OrderRequest", true)
};
```

Skopiuj rekord dla każdej obserwacji, uzupełnij dowód z kodu, ryzyko i decyzję.
W zadaniu 4 dodaj wynik analyzera jako osobną kolumnę — nie traktuj ostrzeżenia
narzędzia jako automatycznej decyzji projektowej.

### Zadanie 5 — Parameter Object

```csharp
public sealed record OrderRequest(string Customer, string Country,
    string Payment, decimal Total, int Items);
public interface IDiscountRule { decimal Calculate(OrderRequest request); }
public sealed class PolandDiscount : IDiscountRule
{
    public decimal Calculate(OrderRequest request)
        => request.Country == "PL" ? request.Total * .05m : 0m;
}
public sealed class CleanProcessor(IEnumerable<IDiscountRule> rules)
{
    public decimal Process(OrderRequest request)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(request.Customer);
        return request.Total - rules.Sum(rule => rule.Calculate(request));
    }
}
```

Najpierw dodaj rekord i test starego wyniku, potem przenieś kolejne reguły do
`IDiscountRule`. Nie zmieniaj formatu wyniku w tym samym commicie.

### Zadanie 6 — Duplicate Code

```csharp
public sealed class Logger(ILogSink sink)
{
    public void Error(string text, DateTime at) => Write("ERROR", text, at);
    public void Warning(string text, DateTime at) => Write("WARNING", text, at);
    private void Write(string level, string text, DateTime at)
        => sink.Write($"{level}: [{at:yyyy-MM-dd HH:mm:ss}] {text}");
}
public interface ILogSink { void Write(string text); }
```

Zastąp prawdziwą konsolę `ListLogSink` w teście i zachowaj identyczny format.

### Zadanie 7 — Long Method

```csharp
public decimal Calculate(Order order)
{
    Validate(order);
    var subtotal = order.Items.Sum(x => x.Price * x.Quantity);
    var discount = order.IsPreferred ? subtotal * .1m : 0m;
    return subtotal - discount + (order.Items.Count == 0 ? 0m : 10m);
}
private static void Validate(Order order) => ArgumentNullException.ThrowIfNull(order);
```

W kolejnym kroku wydziel `CalculateSubtotal`, `CalculateDiscount` i
`CalculateShipping`; po każdym wydzieleniu uruchom test charakterystyki.

### Zadanie 8 — magic numbers i statusy

```csharp
public static class OrderRules
{
    public const decimal PreferredDiscount = .10m;
    public const decimal StandardShipping = 10m;
}
public enum OrderStatus { Accepted, InProgress, Shipped, Cancelled }
```

Zastępuj tylko wartości, które są pojęciami domenowymi. Nie twórz magazynu
`Constants` dla przypadkowych wartości technicznych.

### Zadanie 9 — null i wyjątki

```csharp
public sealed class CustomerDirectory(IReadOnlyDictionary<int, Customer> data)
{
    public Customer? Find(int id) => data.GetValueOrDefault(id);
}
public sealed record Customer(int Id, string Name);
```

Dodaj test braku klienta i osobny test błędu repozytorium. Nie zamieniaj wyjątku
infrastruktury na `null`.

### Zadanie 10 — dead code

```csharp
public sealed class PriceCalculator
{
    public decimal Calculate(decimal price, bool preferred)
        => preferred ? price * .9m : price;
}
```

Najpierw wyszukaj referencje (`rg`), potem usuń martwy kod. Komentarz opisujący
regułę biznesową zastąp nazwą metody lub decyzją w raporcie.

### Zadanie 11 — anemiczny `StockItem`

```csharp
public sealed class StockItem(string sku, int quantity)
{
    public string Sku { get; } = sku;
    public int Quantity { get; private set; } = quantity;
    public void ChangeQuantity(int delta)
    {
        if (Quantity + delta < 0) throw new InvalidOperationException("Negative stock");
        Quantity += delta;
    }
}
```

Dodaj walidację konstruktora oraz trzy testy: zwiększenie, zmniejszenie i zejście
poniżej zera.

### Zadanie 12 — Feature Envy

```csharp
public sealed record CustomerProfile(string Name, bool IsPreferred)
{
    public decimal ApplyDiscount(decimal total) => IsPreferred ? total * .9m : total;
}
```

Przenieś zachowanie tylko wtedy, gdy rzeczywiście używa danych tego obiektu.

### Zadanie 13 — Switch Explosion

```csharp
public interface IMessageChannel { string Send(string to, string body); }
public sealed class EmailChannel : IMessageChannel
{ public string Send(string to, string body) => $"email:{to}:{body}"; }
public sealed class SmsChannel : IMessageChannel
{ public string Send(string to, string body) => $"sms:{to}:{body}"; }
public sealed class Notifications(IReadOnlyDictionary<string, IMessageChannel> map)
{
    public string Send(string kind, string to, string body)
        => map.TryGetValue(kind, out var channel)
            ? channel.Send(to, body) : throw new ArgumentException("Unsupported channel");
}
```

Najpierw zmierz, czy switch dla dwóch wariantów jest problemem. Mapę wprowadź,
gdy trzeci wariant rzeczywiście zwiększa liczbę zmian.

### Zadanie 14 — Speculative Generality

```csharp
public sealed class CsvPriceReader
{
    public decimal Read(string value) => decimal.Parse(value);
}
```

Usuń abstrakcję z jednym użyciem. Dodaj ją ponownie dopiero przy drugim źródle.

### Zadanie 15 — Shotgun Surgery

```csharp
public readonly record struct Money(decimal Amount, string Currency)
{
    public Money Add(Money other)
    {
        if (Currency != other.Currency) throw new InvalidOperationException("Currency mismatch");
        return new(Amount + other.Amount, Currency);
    }
}
```

Zamień powtarzane pary `decimal` i `currency`, a następnie policz zmienione pliki.

### Zadanie 16 — God Class

```csharp
public sealed class OrderApplication(IOrderStore store, IOrderNotification notice, IIdGenerator ids)
{
    public Guid Create(string customer, decimal total)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(customer);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(total);
        var id = ids.Next(); store.Save(id, customer, total); notice.Created(id); return id;
    }
}
```

Wstrzyknij trzy granice, ale nie twórz interfejsu dla każdej prywatnej metody.

### Zadanie 17 — `ShoppingCart`

```csharp
public interface IDiscountPolicy
{ decimal DiscountFor(IReadOnlyCollection<CartLine> lines); }
public sealed class ShoppingCart(IDiscountPolicy policy)
{
    private readonly List<CartLine> _lines = [];
    public void Add(CartLine line) => _lines.Add(line);
    public decimal Total => _lines.Sum(x => x.Price * x.Quantity) - policy.DiscountFor(_lines);
}
public sealed record CartLine(string Sku, decimal Price, int Quantity);
```

Zachowaj testy cen przed wydzieleniem polityki.

### Zadanie 18 — Gilded Rose

```csharp
public static class QualityRules
{
    public static int Decrease(int value, int amount = 1) => Math.Max(0, value - amount);
    public static int Increase(int value, int amount = 1) => Math.Min(50, value + amount);
}
```

Najpierw zamroź charakterystykę testami, potem wydziel reguły `Aged Brie`,
`Backstage passes` i `Conjured`. Nie zmieniaj zwykłego przedmiotu.

### Zadanie 19 — zasoby

```csharp
public sealed class UnitOfWork(IDbConnection connection) : IDisposable
{
    public void Commit() => connection.Commit();
    public void Dispose() => connection.Dispose();
}
public interface IDbConnection : IDisposable { void Commit(); }
```

Implementuj `IDisposable` tylko dla zasobu posiadanego przez obiekt.

### Zadanie 20 — test data builder

```csharp
public sealed class OrderBuilder
{
    private string _customer = "Ada"; private decimal _total = 100m;
    public OrderBuilder For(string value) { _customer = value; return this; }
    public OrderBuilder Worth(decimal value) { _total = value; return this; }
    public TestOrder Build() => new(_customer, _total);
}
public sealed record TestOrder(string Customer, decimal Total);
```

Używaj buildera tylko dla danych drugorzędnych; różnice istotne dla testu zapisz
wprost w jego treści.

### Zadanie 21 — API smells

```csharp
app.MapPost("/orders", (CreateOrder request) => request.Total <= 0
    ? Results.ValidationProblem(new Dictionary<string, string[]>
        { [nameof(request.Total)] = ["Total must be positive"] })
    : Results.Created($"/orders/{Guid.NewGuid()}", request));
public sealed record CreateOrder(string Customer, decimal Total);
```

Dodaj testy `201`, `400`, `404` i jeden kontrakt błędu.

### Zadanie 22 — globalny czas

```csharp
public interface IClock { DateTime UtcNow { get; } }
public sealed class FakeClock(DateTime value) : IClock
{ public DateTime UtcNow => value; }
public sealed class ExpirationService(IClock clock)
{ public bool IsExpired(DateTime date) => date <= clock.UtcNow; }
```

Testuj przez `FakeClock`, nie przez modyfikację statycznego pola.

### Zadania 23–24 — bezpieczna historia zmian

```text
commit 1: characterization tests
commit 2: extract value object
commit 3: move one responsibility
commit 4: delete dead code and update documentation
```

Po każdym commicie uruchom tę samą komendę testów. Dodaj test regresyjny dla
największego ryzyka i wskaż smell, który świadomie pozostawiasz.

## Definition of Done

- minimum 12 wykonanych zadań, w tym 6 z poziomu 2 i 3 z poziomu 3;
- minimum 8 testów ochronnych;
- minimum 4 małe commity lub równoważna historia diffów;
- raport zawiera 20 diagnoz, nie tylko listę nazw smells;
- build i testy są zielone;
- rozwiązanie referencyjne porównano dopiero po własnej pracy.

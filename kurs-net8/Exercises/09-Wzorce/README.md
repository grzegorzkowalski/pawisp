# 9. Wzorce projektowe — pełne laboratorium problemów

Wzorzec nie jest celem ćwiczenia. Każde zadanie zaczyna się od problemu,
ograniczeń, prostszego rozwiązania i testu. Dopiero później implementujesz
wzorzec i porównujesz koszt. Materiał wykorzystuje wszystkie przykłady z
`Examples/09-Wzorce`, zadania z `Extras/WzorceProjektowe/Zadania` oraz dawne
ćwiczenia `wpa/NetDesignPatterns` przeniesione do .NET 8.

## Jak pracować

Dla każdego zadania przygotuj: diagram lub opis relacji, wersję „przed”, wersję
„po”, minimum dwa testy zachowania, prostszą alternatywę, koszt dodatkowych
klas oraz odpowiedź, przy jakiej zmianie wzorzec przestaje być opłacalny.

Nie musisz wykonywać wszystkich zadań na jednych zajęciach. Rdzeń to zadania
1–32, a warsztat integracyjny i ścieżka rozszerzona to zadania 33–40.
To jest laboratorium kilkudziesięciu ćwiczeń, nie lista wzorców do zapamiętania.

## Etap 0 — rozpoznanie problemu

### Zadanie 1 — wzorzec czy zwykła kompozycja?

Przeczytaj wszystkie projekty w `Examples/09-Wzorce`. Dla każdego zapisz problem
przed wzorcem, zmienną część, uczestników i prostszą implementację. Wybierz
trzy przykłady, w których wzorzec byłby overengineeringiem.

### Zadanie 2 — karta decyzji

Utwórz tabelę: problem, warianty zmian, częstotliwość zmian, koszt indirekcji,
testowalność, wybrana opcja. Używaj tej karty w każdym następnym zadaniu.

## Etap 1 — wzorce kreacyjne

### Zadanie 3 — Singleton i globalny stan

Otwórz `Extras/WzorceProjektowe/Singleton-sample` i `SingletonVault`. Zaimplementuj
Vault, który zwraca sekret tylko raz, a potem napisz test dwóch niezależnych
klientów. Następnie pokaż, dlaczego globalny singleton utrudnia izolację testów.
Zastąp go obiektem przekazanym przez composition root i porównaj oba warianty.

### Zadanie 4 — Factory Method: garnizon

Wykorzystaj `Examples/09-Wzorce/WarriorFactory`. Dodaj Piechura, Strzelca i
Konnych oraz `Garnizon`, który tworzy wojownika na podstawie typu. Dodaj
nieznaną profesję i wybierz: wyjątek, wynik `null` czy typ `Unknown`. Nie chowaj
błędu przez cichy default.

### Zadanie 5 — Factory versus switch

Zapisz dwie wersje tego samego zadania: switch oraz Factory Method. Dodaj czwarty
typ wojownika. Policz miejsca zmian i napisz, przy ilu wariantach Factory
rzeczywiście zaczyna pomagać.

### Zadanie 6 — Builder wojownika

Wykorzystaj `Examples/09-Wzorce/WarriorBuilder`. Zbuduj Piechura, Strzelca i
Konnych w krokach: utworzenie, broń, trening. Dodaj `WarriorPost`/Director,
jeśli potrafisz uzasadnić jego istnienie. Następnie usuń Director i sprawdź,
czy Builder nadal jest czytelniejszy.

### Zadanie 7 — Builder zamówienia

Na bazie `Builder-sample` stwórz zamówienie z opcjonalnym adresem, rabatem,
pozycjami i dostawą. Zablokuj zbudowanie zamówienia bez klienta i pozycji.
Porównaj Builder z rekordem i konstruktorem z nazwanymi argumentami.

### Zadanie 8 — Prototype

W `Extras/WzorceProjektowe/OrkPrototype` sklonuj Orka z wyposażeniem i listą
umiejętności. Udowodnij testem, że kopia głęboka nie współdzieli listy z
oryginałem. Porównaj ręczne kopiowanie z serializacją i opisz koszt obu.

### Zadanie 9 — Abstract Factory

Wykorzystaj `AbstractFactory-sample` albo `SantaClausFactory`. Zbuduj dwie
rodziny produktów, np. zabawka + opakowanie. Dodaj trzeci produkt do rodziny
i zapisz, ile klas wymaga zmiana. Zastanów się, czy prosty słownik fabryk nie
byłby wystarczający.

## Etap 2 — wzorce strukturalne

### Zadanie 10 — Adapter: klub nocny

Wykorzystaj `Examples/09-Wzorce/Adapter-sample` albo `Extras/.../PartyAdapter`.
Istniejący klient oczekuje `Adult`, a dane dostarcza `Teenager`. Zbuduj adapter,
który mapuje kontrakt bez zmiany klienta. Dodaj test wieku granicznego i test,
że adapter nie modyfikuje obiektu źródłowego.

### Zadanie 11 — Adapter obcego API

Zasymuluj zewnętrzny katalog zdjęć i ujednolić Pexels/Pixabay z zadania Strategy.
Kod aplikacji ma znać `IPhotoSearch`, nie format dostawcy. Dodaj błędną odpowiedź
zewnętrznego API i jawnie zdecyduj, jak ją mapujesz.

### Zadanie 12 — Facade dla pogody

Wykorzystaj `Extras/WzorceProjektowe/WeatherApiFacade`. Zbuduj fasadę zwracającą
temperaturę miasta, ukrywając HTTP, JSON i kody błędów. Użyj fake `HttpMessageHandler`.
Nie wywołuj prawdziwego OpenWeather w testach i nie zapisuj klucza API w kodzie.

### Zadanie 13 — Proxy kontroli dostępu

Wykorzystaj `DownloadProxy` albo `Proxy-sample`. Dodaj proxy cache, proxy logujące
i proxy autoryzacyjne. Połącz je w różnej kolejności i opisz, dlaczego kolejność
zmienia zachowanie. Test ma dowodzić, że przy odmowie nie wywołano serwera.

### Zadanie 14 — Decorator płatności

Wykorzystaj `ShopDecorator` lub `Decorator-sample`. Zbuduj bazową płatność oraz
dekoratory: SMS, punkty lojalnościowe i przekierowanie. Dodaj wszystkie osiem
kombinacji dwóch lub trzech dekoratorów. Porównaj Decorator z dziedziczeniem.

### Zadanie 15 — Composite menu i pliki

Wykorzystaj `CompositeMenu` i `Composite2`. Zbuduj drzewo menu, w którym klient
może traktować pozycję i podmenu jednolicie. Dodaj sumowanie ceny oraz ukrywanie
pozycji niedostępnej. Zapisz regułę, która nie pasuje do Composite.

### Zadanie 16 — Bridge: system operacyjny i interfejs

Wykorzystaj `BridgeSystemInterface`. Oddziel system Windows/Linux od Console/GUI.
Dodaj trzecią implementację interfejsu bez mnożenia klas wszystkich kombinacji.
Napisz test, który sprawdza delegowanie przycisku menu.

### Zadanie 17 — Flyweight

Wykorzystaj `Flyweight-sample` albo `TextureFactory`. Oddziel stan współdzielony
od zewnętrznego. Zmierz liczbę obiektów przed i po. Dodaj test, że zmiana stanu
zewnętrznego jednego elementu nie zmienia pozostałych.

### Zadanie 18 — Fluent API jako DSL

Wykorzystaj `FluentAPI-sample`. Zaprojektuj builder zapytania lub osoby, który
nie pozwala wywołać kroku w złej kolejności. Porównaj płynność składni z prostym
konstruktorem i nie ukrywaj błędów walidacji za łańcuchem metod.

## Etap 3 — wzorce behawioralne

### Zadanie 19 — Strategy: gotowanie

W `Examples/09-Wzorce/Strategy-sample` porównaj switch z `CookMethod`. Dodaj
trzecią metodę, możliwość zmiany strategii w czasie działania i test każdej
strategii. Następnie zaproponuj wariant słownika funkcji i porównaj koszty.

### Zadanie 20 — Strategy: wyszukiwanie zdjęć

Wykorzystaj `Extras/WzorceProjektowe/PhotoSearchStrategy`. Dodaj Pexels, Pixabay
i lokalny katalog. Klient ma wybierać strategię przez konfigurację, a testy mają
podstawiać fake bez sieci. Zapisz miejsce, w którym Adapter i Strategy się łączą.

### Zadanie 21 — State: cykl życia zamówienia

W `State-sample` wypisz tabelę przejść. Zablokuj wysłanie zamówienia anulowanego,
obsłuż płatność i dodaj stan `Cancelled`. Testuj dozwolone i niedozwolone
przejścia; nie zastępuj każdego prostego enumu klasami bez uzasadnienia.

### Zadanie 22 — Command: restauracja

Wykorzystaj `Command-sample`. Dodaj Add, Remove i Modify oraz historię poleceń.
Dodaj Undo dla dwóch ostatnich zmian. Zabezpiecz usunięcie nieistniejącej pozycji
i porównaj Command z delegatem `Action`.

### Zadanie 23 — Command: fabryka Mikołaja

Wykorzystaj `SantaClausFactory` i `SantaClausFactoryLive`. Zbuduj trzy zabawki
i rózgę przez polecenia. Dodaj walidację adresata i log wykonanych komend.

### Zadanie 24 — Observer: wyniki studentów

Wykorzystaj `TeacherObserver`. Wykładowca publikuje wyniki, studenci subskrybują
się i mogą się wypisać. Dodaj dwóch obserwatorów, błąd jednego obserwatora i
decyzję, czy pozostali nadal mają otrzymać wynik. Porównaj event .NET z własnym
interfejsem Observer.

### Zadanie 25 — Observer: ceny warzyw

W `Observer-sample` dodaj obserwatora, który kupuje tylko poniżej progu, oraz
raport historii cen. Testuj brak powiadomienia, gdy cena się nie zmieniła.

### Zadanie 26 — Chain of Responsibility

Wykorzystaj `ChainOfResponsibility-sample` i `ChainofResponsibility-Doc-solution`.
Zbuduj pipeline walidacji dokumentu: format, właściciel, uprawnienia, limit.
Dodaj handler, który obsługuje błąd, oraz handler, który przekazuje dalej.

### Zadanie 27 — Template Method

Wykorzystaj `TemplateMethod-sample` i `TemplateMethodDocument`. Zdefiniuj stały
proces importu, ale zmienne kroki dla CSV i JSON. Dodaj hook opcjonalny i test,
że kolejność kroków nie może być zmieniona przez klasę potomną.

### Zadanie 28 — Iterator

Wykorzystaj `Iterator-sample`. Zaimplementuj kolekcję historii zamówień z
iteracją tylko po zatwierdzonych elementach. Porównaj własny iterator z
`IEnumerable<T>` i `yield return`.

### Zadanie 29 — Mediator

Wykorzystaj `Mediator-sample` albo `MediatorControlTower`. Zbuduj koordynację
między kasą, kuchnią i magazynem bez bezpośrednich zależności każdego obiektu.
Dodaj awarię magazynu i test, kto otrzymuje komunikat. Zapisz koszt „god object”.

### Zadanie 30 — Memento

Wykorzystaj `Memento-sample` lub `MementoNotepad`. Dodaj undo/redo dla notatnika.
Zadbaj, aby historia nie mogła zmienić stanu bezpośrednio. Porównaj pełne kopie
z zapisem różnic.

### Zadanie 31 — Visitor

Wykorzystaj `Visitor-sample` lub `VisitorShop`. Dodaj raport podatkowy dla kilku
typów produktów bez mieszania raportowania z modelem. Zdecyduj, co jest trudniejsze:
nowy produkt czy nowa operacja.

### Zadanie 32 — Interpreter

Wykorzystaj `Interpreter-sample` albo `InterpreterRobot`. Zdefiniuj mały język
filtrów zamówień. Dodaj literał, operator AND i test błędnej składni. Porównaj
Interpreter z parserem i zwykłym predykatem.

## Etap 4 — warsztat integracyjny Library/OrderWorkshop

Starter znajduje się w `Exercises/09-Wzorce/Starter/OrderWorkshop`. To nowoczesna
wersja dawnego `wpa/OrderWorkshop`. Wykonuj każde zadanie w osobnym commicie.

### Zadanie 33 — solucja i granice

Utwórz solucję `Library` z projektami `Library.ConsoleApp`, `Library.Domain` i
`Library.Persistence`. Uporządkuj projekty w folderach Presentation i Logic,
dodaj referencje tylko w kierunku Domain. Zapisz diagram zależności.

### Zadanie 34 — menu konsolowe

Zaimplementuj logowanie, pętlę komend `dodaj`, `usun`, `wypisz`, `zmien`,
`dodaj zamowienie`, `lista zamowien`, `wyjdz`. Dodaj komunikat dla nieznanej
komendy i test logiki menu bez czytania prawdziwej konsoli.

### Zadanie 35 — książki i repozytorium

Dodaj `Book` z tytułem, autorem, rokiem, ISBN, ceną i stanem. Zaimplementuj
`BooksRepository`: Insert, GetAll, RemoveByTitle i ChangeState. Dodaj dane
startowe z dawnego materiału i test dodania/usunięcia/zmiany stanu.

### Zadanie 36 — zamówienia

Dodaj `BookOrdered`, `Order`, `OrdersRepository` i `OrderService`. Obsłuż wiele
pozycji, zakończenie zamówienia, listowanie, brak książki i przekroczenie stanu.
Nie pobieraj repozytorium przez singleton; wstrzyknij zależność.

### Zadanie 37 — enkapsulacja domeny

Usuń publiczne settery. Dodaj `ChangeProductsAvailableNumber`, konstruktor
`BookOrdered` i walidację przed zejściem poniżej zera. Testy mają zabezpieczać
reguły, a nie prywatne pola.

### Zadanie 38 — BaseRepository i krytyka abstrakcji

Zaimplementuj `IModel`, `BaseModel` i `BaseRepository<T>`, a następnie podłącz
BooksRepository i OrdersRepository. W raporcie wskaż, które zachowanie jest
naprawdę wspólne, a które zostało wymuszone przez generyczną abstrakcję.

### Zadanie 39 — Command i Processor

Wydziel `ICommand`, `IHandler` i `Processor`. Zastąp ogromny if mapą komend.
Dodaj opis komendy, obsługę wyjątku i test nieznanej komendy. Porównaj mapę
delegatów z obiektami Command.

### Zadanie 40 — atrybuty i refleksja

Dodaj atrybut `Command(name, description)` oraz handlery `AddBookHandler`,
`ChangeStateHandler`, `ExitHandler`, `ListBookHandler`, `ListOrderHandler`,
`PlaceOrderHandler`, `RemoveBookHandler`. Zarejestruj je przez refleksję.
Zabezpiecz brak atrybutu i duplikat nazwy. Na końcu opisz, kiedy refleksja jest
warta kosztu, a kiedy lepszy jest jawny composition root.

## Kod krok po kroku — ścieżka ratunkowa

Każdy przykład poniżej można wkleić do osobnego pliku w starterze. Najpierw
uruchom wersję minimalną, potem dodaj test, dopiero na końcu rozbuduj wariant.
To są fragmenty prowadzące do rozwiązania; pełne referencje prowadzącego są w
`kurs-net8-prowadzacy/Solutions/09-Wzorce`.

### Zadanie 1 — rozpoznanie

```csharp
public sealed record PatternDecision(string Problem, string Variation,
    string SimpleOption, string PatternOption, string Decision);
var decision = new PatternDecision(
    "wiele algorytmów dostawy", "algorytm zmienia się niezależnie",
    "switch", "Strategy", "Strategy po pojawieniu się trzeciej reguły");
```

Utwórz trzy takie rekordy dla istniejących przykładów i dopisz test lub dowód,
że zmienność rzeczywiście istnieje.

### Zadanie 2 — karta decyzji

```csharp
public sealed record DecisionCard(string Problem, int Variants,
    int ChangesPerVariant, int ExtraTypes, string Alternative);
var card = new DecisionCard("shipping", 3, 1, 2, "dictionary of delegates");
Console.WriteLine(card);
```

Wypełniaj kartę przed implementacją każdego kolejnego wzorca.

### Zadanie 3 — Singleton

```csharp
public sealed class Vault
{
    private static readonly Lazy<Vault> Instance = new(() => new());
    private bool _used;
    private Vault() { }
    public static Vault Current => Instance.Value;
    public string ReadSecret()
    {
        if (_used) throw new InvalidOperationException("Secret already read");
        _used = true; return "net8-secret";
    }
}
```

Napisz test drugiego odczytu, potem zastąp `Vault.Current` zależnością przekazaną
w konstruktorze i porównaj izolację testów.

### Zadanie 4 — Factory Method

```csharp
public interface IWarrior { string Role { get; } }
public sealed class Infantry : IWarrior { public string Role => "infantry"; }
public sealed class Archer : IWarrior { public string Role => "archer"; }
public sealed class Garrison
{
    public IWarrior Create(string role) => role switch
    {
        "infantry" => new Infantry(), "archer" => new Archer(),
        _ => throw new ArgumentException("Unknown role", nameof(role))
    };
}
```

Dodaj trzeci typ, a następnie przenieś tworzenie do osobnych creatorów tylko
jeśli liczba wariantów uzasadnia dodatkowe klasy.

### Zadanie 5 — Factory kontra switch

```csharp
public interface IWarriorFactory { IWarrior Create(); }
public sealed class InfantryFactory : IWarriorFactory
{ public IWarrior Create() => new Infantry(); }
var factories = new Dictionary<string, IWarriorFactory>
    { ["infantry"] = new InfantryFactory() };
var warrior = factories["infantry"].Create();
```

Policz miejsca zmiany w obu wersjach i zachowaj w raporcie wynik pomiaru.

### Zadanie 6 — Builder wojownika

```csharp
public sealed record Warrior(string Weapon, int Training);
public sealed class WarriorBuilder
{
    private string _weapon = "none"; private int _training;
    public WarriorBuilder WithWeapon(string value) { _weapon = value; return this; }
    public WarriorBuilder Train(int value) { _training += value; return this; }
    public Warrior Build() => new(_weapon, _training);
}
var warrior = new WarriorBuilder().WithWeapon("sword").Train(3).Build();
```

Dodaj walidację `Build()` i test brakującej broni.

### Zadanie 7 — Builder zamówienia

```csharp
public sealed record Order(string Customer, IReadOnlyList<string> Items, string? Address);
public sealed class OrderBuilder
{
    private string? _customer; private string? _address; private readonly List<string> _items = [];
    public OrderBuilder For(string value) { _customer = value; return this; }
    public OrderBuilder ShipTo(string value) { _address = value; return this; }
    public OrderBuilder Add(string value) { _items.Add(value); return this; }
    public Order Build() => _customer is null || _items.Count == 0
        ? throw new InvalidOperationException("Customer and item are required")
        : new(_customer, _items, _address);
}
```

Porównaj tę wersję z rekordem i konstruktorem nazwanym.

### Zadanie 8 — Prototype

```csharp
public sealed class Orc
{
    public string Name { get; set; } = "orc";
    public List<string> Skills { get; } = [];
    public Orc Clone()
    {
        var clone = new Orc { Name = Name };
        clone.Skills.AddRange(Skills);
        return clone;
    }
}
```

Dodaj test, który zmienia `Skills` kopii i sprawdza, że oryginał się nie zmienia.

### Zadanie 9 — Abstract Factory

```csharp
public interface IToy { string Name { get; } }
public interface IPackage { string Label { get; } }
public interface IGiftFactory { IToy CreateToy(); IPackage CreatePackage(); }
public sealed class WinterGiftFactory : IGiftFactory
{
    public IToy CreateToy() => new Toy("sled");
    public IPackage CreatePackage() => new Package("winter");
}
public sealed record Toy(string Name) : IToy;
public sealed record Package(string Label) : IPackage;
```

Dodaj drugą rodzinę i trzeci produkt, a następnie policz liczbę zmian.

### Zadania 10–11 — Adapter

```csharp
public interface IAdult { bool IsAdult { get; } }
public sealed record Teenager(int Age);
public sealed class AdultAdapter(Teenager source) : IAdult
{ public bool IsAdult => source.Age >= 18; }
```

Dla obcego API dodaj drugi adapter do `IPhotoSearch`. Test ma sprawdzić mapowanie
oraz to, że obiekt zewnętrzny nie został zmodyfikowany.

### Zadanie 12 — Facade

```csharp
public interface IWeatherClient { Task<decimal> GetTemperature(string city); }
public sealed class WeatherFacade(IWeatherClient client)
{
    public Task<decimal> Temperature(string city) => client.GetTemperature(city);
}
```

Fake klienta wstrzyknij w teście. HTTP, JSON i klucz API pozostają poza fasadą.

### Zadanie 13 — Proxy

```csharp
public interface IDownload { byte[] Get(string url); }
public sealed class CachingDownload(IDownload inner) : IDownload
{
    private readonly Dictionary<string, byte[]> _cache = [];
    public byte[] Get(string url) => _cache.TryGetValue(url, out var value)
        ? value : (_cache[url] = inner.Get(url));
}
```

Dodaj proxy autoryzacyjne przed cache i test, że odmowa nie wywołuje serwera.

### Zadanie 14 — Decorator

```csharp
public interface IPayment { decimal Pay(decimal amount); }
public sealed class CardPayment : IPayment { public decimal Pay(decimal amount) => amount; }
public sealed class SmsPayment(IPayment inner) : IPayment
{ public decimal Pay(decimal amount) { var result = inner.Pay(amount); return result; } }
```

Dodaj dekoratory punktów i przekierowania. Testuj kolejność, nie tylko wynik liczbowy.

### Zadanie 15 — Composite

```csharp
public interface IMenuItem { decimal Price { get; } }
public sealed record Dish(decimal Price) : IMenuItem;
public sealed class Menu : IMenuItem
{
    private readonly List<IMenuItem> _items = [];
    public decimal Price => _items.Sum(item => item.Price);
    public void Add(IMenuItem item) => _items.Add(item);
}
```

Dodaj niedostępne elementy i jasno zdefiniuj, czy Composite może je pomijać.

### Zadanie 16 — Bridge

```csharp
public interface IUi { void Button(string text); }
public sealed class ConsoleUi : IUi { public void Button(string text) => Console.WriteLine(text); }
public abstract class Screen(IUi ui)
{ public void Render() => ui.Button("Save"); }
public sealed class SettingsScreen(IUi ui) : Screen(ui) { }
```

Dodaj `GuiUi` i trzeci typ ekranu bez tworzenia klas dla każdej kombinacji.

### Zadanie 17 — Flyweight

```csharp
public sealed record Texture(string Key);
public sealed class TextureFactory
{
    private readonly Dictionary<string, Texture> _items = [];
    public Texture Get(string key) => _items.TryGetValue(key, out var item)
        ? item : (_items[key] = new Texture(key));
}
```

Zmierz liczbę instancji przed i po wprowadzeniu fabryki.

### Zadanie 18 — Fluent API

```csharp
public sealed class QueryBuilder
{
    private string? _from; private string? _where;
    public QueryBuilder From(string table) { _from = table; return this; }
    public QueryBuilder Where(string condition) { _where = condition; return this; }
    public string Build() => _from is null ? throw new InvalidOperationException("FROM required")
        : $"SELECT * FROM {_from} WHERE {_where ?? "1=1"}";
}
```

Dodaj test złej kolejności i porównaj DSL z prostym rekordem konfiguracji.

### Zadania 19–20 — Strategy

```csharp
public interface IShippingStrategy { decimal Calculate(decimal total); }
public sealed class StandardShipping : IShippingStrategy
{ public decimal Calculate(decimal total) => 10m; }
public sealed class Checkout(IShippingStrategy strategy)
{ public decimal Total(decimal amount) => amount + strategy.Calculate(amount); }
```

Dodaj Express i lokalną dostawę. W zadaniu 20 adapter mapuje Pexels/Pixabay do
jednego `IPhotoSearch`, a strategia wybiera dostawcę.

### Zadanie 21 — State

```csharp
public interface IOrderState { void Ship(OrderContext order); }
public sealed class AcceptedState : IOrderState
{ public void Ship(OrderContext order) => order.State = new ShippedState(); }
public sealed class OrderContext { public IOrderState State { get; set; } = new AcceptedState(); }
public sealed class ShippedState : IOrderState
{ public void Ship(OrderContext order) => throw new InvalidOperationException("Already shipped"); }
```

Dodaj `CancelledState` i testy dozwolonych oraz zabronionych przejść.

### Zadania 22–23 — Command

```csharp
public interface ICommand { void Execute(); void Undo(); }
public sealed class AddItem(List<string> target, string value) : ICommand
{
    public void Execute() => target.Add(value);
    public void Undo() => target.Remove(value);
}
public sealed class CommandHistory
{
    private readonly Stack<ICommand> _done = [];
    public void Run(ICommand command) { command.Execute(); _done.Push(command); }
    public void Undo() { if (_done.TryPop(out var command)) command.Undo(); }
}
```

Dodaj Remove/Modify, dwa undo i walidację adresata w wariancie Mikołaja.

### Zadania 24–25 — Observer

```csharp
public sealed class ScoreBoard
{
    public event Action<int>? Published;
    public void Publish(int score) => Published?.Invoke(score);
}
var board = new ScoreBoard();
board.Published += score => Console.WriteLine($"score={score}");
```

Dodaj unsubscribe, drugiego obserwatora i test błędu jednego odbiorcy.

### Zadanie 26 — Chain of Responsibility

```csharp
public abstract class Handler
{
    protected Handler? Next;
    public Handler Then(Handler next) { Next = next; return next; }
    public abstract bool Handle(string document);
}
public sealed class FormatHandler : Handler
{ public override bool Handle(string document) => document.EndsWith(".pdf") || Next?.Handle(document) == true; }
```

Dodaj walidację właściciela, uprawnienia i limit oraz test zatrzymania łańcucha.

### Zadanie 27 — Template Method

```csharp
public abstract class Importer
{
    public IReadOnlyList<string> Run(string input)
    { var rows = Read(input); Validate(rows); return Map(rows); }
    protected abstract IReadOnlyList<string> Read(string input);
    protected virtual void Validate(IReadOnlyList<string> rows) { }
    protected abstract IReadOnlyList<string> Map(IReadOnlyList<string> rows);
}
```

Dodaj CSV i JSON. Kolejność procesu ma być niezmienna dla klas potomnych.

### Zadania 28–32 — Iterator, Mediator, Memento, Visitor, Interpreter

```csharp
public sealed class ApprovedOrders(IEnumerable<Order> orders)
{
    public IEnumerable<Order> Get() => orders.Where(order => order.IsApproved);
}

public sealed class TextHistory
{
    private readonly Stack<string> _history = [];
    public void Save(string text) => _history.Push(text);
    public string Restore() => _history.Pop();
}

public interface IVisitor { void Visit(Product product); }
public sealed record Product(string Name, decimal Price);
public sealed class TaxVisitor : IVisitor
{ public decimal Total { get; private set; } public void Visit(Product product) => Total += product.Price * 1.23m; }
```

Dla Mediatora dodaj `IMediator.Send`, dla Memento osobny obiekt snapshotu, a dla
Interpretera parser literału i operatora `AND`. Każdy z pięciu wzorców musi mieć
osobny test zachowania i zapis kosztu względem prostego predykatu/delegata.

### Zadania 33–40 — warsztat Library/OrderWorkshop

```csharp
// Domain
public sealed class Book(string title, int available)
{
    public string Title { get; } = title;
    public int Available { get; private set; } = available;
    public void Take(int count)
    { if (count > Available) throw new InvalidOperationException("Not enough books"); Available -= count; }
}

// Port
public interface IBooksRepository { void Insert(Book book); IReadOnlyCollection<Book> GetAll(); }

// Command
public interface ICommand { string Execute(); }
public sealed class ListBooksCommand(IBooksRepository books) : ICommand
{ public string Execute() => string.Join(Environment.NewLine, books.GetAll().Select(book => book.Title)); }
```

Wykonuj warsztat w kolejności: granice projektów, menu, książki, zamówienia,
enkapsulacja, `BaseRepository<T>`, Command/Processor, atrybuty i refleksja.
Po każdym etapie skopiuj najpierw minimalny kod z tej sekcji i dopiero dodawaj
obsługę błędów, testy oraz kolejne komendy.

## Kryteria ukończenia

- rdzeń: minimum 18 zadań, w tym po trzy kreacyjne, strukturalne i behawioralne;
- warsztat: minimum 5 zadań z etapu 4;
- każdy wybrany wzorzec ma test, alternatywę i opis kosztu;
- minimum 4 małe commity w warsztacie;
- diagram zależności nie pokazuje cykli;
- student potrafi wskazać trzy miejsca, w których wzorzec byłby błędem.

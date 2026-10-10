// --- 1. Klasa Modelu Danych ---

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsInStock { get; set; }

    public override string ToString()
    {
        return $"{Name} (Cena: {Price:C}, W magazynie: {IsInStock})";
    }
}

// --- 2. Interfejs Specyfikacji ---

// Główny interfejs definiujący, że coś jest specyfikacją.
public interface ISpecification<T>
{
    // Metoda sprawdza, czy dany element spełnia kryterium
    bool IsSatisfiedBy(T item);

    // Metody do łączenia specyfikacji
    ISpecification<T> And(ISpecification<T> other);
    ISpecification<T> Or(ISpecification<T> other);
}

// --- 3. Implementacja Bazowa Specyfikacji (Abstract Base) ---

// Klasa abstrakcyjna do obsługi operatorów logicznych (AND/OR),
// co pozwala na unikanie powtarzalnego kodu w każdej specyfikacji.
public abstract class CompositeSpecification<T> : ISpecification<T>
{
    public abstract bool IsSatisfiedBy(T item);

    public ISpecification<T> And(ISpecification<T> other)
    {
        return new AndSpecification<T>(this, other);
    }

    public ISpecification<T> Or(ISpecification<T> other)
    {
        return new OrSpecification<T>(this, other);
    }
}

// --- 4. Konkretne Specyfikacje Biznesowe ---

// Specyfikacja 1: Czy produkt jest drogi
public class IsExpensiveSpecification : CompositeSpecification<Product>
{
    private readonly decimal _minPrice;

    public IsExpensiveSpecification(decimal minPrice = 100)
    {
        _minPrice = minPrice;
    }

    public override bool IsSatisfiedBy(Product product)
    {
        return product.Price > _minPrice;
    }
}

// Specyfikacja 2: Czy produkt jest w magazynie
public class IsInStockSpecification : CompositeSpecification<Product>
{
    public override bool IsSatisfiedBy(Product product)
    {
        return product.IsInStock;
    }
}

// --- 5. Specyfikacje Logiczne (Łączące) ---

// Specyfikacja łącząca dwie inne za pomocą operatora AND (koniunkcja)
public class AndSpecification<T> : CompositeSpecification<T>
{
    private readonly ISpecification<T> _left;
    private readonly ISpecification<T> _right;

    public AndSpecification(ISpecification<T> left, ISpecification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override bool IsSatisfiedBy(T item)
    {
        return _left.IsSatisfiedBy(item) && _right.IsSatisfiedBy(item);
    }
}

// Specyfikacja łącząca dwie inne za pomocą operatora OR (alternatywa)
public class OrSpecification<T> : CompositeSpecification<T>
{
    private readonly ISpecification<T> _left;
    private readonly ISpecification<T> _right;

    public OrSpecification(ISpecification<T> left, ISpecification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override bool IsSatisfiedBy(T item)
    {
        return _left.IsSatisfiedBy(item) || _right.IsSatisfiedBy(item);
    }
}

// --- 6. Użycie w Programie (Test) ---

public class Program
{
    public static void Main()
    {
        var products = new List<Product>
        {
            new Product { Name = "Tania książka", Price = 49.99M, IsInStock = true },
            new Product { Name = "Drogi monitor", Price = 799.00M, IsInStock = true },
            new Product { Name = "Stary dysk HDD", Price = 120.00M, IsInStock = false },
            new Product { Name = "Tania myszka", Price = 25.50M, IsInStock = true }
        };

        // -----------------------------------------------------
        // UŻYCIE 1: Prosta specyfikacja (cena > 100)
        // -----------------------------------------------------
        Console.WriteLine("--- 1. Produkty droższe niż 100 zł ---");
        var expensiveSpec = new IsExpensiveSpecification();

        var expensiveProducts = products.Where(p => expensiveSpec.IsSatisfiedBy(p));

        foreach (var p in expensiveProducts)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("---------------------------------------");

        // -----------------------------------------------------
        // UŻYCIE 2: Specyfikacja złożona (cena > 100 AND w magazynie)
        // -----------------------------------------------------
        Console.WriteLine("--- 2. Produkty drogie I dostępne ---");

        // Budowanie złożonej reguły biznesowej:
        var expensiveAndInStockSpec = expensiveSpec.And(new IsInStockSpecification());

        var resultProducts = products.Where(p => expensiveAndInStockSpec.IsSatisfiedBy(p));

        foreach (var p in resultProducts)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("---------------------------------------");

        // -----------------------------------------------------
        // UŻYCIE 3: Specyfikacja złożona z OR (tanie lub niedostępne)
        // -----------------------------------------------------
        Console.WriteLine("--- 3. Produkty tanie (<= 100) LUB niedostępne ---");

        // Negacja (specyfikacja 'Nie jest drogi' - czyli jest tani)
        var cheapSpec = new IsExpensiveSpecification().And(new AlwaysFalseSpecification<Product>()).Or(new IsExpensiveSpecification());
        // Uwaga: Implementacja negacji (NOT) wymagałaby dodania osobnej klasy NotSpecification, 
        // ale dla uproszczenia, użyjemy prostej logiki: 
        var isCheapSpec = new IsExpensiveSpecification(101).Or(new AlwaysFalseSpecification<Product>()); // Cena < 101

        // Zbudujmy specyfikację: (Cena <= 100) LUB (Nie jest w magazynie)
        var isNotStockedSpec = new NotSpecification<Product>(new IsInStockSpecification());

        var cheapOrNotStockedSpec = isCheapSpec.Or(isNotStockedSpec);

        var resultOrProducts = products.Where(p => cheapOrNotStockedSpec.IsSatisfiedBy(p));

        foreach (var p in resultOrProducts)
        {
            Console.WriteLine(p);
        }
    }
}

// Poniższa klasa to prosty hack, aby pokazać działanie OR i AND bez zagnieżdżania NotSpecification.
// Zostanie usunięta lub zastąpiona NotSpecification, która lepiej pasuje do wzorca.
public class AlwaysFalseSpecification<T> : CompositeSpecification<T>
{
    public override bool IsSatisfiedBy(T item) => false;
}

// Dodanie brakującej NotSpecification dla poprawności wzorca
public class NotSpecification<T> : CompositeSpecification<T>
{
    private readonly ISpecification<T> _other;

    public NotSpecification(ISpecification<T> other)
    {
        _other = other;
    }

    public override bool IsSatisfiedBy(T item)
    {
        return !_other.IsSatisfiedBy(item);
    }
}
import ProductHero from "../components/products/ProductHero";
import SearchBar from "../components/products/SearchBar";
import CategoryFilter from "../components/products/CategoryFilter";
import SortDropdown from "../components/products/SortDropdown";
import ProductCard from "../components/products/ProductCard";

const products = [
  {
    id: 1,
    name: "Fresh Carrots",
    category: "Vegetables",
    price: 350,
    image: "🥕",
  },
  {
    id: 2,
    name: "Red Apples",
    category: "Fruits",
    price: 680,
    image: "🍎",
  },
  {
    id: 3,
    name: "Fresh Milk",
    category: "Dairy",
    price: 450,
    image: "🥛",
  },
  {
    id: 4,
    name: "Broccoli",
    category: "Vegetables",
    price: 550,
    image: "🥦",
  },
  {
    id: 5,
    name: "Chicken Breast",
    category: "Meat",
    price: 1200,
    image: "🍗",
  },
  {
    id: 6,
    name: "Bread",
    category: "Bakery",
    price: 220,
    image: "🍞",
  },
  {
    id: 7,
    name: "Orange Juice",
    category: "Drinks",
    price: 480,
    image: "🧃",
  },
  {
    id: 8,
    name: "Bananas",
    category: "Fruits",
    price: 280,
    image: "🍌",
  },
];

function Products() {
  return (
    <>
      <ProductHero />

      <section className="py-16 bg-gray-50">

        <div className="max-w-7xl mx-auto px-6">

          <div className="flex flex-col lg:flex-row lg:items-center lg:justify-between gap-6">

            <SearchBar />

            <SortDropdown />

          </div>

          <div className="mt-8">

            <CategoryFilter />

          </div>

          <div className="grid md:grid-cols-2 lg:grid-cols-4 gap-8 mt-14">

            {products.map((product) => (

              <ProductCard
                key={product.id}
                product={product}
              />

            ))}

          </div>

        </div>

      </section>
    </>
  );
}

export default Products;
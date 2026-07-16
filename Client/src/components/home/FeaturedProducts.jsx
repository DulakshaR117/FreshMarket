import ProductCard from "../products/ProductCard";

const demoProducts = [
  {
    id: 1,
    name: "Fresh Carrots",
    price: 350,
    image: "🥕",
    category: "Vegetables",
  },
  {
    id: 2,
    name: "Red Apples",
    price: 680,
    image: "🍎",
    category: "Fruits",
  },
  {
    id: 3,
    name: "Fresh Milk",
    price: 450,
    image: "🥛",
    category: "Dairy",
  },
  {
    id: 4,
    name: "Broccoli",
    price: 550,
    image: "🥦",
    category: "Vegetables",
  },
];

function FeaturedProducts() {
  return (
    <section className="py-24 bg-white">
      <div className="max-w-7xl mx-auto px-6">

        <div className="text-center">

          <p className="text-green-600 uppercase font-semibold tracking-widest">
            Featured Products
          </p>

          <h2 className="text-5xl font-bold mt-3">
            Fresh Picks Today
          </h2>

          <p className="text-gray-500 mt-5">
            Hand-picked fresh arrivals from local farmers.
          </p>

        </div>

        <div className="grid md:grid-cols-2 lg:grid-cols-4 gap-8 mt-16">

          {demoProducts.map(product => (
            <ProductCard
              key={product.id}
              product={product}
            />
          ))}

        </div>

      </div>
    </section>
  );
}

export default FeaturedProducts;
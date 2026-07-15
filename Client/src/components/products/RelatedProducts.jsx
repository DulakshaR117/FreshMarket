import ProductCard from "./ProductCard";

const related = [
  {
    id: 1,
    name: "Broccoli",
    category: "Vegetables",
    price: 550,
    image: "🥦",
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
    name: "Bananas",
    category: "Fruits",
    price: 280,
    image: "🍌",
  },
];

function RelatedProducts() {
  return (
    <section className="py-20 bg-gray-50">

      <div className="max-w-7xl mx-auto px-6">

        <h2 className="text-4xl font-bold text-center mb-14">
          Related Products
        </h2>

        <div className="grid md:grid-cols-2 lg:grid-cols-4 gap-8">

          {related.map((product) => (
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

export default RelatedProducts;
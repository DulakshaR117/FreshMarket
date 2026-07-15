const categories = [
  "All",
  "Vegetables",
  "Fruits",
  "Dairy",
  "Meat",
  "Bakery",
  "Drinks",
];

function CategoryFilter() {
  return (
    <div className="flex flex-wrap gap-3">
      {categories.map((category) => (
        <button
          key={category}
          className="
            px-5
            py-2
            rounded-full
            border
            hover:bg-green-600
            hover:text-white
            transition
          "
        >
          {category}
        </button>
      ))}
    </div>
  );
}

export default CategoryFilter;
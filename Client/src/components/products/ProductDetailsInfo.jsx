import { FiStar, FiShoppingCart } from "react-icons/fi";

function ProductDetailsInfo() {
  return (
    <div>

      <span className="inline-block bg-green-100 text-green-700 px-4 py-2 rounded-full text-sm font-semibold">
        Vegetables
      </span>

      <h1 className="text-5xl font-bold mt-6">
        Fresh Organic Carrots
      </h1>

      <div className="flex items-center gap-3 mt-5">

        <div className="flex text-yellow-400">

          <FiStar />
          <FiStar />
          <FiStar />
          <FiStar />
          <FiStar />

        </div>

        <span className="text-gray-500">
          (4.9 • 240 Reviews)
        </span>

      </div>

      <h2 className="text-4xl font-bold text-green-600 mt-8">
        Rs. 350.00
      </h2>

      <p className="mt-8 text-gray-600 leading-8">
        Fresh organic carrots harvested daily from trusted
        local farms. Rich in vitamins and perfect for healthy
        meals, salads and juices.
      </p>

      <div className="mt-8">

        <span className="text-green-600 font-semibold">
          ✓ In Stock
        </span>

      </div>

      <div className="flex gap-4 mt-10">

        <button className="px-5 py-3 border rounded-xl">
          −
        </button>

        <div className="px-8 py-3 border rounded-xl">
          1
        </div>

        <button className="px-5 py-3 border rounded-xl">
          +
        </button>

      </div>

      <button className="mt-10 bg-green-600 hover:bg-green-700 text-white px-10 py-4 rounded-xl flex items-center gap-3 transition">

        <FiShoppingCart />

        Add To Cart

      </button>

    </div>
  );
}

export default ProductDetailsInfo;
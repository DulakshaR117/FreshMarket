import { FiShoppingCart } from "react-icons/fi";

function ProductCard({ product }) {
  return (
    <div className="group bg-white rounded-3xl shadow-sm hover:shadow-2xl transition-all duration-300 overflow-hidden border">

      <div className="h-56 flex items-center justify-center bg-gradient-to-br from-green-50 to-white text-8xl group-hover:scale-110 transition duration-500">

        {product.image}

      </div>

      <div className="p-6">

        <p className="text-green-600 text-sm font-semibold">
          {product.category}
        </p>

        <h3 className="text-2xl font-bold mt-2">
          {product.name}
        </h3>

        <div className="flex justify-between items-center mt-6">

          <span className="text-3xl font-bold text-green-600">
            Rs. {product.price}
          </span>

          <button className="bg-green-600 hover:bg-green-700 text-white rounded-full p-3 transition">

            <FiShoppingCart />

          </button>

        </div>

      </div>

    </div>
  );
}

export default ProductCard;
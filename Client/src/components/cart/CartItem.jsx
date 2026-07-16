import { FiMinus, FiPlus, FiTrash2 } from "react-icons/fi";

function CartItem() {
  return (
    <div className="bg-white rounded-3xl shadow-sm p-6 flex items-center justify-between">

      <div className="flex items-center gap-6">

        <div className="text-6xl bg-green-50 rounded-2xl w-24 h-24 flex items-center justify-center">
          🥕
        </div>

        <div>

          <p className="text-green-600 text-sm">
            Vegetables
          </p>

          <h3 className="text-2xl font-bold">
            Fresh Carrots
          </h3>

          <p className="text-green-600 font-bold mt-2">
            Rs.350
          </p>

        </div>

      </div>

      <div className="flex items-center gap-5">

        <div className="flex items-center border rounded-xl">

          <button className="p-3">
            <FiMinus />
          </button>

          <span className="px-5">
            2
          </span>

          <button className="p-3">
            <FiPlus />
          </button>

        </div>

        <button className="text-red-500 hover:text-red-600">

          <FiTrash2 size={22} />

        </button>

      </div>

    </div>
  );
}

export default CartItem;
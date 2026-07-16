import { Link } from "react-router-dom";

function CartSummary() {
  return (
    <div className="bg-white rounded-3xl shadow-lg p-8 sticky top-28">

      <h2 className="text-3xl font-bold mb-8">
        Order Summary
      </h2>

      <div className="space-y-5">

        <div className="flex justify-between">
          <span>Subtotal</span>
          <span>Rs. 1050</span>
        </div>

        <div className="flex justify-between">
          <span>Delivery</span>
          <span>Rs. 250</span>
        </div>

        <div className="flex justify-between">
          <span>Discount</span>
          <span>- Rs.100</span>
        </div>

        <hr />

        <div className="flex justify-between text-2xl font-bold">

          <span>Total</span>

          <span className="text-green-600">
            Rs.1200
          </span>

        </div>

      </div>

      <Link
        to="/checkout"
        className="block text-center mt-10 bg-green-600 hover:bg-green-700 text-white py-4 rounded-xl font-semibold transition"
      >
        Proceed To Checkout
      </Link>

    </div>
  );
}

export default CartSummary;